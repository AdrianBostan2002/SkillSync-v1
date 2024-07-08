using Microsoft.AspNetCore.Identity;
using SkillSync.Domain.Exceptions.Role;
using SkillSync.Domain.Interfaces.Repositories;
using SkillSync.Domain.Models;

namespace SkillSync.DataAccess.Repositories
{
    public class RolesRepository : IRolesRepository
    {
        private readonly UserManager<User> _userManager;

        private const string adminRole = "Admin";

        public RolesRepository(UserManager<User> userManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }


        public async Task<string> GetUserRoleAsync(User user)
        {
            var roles = await _userManager.GetRolesAsync(user);

            if (roles.Count > 1)
            {
                throw new UserHasMultipleRolesException();
            }

            return roles.FirstOrDefault();
        }

        public async Task<IdentityResult> AddUserRoleAsync(User user, string role)
        {
            return await _userManager.AddToRoleAsync(user, role);
        }

        public async Task<User> GetAdminUser()
        {
            var query = await _userManager.GetUsersInRoleAsync(adminRole);

            return query.FirstOrDefault();
        }
    }
}