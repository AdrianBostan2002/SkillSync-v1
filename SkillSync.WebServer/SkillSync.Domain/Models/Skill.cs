using System.ComponentModel.DataAnnotations.Schema;

namespace SkillSync.Domain.Models
{
    public class Skill
    {
        public Guid Id { get; set; }

        public Guid SkillSubcategoryId { get; set; }

        [ForeignKey("SkillSubcategoryId")]
        [NotMapped]
        public SkillSubcategory SkillSubcategory { get; set; }

        public ICollection<FreelancerSkills> Freelancers { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}