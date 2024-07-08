using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkillSync.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeededSkills : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Skill",
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
                values: new object[] { "788363c7-6927-42ca-9985-c0c52797f48d", "AQAAAAIAAYagAAAAEI3Rdg6jke6pv6IBxcmQfdWP/3vemZjPRDF/Q2+ERyelisJUzArJK8aWCeS/n7qfGg==", "b86f30b8-3938-4a73-8598-f4c77ca40540" });

            migrationBuilder.InsertData(
                table: "Skill",
                columns: new[] { "Id", "Description", "Name", "SkillSubcategoryId" },
                values: new object[,]
                {
                    { new Guid("4c6e20ea-36cb-4562-938a-ec154f72962e"), "Encompasses skills required to build fully functional and feature-rich websites.", "Build a Complete Website", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("51731ffa-f8d4-4959-b9f3-109f9d9de6be"), "Skills related to designing and developing websites for business purposes.", "Business Websites", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("76129785-91f1-4ab5-b2e4-983d01e74fba"), "Involves creating online stores and platforms for e-commerce activities.", "E-Commerce Development", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("8f8f2d8e-8554-4d48-a1b4-518ddb494fae"), "Focuses on creating websites optimized for dropshipping business models.", "Dropshipping Websites", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("c0eabaee-44ef-4456-aede-08775c74dbde"), "Skills in designing and building effective landing pages for websites.", "Landing Pages", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("4c6e20ea-36cb-4562-938a-ec154f72962e"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("51731ffa-f8d4-4959-b9f3-109f9d9de6be"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("76129785-91f1-4ab5-b2e4-983d01e74fba"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("8f8f2d8e-8554-4d48-a1b4-518ddb494fae"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("c0eabaee-44ef-4456-aede-08775c74dbde"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("05e32d9c-da27-454e-8cec-a6fc19337a0f"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("15dd8634-e83c-40a1-a010-a22c37742279"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("577135f8-baee-4aae-b383-559f22d765d6"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("6a32a035-a9fd-48ba-950d-54d1fc5766a4"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("77c605c7-fe8c-4e08-8924-62b8d75d7e2e"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("879021d5-d241-4b98-b287-610daff4a922"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("941f4362-b90b-4fb0-95dc-bb5c479075c0"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("98ec0423-ee89-4080-a235-7e584b36d515"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("9bef0605-b311-4e80-b6e4-ad01f5ae967d"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("ea065843-56d6-4fe5-9b20-cb0ec07d94be"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("00077880-2b41-4bb3-918a-a4b7ee51d5d0"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("38243d46-ad9a-4b64-a136-34891399ab1e"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("4091911a-5bac-469a-8cf6-ed7d41704449"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("433b318d-0d0a-46ff-8456-0e5e94ee06d1"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("663d78dc-e632-4f1c-ba6d-ad3bd752b0dd"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("66d07342-5750-413d-9563-9a4350d3f175"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("6b0a960c-fcf9-4d1f-b3c1-eb28b24e4bcb"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("867f32ee-8ecd-4248-a995-d8a60117fb1a"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("af6ac843-1139-4dcc-bcb0-56be93f4127b"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("c43436d7-a1cf-45b7-a4b7-31962a4842d6"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("cf187e2b-f62b-4f06-9869-5168e01b4497"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("d9929376-0e97-4a3d-9a6d-eb10a5bae1bd"));

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Skill",
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
                values: new object[] { "be6eb09b-88aa-4068-9ba3-0baf6ec09566", "AQAAAAIAAYagAAAAEPFqDI5MHDg9xQFut9HmhWx3/L9NcGSm7NrMsUp4XBZuACpMYSvoQ5miSDReSLTXcw==", "cee75b3e-197a-45fd-b362-92388b0c2037" });

            migrationBuilder.InsertData(
                table: "SkillCategory",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("3bf4951a-0e58-47e4-885d-dbad810cfe74"), "Skills in programming, software development, and technology solutions fall under this category.", "Programming & Tech" },
                    { new Guid("3ce4f130-bba1-42a5-b55d-b0baf65b8545"), "Encompasses skills related to business strategy, management, and entrepreneurial activities.", "Business" },
                    { new Guid("3d4b2688-afb3-422a-9a77-1eb0ddfb6410"), "Skills in music composition, audio production, and sound engineering.", "Music & Audio" },
                    { new Guid("631e07ff-9e93-466f-9084-14eec15b15c8"), "Skills related to content creation, writing, and translation services.", "Writing & Translation" },
                    { new Guid("7fbf95cf-901d-4727-84f0-f21b6d905443"), "This category involves skills related to artificial intelligence, machine learning, and AI-based services.", "AI Services" },
                    { new Guid("aa57fb85-022f-4514-a0e0-6672ea1b34a0"), "Skills in capturing and editing visual images through photography.", "Photography" },
                    { new Guid("af41e868-8145-4f49-9bbf-35c35d20a987"), "Skills related to online marketing, advertising, and promotion in the digital realm.", "Digital Marketing" },
                    { new Guid("b73398e1-c8af-4d1f-b3e8-e98bffc1b600"), "This category encompasses skills related to visual design, graphic arts, and creative visual communication.", "Graphics & Design" },
                    { new Guid("cca1b44e-6ffe-4fc4-aa6b-a77240db0867"), "This category covers skills in video creation, editing, and animation production.", "Video & Animation" },
                    { new Guid("e0eb8887-6eef-49a8-9a27-4d7ba1d47152"), "Skills related to data analysis, management, and interpretation.", "Data" }
                });

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
    }
}
