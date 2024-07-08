using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SkillSync.Domain.Enums;
using SkillSync.Domain.Exceptions.User;
using SkillSync.Domain.Interfaces.Repositories;
using SkillSync.Domain.Models;

namespace SkillSync.DataAccess.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private readonly UserManager<User> _userManager;

        public UsersRepository(UserManager<User> userManager)
        {
            _userManager = userManager ?? throw new ArgumentNullException(nameof(userManager));
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            return await _userManager.Users.FirstOrDefaultAsync(user => user.Email.Equals(email));
        }

        public async Task<IdentityResult> AddUserAsync(User user)
        {
            return await _userManager.CreateAsync(user);
        }

        public async Task<User> CreateUserFromSocialRegisterAsync(User newUser, SocialProvider loginProvider, string providerKey)
        {
            var user = await _userManager.FindByLoginAsync(loginProvider.ToString(), providerKey);

            if (user is not null)
                throw new UserAlreadyExistsException();

            user = await _userManager.FindByEmailAsync(newUser.Email);

            if (user is not null)
            {
                throw new UserAlreadyExistsException();
            }

            user = new User
            {
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Email = newUser.Email,
                UserName = newUser.Email,
                CountryCode = newUser.CountryCode,
                ProfilePicture = newUser.ProfilePicture
            };

            await _userManager.CreateAsync(user);

            user.EmailConfirmed = true;

            await _userManager.UpdateAsync(user);

            UserLoginInfo userLoginInfo = new UserLoginInfo(loginProvider.ToString(), providerKey, loginProvider.ToString());

            var result = await AddLoginAsync(user, userLoginInfo);

            if (!result.Succeeded)
                return null;

            return user;
        }

        public async Task<UserLoginInfo> GetLoginInfoAsync(User user)
        {
            var loginInfo = await _userManager.GetLoginsAsync(user);

            return loginInfo.FirstOrDefault();
        }

        public async Task<IdentityResult> AddLoginAsync(User user, UserLoginInfo userLoginInfo)
        {
            return await _userManager.AddLoginAsync(user, userLoginInfo);
        }

        public async Task<User> GetById(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public async Task<string> GenerateEmailConfirmationToken(User user)
        {
            return await _userManager.GenerateEmailConfirmationTokenAsync(user);
        }

        public async Task<IdentityResult> ConfirmEmailAsync(User user, string confirmationToken)
        {
            return await _userManager.ConfirmEmailAsync(user, confirmationToken);
        }
    }
}