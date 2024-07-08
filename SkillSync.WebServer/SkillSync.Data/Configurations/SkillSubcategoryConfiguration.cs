using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillSync.Domain.Models;

namespace SkillSync.DataAccess.Configurations
{
    public class SkillSubcategoryConfiguration : IEntityTypeConfiguration<SkillSubcategory>
    {
        public void Configure(EntityTypeBuilder<SkillSubcategory> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Description).IsRequired();

            builder
                .HasOne(x => x.SkillCategory)
                .WithMany(p => p.SkillSubcategories)
                .HasForeignKey(x => x.SkillCategoryId)
            .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new SkillSubcategory
                {
                    Id = Guid.NewGuid(),
                    SkillCategoryId = Guid.Parse("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e"),
                    Name = "Website Development",
                    Description = "Involves creating and maintaining websites, focusing on design, functionality, and user experience.",
                },
                new SkillSubcategory
                {
                    Id = Guid.NewGuid(),
                    SkillCategoryId = Guid.Parse("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e"),
                    Name = "Software Development",
                    Description = "Encompasses the creation and maintenance of software applications for various platforms.",
                },
                new SkillSubcategory
                {
                    Id = Guid.NewGuid(),
                    SkillCategoryId = Guid.Parse("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e"),
                    Name = "Mobile App Development",
                    Description = "Focuses on designing and building applications specifically for mobile devices.",
                },
                new SkillSubcategory
                {
                    Id = Guid.NewGuid(),
                    SkillCategoryId = Guid.Parse("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e"),
                    Name = "AI Development",
                    Description = "Involves the creation and implementation of artificial intelligence algorithms and systems.",
                },
                new SkillSubcategory
                {
                    Id = Guid.NewGuid(),
                    SkillCategoryId = Guid.Parse("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e"),
                    Name = "Game Development",
                    Description = "Focuses on creating interactive and engaging video games for various platforms.",
                },
                new SkillSubcategory
                {
                    Id = Guid.NewGuid(),
                    SkillCategoryId = Guid.Parse("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e"),
                    Name = "Chatbots",
                    Description = "Involves the development and implementation of conversational agents for automated interactions.",
                },
                new SkillSubcategory
                {
                    Id = Guid.NewGuid(),
                    SkillCategoryId = Guid.Parse("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e"),
                    Name = "Website Maintenance",
                    Description = "Concerned with the ongoing support, updates, and troubleshooting of existing websites.",
                },
                new SkillSubcategory
                {
                    Id = Guid.NewGuid(),
                    SkillCategoryId = Guid.Parse("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e"),
                    Name = "QA & Review",
                    Description = "Encompasses quality assurance, testing, and review processes to ensure software reliability.",
                },
                new SkillSubcategory
                {
                    Id = Guid.NewGuid(),
                    SkillCategoryId = Guid.Parse("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e"),
                    Name = "Support & Cybersecurity",
                    Description = "Involves providing support services and addressing cybersecurity concerns for software and systems.",
                }
            );
        }
    }
}