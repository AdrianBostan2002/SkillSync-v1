namespace SkillSync.Domain.DTOs.Review
{
    public class GetFreelancerReviewDto : GetProjectReviewDto
    {
        public Guid ProjectId { get; set; }
    }
}