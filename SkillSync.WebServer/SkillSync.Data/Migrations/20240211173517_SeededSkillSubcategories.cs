using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkillSync.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeededSkillSubcategories : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SkillSubcategory",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddb34bfe-616a-46a0-af02-b7f29ee25daa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "be6eb09b-88aa-4068-9ba3-0baf6ec09566", "AQAAAAIAAYagAAAAEPFqDI5MHDg9xQFut9HmhWx3/L9NcGSm7NrMsUp4XBZuACpMYSvoQ5miSDReSLTXcw==", "cee75b3e-197a-45fd-b362-92388b0c2037" });

            migrationBuilder.InsertData(
                table: "SkillSubcategory",
                columns: new[] { "Id", "Description", "Name", "SkillCategoryId" },
                values: new object[,]
                {
                    { new Guid("0f61f61d-f55c-4dbf-9490-092e2f1d9c77"), "Includes miscellaneous skills or services related to the broader category of programming and technology.", "Miscellaneous", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("241bbcfd-c981-4a19-803b-1753ce92643b"), "Involves creating and maintaining websites, focusing on design, functionality, and user experience.", "Website Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("30a6b7a6-cc7f-4224-9b78-08c238d25271"), "Encompasses the creation and maintenance of software applications for various platforms.", "Software Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("43d0dc1e-3da6-4407-b984-d6bc91873fdf"), "Concerned with the ongoing support, updates, and troubleshooting of existing websites.", "Website Maintenance", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("4cf2f802-220b-46cc-8032-e3e1ebd4a312"), "Focuses on designing and building applications specifically for mobile devices.", "Mobile App Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("526672e5-87f2-400a-90fe-1b2251a77943"), "Involves the creation and implementation of artificial intelligence algorithms and systems.", "AI Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("914a86c0-ee84-4a3a-9313-e48d61f0e38e"), "Encompasses quality assurance, testing, and review processes to ensure software reliability.", "QA & Review", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("9447d817-d8e3-455b-9303-8ae66a15d6bc"), "Involves providing support services and addressing cybersecurity concerns for software and systems.", "Support & Cybersecurity", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("c95e06b8-9c52-4de6-b2e6-4a0f7d62908a"), "Deals with understanding and utilizing various website development platforms and frameworks.", "Website Platforms", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("d79dd736-6a61-4ecc-bc45-61dddd67cf88"), "Focuses on creating interactive and engaging video games for various platforms.", "Game Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("dffdcafd-339a-4491-8c60-ce0d6e4a2c00"), "Professionals specializing in software development, coding, and programming.", "Software Developers", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("fb996aff-82f7-4b6c-a673-4befddfcf693"), "Involves the development and implementation of conversational agents for automated interactions.", "Chatbots", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("3bf4951a-0e58-47e4-885d-dbad810cfe74"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("3ce4f130-bba1-42a5-b55d-b0baf65b8545"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("3d4b2688-afb3-422a-9a77-1eb0ddfb6410"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("631e07ff-9e93-466f-9084-14eec15b15c8"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("7fbf95cf-901d-4727-84f0-f21b6d905443"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("aa57fb85-022f-4514-a0e0-6672ea1b34a0"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("af41e868-8145-4f49-9bbf-35c35d20a987"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("b73398e1-c8af-4d1f-b3e8-e98bffc1b600"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("cca1b44e-6ffe-4fc4-aa6b-a77240db0867"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("e0eb8887-6eef-49a8-9a27-4d7ba1d47152"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("0f61f61d-f55c-4dbf-9490-092e2f1d9c77"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("241bbcfd-c981-4a19-803b-1753ce92643b"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("30a6b7a6-cc7f-4224-9b78-08c238d25271"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("43d0dc1e-3da6-4407-b984-d6bc91873fdf"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("4cf2f802-220b-46cc-8032-e3e1ebd4a312"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("526672e5-87f2-400a-90fe-1b2251a77943"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("914a86c0-ee84-4a3a-9313-e48d61f0e38e"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("9447d817-d8e3-455b-9303-8ae66a15d6bc"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("c95e06b8-9c52-4de6-b2e6-4a0f7d62908a"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("d79dd736-6a61-4ecc-bc45-61dddd67cf88"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("dffdcafd-339a-4491-8c60-ce0d6e4a2c00"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("fb996aff-82f7-4b6c-a673-4befddfcf693"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "SkillSubcategory",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddb34bfe-616a-46a0-af02-b7f29ee25daa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "902bfeb2-99e9-48d8-a298-5a6dfa638206", "AQAAAAIAAYagAAAAEEQixcLMvHBuSwfQIxKwAKgybl1++Vth6T7stm+kaul7+G8dRJn3fPJ4SSjej70v9g==", "0e3ffb57-6bb1-447f-a350-3060fb03af1b" });

            migrationBuilder.InsertData(
                table: "SkillCategory",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("0a9f31ea-1985-46fc-9c34-68ab4ade5ff7"), "Skills in music composition, audio production, and sound engineering.", "Music & Audio" },
                    { new Guid("21e49046-de06-4509-b9c7-4b34576dee9b"), "Encompasses skills related to business strategy, management, and entrepreneurial activities.", "Business" },
                    { new Guid("2412f077-04e5-479b-94e5-b12a3e3f1ae7"), "This category involves skills related to artificial intelligence, machine learning, and AI-based services.", "AI Services" },
                    { new Guid("5ad19a71-d5c1-476b-b744-bfabf3b77403"), "This category encompasses skills related to visual design, graphic arts, and creative visual communication.", "Graphics & Design" },
                    { new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e"), "Skills in programming, software development, and technology solutions fall under this category.", "Programming & Tech" },
                    { new Guid("a5e75c57-60c9-4ab1-971a-5d0ccc1eff28"), "Skills related to online marketing, advertising, and promotion in the digital realm.", "Digital Marketing" },
                    { new Guid("c8f08c2f-6a9f-41eb-a133-f1b564dfb2ef"), "Skills related to data analysis, management, and interpretation.", "Data" },
                    { new Guid("ce3377b5-efe6-4bd1-bcd8-22b026058096"), "This category covers skills in video creation, editing, and animation production.", "Video & Animation" },
                    { new Guid("f17e34d1-ae99-4bb0-89c9-755cb4560980"), "Skills related to content creation, writing, and translation services.", "Writing & Translation" },
                    { new Guid("fa2b0f07-c807-426a-a523-8f46becb0717"), "Skills in capturing and editing visual images through photography.", "Photography" }
                });
        }
    }
}
