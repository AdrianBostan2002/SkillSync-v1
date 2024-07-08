using SkillSync.Domain.DTOs.Models;
using SkillSync.Domain.DTOs.Project;

namespace SkillSync.Domain.Interfaces.Services
{
    public interface ISkillCategoryService
    {
        Task<List<SkillCategoryDto>> GetWithAllDependenciesAsync();

        Task<List<FrequentlyAskedQuestionDto>> GetSkillCategoryFrequentlyAskedQuestionsAsync(Guid skillId);
    }
}