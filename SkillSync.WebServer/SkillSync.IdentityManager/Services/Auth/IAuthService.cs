using Microsoft.AspNetCore.Http;
using SkillSync.Domain.Dtos.Login;
using SkillSync.Domain.DTOs.Login;
using SkillSync.Domain.DTOs.Register;
using SkillSync.IdentityManager.Dtos;

namespace SkillSync.IdentityManager.Services.Auth
{
    public interface IAuthService
    {
        Task<LoginResponse> OwnSystemLoginAsync(OwnSystemLoginRequest request);
        Task<LoginResponse> LoginWithSocialProviderAsync(SocialProviderLoginRequest model);
        Task<SocialRegisterResponse> SocialProviderRegisterAsync(SocialProviderRegisterRequest request);
        Task OwnSystemRegisterAsync(OwnSysRegisterRequest request, HttpRequest httpRequest);
        Task ConfirmEmailAsync(string id, string confirmationToken);
    }
}