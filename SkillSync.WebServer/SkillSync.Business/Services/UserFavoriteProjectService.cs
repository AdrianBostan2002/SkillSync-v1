using SkillSync.Domain.Exceptions.User;
using SkillSync.Domain.Interfaces.Repositories;
using SkillSync.Domain.Interfaces.Services;
using SkillSync.Domain.Models;

namespace SkillSync.Business.Services
{
    public class UserFavoriteProjectService : IUserFavoriteProjectService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IUserFavoriteProjectRepository _userFavoriteProjectRepository;

        public UserFavoriteProjectService(IUsersRepository usersRepository, IUserFavoriteProjectRepository userFavoriteProjectRepository)
        {
            _usersRepository = usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));
            _userFavoriteProjectRepository = userFavoriteProjectRepository ?? throw new ArgumentNullException(nameof(userFavoriteProjectRepository));
        }

        public async Task ChangeProjectFavoriteStatusAsync(Guid projectId, bool status, string userWhoMadeRequestEmail)
        {
            var userWhoMadeRequest = await _usersRepository.GetUserByEmailAsync(userWhoMadeRequestEmail);

            if (userWhoMadeRequest == null)
            {
                throw new UserNotFoundException();
            }

            var userFavoriteProject = await _userFavoriteProjectRepository.FindByCondition(uf => uf.UserId == userWhoMadeRequest.Id && uf.ProjectId == projectId);
            var favoriteProject = userFavoriteProject.FirstOrDefault();
            var isFavoriteProject = favoriteProject != null ? true : false;

            if (isFavoriteProject == status)
            {
                return;
            }
            else if (status == true)
            {
                await AddProjectFavorite(projectId, userWhoMadeRequest);
            }
            else if (status == false && favoriteProject != null)
            {
                await _userFavoriteProjectRepository.DeleteAsync(favoriteProject);
            }
        }

        private async Task AddProjectFavorite(Guid projectId, User user)
        {
            var userFavoriteProject = new UserFavoriteProject
            {
                ProjectId = projectId,
                UserId = user.Id,
            };

            await _userFavoriteProjectRepository.AddAsync(userFavoriteProject);
        }
    }
}