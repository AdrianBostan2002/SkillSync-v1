using SkillSync.Domain.Interfaces.Repositories;
using SkillSync.Domain.Models;

namespace SkillSync.DataAccess.Repositories
{
    public class SkillRepository : RepositoryBase<Skill>, ISkillRepository
    {
        private readonly RepositoryContext _repositoryContext;

        public SkillRepository(RepositoryContext repositoryContext) :
            base(repositoryContext)
        {
            _repositoryContext = repositoryContext ?? throw new ArgumentNullException(nameof(repositoryContext));
        }
    }
}