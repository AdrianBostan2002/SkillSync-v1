using SkillSync.Domain.Exceptions.Skill;
using SkillSync.Domain.Interfaces.Repositories;
using SkillSync.Domain.Interfaces.Services;
using SkillSync.Domain.Models;

namespace SkillSync.Business.Services
{
    public class SkillSubcategoryService : ISkillSubcategoryService
    {
        private readonly ISkillSubcategoryRepository _skillSubcategoryRepository;

        public SkillSubcategoryService(ISkillSubcategoryRepository skillSubcategoryRepository)
        {
            _skillSubcategoryRepository = skillSubcategoryRepository ?? throw new ArgumentNullException(nameof(skillSubcategoryRepository));
        }

        public async Task<IEnumerable<Feature>> GetSkillFeatureOptions(Guid skillId)
        {
            var skill = await _skillSubcategoryRepository.GetByIdWithSkillFeatureOptionsInclude(skillId);

            if (skill is null)
            {
                throw new SkillSubcategoryNotFoundException();
            }

            return skill.FeatureOptions.Select(s => s.Feature);
        }
    }
}