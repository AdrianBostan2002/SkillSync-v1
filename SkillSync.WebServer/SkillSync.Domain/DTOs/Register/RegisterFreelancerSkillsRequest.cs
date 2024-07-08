using SkillSync.Domain.DTOs.Models;

namespace SkillSync.Domain.DTOs.Register
{
    public class RegisterFreelancerSkillsRequest
    {
        public IEnumerable<SkillDto> Skills { get; set; }
    }
}