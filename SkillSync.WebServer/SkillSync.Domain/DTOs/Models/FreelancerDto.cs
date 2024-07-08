using SkillSync.Domain.DTOs.Project;
using SkillSync.Domain.DTOs.Review;

namespace SkillSync.Domain.DTOs.Models
{
    public class FreelancerDto
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Description { get; set; }

        public string CountryCode { get; set; }

        public string ProfilePicture { get; set; }

        public List<FreelancerSkillsDto>? Skills { get; set; }

        public List<GetProjectPreviewDto> Projects { get; set; }

        public FreelancerReviewsDto? Reviews { get; set; }
    }

    public class FreelancerSkillsDto
    {
        public string SkillName { get; set; }
        public Guid SkillId { get; set; }
    }
}