namespace SkillSync.Domain.Models
{
    public class SkillCategoryFrequentlyAskedQuestion : FrequentlyAskedQuestionBase
    {
        public Guid SkillCategoryId { get; set; }
        public SkillCategory SkillCategory { get; set; }
    }
}