using SkillSync.Domain.Dtos.Login;
using SkillSync.Domain.Models;
using SkillSync.IdentityManager.Dtos;

namespace SkillSync.IdentityManager.Services.Google
{
    public interface IGoogleAuthService
    {
        Task<User> SignInAsync(SocialProviderLoginRequest model);
        Task<User> RegisterAsync(SocialProviderRegisterRequest request);
    }
}
