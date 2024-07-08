using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkillSync.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedMoreFeatureSeeds : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddb34bfe-616a-46a0-af02-b7f29ee25daa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "54fa9a23-e468-47f1-a33f-9fb25e6d5cd8", "AQAAAAIAAYagAAAAEMqhZtMtMPFjCHLIT9JAq1pSsYLdg7JWwZK6lVNSyCuIKmp7ET+RPL2mltMHfSsNhQ==", "903cd784-ed66-4c19-9580-5956533aa07e" });

            migrationBuilder.InsertData(
                table: "Feature",
                columns: new[] { "Id", "DropdownOptionId", "InputType", "Name" },
                values: new object[,]
                {
                    { new Guid("0a050394-f7af-483a-9f94-043bc4d959f0"), null, 2, "Package name" },
                    { new Guid("80e10c56-c46d-45c1-9d65-1930951b4b30"), new Guid("e0046a44-904f-4124-8728-298394557fb6"), 1, "Delivery time" },
                    { new Guid("d74075a6-7d42-4665-ba2e-bac6d085f944"), null, 2, "Package description" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DropdownOption",
                keyColumn: "Id",
                keyValue: new Guid("c7ecddd3-a329-487f-b483-92af937eee12"));

            migrationBuilder.DeleteData(
                table: "DropdownOption",
                keyColumn: "Id",
                keyValue: new Guid("cea6852e-d2d7-4c7a-a80d-d7e1c063cda2"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("0a050394-f7af-483a-9f94-043bc4d959f0"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("80e10c56-c46d-45c1-9d65-1930951b4b30"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("d74075a6-7d42-4665-ba2e-bac6d085f944"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("680a1210-8314-4e99-9c16-cea53da9abb6"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("9958e1de-7f6b-4a66-9136-313055d9cb84"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("de70b3ab-c9a0-4ee7-921b-ec51a86280af"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("df278931-02c3-4f08-9460-a7a6275de88c"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("e033ffe3-6225-4436-8c71-c9a76f2ded2c"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("0617ba4a-c714-4d73-b39c-06ec7d507f8c"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("0bcf3b46-3d19-4777-b55a-20bc6d287d91"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("378ac98f-3013-4cc6-91f4-3634eb61c1ba"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("581bbe68-a381-4e9e-86c7-753b411d3b18"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("5b13fbb4-266a-4dc2-a04b-0c857cbdc22f"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("5d83d0e6-61a2-4bac-8e53-a87b7dd7ec0e"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("b1c1f2a1-4a23-4df2-b3ad-31b09dd3afaf"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("c1f30020-d899-414b-911e-5c79e34d8d0b"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("c4e5bf17-31ba-445e-a99c-1f0f5df70b98"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("dc37a78d-80d1-44a8-bd60-318b8f9930da"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("02b7e395-2098-46f6-a084-6bc2d204205d"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("109d095e-b505-4f3f-aedc-5f11463bc945"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("1d803498-84bd-4b22-81ac-09e465cbad64"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("2922c1d2-7c35-4ac4-bdc0-888cd81ac6ff"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("55c90252-662d-47fe-a1e9-49b5260d6ca9"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("5bc5b83c-0eed-4950-9605-2978d9b8017a"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("6b0c3bc3-5821-4001-aa47-9661abe9320a"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("82b721c4-59b0-4326-861b-e0ac6b068715"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("8f1316ad-1e8d-4faa-a3e1-f27f28a14055"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("950f1a8c-9dba-439e-a616-9d3f722a4106"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("b2f50165-1136-4701-9863-821231aec34f"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("d61ec708-0ab6-4227-a14c-dd08d288eefc"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddb34bfe-616a-46a0-af02-b7f29ee25daa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9cf28dba-27e6-498b-83c0-2ed859b6dbac", "AQAAAAIAAYagAAAAENsG6aPbpZEp5Sxr7kuv77DoOR7u55CQz2ja98Voli3FJamwcx2tfa+1335V5bjqCA==", "58bd80dc-53ca-41d8-a24c-d8e750577bec" });

            migrationBuilder.InsertData(
                table: "DropdownOption",
                columns: new[] { "Id", "IncrementValue", "LowerInterval", "UpperInterval" },
                values: new object[,]
                {
                    { new Guid("5cdca73d-ec5d-4e15-a81b-b4827ed2e40d"), 1, 1, 10 },
                    { new Guid("93fd8f6a-840f-45d5-b299-d5ff7a90a208"), 1, 1, 50 }
                });

            migrationBuilder.InsertData(
                table: "Feature",
                columns: new[] { "Id", "DropdownOptionId", "InputType", "Name" },
                values: new object[,]
                {
                    { new Guid("098e9f07-32fa-4e63-a9d1-4b38d2404d95"), null, 0, "Opt-in form" },
                    { new Guid("12abe958-081e-4586-817f-386a7176d083"), null, 0, "Functional website" },
                    { new Guid("318fb6c0-2a65-44da-bc8e-7af43497acf1"), null, 2, "Price" },
                    { new Guid("5511456b-50c9-4420-a578-003e735a66c6"), null, 1, "Revisions" },
                    { new Guid("5dda7d64-42f3-4e3a-8964-31479305fa67"), null, 0, "E-commerce functionality" },
                    { new Guid("68f445ec-3b99-4d1c-9223-53d1f5cd63f8"), null, 0, "Payment processing" },
                    { new Guid("7a978af5-165a-4a32-b9da-4870433135c1"), null, 0, "Autoresponder" },
                    { new Guid("881898f4-6344-4fa6-af98-4e0d238bcded"), null, 0, "Social media" },
                    { new Guid("886599eb-a3af-4f90-8b40-0c37e052d972"), null, 0, "Content upload" },
                    { new Guid("90e75f96-e354-42a9-8cb3-b1323d5a778e"), new Guid("e0046a44-904f-4124-8728-298394557fb6"), 1, "Number of products" },
                    { new Guid("b835276f-782e-49db-8cac-e63c1234a579"), null, 0, "Hosting setup" },
                    { new Guid("c192750f-9da2-4486-9860-d62b80c18b58"), null, 0, "Speed optimization" },
                    { new Guid("c48120dc-09c8-4c18-90ff-04c2b86df04e"), null, 0, "Responsive design" },
                    { new Guid("ce87d483-47a9-4980-93d5-cd964efa2fd9"), new Guid("8a4b9c88-1f53-4ab9-9052-f8594d732430"), 1, "Number of pages" },
                    { new Guid("ebec80b6-7b5d-45f3-94d0-2ac40a148cbf"), new Guid("8a4b9c88-1f53-4ab9-9052-f8594d732430"), 1, "Plugins/extensions " }
                });

            migrationBuilder.InsertData(
                table: "Skill",
                columns: new[] { "Id", "Description", "Name", "SkillSubcategoryId" },
                values: new object[,]
                {
                    { new Guid("2c6c9d49-9936-4e70-8abe-113a13b39b2c"), "Skills related to designing and developing websites for business purposes.", "Business Websites", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("48f5067b-f786-4f94-91e7-ba8c106d6b93"), "Skills in designing and building effective landing pages for websites.", "Landing Pages", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("b30938ae-a1fa-4c48-9e47-3fc98fcd8d3a"), "Encompasses skills required to build fully functional and feature-rich websites.", "Build a Complete Website", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("baf21a01-861e-4207-9fda-58afd7824f8b"), "Focuses on creating websites optimized for dropshipping business models.", "Dropshipping Websites", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("cb5f36c3-46ed-41f0-aa57-1f63fa7e24d7"), "Involves creating online stores and platforms for e-commerce activities.", "E-Commerce Development", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") }
                });

            migrationBuilder.InsertData(
                table: "SkillCategory",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("149c11a8-9381-4c8c-8980-6979239b4855"), "Skills related to data analysis, management, and interpretation.", "Data" },
                    { new Guid("19f70424-90d9-4a72-b3fe-d2693797d41b"), "Skills in programming, software development, and technology solutions fall under this category.", "Programming & Tech" },
                    { new Guid("24af2846-fbbb-475a-82f9-0cdc6277532e"), "Encompasses skills related to business strategy, management, and entrepreneurial activities.", "Business" },
                    { new Guid("30ab3ac4-95ca-441a-8739-6efecdeb8b11"), "Skills in music composition, audio production, and sound engineering.", "Music & Audio" },
                    { new Guid("5b26ab09-ffda-4f70-a193-ff9f03def0a5"), "This category involves skills related to artificial intelligence, machine learning, and AI-based services.", "AI Services" },
                    { new Guid("7ebf5136-e772-4515-8ef6-37397d18b977"), "Skills related to online marketing, advertising, and promotion in the digital realm.", "Digital Marketing" },
                    { new Guid("8b932b99-4be9-4648-8493-f4e4c439e95d"), "Skills in capturing and editing visual images through photography.", "Photography" },
                    { new Guid("a625e362-7b58-4ca6-b340-4c3685f5d3b3"), "This category encompasses skills related to visual design, graphic arts, and creative visual communication.", "Graphics & Design" },
                    { new Guid("ae0d2920-cc83-4a80-9944-f6822c29e37b"), "Skills related to content creation, writing, and translation services.", "Writing & Translation" },
                    { new Guid("cd775c8c-55f8-42b9-8453-882d56df04ed"), "This category covers skills in video creation, editing, and animation production.", "Video & Animation" }
                });

            migrationBuilder.InsertData(
                table: "SkillSubcategory",
                columns: new[] { "Id", "Description", "Name", "SkillCategoryId" },
                values: new object[,]
                {
                    { new Guid("14d6f5ed-3711-4901-9934-f8456372bc81"), "Involves creating and maintaining websites, focusing on design, functionality, and user experience.", "Website Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("19b5239b-0612-4b55-9053-f95fede6880d"), "Concerned with the ongoing support, updates, and troubleshooting of existing websites.", "Website Maintenance", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("296a6b8c-a20d-4257-9c8a-ffbe168c6d5f"), "Encompasses the creation and maintenance of software applications for various platforms.", "Software Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("4de6577c-4b18-4bc3-ad9c-02cabfc8a007"), "Encompasses quality assurance, testing, and review processes to ensure software reliability.", "QA & Review", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("4e9d4444-8674-4dd8-b27e-9112b4c8750b"), "Involves the creation and implementation of artificial intelligence algorithms and systems.", "AI Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("65382145-512d-4260-bc3f-73e9fff6403b"), "Focuses on designing and building applications specifically for mobile devices.", "Mobile App Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("88a9c441-0c51-4e4b-96a4-4f4ca4009119"), "Involves providing support services and addressing cybersecurity concerns for software and systems.", "Support & Cybersecurity", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("8c07961f-96e3-407e-922f-0bb3c3f14aeb"), "Includes miscellaneous skills or services related to the broader category of programming and technology.", "Miscellaneous", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("8f7c00af-0185-4ed2-861f-10d38c839eba"), "Deals with understanding and utilizing various website development platforms and frameworks.", "Website Platforms", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("963cdfeb-9701-49e8-88c1-24997151687a"), "Involves the development and implementation of conversational agents for automated interactions.", "Chatbots", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("d682f247-77cb-4033-860b-938840114d95"), "Focuses on creating interactive and engaging video games for various platforms.", "Game Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("d8e2046d-50f8-4bbf-9265-b7f00c0ba8b9"), "Professionals specializing in software development, coding, and programming.", "Software Developers", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") }
                });
        }
    }
}
