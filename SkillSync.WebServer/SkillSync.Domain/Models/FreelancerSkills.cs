using SkillSync.Domain.Enums;

namespace SkillSync.Domain.Models
{
    public class FreelancerSkills
    {
        public Guid FreelancerId { get; set; }
        public Freelancer Freelancer { get; set; }

        public Guid SkillId { get; set; }
        public Skill Skill { get; set; }

        public SkillExperienceLevel Experience { get; set; }
    }
}