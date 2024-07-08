using SkillSync.Domain.Models;

namespace SkillSync.Domain.Interfaces.Repositories
{
    public interface ISkillSubcategoryRepository : IRepository<SkillSubcategory>
    {
        Task<SkillSubcategory> GetByIdWithSkillFeatureOptionsInclude(Guid id);
    }
}