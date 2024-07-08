using Microsoft.AspNetCore.Http;
using SkillSync.Domain.Dtos.Login;
using SkillSync.Domain.DTOs.Login;
using SkillSync.Domain.DTOs.Register;
using SkillSync.Domain.Enums;
using SkillSync.Domain.Exceptions.LoginProvider;
using SkillSync.Domain.Exceptions.Register;
using SkillSync.Domain.Exceptions.User;
using SkillSync.Domain.Interfaces.Repositories;
using SkillSync.Domain.Interfaces.Services;
using SkillSync.Domain.Models;
using SkillSync.IdentityManager.Dtos;
using SkillSync.IdentityManager.Interfaces.IdentityManager;
using SkillSync.IdentityManager.Services.Google;
using SkillSync.IdentityManager.Services.LinkedIn;
using SkillSync.Notifications.Services;
using System.Web;

namespace SkillSync.IdentityManager.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IOwnSystemAuthService _ownSystemAuthService;
        private readonly IGoogleAuthService _googleAuthService;
        private readonly ILinkedInService _linkedInAuthService;
        private readonly IUserService _usersService;
        private readonly IPushNotificationService _pushNotificationService;

        private readonly IRolesRepository _rolesRepository;
        private readonly IUsersRepository _usersRepository;
        private readonly IFreelancerRepository _freelancerRepository;
        private readonly ISkillScoutRepository _skillScoutRepository;

        private readonly ITokenService _tokenService;

        public AuthService
        (
            IOwnSystemAuthService ownSystemAuthService,
            IGoogleAuthService googleAuthService,
            ILinkedInService linkedInAuthService,
            IUserService userService,
            IRolesRepository rolesRepository,
            IUsersRepository usersRepository,
            IFreelancerRepository freelancerRepository,
            ISkillScoutRepository skillScoutRepository,
            ITokenService tokenService,
            IPushNotificationService pushNotificationService
        )
        {
            _ownSystemAuthService = ownSystemAuthService ?? throw new ArgumentNullException(nameof(ownSystemAuthService));
            _googleAuthService = googleAuthService ?? throw new ArgumentNullException(nameof(googleAuthService));
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
            _linkedInAuthService = linkedInAuthService ?? throw new ArgumentNullException(nameof(linkedInAuthService));
            _usersService = userService ?? throw new ArgumentNullException(nameof(userService));
            _rolesRepository = rolesRepository ?? throw new ArgumentNullException(nameof(rolesRepository));
            _usersRepository = usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));
            _freelancerRepository = freelancerRepository ?? throw new ArgumentNullException(nameof(freelancerRepository));
            _skillScoutRepository = skillScoutRepository ?? throw new ArgumentNullException(nameof(skillScoutRepository));
            _pushNotificationService = pushNotificationService ?? throw new ArgumentNullException(nameof(pushNotificationService));
        }

        public async Task<LoginResponse> OwnSystemLoginAsync(OwnSystemLoginRequest request)
        {
            return await _ownSystemAuthService.LoginAsync(request);
        }

        public async Task<LoginResponse> LoginWithSocialProviderAsync(SocialProviderLoginRequest request)
        {
            switch (request.SocialProvider)
            {
                case SocialProvider.Google:
                    return await LoginWithGoogleAsync(request);

                case SocialProvider.LinkedIn:
                    return await LoginInWithLinkedInAsync(request);
            }

            throw new InvalidSocialProviderException();
        }

        private async Task<LoginResponse> LoginInWithLinkedInAsync(SocialProviderLoginRequest model)
        {
            var user = await _linkedInAuthService.LinkedInSignIn(model);

            if (user is null)
            {
                throw new UserNotFoundException();
            }

            string? role = await _rolesRepository.GetUserRoleAsync(user);

            var profilePicture = await _usersService.GetProfilePictureAsync(user);
            user.ProfilePicture = profilePicture;

            var token = _tokenService.GetToken(user, role);

            return new LoginResponse { Token = token };

        }

        private async Task<LoginResponse> LoginWithGoogleAsync(SocialProviderLoginRequest model)
        {
            var response = await _googleAuthService.SignInAsync(model);

            string? role = await _rolesRepository.GetUserRoleAsync(response);

            var profilePicture = await _usersService.GetProfilePictureAsync(response);
            response.ProfilePicture = profilePicture;

            var token = _tokenService.GetToken(response, role);

            return new LoginResponse { Token = token };
        }

        public async Task OwnSystemRegisterAsync(OwnSysRegisterRequest request, HttpRequest httpRequest)
        {
            var user = await _ownSystemAuthService.RegisterAsync(request, httpRequest);

            await AssignUserRoleAsync(user, request.Role);

            await _pushNotificationService.SendWelcomeNotificationAsync(user, request.Role);
        }

        public async Task<SocialRegisterResponse> SocialProviderRegisterAsync(SocialProviderRegisterRequest request)
        {
            User user;
            switch (request.SocialProvider)
            {
                case SocialProvider.Google:
                    user = await _googleAuthService.RegisterAsync(request);
                    break;

                case SocialProvider.LinkedIn:
                    user = await _linkedInAuthService.LinkedInRegisterAsync(request);
                    break;

                default:
                    throw new InvalidSocialProviderException();
            }

            await AssignUserRoleAsync(user, request.Role);

            string? userRole = await _rolesRepository.GetUserRoleAsync(user);
            var profilePicture = await _usersService.GetProfilePictureAsync(user);
            user.ProfilePicture = profilePicture;

            var token = _tokenService.GetToken(user, userRole);

            await _pushNotificationService.SendWelcomeNotificationAsync(user, request.Role);

            return new SocialRegisterResponse()
            {
                Token = token
            };
        }

        private async Task AssignUserRoleAsync(User user, RoleType role)
        {
            if (user is null)
            {
                throw new RegisterFailedException();
            }

            await CreateUserRole(role, user);
        }

        public async Task ConfirmEmailAsync(string id, string confirmationToken)
        {
            var userId = HttpUtility.UrlDecode(id);
            var token = HttpUtility.UrlDecode(confirmationToken);

            var user = await _usersRepository.GetById(userId);

            if (user == null)
            {
                throw new UserNotFoundException();
            }

            var confirmEmail = await _usersRepository.ConfirmEmailAsync(user, token);

            if (!confirmEmail.Succeeded)
            {
                throw new ConfirmEmailFailedException();
            }
        }

        private async Task CreateUserRole(RoleType role, User newUser)
        {
            switch (role)
            {
                case RoleType.Freelancer:
                    var freelancer = new Freelancer
                    {
                        User = newUser,
                        HasCompletedExperienceInformations = false
                    };

                    await _freelancerRepository.AddAsync(freelancer);
                    await AddUserRole(newUser, RoleType.Freelancer);
                    break;

                case RoleType.SkillScout:
                    var skillScout = new SkillScout
                    {
                        User = newUser
                    };

                    await _skillScoutRepository.AddAsync(skillScout);

                    await AddUserRole(newUser, RoleType.SkillScout);
                    break;
            }
        }

        private async Task AddUserRole(User newUser, RoleType roleType)
        {
            var role = roleType.ToString();

            await _rolesRepository.AddUserRoleAsync(newUser, role);
        }
    }
}