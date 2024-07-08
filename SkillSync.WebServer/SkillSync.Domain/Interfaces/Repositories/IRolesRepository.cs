using Microsoft.AspNetCore.Identity;
using SkillSync.Domain.Models;

namespace SkillSync.Domain.Interfaces.Repositories
{
    public interface IRolesRepository
    {
        Task<string> GetUserRoleAsync(User user);

        Task<IdentityResult> AddUserRoleAsync(User user, string role);
        Task<User> GetAdminUser();
    }
}