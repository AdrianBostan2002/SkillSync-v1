using SkillSync.AzureBlobStorage.Interfaces;
using SkillSync.Domain.Enums;
using SkillSync.Domain.Exceptions.Role;
using SkillSync.Domain.Exceptions.User;
using SkillSync.Domain.Extensions;
using SkillSync.Domain.Interfaces.Repositories;
using SkillSync.Domain.Interfaces.Services;
using SkillSync.Domain.Models;

namespace SkillSync.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IRolesRepository _rolesRepository;
        private readonly IFileService _fileService;

        public UserService(IUsersRepository usersRepository, IRolesRepository rolesRepository, IFileService fileService)
        {
            _usersRepository = usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));
            _rolesRepository = rolesRepository ?? throw new ArgumentNullException(nameof(rolesRepository));
            _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
        }

        public async Task<RoleType> GetUserRoleAsync(string email)
        {
            var user = await GetUserByEmailAsync(email);

            var role = await GetUserRoleAsync(user);

            return role;
        }

        public async Task<RoleType> GetUserRoleAsync(User user)
        {
            var role = await _rolesRepository.GetUserRoleAsync(user);

            if (role is null)
            {
                throw new UserDontHaveRoleException();
            }

            return role.ToRoleType();
        }

        public async Task<User> GetAdminAsync()
        {
            return await _rolesRepository.GetAdminUser();
        }

        public async Task<User> GetUserByEmailAsync(string email)
        {
            var user = await _usersRepository.GetUserByEmailAsync(email);

            if (user is null)
            {
                throw new UserNotFoundException();
            }

            return user;
        }

        public async Task<User> GetUserByIdAsync(string id)
        {
            var user = await _usersRepository.GetById(id);

            if (user is null)
            {
                throw new UserNotFoundException();
            }

            return user;
        }

        public async Task<string> GetProfilePictureAsync(string email)
        {
            var user = await _usersRepository.GetUserByEmailAsync(email);

            var profilePicture = await GetProfilePictureAsync(user);

            return profilePicture;
        }

        public async Task<string> GetProfilePictureAsync(User user)
        {
            var loginInfo = await _usersRepository.GetLoginInfoAsync(user);

            string profilePictureUrl = user.ProfilePicture;

            if (loginInfo == null)
            {
                profilePictureUrl = _fileService.GetProfilePicture(user.ProfilePicture);
            }

            return profilePictureUrl;
        }
    }
}