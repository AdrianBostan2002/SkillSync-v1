namespace SkillSync.Domain.DTOs.Review
{
    public class GetProjectReviewDto
    {
        public string ReviewerProfilePicture { get; set; }
        public string ReviewerName { get; set; }

        public string Content { get; set; }
        public int Stars { get; set; }
        public DateTime ReviewAt { get; set; }
    }
}