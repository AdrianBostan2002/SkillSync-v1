using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkillSync.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class MadeProjectDescriptionNullablex2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Project",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddb34bfe-616a-46a0-af02-b7f29ee25daa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9cf28dba-27e6-498b-83c0-2ed859b6dbac", "AQAAAAIAAYagAAAAENsG6aPbpZEp5Sxr7kuv77DoOR7u55CQz2ja98Voli3FJamwcx2tfa+1335V5bjqCA==", "58bd80dc-53ca-41d8-a24c-d8e750577bec" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DropdownOption",
                keyColumn: "Id",
                keyValue: new Guid("5cdca73d-ec5d-4e15-a81b-b4827ed2e40d"));

            migrationBuilder.DeleteData(
                table: "DropdownOption",
                keyColumn: "Id",
                keyValue: new Guid("93fd8f6a-840f-45d5-b299-d5ff7a90a208"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("098e9f07-32fa-4e63-a9d1-4b38d2404d95"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("12abe958-081e-4586-817f-386a7176d083"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("318fb6c0-2a65-44da-bc8e-7af43497acf1"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("5511456b-50c9-4420-a578-003e735a66c6"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("5dda7d64-42f3-4e3a-8964-31479305fa67"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("68f445ec-3b99-4d1c-9223-53d1f5cd63f8"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("7a978af5-165a-4a32-b9da-4870433135c1"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("881898f4-6344-4fa6-af98-4e0d238bcded"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("886599eb-a3af-4f90-8b40-0c37e052d972"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("90e75f96-e354-42a9-8cb3-b1323d5a778e"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("b835276f-782e-49db-8cac-e63c1234a579"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("c192750f-9da2-4486-9860-d62b80c18b58"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("c48120dc-09c8-4c18-90ff-04c2b86df04e"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("ce87d483-47a9-4980-93d5-cd964efa2fd9"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("ebec80b6-7b5d-45f3-94d0-2ac40a148cbf"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("2c6c9d49-9936-4e70-8abe-113a13b39b2c"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("48f5067b-f786-4f94-91e7-ba8c106d6b93"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("b30938ae-a1fa-4c48-9e47-3fc98fcd8d3a"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("baf21a01-861e-4207-9fda-58afd7824f8b"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("cb5f36c3-46ed-41f0-aa57-1f63fa7e24d7"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("149c11a8-9381-4c8c-8980-6979239b4855"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("19f70424-90d9-4a72-b3fe-d2693797d41b"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("24af2846-fbbb-475a-82f9-0cdc6277532e"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("30ab3ac4-95ca-441a-8739-6efecdeb8b11"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("5b26ab09-ffda-4f70-a193-ff9f03def0a5"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("7ebf5136-e772-4515-8ef6-37397d18b977"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("8b932b99-4be9-4648-8493-f4e4c439e95d"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("a625e362-7b58-4ca6-b340-4c3685f5d3b3"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("ae0d2920-cc83-4a80-9944-f6822c29e37b"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("cd775c8c-55f8-42b9-8453-882d56df04ed"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("14d6f5ed-3711-4901-9934-f8456372bc81"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("19b5239b-0612-4b55-9053-f95fede6880d"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("296a6b8c-a20d-4257-9c8a-ffbe168c6d5f"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("4de6577c-4b18-4bc3-ad9c-02cabfc8a007"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("4e9d4444-8674-4dd8-b27e-9112b4c8750b"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("65382145-512d-4260-bc3f-73e9fff6403b"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("88a9c441-0c51-4e4b-96a4-4f4ca4009119"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("8c07961f-96e3-407e-922f-0bb3c3f14aeb"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("8f7c00af-0185-4ed2-861f-10d38c839eba"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("963cdfeb-9701-49e8-88c1-24997151687a"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("d682f247-77cb-4033-860b-938840114d95"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("d8e2046d-50f8-4bbf-9265-b7f00c0ba8b9"));

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Project",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddb34bfe-616a-46a0-af02-b7f29ee25daa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "92859966-bc1e-4eae-aff8-ee9b88dd00e8", "AQAAAAIAAYagAAAAEAJByIOXmSunCH14DgJ0vnkjmyW4O2rItjcIF91RNQ17kz8OhN932xc3hF912pIrrg==", "10fa21de-5060-4b1d-9c60-47f36e31e594" });

            migrationBuilder.InsertData(
                table: "DropdownOption",
                columns: new[] { "Id", "IncrementValue", "LowerInterval", "UpperInterval" },
                values: new object[,]
                {
                    { new Guid("05d28a08-438a-49ca-94a4-74e00bbc84dc"), 1, 1, 50 },
                    { new Guid("6c2ef4f4-7a7f-4afc-83ea-558d65a2587a"), 1, 1, 10 }
                });

            migrationBuilder.InsertData(
                table: "Feature",
                columns: new[] { "Id", "DropdownOptionId", "InputType", "Name" },
                values: new object[,]
                {
                    { new Guid("04295909-d936-4e58-950d-e60c8d19436b"), new Guid("8a4b9c88-1f53-4ab9-9052-f8594d732430"), 1, "Plugins/extensions " },
                    { new Guid("0d498ecf-ab08-4def-8af5-0b0f072603ac"), null, 2, "Price" },
                    { new Guid("1054152b-1271-46fc-bee8-8b40fcc4f0f3"), null, 0, "Speed optimization" },
                    { new Guid("191b70be-ef05-49c0-ae5a-a9b4a90d38c5"), null, 0, "Functional website" },
                    { new Guid("254137e5-6a07-4ed9-9868-d5dda057ba11"), new Guid("e0046a44-904f-4124-8728-298394557fb6"), 1, "Number of products" },
                    { new Guid("300e800f-3baf-4fa2-bf29-dfe50f75feab"), null, 0, "Responsive design" },
                    { new Guid("3d805091-1a04-4b1c-9087-91828a3aae72"), null, 0, "Autoresponder" },
                    { new Guid("718dd9b5-eac2-4a0a-a284-f2b16a28e71d"), new Guid("8a4b9c88-1f53-4ab9-9052-f8594d732430"), 1, "Number of pages" },
                    { new Guid("9dbf8e12-e1a5-4e05-8404-cc28c664c437"), null, 0, "Social media" },
                    { new Guid("a2e6daee-6f2d-41c3-8f91-0ed4ca4e0c56"), null, 0, "Payment processing" },
                    { new Guid("a9d11fb6-87d5-4cdc-b8fd-ea1feb182559"), null, 1, "Revisions" },
                    { new Guid("b82506f7-95b7-48fd-8ba0-ac36cff8a7ad"), null, 0, "Opt-in form" },
                    { new Guid("c8a78162-33e7-43f1-be09-d15a09285705"), null, 0, "E-commerce functionality" },
                    { new Guid("db4ef458-7ad5-476e-9559-19472db3de06"), null, 0, "Hosting setup" },
                    { new Guid("efae5b8f-bb65-440b-9c64-76ff127fdccb"), null, 0, "Content upload" }
                });

            migrationBuilder.InsertData(
                table: "Skill",
                columns: new[] { "Id", "Description", "Name", "SkillSubcategoryId" },
                values: new object[,]
                {
                    { new Guid("0a2025e7-02d2-43f1-9800-c0e2f6574027"), "Focuses on creating websites optimized for dropshipping business models.", "Dropshipping Websites", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("19548c94-877f-4bca-aff4-26a85aa24f55"), "Skills related to designing and developing websites for business purposes.", "Business Websites", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("3ce40d59-98a8-445a-802d-b21f2feed608"), "Encompasses skills required to build fully functional and feature-rich websites.", "Build a Complete Website", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("9bd19e8d-4a2c-45f2-a276-878d7ba4e6cb"), "Skills in designing and building effective landing pages for websites.", "Landing Pages", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("dc8e0329-b5dd-44a5-a074-79b17ef1cc5d"), "Involves creating online stores and platforms for e-commerce activities.", "E-Commerce Development", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") }
                });

            migrationBuilder.InsertData(
                table: "SkillCategory",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("0045c6fb-8db0-4604-9af8-e57c4f90906f"), "Skills related to online marketing, advertising, and promotion in the digital realm.", "Digital Marketing" },
                    { new Guid("0a9f043f-0a99-425e-86b1-ea129869af41"), "Skills related to content creation, writing, and translation services.", "Writing & Translation" },
                    { new Guid("16dedd0c-751a-43f9-8d16-c942d7ca559b"), "This category covers skills in video creation, editing, and animation production.", "Video & Animation" },
                    { new Guid("4f111742-2665-4a9f-9659-55ef1a869313"), "Skills related to data analysis, management, and interpretation.", "Data" },
                    { new Guid("6ce6ad39-a765-412f-bdb6-ee10fb9e73cb"), "This category involves skills related to artificial intelligence, machine learning, and AI-based services.", "AI Services" },
                    { new Guid("7e088c87-fb36-499d-911c-d14ab1a401b2"), "Skills in programming, software development, and technology solutions fall under this category.", "Programming & Tech" },
                    { new Guid("b249dcd2-ec12-41af-9d35-2bee71491e3d"), "Skills in capturing and editing visual images through photography.", "Photography" },
                    { new Guid("d8df91c7-d1a7-485a-93b4-06d46358427b"), "Encompasses skills related to business strategy, management, and entrepreneurial activities.", "Business" },
                    { new Guid("eea6cec9-0beb-4c1d-b230-3c91d23d0d4e"), "This category encompasses skills related to visual design, graphic arts, and creative visual communication.", "Graphics & Design" },
                    { new Guid("fd70e162-4d6b-4a99-aa4e-0107bc4ee5b0"), "Skills in music composition, audio production, and sound engineering.", "Music & Audio" }
                });

            migrationBuilder.InsertData(
                table: "SkillSubcategory",
                columns: new[] { "Id", "Description", "Name", "SkillCategoryId" },
                values: new object[,]
                {
                    { new Guid("06465aeb-bf4d-4290-ac60-7f4d41fa7b19"), "Involves providing support services and addressing cybersecurity concerns for software and systems.", "Support & Cybersecurity", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("0988f4d3-0820-4d13-80a5-6acc239a9825"), "Focuses on designing and building applications specifically for mobile devices.", "Mobile App Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("199bd0c5-1e00-415a-8aba-2278ad49a9db"), "Concerned with the ongoing support, updates, and troubleshooting of existing websites.", "Website Maintenance", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("1eb4b075-b8b9-4703-a75c-6c0a3141b5fa"), "Encompasses the creation and maintenance of software applications for various platforms.", "Software Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("3ca86ac4-2d27-4205-a469-8ae024d4f5e4"), "Includes miscellaneous skills or services related to the broader category of programming and technology.", "Miscellaneous", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("4a1924fe-957a-4641-94b8-0c47febc0010"), "Involves the creation and implementation of artificial intelligence algorithms and systems.", "AI Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("8a57b460-cc65-42fb-854a-af45aa5059bb"), "Involves the development and implementation of conversational agents for automated interactions.", "Chatbots", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("8ae735ea-5477-487a-9c20-55037f8cc080"), "Involves creating and maintaining websites, focusing on design, functionality, and user experience.", "Website Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("a237025d-6bcc-4db8-93f6-7f8c206df751"), "Deals with understanding and utilizing various website development platforms and frameworks.", "Website Platforms", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("ae46ee3b-45c3-479d-8577-4fd5247774be"), "Focuses on creating interactive and engaging video games for various platforms.", "Game Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("e62644b4-9274-4a5c-b213-d22f3c9e906c"), "Professionals specializing in software development, coding, and programming.", "Software Developers", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("f8226e1b-be1e-448b-a865-04372e44b6c2"), "Encompasses quality assurance, testing, and review processes to ensure software reliability.", "QA & Review", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") }
                });
        }
    }
}
