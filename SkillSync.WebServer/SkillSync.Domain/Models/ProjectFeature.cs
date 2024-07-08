namespace SkillSync.Domain.Models
{
    public class ProjectFeature
    {
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }

        public Guid FeatureId { get; set; }
        public Feature Feature { get; set; }

        public string BasicSelectedValue { get; set; }
        public string? StandardSelectedValue { get; set; }
        public string? PremiumSelectedValue { get; set; }
    }
}