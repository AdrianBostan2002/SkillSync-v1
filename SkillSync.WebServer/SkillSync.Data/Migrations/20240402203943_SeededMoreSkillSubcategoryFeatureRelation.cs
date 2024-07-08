using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkillSync.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeededMoreSkillSubcategoryFeatureRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddb34bfe-616a-46a0-af02-b7f29ee25daa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fe58b78a-4361-4146-9781-2a748c08f4bf", "AQAAAAIAAYagAAAAEMReyb44cT5sJ2u+2UwLy4p/5eVEo14n2omU56lfMeupsTkhntI/LbWd8noSXhREIA==", "d612b793-5c99-494b-8ef2-af1473cf0431" });

            migrationBuilder.InsertData(
                table: "SkillSubcategoryFeatureOption",
                columns: new[] { "FeatureId", "SkillSubcategoryId" },
                values: new object[,]
                {
                    { new Guid("0a050394-f7af-483a-9f94-043bc4d959f0"), new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("80e10c56-c46d-45c1-9d65-1930951b4b30"), new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("d74075a6-7d42-4665-ba2e-bac6d085f944"), new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DropdownOption",
                keyColumn: "Id",
                keyValue: new Guid("cbcf6f2c-26e5-473c-a1dd-e8eabf21002d"));

            migrationBuilder.DeleteData(
                table: "DropdownOption",
                keyColumn: "Id",
                keyValue: new Guid("fccda09a-fe36-4e52-9b1d-1a5db61c7eb6"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("0b9c10f0-8e6c-43e8-8f0a-1691c3f7ad09"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("0ce70c32-d074-4cda-b0ee-abdb9b417547"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("112d36dc-653d-488c-8539-6f753260f94d"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("2a5c736d-8dc3-417b-be53-83d76e81a5a9"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("3cb68593-609a-4dbc-bfa5-82a977e5df78"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("419cee0e-cf92-434a-90fb-c46b216105e9"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("4b297553-b81e-4b90-9ff0-a38843ccb4ca"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("66619125-eb7a-4878-be11-ffd4aeec86c1"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("6fe0d37a-4f06-4a7c-b3db-0d80e16aaeee"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("705dd53c-6777-445b-8b5b-96b9ca4c3ffc"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("78960370-84db-4217-9f1e-2591105fda85"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("8745207e-b84b-44af-93d7-1bb29d632bf3"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("8e110524-dc9d-4954-a55b-f4a4da3be41f"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("af61bc5b-8435-49a6-a15a-b2d84adc04a3"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("b137340c-8031-4c1c-a796-151782123a08"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("bbb3515c-47f6-4a30-b308-3c668fd509ed"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("db65ffff-4896-49da-92fa-0d2a6f4c091f"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("e034faf0-10c5-40ff-b31e-533536121ba4"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("025ff596-7a5a-4a97-a40f-29c66c0cab31"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("2072ca2c-69ed-4625-9117-8738f8e6fe56"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("88a16547-84e6-423f-8949-0b0b195192e8"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("dd5fcb66-dbe8-4541-9535-b7c0c69b558d"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("f706b94e-776c-461a-b54b-e3110c2243b4"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("0d790d03-54b7-4011-8732-9e192c101797"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("2213841b-0c10-4f9c-acec-d23d775053cc"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("386c040e-2e52-4653-9f67-65e46f02bfae"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("3d25faa5-5e20-4242-a78b-85f798e96ad4"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("4639595b-1c76-4bbc-a3dc-5c6c122936e6"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("63afaff6-9721-4004-8ee8-36e2f3eb999f"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("a3a24873-39c7-4567-a8d2-2a36c2adee8c"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("e2f32885-984c-4df9-b9bc-ff18ae4c6a09"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("eec76905-2d1a-4cdd-9f1c-084904621868"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("f7e72361-09b3-4a60-af02-92e170912b95"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("004d3473-819f-4373-876c-baab95fc27fe"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("03be9f36-dc77-4cbc-b243-de4f88be1e54"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("0fb84244-15e8-4992-a026-62a5ffcc3607"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("2f6198dd-d87b-45c5-bb28-9f501071b81b"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("4757f334-5e24-471d-b64f-f89014759a2d"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("68c6f6d0-50bf-4590-8112-02f996e62b51"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("7b2f3780-0739-41d6-9bac-ebf71927d6c8"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("c4b06971-75fd-42de-aa5b-95642e74701d"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("c5885b6a-ac1d-4427-b2af-18c98fa73f89"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("d775f149-e725-4c57-9694-26d806c53463"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("e377fd92-3420-4456-b3b0-86d5a419eeca"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("e86f9a52-02ac-4593-97b2-0ce594661602"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategoryFeatureOption",
                keyColumns: new[] { "FeatureId", "SkillSubcategoryId" },
                keyValues: new object[] { new Guid("0a050394-f7af-483a-9f94-043bc4d959f0"), new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") });

            migrationBuilder.DeleteData(
                table: "SkillSubcategoryFeatureOption",
                keyColumns: new[] { "FeatureId", "SkillSubcategoryId" },
                keyValues: new object[] { new Guid("80e10c56-c46d-45c1-9d65-1930951b4b30"), new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") });

            migrationBuilder.DeleteData(
                table: "SkillSubcategoryFeatureOption",
                keyColumns: new[] { "FeatureId", "SkillSubcategoryId" },
                keyValues: new object[] { new Guid("d74075a6-7d42-4665-ba2e-bac6d085f944"), new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddb34bfe-616a-46a0-af02-b7f29ee25daa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "54fa9a23-e468-47f1-a33f-9fb25e6d5cd8", "AQAAAAIAAYagAAAAEMqhZtMtMPFjCHLIT9JAq1pSsYLdg7JWwZK6lVNSyCuIKmp7ET+RPL2mltMHfSsNhQ==", "903cd784-ed66-4c19-9580-5956533aa07e" });

            migrationBuilder.InsertData(
                table: "DropdownOption",
                columns: new[] { "Id", "IncrementValue", "LowerInterval", "UpperInterval" },
                values: new object[,]
                {
                    { new Guid("c7ecddd3-a329-487f-b483-92af937eee12"), 1, 1, 50 },
                    { new Guid("cea6852e-d2d7-4c7a-a80d-d7e1c063cda2"), 1, 1, 10 }
                });

            migrationBuilder.InsertData(
                table: "Feature",
                columns: new[] { "Id", "DropdownOptionId", "InputType", "Name" },
                values: new object[,]
                {
                    { new Guid("0a050394-f7af-483a-9f94-043bc4d959f0"), null, 2, "Package name" },
                    { new Guid("80e10c56-c46d-45c1-9d65-1930951b4b30"), new Guid("e0046a44-904f-4124-8728-298394557fb6"), 1, "Delivery time" },
                    { new Guid("d74075a6-7d42-4665-ba2e-bac6d085f944"), null, 2, "Package description" }
                });

            migrationBuilder.InsertData(
                table: "Skill",
                columns: new[] { "Id", "Description", "Name", "SkillSubcategoryId" },
                values: new object[,]
                {
                    { new Guid("680a1210-8314-4e99-9c16-cea53da9abb6"), "Focuses on creating websites optimized for dropshipping business models.", "Dropshipping Websites", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("9958e1de-7f6b-4a66-9136-313055d9cb84"), "Skills in designing and building effective landing pages for websites.", "Landing Pages", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("de70b3ab-c9a0-4ee7-921b-ec51a86280af"), "Involves creating online stores and platforms for e-commerce activities.", "E-Commerce Development", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("df278931-02c3-4f08-9460-a7a6275de88c"), "Encompasses skills required to build fully functional and feature-rich websites.", "Build a Complete Website", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("e033ffe3-6225-4436-8c71-c9a76f2ded2c"), "Skills related to designing and developing websites for business purposes.", "Business Websites", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") }
                });

            migrationBuilder.InsertData(
                table: "SkillCategory",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("0617ba4a-c714-4d73-b39c-06ec7d507f8c"), "Skills in music composition, audio production, and sound engineering.", "Music & Audio" },
                    { new Guid("0bcf3b46-3d19-4777-b55a-20bc6d287d91"), "Skills related to data analysis, management, and interpretation.", "Data" },
                    { new Guid("378ac98f-3013-4cc6-91f4-3634eb61c1ba"), "Skills in capturing and editing visual images through photography.", "Photography" },
                    { new Guid("581bbe68-a381-4e9e-86c7-753b411d3b18"), "Encompasses skills related to business strategy, management, and entrepreneurial activities.", "Business" },
                    { new Guid("5b13fbb4-266a-4dc2-a04b-0c857cbdc22f"), "This category encompasses skills related to visual design, graphic arts, and creative visual communication.", "Graphics & Design" },
                    { new Guid("5d83d0e6-61a2-4bac-8e53-a87b7dd7ec0e"), "Skills related to content creation, writing, and translation services.", "Writing & Translation" },
                    { new Guid("b1c1f2a1-4a23-4df2-b3ad-31b09dd3afaf"), "Skills related to online marketing, advertising, and promotion in the digital realm.", "Digital Marketing" },
                    { new Guid("c1f30020-d899-414b-911e-5c79e34d8d0b"), "This category covers skills in video creation, editing, and animation production.", "Video & Animation" },
                    { new Guid("c4e5bf17-31ba-445e-a99c-1f0f5df70b98"), "Skills in programming, software development, and technology solutions fall under this category.", "Programming & Tech" },
                    { new Guid("dc37a78d-80d1-44a8-bd60-318b8f9930da"), "This category involves skills related to artificial intelligence, machine learning, and AI-based services.", "AI Services" }
                });

            migrationBuilder.InsertData(
                table: "SkillSubcategory",
                columns: new[] { "Id", "Description", "Name", "SkillCategoryId" },
                values: new object[,]
                {
                    { new Guid("02b7e395-2098-46f6-a084-6bc2d204205d"), "Involves the creation and implementation of artificial intelligence algorithms and systems.", "AI Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("109d095e-b505-4f3f-aedc-5f11463bc945"), "Encompasses quality assurance, testing, and review processes to ensure software reliability.", "QA & Review", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("1d803498-84bd-4b22-81ac-09e465cbad64"), "Concerned with the ongoing support, updates, and troubleshooting of existing websites.", "Website Maintenance", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("2922c1d2-7c35-4ac4-bdc0-888cd81ac6ff"), "Focuses on creating interactive and engaging video games for various platforms.", "Game Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("55c90252-662d-47fe-a1e9-49b5260d6ca9"), "Involves the development and implementation of conversational agents for automated interactions.", "Chatbots", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("5bc5b83c-0eed-4950-9605-2978d9b8017a"), "Involves providing support services and addressing cybersecurity concerns for software and systems.", "Support & Cybersecurity", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("6b0c3bc3-5821-4001-aa47-9661abe9320a"), "Deals with understanding and utilizing various website development platforms and frameworks.", "Website Platforms", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("82b721c4-59b0-4326-861b-e0ac6b068715"), "Involves creating and maintaining websites, focusing on design, functionality, and user experience.", "Website Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("8f1316ad-1e8d-4faa-a3e1-f27f28a14055"), "Professionals specializing in software development, coding, and programming.", "Software Developers", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("950f1a8c-9dba-439e-a616-9d3f722a4106"), "Includes miscellaneous skills or services related to the broader category of programming and technology.", "Miscellaneous", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("b2f50165-1136-4701-9863-821231aec34f"), "Encompasses the creation and maintenance of software applications for various platforms.", "Software Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("d61ec708-0ab6-4227-a14c-dd08d288eefc"), "Focuses on designing and building applications specifically for mobile devices.", "Mobile App Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") }
                });

            migrationBuilder.InsertData(
                table: "SkillSubcategoryFeatureOption",
                columns: new[] { "FeatureId", "SkillSubcategoryId" },
                values: new object[,]
                {
                    { new Guid("0a6ea85a-da41-4cab-917d-60402a960977"), new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("0f462b41-bb48-42bd-abfa-cb4f72ec1b81"), new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("3837b73a-b536-4ba0-b22f-f03725b5a39d"), new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("3b4c9453-d434-4b82-8d68-e35253006b75"), new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("462b11f3-caea-46f7-8046-855d54eadc26"), new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("673ffae4-103d-4380-a4e0-c17087bf0312"), new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("6d5ef352-bd44-4fb9-8f69-2bc5f7b35110"), new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("885fedc2-0997-47a0-a019-02e8912d60ac"), new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("aabb1612-8c9b-4d29-aac9-529957386d7b"), new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("b9f4986e-33aa-4f2c-bcfe-bdb4f66b6635"), new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("cada2850-5dfe-43bf-8073-8ead5650f98a"), new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("dd2dda79-ea1a-4c0c-8bde-7304f23d1208"), new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("fc434379-0b67-4e39-8cf3-d0383ca62571"), new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("fd5c869d-2533-4316-8ee9-78f2eb8dde23"), new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("fe16d65c-dbbf-42cf-b416-d1da153094eb"), new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") }
                });
        }
    }
}
