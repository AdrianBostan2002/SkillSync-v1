using SkillSync.Domain.DTOs.Models;

namespace SkillSync.Domain.DTOs.Register
{
    public class CompleteFreelancerExperienceInfoRequest
    {
        public IEnumerable<SkillDto> Skills { get; set; }

        public string ScopeDescription { get; set; }
    }
}