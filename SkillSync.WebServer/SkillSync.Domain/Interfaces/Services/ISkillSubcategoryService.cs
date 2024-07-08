using SkillSync.Domain.Models;

namespace SkillSync.Domain.Interfaces.Services
{
    public interface ISkillSubcategoryService
    {
        Task<IEnumerable<Feature>> GetSkillFeatureOptions(Guid skillId);
    }
}