namespace SkillSync.Domain.DTOs.Models
{
    public class ProjectFeatureDto
    {
        public Guid FeatureId { get; set; }

        public string BasicSelectedValue { get; set; }
        public string? StandardSelectedValue { get; set; }
        public string? PremiumSelectedValue { get; set; }
    }
}