using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using SkillSync.Domain.Dtos.Login;
using SkillSync.Domain.Enums;
using SkillSync.Domain.Exceptions.Google;
using SkillSync.Domain.Exceptions.User;
using SkillSync.Domain.Interfaces.Repositories;
using SkillSync.Domain.Models;
using SkillSync.IdentityManager.Configurations;
using SkillSync.IdentityManager.Dtos;
using static Google.Apis.Auth.GoogleJsonWebSignature;

namespace SkillSync.IdentityManager.Services.Google
{
    public class GoogleAuthService : IGoogleAuthService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly GoogleAuthConfig _googleAuthConfig;

        public GoogleAuthService
        (
            IOptions<GoogleAuthConfig> googleAuthConfig,
            IUsersRepository usersRepository
        )
        {
            _usersRepository = usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));
            _googleAuthConfig = googleAuthConfig.Value ?? throw new ArgumentNullException(nameof(googleAuthConfig.Value));
        }

        public async Task<User> SignInAsync(SocialProviderLoginRequest model)
        {
            Payload payload = await GetGoogleDataByAccessToken(model.AuthorizationCode);

            User user = await _usersRepository.GetUserByEmailAsync(payload.Email);

            if (user == null)
            {
                throw new UserNotFoundException();
            }

            if (!user.EmailConfirmed)
            {
                throw new EmailNotConfirmedException();
            }

            var userLoginInfo = new UserLoginInfo(SocialProvider.Google.ToString(), payload.Subject, SocialProvider.Google.ToString());

            await _usersRepository.AddLoginAsync(user, userLoginInfo);
            
            return user;
        }

        public async Task<User> RegisterAsync(SocialProviderRegisterRequest request)
        {
            Payload payload = await GetGoogleDataByAccessToken(request.AccessToken);

            var userToBeCreated = new User
            {
                FirstName = payload.GivenName,
                LastName = payload.FamilyName,
                Email = payload.Email,
                CountryCode = payload.Locale != null ? payload.Locale.ToUpper() : "RO",
                ProfilePicture = payload.Picture
            };

            return await _usersRepository.CreateUserFromSocialRegisterAsync(userToBeCreated, SocialProvider.Google, payload.Subject);
        }

        private async Task<Payload> GetGoogleDataByAccessToken(string accessToken)
        {
            Payload payload = new();

            try
            {
                payload = await ValidateAsync(accessToken, new ValidationSettings
                {
                    Audience = new[] { _googleAuthConfig.ClientId }
                });

            }
            catch
            {
                throw new GoogleAuthenticationFailed();
            }

            return payload;
        }
    }
}