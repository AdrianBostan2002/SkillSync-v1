using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using SkillSync.Domain.Dtos.Login;
using SkillSync.Domain.Enums;
using SkillSync.Domain.Exceptions.SocialProvider;
using SkillSync.Domain.Exceptions.User;
using SkillSync.Domain.Interfaces.Repositories;
using SkillSync.Domain.Models;
using SkillSync.IdentityManager.Configurations;
using SkillSync.IdentityManager.Dtos;
using System.Net.Http.Headers;

namespace SkillSync.IdentityManager.Services.LinkedIn
{
    public class LinkedInService : ILinkedInService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly LinkedInAuthConfig _linkedInAuthConfig;
        private readonly HttpClient _httpClient;
        private readonly string _apiUrl; 

        public LinkedInService(IOptions<LinkedInAuthConfig> linkedInAuthConfig, HttpClient httpClient, IUsersRepository usersRepository, IConfiguration configuration)
        {
            _usersRepository = usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));
            _linkedInAuthConfig = linkedInAuthConfig.Value ?? throw new ArgumentNullException(nameof(linkedInAuthConfig));
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _apiUrl = configuration["FrontendApp:Url"];
        }

        public async Task<User> LinkedInSignIn(SocialProviderLoginRequest model)
        {
            LinkedInUserDto? deserializedUserInfo = await GetLinkedinUserDataByAccessTokenAsync(model.AuthorizationCode, true);

            User user = await _usersRepository.GetUserByEmailAsync(deserializedUserInfo.Email);

            if (user == null)
            {
                throw new UserNotFoundException();
            }

            if (!user.EmailConfirmed)
            {
                throw new EmailNotConfirmedException();
            }

            var userLoginInfo = new UserLoginInfo(SocialProvider.LinkedIn.ToString(), deserializedUserInfo.Subject, SocialProvider.LinkedIn.ToString());

            await _usersRepository.AddLoginAsync(user, userLoginInfo);

            return user;
        }

        public async Task<User> LinkedInRegisterAsync(SocialProviderRegisterRequest request)
        {
            LinkedInUserDto? deserializedUserInfo = await GetLinkedinUserDataByAccessTokenAsync(request.AccessToken, false);

            if (deserializedUserInfo is null)
            {
                throw new SocialProviderDidNotProvideAnyUserData();
            }

            var userToBeCreated = new User
            {
                FirstName = deserializedUserInfo.FirstName,
                LastName = deserializedUserInfo.LastName,
                Email = deserializedUserInfo.Email,
                CountryCode = deserializedUserInfo.Locale.Country,
                ProfilePicture = deserializedUserInfo.ProfilePicture
            };

            return await _usersRepository.CreateUserFromSocialRegisterAsync(userToBeCreated, SocialProvider.Google, deserializedUserInfo.Subject);
        }

        private async Task<LinkedInUserDto?> GetLinkedinUserDataByAccessTokenAsync(string authorizationCode, bool isLogin)
        {
            var linkedInResponse = await GetAccessToken(authorizationCode, isLogin);

            if (linkedInResponse.AccessToken is null)
            {
                throw new LinkedInObtainedTokenIsNullException();
            }

            var accessToken = linkedInResponse.AccessToken;

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

            var response = await _httpClient.GetAsync("v2/userinfo");

            if (!response.IsSuccessStatusCode)
            {
                var errorResponse = await response.Content.ReadAsStringAsync();
                throw new Exception();
            }

            var userInfo = await response.Content.ReadAsStringAsync();

            var deserializedUserInfo = JsonConvert.DeserializeObject<LinkedInUserDto>(userInfo);
            return deserializedUserInfo;
        }

        private async Task<LinkedInToken> GetAccessToken(string authorizationCode, bool isLogin)
        {
            var clientId = _linkedInAuthConfig.ClientId;
            var clientSecret = _linkedInAuthConfig.ClientSecret;
            string redirectUri;
            if (isLogin)
            {
                redirectUri = $"{_apiUrl}/linkedInLogin";
            }
            else
            {
                redirectUri = $"{_apiUrl}/choose-role";
            }

            var tokenEndpoint = "https://www.linkedin.com/oauth/v2/accessToken";


            var content = new FormUrlEncodedContent(new Dictionary<string, string>
                {
                    { "grant_type", "authorization_code" },
                    { "code", authorizationCode },
                    { "redirect_uri", redirectUri },
                    { "client_id", clientId },
                    { "client_secret", clientSecret }
                });

            var tokenResponse = await _httpClient.PostAsync(tokenEndpoint, content);
            var tokenContent = await tokenResponse.Content.ReadAsStringAsync();

            var tokenData = JsonConvert.DeserializeObject<LinkedInToken>(tokenContent);

            return tokenData;
        }
    }
}