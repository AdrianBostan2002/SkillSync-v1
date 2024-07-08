namespace SkillSync.Domain.DTOs.Project.PostSteps
{
    public class FreelancerProjectDto
    {
        public Guid Id { get; set; }

        public string? Picture { get; set; }

        public string Title { get; set; }

        public DateTime CreatedAt { get; set; }

        public int? BasicPrice { get; set; }

        public int? StandardPrice { get; set; }

        public int? PremiumPrice { get; set; }
    }
}