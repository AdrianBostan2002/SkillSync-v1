using SkillSync.Domain.Interfaces.Repositories;
using SkillSync.Domain.Models;

namespace SkillSync.DataAccess.Repositories
{
    public class SkillScoutRepository : RepositoryBase<SkillScout>, ISkillScoutRepository
    {
        public SkillScoutRepository(RepositoryContext repositoryContext) :
            base(repositoryContext)
        { }
    }
}