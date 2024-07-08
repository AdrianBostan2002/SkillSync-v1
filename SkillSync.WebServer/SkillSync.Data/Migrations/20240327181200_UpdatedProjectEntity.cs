using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkillSync.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedProjectEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<bool>(
                name: "HasPackages",
                table: "Project",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AddColumn<string>(
                name: "CreatedAt",
                table: "Project",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsPublished",
                table: "Project",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddb34bfe-616a-46a0-af02-b7f29ee25daa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "66052222-c828-4988-ae22-d66b33416295", "AQAAAAIAAYagAAAAEPzzWUazIXd6+sCNU4GzmUdHhwiplMbds5ZRoPtV1Vt03QRthXxhmN1J22/29ukdHQ==", "01f37064-553b-4a18-b408-a0718a4148d5" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DropdownOption",
                keyColumn: "Id",
                keyValue: new Guid("157bc7ab-3fd0-4376-b80b-d21f1b36e107"));

            migrationBuilder.DeleteData(
                table: "DropdownOption",
                keyColumn: "Id",
                keyValue: new Guid("48d362bb-af1b-48b7-bf2d-f899d0925b04"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("0a60e87f-243b-4210-9558-f46c43ae50fc"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("275e6404-6fb3-46c0-9299-69f46412d46f"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("316ff586-7019-425b-a5a4-8e67a707bcfa"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("45d64a17-80e4-473f-a97b-6d95c7491778"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("5e27ccc6-5154-4c94-a4fa-f71f91ed32b9"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("786a83ac-0afc-4d7d-94e7-be1b283479d5"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("870b31f3-ffdf-440f-b9c7-156b5ee7c2cc"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("91cdb105-173a-4a4a-be24-e516272501c9"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("96d46158-8c19-4a48-86d9-75bc89cbdea4"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("a1a4c9c1-c564-4696-8660-bd8e5fa95da1"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("b1f614c1-c834-43c1-9f31-83f630da7296"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("b791a4be-c78e-4482-a2d1-4145bf5279db"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("ba300c95-6ab7-4b03-b1de-ddd91b2553cc"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("db81f89c-8a10-49cf-a7ec-c9672d1c2e8f"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("f520bf26-672e-46f7-a34b-4e0a1f0f76f7"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("0836c225-4578-4d30-9c6f-ad63c9e9723b"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("8a2def80-aa98-40f2-8266-1166309ff175"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("db893c6e-8b3d-48dd-ad1d-db9894edadb1"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("dfa80f79-aaf4-4190-a530-44fb0477ee60"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("e7efb255-1646-4d68-b0bf-7a37940e43e2"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("26f40422-064f-49bb-8ad9-379b657881cf"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("6986aa3f-7e64-4a58-8c71-55fb2595d7a4"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("71843b63-b34e-4955-9309-9c3cdfdb488b"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("7768585c-b20d-4b3e-9da1-d4227a7edf00"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("7995377e-4bd9-4181-a8f3-7c7212094d84"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("b28d02a3-e2a1-427f-8d68-0996f1797df8"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("e55adbcf-a537-4409-99c2-4625844e6f97"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("e7435357-6d46-4309-be92-7eedb5a9a7c1"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("ee85f790-5ad4-4514-9f4c-e9d0baf93dc8"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("f87c421d-b4c2-4221-b208-8620c9ba83fb"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("0c696d59-732a-404c-91cb-deb174bcde36"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("2ad580c2-5aec-4621-8405-a8d14b424bd4"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("3d28ffe9-79a3-4964-8544-8fc8395a57c1"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("3fbf0ac5-42c3-469a-b38e-062dbcdb16e6"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("43f7cd7a-1065-4421-9328-b9fc2319eb6c"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("59f97469-82bc-4250-b406-1c791f3a9c35"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("6e3c04c3-a10b-47a5-9618-5e96dd9326d9"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("8f93de1a-447e-4f63-9109-32a20a2afe96"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("b5ac9156-c934-4bac-86dc-2dfb9d4bca3b"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("c4069d7a-ebe5-4d8d-8b68-8ad48f0fd20a"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("cdbd7090-3103-4814-8be3-953a67232d6f"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("ce5c1bef-510d-4d94-bde5-60022d3caa91"));

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "IsPublished",
                table: "Project");

            migrationBuilder.AlterColumn<bool>(
                name: "HasPackages",
                table: "Project",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddb34bfe-616a-46a0-af02-b7f29ee25daa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "558237b5-71f4-4924-bad5-13f34f9692d7", "AQAAAAIAAYagAAAAECwtdSJQM4hKz724yYnmljEf7Z44HUgHnB8/6yRi+waeysp7uLExBJz6WM/M/eWE7A==", "49f03d94-c2b4-4385-831a-2db3ca016e47" });

            migrationBuilder.InsertData(
                table: "DropdownOption",
                columns: new[] { "Id", "IncrementValue", "LowerInterval", "UpperInterval" },
                values: new object[,]
                {
                    { new Guid("7bc6ffc0-83de-4262-9fd4-b1a1a3b3b0cf"), 1, 1, 50 },
                    { new Guid("da90b4d1-7663-4955-93c3-10f9255444e9"), 1, 1, 10 }
                });

            migrationBuilder.InsertData(
                table: "Feature",
                columns: new[] { "Id", "DropdownOptionId", "InputType", "Name" },
                values: new object[,]
                {
                    { new Guid("0160686a-da8e-492f-b327-39ba5e755b19"), null, 2, "Price" },
                    { new Guid("100548e9-d51b-4486-a253-1516ff927626"), new Guid("e0046a44-904f-4124-8728-298394557fb6"), 1, "Number of products" },
                    { new Guid("18238a5a-a6a9-4434-a149-d557b63989ae"), new Guid("8a4b9c88-1f53-4ab9-9052-f8594d732430"), 1, "Number of pages" },
                    { new Guid("3102b202-cb6a-46fe-b68d-2b5c02fe8ea2"), new Guid("8a4b9c88-1f53-4ab9-9052-f8594d732430"), 1, "Plugins/extensions " },
                    { new Guid("3973d186-6815-4fab-ad76-21e9afacc2b4"), null, 0, "Functional website" },
                    { new Guid("3d3870f9-68e6-4c22-a360-09cf08e70348"), null, 0, "Payment processing" },
                    { new Guid("6a4f000e-f61e-4180-b22e-b34ca6d19f8c"), null, 0, "E-commerce functionality" },
                    { new Guid("744b5596-2e26-493e-aaab-927e96101c00"), null, 0, "Responsive design" },
                    { new Guid("7c06dd2a-3f8c-41f0-80fd-b691fbc0a910"), null, 0, "Social media" },
                    { new Guid("83ae8a7a-bf04-430d-bd77-e73a91f99dfa"), null, 0, "Opt-in form" },
                    { new Guid("90ef0114-a89b-4d18-aae8-70d9f0e12648"), null, 0, "Speed optimization" },
                    { new Guid("a0d58927-77d0-4a53-8ca6-3ed83d4b1c0e"), null, 0, "Hosting setup" },
                    { new Guid("afb5bcc7-1d6f-4872-88a5-fe8dccabba7d"), null, 0, "Autoresponder" },
                    { new Guid("b3afe9a5-9076-47c4-bb37-cee49109ec37"), null, 1, "Revisions" },
                    { new Guid("e7cacbd2-7669-4476-993f-64e98263e219"), null, 0, "Content upload" }
                });

            migrationBuilder.InsertData(
                table: "Skill",
                columns: new[] { "Id", "Description", "Name", "SkillSubcategoryId" },
                values: new object[,]
                {
                    { new Guid("0b022128-7eb4-4499-8013-09294c4ddcf2"), "Encompasses skills required to build fully functional and feature-rich websites.", "Build a Complete Website", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("25e99a95-45da-4465-8981-b5dd19c7386b"), "Skills related to designing and developing websites for business purposes.", "Business Websites", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("5202027f-ef3b-4dfe-a7dd-765fe5ccf5aa"), "Involves creating online stores and platforms for e-commerce activities.", "E-Commerce Development", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("903e0447-c479-49cc-a29f-93cd9ea1aa93"), "Focuses on creating websites optimized for dropshipping business models.", "Dropshipping Websites", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("98db778a-81bc-42c4-b93e-e9d64f995b65"), "Skills in designing and building effective landing pages for websites.", "Landing Pages", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") }
                });

            migrationBuilder.InsertData(
                table: "SkillCategory",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("01f5840b-b6f9-463d-9cf3-8c786172202b"), "Skills in capturing and editing visual images through photography.", "Photography" },
                    { new Guid("3b1c084a-b9bf-4ee5-8539-7074853fb904"), "Encompasses skills related to business strategy, management, and entrepreneurial activities.", "Business" },
                    { new Guid("4920d2dd-e6af-4d11-83ac-becfc87f3681"), "This category covers skills in video creation, editing, and animation production.", "Video & Animation" },
                    { new Guid("5b390391-4f39-4b81-b6fb-e39b34b30fe0"), "Skills related to data analysis, management, and interpretation.", "Data" },
                    { new Guid("5ce620e7-0ecb-473d-b630-f50bd2bcda20"), "This category encompasses skills related to visual design, graphic arts, and creative visual communication.", "Graphics & Design" },
                    { new Guid("640c288a-9a9c-476b-90b5-f73aea91551a"), "Skills related to online marketing, advertising, and promotion in the digital realm.", "Digital Marketing" },
                    { new Guid("70385480-db66-4595-a0e3-28dddd4c1109"), "Skills in music composition, audio production, and sound engineering.", "Music & Audio" },
                    { new Guid("7cb2b40c-3f53-4f7a-95a7-a807acaae9c5"), "Skills related to content creation, writing, and translation services.", "Writing & Translation" },
                    { new Guid("846ffab6-c4f2-4ba9-aa98-fd4ca114441b"), "Skills in programming, software development, and technology solutions fall under this category.", "Programming & Tech" },
                    { new Guid("e8ba438c-6a5b-404b-ac87-74fe2388fa8a"), "This category involves skills related to artificial intelligence, machine learning, and AI-based services.", "AI Services" }
                });

            migrationBuilder.InsertData(
                table: "SkillSubcategory",
                columns: new[] { "Id", "Description", "Name", "SkillCategoryId" },
                values: new object[,]
                {
                    { new Guid("35c207cc-c220-4f82-9dc8-9fc0ccf8219f"), "Involves the development and implementation of conversational agents for automated interactions.", "Chatbots", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("4e0af15c-2956-4b26-ad86-3162f714cf62"), "Concerned with the ongoing support, updates, and troubleshooting of existing websites.", "Website Maintenance", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("66efb135-8768-4cba-b1d4-3994e0f098c2"), "Deals with understanding and utilizing various website development platforms and frameworks.", "Website Platforms", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("7301d5e5-92b4-4385-ad4c-4ed31e163e54"), "Involves the creation and implementation of artificial intelligence algorithms and systems.", "AI Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("78f094bd-2351-4388-9be5-5a2f278cdc8f"), "Focuses on designing and building applications specifically for mobile devices.", "Mobile App Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("7f4ed4b1-53e9-43b6-b5b3-1ee1cd7ced2e"), "Includes miscellaneous skills or services related to the broader category of programming and technology.", "Miscellaneous", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("80546c21-1f14-489f-8f29-133f6a5dd437"), "Professionals specializing in software development, coding, and programming.", "Software Developers", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("842aa415-5623-491a-a73f-6e6de2508d4c"), "Encompasses the creation and maintenance of software applications for various platforms.", "Software Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("c5ad0b41-d270-4f21-b221-14134efc260a"), "Involves creating and maintaining websites, focusing on design, functionality, and user experience.", "Website Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("d2a9fc50-883a-4f75-81bc-32ddd5e31a07"), "Encompasses quality assurance, testing, and review processes to ensure software reliability.", "QA & Review", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("dca2aabf-c516-4d24-86d4-5f3847b3d9aa"), "Focuses on creating interactive and engaging video games for various platforms.", "Game Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("e7a96c5e-60be-45bf-b490-263cc3005744"), "Involves providing support services and addressing cybersecurity concerns for software and systems.", "Support & Cybersecurity", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") }
                });
        }
    }
}
