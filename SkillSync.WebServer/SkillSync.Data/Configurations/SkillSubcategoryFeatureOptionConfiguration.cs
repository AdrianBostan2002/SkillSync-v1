using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillSync.Domain.Models;

namespace SkillSync.DataAccess.Configurations
{
    public class SkillSubcategoryFeatureOptionConfiguration : IEntityTypeConfiguration<SkillSubcategoryFeatureOption>
    {
        public void Configure(EntityTypeBuilder<SkillSubcategoryFeatureOption> builder)
        {
            builder.HasData(
                new SkillSubcategoryFeatureOption
                {
                    SkillSubcategoryId = Guid.Parse("241bbcfd-c981-4a19-803b-1753ce92643b"),
                    FeatureId = Guid.Parse("885fedc2-0997-47a0-a019-02e8912d60ac")
                },
                new SkillSubcategoryFeatureOption
                {
                    SkillSubcategoryId = Guid.Parse("241bbcfd-c981-4a19-803b-1753ce92643b"),
                    FeatureId = Guid.Parse("6d5ef352-bd44-4fb9-8f69-2bc5f7b35110")
                }, new SkillSubcategoryFeatureOption
                {
                    SkillSubcategoryId = Guid.Parse("241bbcfd-c981-4a19-803b-1753ce92643b"),
                    FeatureId = Guid.Parse("aabb1612-8c9b-4d29-aac9-529957386d7b")
                }, new SkillSubcategoryFeatureOption
                {
                    SkillSubcategoryId = Guid.Parse("241bbcfd-c981-4a19-803b-1753ce92643b"),
                    FeatureId = Guid.Parse("0a6ea85a-da41-4cab-917d-60402a960977")
                }, new SkillSubcategoryFeatureOption
                {
                    SkillSubcategoryId = Guid.Parse("241bbcfd-c981-4a19-803b-1753ce92643b"),
                    FeatureId = Guid.Parse("dd2dda79-ea1a-4c0c-8bde-7304f23d1208")
                }, new SkillSubcategoryFeatureOption
                {
                    SkillSubcategoryId = Guid.Parse("241bbcfd-c981-4a19-803b-1753ce92643b"),
                    FeatureId = Guid.Parse("fd5c869d-2533-4316-8ee9-78f2eb8dde23")
                }, new SkillSubcategoryFeatureOption
                {
                    SkillSubcategoryId = Guid.Parse("241bbcfd-c981-4a19-803b-1753ce92643b"),
                    FeatureId = Guid.Parse("462b11f3-caea-46f7-8046-855d54eadc26")
                }, new SkillSubcategoryFeatureOption
                {
                    SkillSubcategoryId = Guid.Parse("241bbcfd-c981-4a19-803b-1753ce92643b"),
                    FeatureId = Guid.Parse("b9f4986e-33aa-4f2c-bcfe-bdb4f66b6635")
                }, new SkillSubcategoryFeatureOption
                {
                    SkillSubcategoryId = Guid.Parse("241bbcfd-c981-4a19-803b-1753ce92643b"),
                    FeatureId = Guid.Parse("673ffae4-103d-4380-a4e0-c17087bf0312")
                }, new SkillSubcategoryFeatureOption
                {
                    SkillSubcategoryId = Guid.Parse("241bbcfd-c981-4a19-803b-1753ce92643b"),
                    FeatureId = Guid.Parse("0f462b41-bb48-42bd-abfa-cb4f72ec1b81")
                }, new SkillSubcategoryFeatureOption
                {
                    SkillSubcategoryId = Guid.Parse("241bbcfd-c981-4a19-803b-1753ce92643b"),
                    FeatureId = Guid.Parse("fc434379-0b67-4e39-8cf3-d0383ca62571")
                }, new SkillSubcategoryFeatureOption
                {
                    SkillSubcategoryId = Guid.Parse("241bbcfd-c981-4a19-803b-1753ce92643b"),
                    FeatureId = Guid.Parse("fe16d65c-dbbf-42cf-b416-d1da153094eb")
                }, new SkillSubcategoryFeatureOption
                {
                    SkillSubcategoryId = Guid.Parse("241bbcfd-c981-4a19-803b-1753ce92643b"),
                    FeatureId = Guid.Parse("3b4c9453-d434-4b82-8d68-e35253006b75")
                }, new SkillSubcategoryFeatureOption
                {
                    SkillSubcategoryId = Guid.Parse("241bbcfd-c981-4a19-803b-1753ce92643b"),
                    FeatureId = Guid.Parse("3837b73a-b536-4ba0-b22f-f03725b5a39d")
                }, new SkillSubcategoryFeatureOption
                {
                    SkillSubcategoryId = Guid.Parse("241bbcfd-c981-4a19-803b-1753ce92643b"),
                    FeatureId = Guid.Parse("cada2850-5dfe-43bf-8073-8ead5650f98a")
                },
                new SkillSubcategoryFeatureOption
                {
                    SkillSubcategoryId = Guid.Parse("241bbcfd-c981-4a19-803b-1753ce92643b"),
                    FeatureId = Guid.Parse("80e10c56-c46d-45c1-9d65-1930951b4b30")
                }, new SkillSubcategoryFeatureOption
                {
                    SkillSubcategoryId = Guid.Parse("241bbcfd-c981-4a19-803b-1753ce92643b"),
                    FeatureId = Guid.Parse("0a050394-f7af-483a-9f94-043bc4d959f0")
                }, new SkillSubcategoryFeatureOption
                {
                    SkillSubcategoryId = Guid.Parse("241bbcfd-c981-4a19-803b-1753ce92643b"),
                    FeatureId = Guid.Parse("d74075a6-7d42-4665-ba2e-bac6d085f944")
                }
            );
        }
    }
}