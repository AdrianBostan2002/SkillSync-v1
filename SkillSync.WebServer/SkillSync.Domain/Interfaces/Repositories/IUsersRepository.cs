using Microsoft.AspNetCore.Identity;
using SkillSync.Domain.Enums;
using SkillSync.Domain.Models;

namespace SkillSync.Domain.Interfaces.Repositories
{
    public interface IUsersRepository
    {
        Task<User> GetUserByEmailAsync(string email);
        Task<IdentityResult> AddUserAsync(User user);
        Task<User> CreateUserFromSocialRegisterAsync(User newUser, SocialProvider loginProvider, string providerKey);
        Task<User> GetById(string id);
        Task<string> GenerateEmailConfirmationToken(User user);
        Task<IdentityResult> ConfirmEmailAsync(User user, string confirmationToken);
        Task<UserLoginInfo> GetLoginInfoAsync(User user);
        Task<IdentityResult> AddLoginAsync(User user, UserLoginInfo userLoginInfo);
    }
}