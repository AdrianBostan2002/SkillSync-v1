using System.ComponentModel.DataAnnotations.Schema;

namespace SkillSync.Domain.Models
{
    public class Freelancer
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public bool HasCompletedExperienceInformations { get; set; }

        public string? ScopeDescription { get; set; }

        public ICollection<FreelancerSkills> FreelancerSkills { get; set; }
    }
}