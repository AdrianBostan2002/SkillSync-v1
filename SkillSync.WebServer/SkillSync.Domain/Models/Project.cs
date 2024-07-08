namespace SkillSync.Domain.Models
{
    public class Project
    {
        public Guid Id { get; set; }

        public Guid FreelancerId { get; set; }
        public Freelancer Freelancer { get; set; }

        public Guid SkillId { get; set; }
        public Skill Skill { get; set; }

        public string Title { get; set; }

        public bool IsPublished { get; set; }

        public DateTime CreatedAt { get; set; }

        public string? Description { get; set; }

        public bool? HasPackages { get; set; }

        public ICollection<ProjectFeature> Features { get; set; }

        public ICollection<ProjectFrequentlyAskedQuestion> FrequentlyAskedQuestions { get; set; }

        public ICollection<ProjectPicture> Pictures { get; set; }

        public ProjectVideo Video { get; set; }

        public ICollection<ProjectDocument> Documents { get; set; }

        public List<ProjectReview> Reviews { get; set; }
    }
}