using SkillSync.Domain.Models;

namespace SkillSync.Domain.Interfaces.Repositories
{
    public interface ISkillCategoryRepository : IRepository<SkillCategory>
    {
        IQueryable<SkillCategory> GetWithAllDependencies();

        Task<List<SkillCategoryFrequentlyAskedQuestion>> GetFrequentlyAskedQuestionsAsync(Guid id);
    }
}