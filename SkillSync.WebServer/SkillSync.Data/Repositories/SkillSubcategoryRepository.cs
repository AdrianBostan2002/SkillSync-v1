using Microsoft.EntityFrameworkCore;
using SkillSync.Domain.Interfaces.Repositories;
using SkillSync.Domain.Models;

namespace SkillSync.DataAccess.Repositories
{
    public class SkillSubcategoryRepository : RepositoryBase<SkillSubcategory>, ISkillSubcategoryRepository
    {
        private readonly RepositoryContext _repositoryContext;

        public SkillSubcategoryRepository(RepositoryContext repositoryContext) :
            base(repositoryContext)
        {
            _repositoryContext = repositoryContext ?? throw new ArgumentNullException(nameof(repositoryContext));
        }

        public async Task<SkillSubcategory> GetByIdWithSkillFeatureOptionsInclude(Guid id)
        {
            return await _repositoryContext.Set<SkillSubcategory>().Where(s => s.Id == id).Include(s => s.FeatureOptions).ThenInclude(s => s.Feature).ThenInclude(s => s.DropdownOption).FirstOrDefaultAsync();
        }
    }
}