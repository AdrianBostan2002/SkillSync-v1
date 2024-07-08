using Microsoft.EntityFrameworkCore;
using SkillSync.Domain.Interfaces.Repositories;
using SkillSync.Domain.Models;

namespace SkillSync.DataAccess.Repositories
{
    public class SkillCategoryRepository : RepositoryBase<SkillCategory>, ISkillCategoryRepository
    {
        public SkillCategoryRepository(RepositoryContext repositoryContext) :
            base(repositoryContext)
        { }

        public IQueryable<SkillCategory> GetWithAllDependencies()
        {
            return context.Set<SkillCategory>()
                .Include(su => su.SkillSubcategories)
                .ThenInclude(s => s.Skills);
        }

        public async Task<List<SkillCategoryFrequentlyAskedQuestion>> GetFrequentlyAskedQuestionsAsync(Guid id)
        {
            var category = await context.Set<SkillCategory>().Where(sk => sk.Id == id).Include(sk => sk.FrequentlyAskedQuestions).FirstOrDefaultAsync();

            return category?.FrequentlyAskedQuestions.ToList() ?? new List<SkillCategoryFrequentlyAskedQuestion>();
        }
    }
}