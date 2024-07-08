using SkillSync.Domain.Interfaces.Repositories;
using SkillSync.Domain.Models;

namespace SkillSync.DataAccess.Repositories
{
    public class UserFavoriteProjectRepository : RepositoryBase<UserFavoriteProject>, IUserFavoriteProjectRepository
    {
        private readonly RepositoryContext _repositoryContext;

        public UserFavoriteProjectRepository(RepositoryContext repositoryContext) :
            base(repositoryContext)
        {
            _repositoryContext = repositoryContext ?? throw new ArgumentNullException(nameof(repositoryContext));
        }
    }
}