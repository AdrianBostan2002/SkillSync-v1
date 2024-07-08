namespace SkillSync.Domain.Models
{
    public class SkillSubcategoryFeatureOption
    {
        public Guid SkillSubcategoryId { get; set; }
        public SkillSubcategory SkillSubcategory { get; set; }

        public Guid FeatureId { get; set; }
        public Feature Feature { get; set; }
    }
}