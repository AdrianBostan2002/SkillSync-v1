namespace SkillSync.Domain.Models
{
    public class ProjectReview
    {
        public string ReviewerId { get; set; }
        public User Reviewer { get; set; }

        public Guid ProjectId { get; set; }
        public Project Project { get; set; }

        public string Content { get; set; }

        public int Stars { get; set; }
        
        public DateTime ReviewAt { get; set; }
    }
}