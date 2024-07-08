using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkillSync.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeededSkillSubcategoryFeatureOptionData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddb34bfe-616a-46a0-af02-b7f29ee25daa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c38026c0-bf91-4dbe-abfc-be5b6bd7eef0", "AQAAAAIAAYagAAAAEO6PPBF8SWy970WPIzDybaUtwBL8utUUV+bzl2IezBGBZvbrtnWA13rLcLVOxlvWsg==", "4acb72f1-adba-4b49-a268-65641589341b" });

            migrationBuilder.InsertData(
                table: "SkillSubcategoryFeatureOption",
                columns: new[] { "FeatureId", "SkillSubcategoryId" },
                values: new object[,]
                {
                    { new Guid("0a6ea85a-da41-4cab-917d-60402a960977"), new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("0f462b41-bb48-42bd-abfa-cb4f72ec1b81"), new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("3b4c9453-d434-4b82-8d68-e35253006b75"), new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("462b11f3-caea-46f7-8046-855d54eadc26"), new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("673ffae4-103d-4380-a4e0-c17087bf0312"), new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("6d5ef352-bd44-4fb9-8f69-2bc5f7b35110"), new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("885fedc2-0997-47a0-a019-02e8912d60ac"), new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("aabb1612-8c9b-4d29-aac9-529957386d7b"), new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("b9f4986e-33aa-4f2c-bcfe-bdb4f66b6635"), new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("dd2dda79-ea1a-4c0c-8bde-7304f23d1208"), new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("fc434379-0b67-4e39-8cf3-d0383ca62571"), new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("fd5c869d-2533-4316-8ee9-78f2eb8dde23"), new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("fe16d65c-dbbf-42cf-b416-d1da153094eb"), new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DropdownOption",
                keyColumn: "Id",
                keyValue: new Guid("158f4680-e266-4af6-bc5f-f5d508faa626"));

            migrationBuilder.DeleteData(
                table: "DropdownOption",
                keyColumn: "Id",
                keyValue: new Guid("41ae58b0-0175-4093-bac5-4d2caaa9c151"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("00f2211b-ff16-4fa8-b62d-b48f2135152f"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("15c7d622-832d-44be-8bbe-27408f926106"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("1861ff89-023b-4079-bfb2-e63205043b7a"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("48353270-da63-4001-893b-b34557858ee5"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("4b787a45-707d-4f05-8c31-6b1da9345162"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("50b6fe2a-db77-4592-89e0-a08d1d4dc5c9"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("531a9651-4f98-4734-b0f9-2b297d1d08d4"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("63c35d87-a949-49d7-9e34-42947c11224c"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("64929635-e49c-44ef-ba1a-c5bdce062253"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("7735f42f-be9d-48b9-91ef-a619fc56e5aa"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("85c6e32c-6c29-4251-b114-1705e567ba96"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("8a627f65-53bf-41a3-993d-ff71e956e752"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("fb8f2b42-562d-40f0-b6ed-89751197483c"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("3bec97b6-dcd6-4821-8147-ba5d0230fee7"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("72da57ce-33ed-42a1-a84f-f644991f2bc2"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("b1481c52-533f-46a8-bc15-ad789be80f74"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("b7377409-3003-41f5-be43-6880e8b542f3"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("bf15fe94-4f48-45df-aecf-9ace3bfd31f3"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("02514f15-befa-4eb0-9d08-095267711c58"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("2c754d2b-4693-4395-a033-55a7d279f095"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("3de1170a-09a1-43fb-985b-57da2266b14f"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("4c09ec8f-6d9f-490f-bb70-dd2a8f6d702d"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("59ec5ca4-8f12-4b8f-8c4e-372143ec1cf9"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("6c3d7632-653f-4bcf-aede-cb9382ec6aad"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("6ecb7f1a-7604-4c57-8116-7526073d599f"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("7bc22640-56ea-4564-8cb3-be1a7e969ad0"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("d9a6b2db-a293-4f85-89f9-cd30c2610e46"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("df2f418f-5e9b-4d48-b097-29e0c26d04a8"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("069c4e67-1ac1-47f8-9c3a-90f7e6461710"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("10860381-6ee4-4c7c-8830-41f5eea7917c"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("1c79cb8d-741b-471d-9176-97fb484941d6"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("2366f47c-22e9-49b3-a626-a740f30fbcff"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("24e5a983-0bd5-4062-8997-2534bd0d6961"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("26419cef-bb22-46b6-a144-7126825a7169"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("2d9d3164-1eee-45b5-bd1b-0ffea908620a"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("5c8696ef-4485-4bea-9005-dab2fc335550"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("91371b15-9745-4128-ba5e-c0e7f9bd151f"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("a5f040ab-217c-4e46-a0e0-88f4f0e06f2f"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("ce71f8b8-5e33-4fe2-8d2c-62f511e832e9"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("ea5cdf11-5855-40eb-b4ab-25d7300314d3"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategoryFeatureOption",
                keyColumns: new[] { "FeatureId", "SkillSubcategoryId" },
                keyValues: new object[] { new Guid("0a6ea85a-da41-4cab-917d-60402a960977"), new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") });

            migrationBuilder.DeleteData(
                table: "SkillSubcategoryFeatureOption",
                keyColumns: new[] { "FeatureId", "SkillSubcategoryId" },
                keyValues: new object[] { new Guid("0f462b41-bb48-42bd-abfa-cb4f72ec1b81"), new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") });

            migrationBuilder.DeleteData(
                table: "SkillSubcategoryFeatureOption",
                keyColumns: new[] { "FeatureId", "SkillSubcategoryId" },
                keyValues: new object[] { new Guid("3b4c9453-d434-4b82-8d68-e35253006b75"), new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") });

            migrationBuilder.DeleteData(
                table: "SkillSubcategoryFeatureOption",
                keyColumns: new[] { "FeatureId", "SkillSubcategoryId" },
                keyValues: new object[] { new Guid("462b11f3-caea-46f7-8046-855d54eadc26"), new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") });

            migrationBuilder.DeleteData(
                table: "SkillSubcategoryFeatureOption",
                keyColumns: new[] { "FeatureId", "SkillSubcategoryId" },
                keyValues: new object[] { new Guid("673ffae4-103d-4380-a4e0-c17087bf0312"), new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") });

            migrationBuilder.DeleteData(
                table: "SkillSubcategoryFeatureOption",
                keyColumns: new[] { "FeatureId", "SkillSubcategoryId" },
                keyValues: new object[] { new Guid("6d5ef352-bd44-4fb9-8f69-2bc5f7b35110"), new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") });

            migrationBuilder.DeleteData(
                table: "SkillSubcategoryFeatureOption",
                keyColumns: new[] { "FeatureId", "SkillSubcategoryId" },
                keyValues: new object[] { new Guid("885fedc2-0997-47a0-a019-02e8912d60ac"), new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") });

            migrationBuilder.DeleteData(
                table: "SkillSubcategoryFeatureOption",
                keyColumns: new[] { "FeatureId", "SkillSubcategoryId" },
                keyValues: new object[] { new Guid("aabb1612-8c9b-4d29-aac9-529957386d7b"), new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") });

            migrationBuilder.DeleteData(
                table: "SkillSubcategoryFeatureOption",
                keyColumns: new[] { "FeatureId", "SkillSubcategoryId" },
                keyValues: new object[] { new Guid("b9f4986e-33aa-4f2c-bcfe-bdb4f66b6635"), new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") });

            migrationBuilder.DeleteData(
                table: "SkillSubcategoryFeatureOption",
                keyColumns: new[] { "FeatureId", "SkillSubcategoryId" },
                keyValues: new object[] { new Guid("dd2dda79-ea1a-4c0c-8bde-7304f23d1208"), new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") });

            migrationBuilder.DeleteData(
                table: "SkillSubcategoryFeatureOption",
                keyColumns: new[] { "FeatureId", "SkillSubcategoryId" },
                keyValues: new object[] { new Guid("fc434379-0b67-4e39-8cf3-d0383ca62571"), new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") });

            migrationBuilder.DeleteData(
                table: "SkillSubcategoryFeatureOption",
                keyColumns: new[] { "FeatureId", "SkillSubcategoryId" },
                keyValues: new object[] { new Guid("fd5c869d-2533-4316-8ee9-78f2eb8dde23"), new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") });

            migrationBuilder.DeleteData(
                table: "SkillSubcategoryFeatureOption",
                keyColumns: new[] { "FeatureId", "SkillSubcategoryId" },
                keyValues: new object[] { new Guid("fe16d65c-dbbf-42cf-b416-d1da153094eb"), new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddb34bfe-616a-46a0-af02-b7f29ee25daa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8165821a-388d-4a66-bd83-3a4706258c05", "AQAAAAIAAYagAAAAEK5L2IjfoKx8Qbzd88alMp+xiA1Zno6ab/fW84UfSqA73JEZiApqvl5taFaoyUlCHw==", "15694c77-d565-486f-b95b-13704640642d" });

            migrationBuilder.InsertData(
                table: "DropdownOption",
                columns: new[] { "Id", "IncrementValue", "LowerInterval", "UpperInterval" },
                values: new object[,]
                {
                    { new Guid("dbcc3ec4-846f-4b01-9491-779c6b74adf0"), 1, 1, 50 },
                    { new Guid("fb0f11ec-44e1-464e-9dfe-fc6c831096bc"), 1, 1, 10 }
                });

            migrationBuilder.InsertData(
                table: "Feature",
                columns: new[] { "Id", "DropdownOptionId", "InputType", "Name" },
                values: new object[,]
                {
                    { new Guid("0a6ea85a-da41-4cab-917d-60402a960977"), null, 0, "Social media" },
                    { new Guid("0f462b41-bb48-42bd-abfa-cb4f72ec1b81"), new Guid("8a4b9c88-1f53-4ab9-9052-f8594d732430"), 1, "Plugins/extensions " },
                    { new Guid("3b4c9453-d434-4b82-8d68-e35253006b75"), new Guid("8a4b9c88-1f53-4ab9-9052-f8594d732430"), 1, "Number of pages" },
                    { new Guid("462b11f3-caea-46f7-8046-855d54eadc26"), null, 0, "Autoresponder" },
                    { new Guid("673ffae4-103d-4380-a4e0-c17087bf0312"), null, 0, "Functional website" },
                    { new Guid("6d5ef352-bd44-4fb9-8f69-2bc5f7b35110"), null, 0, "E-commerce functionality" },
                    { new Guid("885fedc2-0997-47a0-a019-02e8912d60ac"), new Guid("e0046a44-904f-4124-8728-298394557fb6"), 1, "Number of products Dropdown" },
                    { new Guid("aabb1612-8c9b-4d29-aac9-529957386d7b"), null, 0, "Responsive design" },
                    { new Guid("b9f4986e-33aa-4f2c-bcfe-bdb4f66b6635"), null, 0, "Hosting setup" },
                    { new Guid("dd2dda79-ea1a-4c0c-8bde-7304f23d1208"), null, 0, "Speed optimization" },
                    { new Guid("fc434379-0b67-4e39-8cf3-d0383ca62571"), null, 0, "Payment processing" },
                    { new Guid("fd5c869d-2533-4316-8ee9-78f2eb8dde23"), null, 0, "Content upload" },
                    { new Guid("fe16d65c-dbbf-42cf-b416-d1da153094eb"), null, 0, "Opt-in form" }
                });

            migrationBuilder.InsertData(
                table: "Skill",
                columns: new[] { "Id", "Description", "Name", "SkillSubcategoryId" },
                values: new object[,]
                {
                    { new Guid("5b8ed014-d8c0-48b0-8541-b1ab28c7468b"), "Involves creating online stores and platforms for e-commerce activities.", "E-Commerce Development", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("afdbfef9-64b1-476a-873f-da1509ac6bf8"), "Skills in designing and building effective landing pages for websites.", "Landing Pages", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("db4e156c-5f93-40f5-98df-c43c38f05c1a"), "Encompasses skills required to build fully functional and feature-rich websites.", "Build a Complete Website", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("df83f510-2bd2-4c61-b72a-009b06a17d5b"), "Skills related to designing and developing websites for business purposes.", "Business Websites", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("fea5efa8-4dfb-446b-9314-945e88d57b20"), "Focuses on creating websites optimized for dropshipping business models.", "Dropshipping Websites", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") }
                });

            migrationBuilder.InsertData(
                table: "SkillCategory",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("14170649-e2d6-4783-ba9d-2768665b8970"), "This category encompasses skills related to visual design, graphic arts, and creative visual communication.", "Graphics & Design" },
                    { new Guid("7c7475af-99fc-456c-8884-043b4d0645df"), "This category covers skills in video creation, editing, and animation production.", "Video & Animation" },
                    { new Guid("a1cbe52e-91cb-458f-a28f-9b10c2ead52c"), "Skills in music composition, audio production, and sound engineering.", "Music & Audio" },
                    { new Guid("ab31e316-633e-4030-ab84-c5732df1d513"), "Encompasses skills related to business strategy, management, and entrepreneurial activities.", "Business" },
                    { new Guid("be46eaad-1eb3-40db-b1a3-cb520424a89c"), "Skills in programming, software development, and technology solutions fall under this category.", "Programming & Tech" },
                    { new Guid("d59e8388-b43b-4061-a254-13c672591a1e"), "Skills related to content creation, writing, and translation services.", "Writing & Translation" },
                    { new Guid("d75e19d6-52ee-45c6-9b53-0eea893ea725"), "This category involves skills related to artificial intelligence, machine learning, and AI-based services.", "AI Services" },
                    { new Guid("d8d419b2-5a33-4461-a645-28ee3a29b045"), "Skills related to online marketing, advertising, and promotion in the digital realm.", "Digital Marketing" },
                    { new Guid("e03c9e79-4633-46fa-9741-af6ac80ce19f"), "Skills in capturing and editing visual images through photography.", "Photography" },
                    { new Guid("e607fefe-4370-4531-8a90-246a8627a437"), "Skills related to data analysis, management, and interpretation.", "Data" }
                });

            migrationBuilder.InsertData(
                table: "SkillSubcategory",
                columns: new[] { "Id", "Description", "Name", "SkillCategoryId" },
                values: new object[,]
                {
                    { new Guid("10ea1de4-bf3e-4911-88e5-8b01b1d00685"), "Encompasses quality assurance, testing, and review processes to ensure software reliability.", "QA & Review", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("156a9737-b4bd-431b-99b4-bf611cf79115"), "Focuses on creating interactive and engaging video games for various platforms.", "Game Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("17f56b73-5e69-45f0-9dce-01a1b8c4ff6c"), "Involves providing support services and addressing cybersecurity concerns for software and systems.", "Support & Cybersecurity", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("18fb8d2d-56a6-4d67-ad08-54b85d3c652b"), "Involves the creation and implementation of artificial intelligence algorithms and systems.", "AI Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("3564fb7d-b725-45bd-9ddd-a6e04b74b7c2"), "Focuses on designing and building applications specifically for mobile devices.", "Mobile App Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("53292e6d-9927-40f9-b237-ad1d4d47c24e"), "Professionals specializing in software development, coding, and programming.", "Software Developers", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("6af58c56-feb4-4013-9ad2-70fdfd0de067"), "Concerned with the ongoing support, updates, and troubleshooting of existing websites.", "Website Maintenance", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("ba2c7839-7c76-4a1c-a684-c9f2fd6cee31"), "Encompasses the creation and maintenance of software applications for various platforms.", "Software Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("bd78ce1f-aa9d-42ea-802e-86d168c3d67b"), "Includes miscellaneous skills or services related to the broader category of programming and technology.", "Miscellaneous", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("d04a2a53-8f07-4807-8937-1006b1b92738"), "Involves creating and maintaining websites, focusing on design, functionality, and user experience.", "Website Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("f3647376-1ab2-4a5f-b837-2cc7409a41e2"), "Involves the development and implementation of conversational agents for automated interactions.", "Chatbots", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("f78aeb7c-0814-4036-b812-c65ae54765b7"), "Deals with understanding and utilizing various website development platforms and frameworks.", "Website Platforms", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") }
                });
        }
    }
}
