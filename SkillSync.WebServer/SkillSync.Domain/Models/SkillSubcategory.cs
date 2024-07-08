using System.ComponentModel.DataAnnotations.Schema;

namespace SkillSync.Domain.Models
{
    public class SkillSubcategory
    {
        public Guid Id { get; set; }

        public Guid SkillCategoryId { get; set; }
        [NotMapped]
        public SkillCategory SkillCategory { get; set; }

        public List<Skill> Skills { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<SkillSubcategoryFeatureOption> FeatureOptions { get; set; }
    }
}