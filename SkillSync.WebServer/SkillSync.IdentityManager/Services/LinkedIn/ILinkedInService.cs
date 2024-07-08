using SkillSync.Domain.Dtos.Login;
using SkillSync.Domain.Models;
using SkillSync.IdentityManager.Dtos;

namespace SkillSync.IdentityManager.Services.LinkedIn
{
    public interface ILinkedInService
    {
        Task<User> LinkedInSignIn(SocialProviderLoginRequest model);
        Task<User> LinkedInRegisterAsync(SocialProviderRegisterRequest request);
    }
}