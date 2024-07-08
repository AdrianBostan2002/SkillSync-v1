using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkillSync.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class MadeProjectDescriptionNullable : Migration
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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DropdownOption",
                keyColumn: "Id",
                keyValue: new Guid("05d28a08-438a-49ca-94a4-74e00bbc84dc"));

            migrationBuilder.DeleteData(
                table: "DropdownOption",
                keyColumn: "Id",
                keyValue: new Guid("6c2ef4f4-7a7f-4afc-83ea-558d65a2587a"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("04295909-d936-4e58-950d-e60c8d19436b"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("0d498ecf-ab08-4def-8af5-0b0f072603ac"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("1054152b-1271-46fc-bee8-8b40fcc4f0f3"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("191b70be-ef05-49c0-ae5a-a9b4a90d38c5"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("254137e5-6a07-4ed9-9868-d5dda057ba11"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("300e800f-3baf-4fa2-bf29-dfe50f75feab"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("3d805091-1a04-4b1c-9087-91828a3aae72"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("718dd9b5-eac2-4a0a-a284-f2b16a28e71d"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("9dbf8e12-e1a5-4e05-8404-cc28c664c437"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("a2e6daee-6f2d-41c3-8f91-0ed4ca4e0c56"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("a9d11fb6-87d5-4cdc-b8fd-ea1feb182559"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("b82506f7-95b7-48fd-8ba0-ac36cff8a7ad"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("c8a78162-33e7-43f1-be09-d15a09285705"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("db4ef458-7ad5-476e-9559-19472db3de06"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("efae5b8f-bb65-440b-9c64-76ff127fdccb"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("0a2025e7-02d2-43f1-9800-c0e2f6574027"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("19548c94-877f-4bca-aff4-26a85aa24f55"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("3ce40d59-98a8-445a-802d-b21f2feed608"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("9bd19e8d-4a2c-45f2-a276-878d7ba4e6cb"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("dc8e0329-b5dd-44a5-a074-79b17ef1cc5d"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("0045c6fb-8db0-4604-9af8-e57c4f90906f"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("0a9f043f-0a99-425e-86b1-ea129869af41"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("16dedd0c-751a-43f9-8d16-c942d7ca559b"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("4f111742-2665-4a9f-9659-55ef1a869313"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("6ce6ad39-a765-412f-bdb6-ee10fb9e73cb"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("7e088c87-fb36-499d-911c-d14ab1a401b2"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("b249dcd2-ec12-41af-9d35-2bee71491e3d"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("d8df91c7-d1a7-485a-93b4-06d46358427b"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("eea6cec9-0beb-4c1d-b230-3c91d23d0d4e"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("fd70e162-4d6b-4a99-aa4e-0107bc4ee5b0"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("06465aeb-bf4d-4290-ac60-7f4d41fa7b19"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("0988f4d3-0820-4d13-80a5-6acc239a9825"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("199bd0c5-1e00-415a-8aba-2278ad49a9db"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("1eb4b075-b8b9-4703-a75c-6c0a3141b5fa"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("3ca86ac4-2d27-4205-a469-8ae024d4f5e4"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("4a1924fe-957a-4641-94b8-0c47febc0010"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("8a57b460-cc65-42fb-854a-af45aa5059bb"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("8ae735ea-5477-487a-9c20-55037f8cc080"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("a237025d-6bcc-4db8-93f6-7f8c206df751"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("ae46ee3b-45c3-479d-8577-4fd5247774be"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("e62644b4-9274-4a5c-b213-d22f3c9e906c"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("f8226e1b-be1e-448b-a865-04372e44b6c2"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddb34bfe-616a-46a0-af02-b7f29ee25daa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "66052222-c828-4988-ae22-d66b33416295", "AQAAAAIAAYagAAAAEPzzWUazIXd6+sCNU4GzmUdHhwiplMbds5ZRoPtV1Vt03QRthXxhmN1J22/29ukdHQ==", "01f37064-553b-4a18-b408-a0718a4148d5" });

            migrationBuilder.InsertData(
                table: "DropdownOption",
                columns: new[] { "Id", "IncrementValue", "LowerInterval", "UpperInterval" },
                values: new object[,]
                {
                    { new Guid("157bc7ab-3fd0-4376-b80b-d21f1b36e107"), 1, 1, 10 },
                    { new Guid("48d362bb-af1b-48b7-bf2d-f899d0925b04"), 1, 1, 50 }
                });

            migrationBuilder.InsertData(
                table: "Feature",
                columns: new[] { "Id", "DropdownOptionId", "InputType", "Name" },
                values: new object[,]
                {
                    { new Guid("0a60e87f-243b-4210-9558-f46c43ae50fc"), null, 1, "Revisions" },
                    { new Guid("275e6404-6fb3-46c0-9299-69f46412d46f"), null, 0, "Functional website" },
                    { new Guid("316ff586-7019-425b-a5a4-8e67a707bcfa"), new Guid("e0046a44-904f-4124-8728-298394557fb6"), 1, "Number of products" },
                    { new Guid("45d64a17-80e4-473f-a97b-6d95c7491778"), null, 0, "Speed optimization" },
                    { new Guid("5e27ccc6-5154-4c94-a4fa-f71f91ed32b9"), new Guid("8a4b9c88-1f53-4ab9-9052-f8594d732430"), 1, "Plugins/extensions " },
                    { new Guid("786a83ac-0afc-4d7d-94e7-be1b283479d5"), null, 0, "Responsive design" },
                    { new Guid("870b31f3-ffdf-440f-b9c7-156b5ee7c2cc"), null, 0, "Opt-in form" },
                    { new Guid("91cdb105-173a-4a4a-be24-e516272501c9"), new Guid("8a4b9c88-1f53-4ab9-9052-f8594d732430"), 1, "Number of pages" },
                    { new Guid("96d46158-8c19-4a48-86d9-75bc89cbdea4"), null, 0, "E-commerce functionality" },
                    { new Guid("a1a4c9c1-c564-4696-8660-bd8e5fa95da1"), null, 0, "Content upload" },
                    { new Guid("b1f614c1-c834-43c1-9f31-83f630da7296"), null, 2, "Price" },
                    { new Guid("b791a4be-c78e-4482-a2d1-4145bf5279db"), null, 0, "Social media" },
                    { new Guid("ba300c95-6ab7-4b03-b1de-ddd91b2553cc"), null, 0, "Payment processing" },
                    { new Guid("db81f89c-8a10-49cf-a7ec-c9672d1c2e8f"), null, 0, "Hosting setup" },
                    { new Guid("f520bf26-672e-46f7-a34b-4e0a1f0f76f7"), null, 0, "Autoresponder" }
                });

            migrationBuilder.InsertData(
                table: "Skill",
                columns: new[] { "Id", "Description", "Name", "SkillSubcategoryId" },
                values: new object[,]
                {
                    { new Guid("0836c225-4578-4d30-9c6f-ad63c9e9723b"), "Skills related to designing and developing websites for business purposes.", "Business Websites", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("8a2def80-aa98-40f2-8266-1166309ff175"), "Encompasses skills required to build fully functional and feature-rich websites.", "Build a Complete Website", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("db893c6e-8b3d-48dd-ad1d-db9894edadb1"), "Skills in designing and building effective landing pages for websites.", "Landing Pages", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("dfa80f79-aaf4-4190-a530-44fb0477ee60"), "Involves creating online stores and platforms for e-commerce activities.", "E-Commerce Development", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("e7efb255-1646-4d68-b0bf-7a37940e43e2"), "Focuses on creating websites optimized for dropshipping business models.", "Dropshipping Websites", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") }
                });

            migrationBuilder.InsertData(
                table: "SkillCategory",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("26f40422-064f-49bb-8ad9-379b657881cf"), "Skills in capturing and editing visual images through photography.", "Photography" },
                    { new Guid("6986aa3f-7e64-4a58-8c71-55fb2595d7a4"), "Skills related to online marketing, advertising, and promotion in the digital realm.", "Digital Marketing" },
                    { new Guid("71843b63-b34e-4955-9309-9c3cdfdb488b"), "Encompasses skills related to business strategy, management, and entrepreneurial activities.", "Business" },
                    { new Guid("7768585c-b20d-4b3e-9da1-d4227a7edf00"), "Skills in music composition, audio production, and sound engineering.", "Music & Audio" },
                    { new Guid("7995377e-4bd9-4181-a8f3-7c7212094d84"), "Skills related to data analysis, management, and interpretation.", "Data" },
                    { new Guid("b28d02a3-e2a1-427f-8d68-0996f1797df8"), "This category covers skills in video creation, editing, and animation production.", "Video & Animation" },
                    { new Guid("e55adbcf-a537-4409-99c2-4625844e6f97"), "This category encompasses skills related to visual design, graphic arts, and creative visual communication.", "Graphics & Design" },
                    { new Guid("e7435357-6d46-4309-be92-7eedb5a9a7c1"), "Skills related to content creation, writing, and translation services.", "Writing & Translation" },
                    { new Guid("ee85f790-5ad4-4514-9f4c-e9d0baf93dc8"), "This category involves skills related to artificial intelligence, machine learning, and AI-based services.", "AI Services" },
                    { new Guid("f87c421d-b4c2-4221-b208-8620c9ba83fb"), "Skills in programming, software development, and technology solutions fall under this category.", "Programming & Tech" }
                });

            migrationBuilder.InsertData(
                table: "SkillSubcategory",
                columns: new[] { "Id", "Description", "Name", "SkillCategoryId" },
                values: new object[,]
                {
                    { new Guid("0c696d59-732a-404c-91cb-deb174bcde36"), "Encompasses the creation and maintenance of software applications for various platforms.", "Software Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("2ad580c2-5aec-4621-8405-a8d14b424bd4"), "Focuses on creating interactive and engaging video games for various platforms.", "Game Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("3d28ffe9-79a3-4964-8544-8fc8395a57c1"), "Deals with understanding and utilizing various website development platforms and frameworks.", "Website Platforms", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("3fbf0ac5-42c3-469a-b38e-062dbcdb16e6"), "Involves the development and implementation of conversational agents for automated interactions.", "Chatbots", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("43f7cd7a-1065-4421-9328-b9fc2319eb6c"), "Concerned with the ongoing support, updates, and troubleshooting of existing websites.", "Website Maintenance", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("59f97469-82bc-4250-b406-1c791f3a9c35"), "Involves the creation and implementation of artificial intelligence algorithms and systems.", "AI Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("6e3c04c3-a10b-47a5-9618-5e96dd9326d9"), "Involves providing support services and addressing cybersecurity concerns for software and systems.", "Support & Cybersecurity", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("8f93de1a-447e-4f63-9109-32a20a2afe96"), "Involves creating and maintaining websites, focusing on design, functionality, and user experience.", "Website Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("b5ac9156-c934-4bac-86dc-2dfb9d4bca3b"), "Professionals specializing in software development, coding, and programming.", "Software Developers", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("c4069d7a-ebe5-4d8d-8b68-8ad48f0fd20a"), "Focuses on designing and building applications specifically for mobile devices.", "Mobile App Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("cdbd7090-3103-4814-8be3-953a67232d6f"), "Includes miscellaneous skills or services related to the broader category of programming and technology.", "Miscellaneous", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("ce5c1bef-510d-4d94-bde5-60022d3caa91"), "Encompasses quality assurance, testing, and review processes to ensure software reliability.", "QA & Review", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") }
                });
        }
    }
}
