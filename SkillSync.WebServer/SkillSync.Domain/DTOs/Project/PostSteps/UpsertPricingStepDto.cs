using SkillSync.Domain.DTOs.Models;

namespace SkillSync.Domain.DTOs.Project.PostSteps
{
    public class UpsertPricingStepDto
    {
        public ICollection<ProjectFeatureDto> Features { get; set; }

        public bool HasPackages { get; set; }
    }
}