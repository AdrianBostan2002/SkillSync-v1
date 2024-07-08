using SkillSync.Domain.Enums;

namespace SkillSync.Domain.Models
{
    public class Feature
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public FeatureInputType InputType { get; set; }

        public Guid? DropdownOptionId { get; set; }
        public DropdownOption? DropdownOption { get; set; }
    }
}