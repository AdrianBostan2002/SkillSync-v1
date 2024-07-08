using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillSync.Domain.Models;

namespace SkillSync.DataAccess.Configurations
{
    public class SkillCategoryConfiguration : IEntityTypeConfiguration<SkillCategory>
    {
        public void Configure(EntityTypeBuilder<SkillCategory> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Description).IsRequired();

            builder
                .HasMany(x => x.SkillSubcategories)
                .WithOne(p => p.SkillCategory)
                .HasForeignKey(x => x.SkillCategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder
                .HasMany(x => x.FrequentlyAskedQuestions)
                .WithOne(f => f.SkillCategory)
                .HasForeignKey(x => x.SkillCategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new SkillCategory
                {
                    Id = Guid.NewGuid(),
                    Name = "Graphics & Design",
                    Description = "This category encompasses skills related to visual design, graphic arts, and creative visual communication.",
                },
                new SkillCategory
                {
                    Id = Guid.NewGuid(),
                    Name = "Programming & Tech",
                    Description = "Skills in programming, software development, and technology solutions fall under this category.",
                },
                new SkillCategory
                {
                    Id = Guid.NewGuid(),
                    Name = "Digital Marketing",
                    Description = "Skills related to online marketing, advertising, and promotion in the digital realm.",
                },
                new SkillCategory
                {
                    Id = Guid.NewGuid(),
                    Name = "Video & Animation",
                    Description = "This category covers skills in video creation, editing, and animation production.",
                },
                new SkillCategory
                {
                    Id = Guid.NewGuid(),
                    Name = "Writing & Translation",
                    Description = "Skills related to content creation, writing, and translation services.",
                },
                new SkillCategory
                {
                    Id = Guid.NewGuid(),
                    Name = "Music & Audio",
                    Description = "Skills in music composition, audio production, and sound engineering.",
                },
                new SkillCategory
                {
                    Id = Guid.NewGuid(),
                    Name = "Business",
                    Description = "Encompasses skills related to business strategy, management, and entrepreneurial activities.",
                },
                new SkillCategory
                {
                    Id = Guid.NewGuid(),
                    Name = "Data",
                    Description = "Skills related to data analysis, management, and interpretation.",
                },
                new SkillCategory
                {
                    Id = Guid.NewGuid(),
                    Name = "Photography",
                    Description = "Skills in capturing and editing visual images through photography.",
                },
                new SkillCategory
                {
                    Id = Guid.NewGuid(),
                    Name = "AI Services",
                    Description = "This category involves skills related to artificial intelligence, machine learning, and AI-based services.",
                }
            );
        }
    }
}