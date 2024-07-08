namespace SkillSync.Domain.Models
{
    public class SkillCategory
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<SkillSubcategory> SkillSubcategories { get; set; }

        public ICollection<SkillCategoryFrequentlyAskedQuestion> FrequentlyAskedQuestions { get; set; }
    }
}