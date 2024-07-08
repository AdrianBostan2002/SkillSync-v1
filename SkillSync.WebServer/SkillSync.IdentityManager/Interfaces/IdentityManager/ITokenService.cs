using SkillSync.Domain.Models;

namespace SkillSync.IdentityManager.Interfaces.IdentityManager
{
    public interface ITokenService
    {
        string GetToken(User user, string role);
    }
}