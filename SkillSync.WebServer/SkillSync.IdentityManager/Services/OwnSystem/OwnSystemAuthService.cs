using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SkillSync.AzureBlobStorage.Interfaces;
using SkillSync.Domain.DTOs.File;
using SkillSync.Domain.DTOs.Login;
using SkillSync.Domain.Enums;
using SkillSync.Domain.Exceptions.Register;
using SkillSync.Domain.Exceptions.User;
using SkillSync.Domain.Interfaces.Repositories;
using SkillSync.Domain.Interfaces.Services;
using SkillSync.Domain.Models;
using SkillSync.Email.Interfaces;
using SkillSync.IdentityManager.Dtos;
using SkillSync.IdentityManager.Extensions;
using SkillSync.IdentityManager.Interfaces.IdentityManager;

namespace SkillSync.IdentityManager.Services.Login
{
    public class OwnSystemAuthService : IOwnSystemAuthService
    {
        private readonly ITokenService _tokenService;
        private readonly IFileService _fileService;
        private readonly IEmailService _emailService;
        private readonly IUserService _usersService;

        private readonly IUsersRepository _userRepository;
        private readonly IRolesRepository _rolesRepository;

        private readonly SignInManager<User> _signInManager;

        public OwnSystemAuthService
        (
            ITokenService tokenService,
            IFileService fileService,
            IEmailService emailService,
            IUserService userService,
            IUsersRepository userRepository,
            IRolesRepository rolesRepository,
            SignInManager<User> signInManager
        )
        {
            _tokenService = tokenService ?? throw new ArgumentNullException(nameof(tokenService));
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
            _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
            _usersService = userService ?? throw new ArgumentNullException(nameof(userService));
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _rolesRepository = rolesRepository ?? throw new ArgumentNullException(nameof(rolesRepository));
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
        }

        public async Task<LoginResponse> LoginAsync(OwnSystemLoginRequest request)
        {
            User user = await _userRepository.GetUserByEmailAsync(request.Email);

            if (user == null)
            {
                throw new UserNotFoundException();
            }

            if (!user.EmailConfirmed)
            {
                throw new EmailNotConfirmedException();
            }

            var checkPassword = await _signInManager.CheckPasswordSignInAsync(user, request.Password, true);

            if (!checkPassword.Succeeded)
            {
                throw new InvalidPasswordException();
            }

            string? role = await _rolesRepository.GetUserRoleAsync(user);

            var profilePicture = await _usersService.GetProfilePictureAsync(user);
            user.ProfilePicture = profilePicture;

            var token = _tokenService.GetToken(user, role);

            var response = new LoginResponse
            {
                Token = token
            };

            return await Task.FromResult(response);
        }

        public async Task<User> RegisterAsync(OwnSysRegisterRequest request, HttpRequest httpRequest)
        {
            if (request.Role == RoleType.Administrator)
            {
                throw new NotAbleToRegisterNewAdministratorException();
            }

            var user = await _userRepository.GetUserByEmailAsync(request.Email);

            if (user != null)
            {
                throw new UserAlreadyExistsException();
            }

            var passwordHasher = new PasswordHasher<User>();

            var profilePictureName = $"{request.Email}-profilePicture";

            var newUser = new User
            {
                Email = request.Email,
                FirstName = request.FirstName,
                LastName = request.LastName,
                PasswordHash = passwordHasher.HashPassword(null, request.Password),
                CountryCode = request.CountryCode,
                UserName = request.Email,
                EmailConfirmed = false,
                ProfilePicture = profilePictureName
            };

            var result = _userRepository.AddUserAsync(newUser).Result;

            var isSucceded = result.Succeeded;

            if (!isSucceded)
            {
                throw new RegisterFailedException(result.Errors.FirstOrDefault().Description);
            }

            var uploadProfilePictureRequest = new UploadFileDto()
            {
                File = request.ProfilePicture,
                Name = profilePictureName,
                ContentType = request.ProfilePicture.ContentType
            };

            await _fileService.UploadProfilePictureAsync(uploadProfilePictureRequest);

            User createdUser = await _userRepository.GetUserByEmailAsync(request.Email);

            var confirmationToken = await _userRepository.GenerateEmailConfirmationToken(createdUser);

            await _emailService.SendConfirmationEmail(createdUser, confirmationToken, httpRequest.BaseUrl());

            return createdUser;
        }
    }
}