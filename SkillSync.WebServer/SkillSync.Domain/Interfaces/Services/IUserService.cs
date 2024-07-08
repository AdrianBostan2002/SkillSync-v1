using SkillSync.Domain.Enums;
using SkillSync.Domain.Models;

namespace SkillSync.Domain.Interfaces.Services
{
    public interface IUserService
    {
        Task<RoleType> GetUserRoleAsync(string email);
        Task<RoleType> GetUserRoleAsync(User user);
        Task<string> GetProfilePictureAsync(string email);
        Task<string> GetProfilePictureAsync(User user);
        Task<User> GetUserByEmailAsync(string email);
        Task<User> GetUserByIdAsync(string id);
        Task<User> GetAdminAsync();
    }
}