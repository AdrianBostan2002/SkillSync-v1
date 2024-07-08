using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillSync.Domain.Enums;
using SkillSync.Domain.Models;

namespace SkillSync.DataAccess.Configurations
{
    public class FeatureConfiguration : IEntityTypeConfiguration<Feature>
    {
        public void Configure(EntityTypeBuilder<Feature> builder)
        {
            builder.HasData(
                new Feature { Id = Guid.NewGuid(), Name = "Functional website", InputType = FeatureInputType.Checkbox },
                new Feature { Id = Guid.NewGuid(), Name = "Number of pages", InputType = FeatureInputType.Dropdown, DropdownOptionId = Guid.Parse("8a4b9c88-1f53-4ab9-9052-f8594d732430") },
                new Feature { Id = Guid.NewGuid(), Name = "Responsive design", InputType = FeatureInputType.Checkbox },
                new Feature { Id = Guid.NewGuid(), Name = "Content upload", InputType = FeatureInputType.Checkbox },
                new Feature { Id = Guid.NewGuid(), Name = "Plugins/extensions ", InputType = FeatureInputType.Dropdown, DropdownOptionId = Guid.Parse("8a4b9c88-1f53-4ab9-9052-f8594d732430") },
                new Feature { Id = Guid.NewGuid(), Name = "E-commerce functionality", InputType = FeatureInputType.Checkbox },
                new Feature { Id = Guid.NewGuid(), Name = "Number of products", InputType = FeatureInputType.Dropdown, DropdownOptionId = Guid.Parse("e0046a44-904f-4124-8728-298394557fb6") },
                new Feature { Id = Guid.NewGuid(), Name = "Payment processing", InputType = FeatureInputType.Checkbox },
                new Feature { Id = Guid.NewGuid(), Name = "Opt-in form", InputType = FeatureInputType.Checkbox },
                new Feature { Id = Guid.NewGuid(), Name = "Autoresponder", InputType = FeatureInputType.Checkbox },
                new Feature { Id = Guid.NewGuid(), Name = "Speed optimization", InputType = FeatureInputType.Checkbox },
                new Feature { Id = Guid.NewGuid(), Name = "Hosting setup", InputType = FeatureInputType.Checkbox },
                new Feature { Id = Guid.NewGuid(), Name = "Social media", InputType = FeatureInputType.Checkbox },
                new Feature { Id = Guid.NewGuid(), Name = "Revisions", InputType = FeatureInputType.Dropdown },
                new Feature { Id = Guid.NewGuid(), Name = "Price", InputType = FeatureInputType.TextArea },
                new Feature { Id = Guid.NewGuid(), Name = "Delivery time", InputType = FeatureInputType.Dropdown, DropdownOptionId = Guid.Parse("e0046a44-904f-4124-8728-298394557fb6") },
                new Feature { Id = Guid.NewGuid(), Name = "Package name", InputType = FeatureInputType.TextArea },
                new Feature { Id = Guid.NewGuid(), Name = "Package description", InputType = FeatureInputType.TextArea }
                );
        }
    }
}