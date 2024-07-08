using SkillSync.Domain.Interfaces.Repositories;
using SkillSync.Domain.Models;

namespace SkillSync.DataAccess.Repositories
{
    public class DropdownOptionRepository : RepositoryBase<DropdownOption>, IDropdownOptionRepository
    {
        public DropdownOptionRepository(RepositoryContext repositoryContext) :
            base(repositoryContext)
        { }
    }
}