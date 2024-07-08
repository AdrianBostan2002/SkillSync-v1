using SkillSync.Domain.Models;

namespace SkillSync.Domain.DTOs.Models
{
    public class SkillDto
    {
        public Guid Id { get; set; }

        public Guid SkillSubcategoryId { get; set; }

        public ICollection<FreelancerSkills> Freelancers { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}