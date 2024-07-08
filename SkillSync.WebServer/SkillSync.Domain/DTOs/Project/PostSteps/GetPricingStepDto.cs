using SkillSync.Domain.DTOs.Models;

namespace SkillSync.Domain.DTOs.Project.PostSteps
{
    public class GetPricingStepDto
    {
        public IDictionary<Guid, GetProjectFeatureDto> Features { get; set; }

        public bool HasPackages { get; set; }
    }
}