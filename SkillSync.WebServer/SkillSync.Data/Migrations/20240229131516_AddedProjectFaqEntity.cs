using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkillSync.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedProjectFaqEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ScopeDescription",
                table: "Freelancer",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateTable(
                name: "ProjectFrequentlyAskedQuestion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectFrequentlyAskedQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectFrequentlyAskedQuestion_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddb34bfe-616a-46a0-af02-b7f29ee25daa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9e515fda-6763-40fa-ad97-9dd429f1c11f", "AQAAAAIAAYagAAAAEIcTkvFfE1wZ4tK2AoUkt29PBuQ+8vuBwfBExBjCDQWIZ4Kx40WATucuCZ3/nANGEg==", "b6d132e4-bd00-4f40-a8ce-5d83ba0f4bd7" });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectFrequentlyAskedQuestion_ProjectId",
                table: "ProjectFrequentlyAskedQuestion",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectFrequentlyAskedQuestion");

            migrationBuilder.DeleteData(
                table: "DropdownOption",
                keyColumn: "Id",
                keyValue: new Guid("cf8fe3f6-74c7-43d4-bfb6-b5d016a89b02"));

            migrationBuilder.DeleteData(
                table: "DropdownOption",
                keyColumn: "Id",
                keyValue: new Guid("ee5787ea-fd88-4f12-bee6-a5775d9151a9"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("0ca05154-ba88-467c-b821-8c42f9fea5c2"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("0ee53df1-15e9-4962-82e7-bb247622f321"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("17dcaf3d-2c86-4d97-b5b7-560f34dd74eb"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("1f3618b1-a3cc-4a6e-8cbb-8c29ddbb4922"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("253df5dc-8d8e-40db-aa6d-a12f94e4f74e"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("37d68708-81ec-46c3-b41f-f74a8490c85f"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("38782b20-8635-416b-a294-f07d74724640"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("4d065daf-a013-4d92-a5ca-86594be75ae4"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("63d26668-1f3a-4957-8af6-3ed6b1bba971"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("7882a3a8-3cd3-47fe-ae77-89b70f6723c4"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("7d3f526a-96d3-4557-be38-f92878cfb31a"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("89eb1f5b-6c03-44ec-9846-7db644780b36"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("8f77a65f-51c7-493f-842b-8d28960d841c"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("9f7cb17b-4763-430d-b90e-522e1160a9ef"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("b9c6be18-b113-4489-bb32-6400f1f2643e"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("6ff8b24d-c146-4676-a393-a65ba5c58065"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("ab8bc867-ef81-4808-b250-d06960309f4a"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("dc8347e6-599a-4a01-9f1f-32f76767ae5c"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("f3b854a1-def5-44c0-abd7-bc4470474048"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("fce4534b-535b-4558-9de9-24d24c630766"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("0983fded-e262-43d7-a485-e5f1a1ca5c87"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("16cdb431-1f7d-447c-9a99-c4bc3e85f46f"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("1ede11ab-7308-4191-b777-ff403244ba1b"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("6fd34255-00b6-450e-8a85-939368dd9f94"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("a397ee70-15da-4c02-94e8-325ef2ae1f42"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("a3a522fb-117a-4cfb-8213-0ca8343e26b1"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("a90acf25-123c-4530-aa8f-31bdc1299c5d"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("d22915dc-5a69-492b-a5b7-3462b9751b7a"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("d98055c8-6ab4-49f8-a47f-f1bd1593a2db"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("fcb6afce-a79d-49bf-a254-919e4a3d2f34"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("1c4e1c08-29d4-41f9-831b-5db779d83a7e"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("265ea8d5-f503-4aa6-a39c-642cd72b22d5"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("31aa27be-c0d7-4371-abac-c28103ffb316"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("3c9c71a1-3a0a-4d9e-bbb3-24f34bf52f6d"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("3ca38b5a-2940-4c2b-9580-4451d64a1c20"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("4d80e4fa-8f6d-4c59-a028-dd16b93e0952"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("a216406e-0b98-4613-8dda-df6aa3593056"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("badf1460-3e31-401c-b880-558faa75f94f"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("ce4d37cb-888a-4369-86e5-3fbe6b3b377e"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("db815348-b3a6-4313-b062-3ef908f9385d"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("e52caddb-2b11-4ff7-80b1-d374be1a709f"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("ffc4264b-55ac-43b2-87e8-154fe4169ac5"));

            migrationBuilder.AlterColumn<string>(
                name: "ScopeDescription",
                table: "Freelancer",
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
                values: new object[] { "463e0d7b-0cef-4223-a442-cbe33685b7d0", "AQAAAAIAAYagAAAAEDEc4arke5cuqk7A5jL0vrUKCYev/dZAdX0uTD9zfk5sNolZjEBlAEgeU4l5ibKViw==", "7f115cdb-f4e6-4e77-9c4e-ac027d0d70a5" });

            migrationBuilder.InsertData(
                table: "DropdownOption",
                columns: new[] { "Id", "IncrementValue", "LowerInterval", "UpperInterval" },
                values: new object[,]
                {
                    { new Guid("c4ebcac4-61fd-413c-bea3-d18cb18ae891"), 1, 1, 50 },
                    { new Guid("fa428814-528a-407c-9e8a-e2547af1eed5"), 1, 1, 10 }
                });

            migrationBuilder.InsertData(
                table: "Feature",
                columns: new[] { "Id", "DropdownOptionId", "InputType", "Name" },
                values: new object[,]
                {
                    { new Guid("167dda74-1cec-4a9a-a871-c014e7734826"), new Guid("e0046a44-904f-4124-8728-298394557fb6"), 1, "Number of products" },
                    { new Guid("22373e6c-e472-4956-9094-7cd9337891a1"), null, 0, "Speed optimization" },
                    { new Guid("350f6dac-f0cb-4d35-bea4-c4f9ac9f98ab"), null, 0, "Responsive design" },
                    { new Guid("46cb8e59-ed5c-4e98-90a0-b8c49f8b7ffb"), null, 0, "Autoresponder" },
                    { new Guid("48bfa35b-7121-4558-b448-1213526b0f4f"), null, 0, "Opt-in form" },
                    { new Guid("4afee1d2-e649-4cfd-a201-3b0004a2bff1"), null, 0, "E-commerce functionality" },
                    { new Guid("5c7fba81-07b7-4e00-8958-88508e89c3c1"), null, 0, "Payment processing" },
                    { new Guid("76bcd255-884c-4e64-9a0c-ce24ff484651"), new Guid("8a4b9c88-1f53-4ab9-9052-f8594d732430"), 1, "Plugins/extensions " },
                    { new Guid("a9d44ad8-cf87-49aa-9eac-8f60f9124124"), null, 0, "Content upload" },
                    { new Guid("c4967fdd-edb6-42c1-b3a2-e51ad192095f"), null, 1, "Revisions" },
                    { new Guid("c6398ced-8573-4caf-ac0c-3f57794345ad"), null, 0, "Functional website" },
                    { new Guid("caadc45b-e6e9-4968-b2a4-b985970e84de"), new Guid("8a4b9c88-1f53-4ab9-9052-f8594d732430"), 1, "Number of pages" },
                    { new Guid("dc48dbe3-abbe-47b8-bbf5-749ffa1028c2"), null, 0, "Hosting setup" },
                    { new Guid("f60a94e0-c52d-4989-8330-4e30fa454751"), null, 0, "Social media" },
                    { new Guid("fa1fd9b4-147c-472a-920e-71e6bd8a031e"), null, 2, "Price" }
                });

            migrationBuilder.InsertData(
                table: "Skill",
                columns: new[] { "Id", "Description", "Name", "SkillSubcategoryId" },
                values: new object[,]
                {
                    { new Guid("072c52f7-79cd-43b6-a06c-fd529495edea"), "Focuses on creating websites optimized for dropshipping business models.", "Dropshipping Websites", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("20e124cd-9364-4665-9cc5-f42134ffaa02"), "Involves creating online stores and platforms for e-commerce activities.", "E-Commerce Development", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("2c770101-a625-455e-ae4f-fc62354dafeb"), "Encompasses skills required to build fully functional and feature-rich websites.", "Build a Complete Website", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("53da9ba0-71d3-43b2-89c4-e4e17f0279e1"), "Skills related to designing and developing websites for business purposes.", "Business Websites", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("c38742bc-2495-4f2d-a6bd-89dd72ed5a38"), "Skills in designing and building effective landing pages for websites.", "Landing Pages", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") }
                });

            migrationBuilder.InsertData(
                table: "SkillCategory",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("035cde21-9a76-4aab-a985-3124f96d2bc5"), "Skills in capturing and editing visual images through photography.", "Photography" },
                    { new Guid("0adb0c91-d3f5-443d-8cb9-2b6ab5fc190c"), "Skills related to data analysis, management, and interpretation.", "Data" },
                    { new Guid("1d0ead72-77df-4c63-b3ce-179c32a898b6"), "Skills related to online marketing, advertising, and promotion in the digital realm.", "Digital Marketing" },
                    { new Guid("2c038305-0de9-429a-b506-692ae9074460"), "Skills in music composition, audio production, and sound engineering.", "Music & Audio" },
                    { new Guid("364cf763-4e6e-45e5-b583-8ab0e47fc0e0"), "Skills in programming, software development, and technology solutions fall under this category.", "Programming & Tech" },
                    { new Guid("4cb315bb-ad4a-475c-9d2c-88e8105094ac"), "Skills related to content creation, writing, and translation services.", "Writing & Translation" },
                    { new Guid("5c0fced6-c74e-49e0-aaf0-3130238c0f9f"), "This category covers skills in video creation, editing, and animation production.", "Video & Animation" },
                    { new Guid("a4eb6387-0a32-4f33-96e9-3b76c38d1659"), "This category involves skills related to artificial intelligence, machine learning, and AI-based services.", "AI Services" },
                    { new Guid("c35e32d1-b69a-4ef6-aa48-7fa354e840fe"), "Encompasses skills related to business strategy, management, and entrepreneurial activities.", "Business" },
                    { new Guid("c7b939f3-2738-446b-b820-e1d54ce249f1"), "This category encompasses skills related to visual design, graphic arts, and creative visual communication.", "Graphics & Design" }
                });

            migrationBuilder.InsertData(
                table: "SkillSubcategory",
                columns: new[] { "Id", "Description", "Name", "SkillCategoryId" },
                values: new object[,]
                {
                    { new Guid("03f940c9-c41e-46ee-be36-ff473d103d0a"), "Involves the creation and implementation of artificial intelligence algorithms and systems.", "AI Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("08d42043-92ba-4d9a-a839-ba6e1e8d1165"), "Deals with understanding and utilizing various website development platforms and frameworks.", "Website Platforms", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("2466561f-6120-419e-93ef-8be57a24d40c"), "Encompasses the creation and maintenance of software applications for various platforms.", "Software Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("4200a51b-5cb1-4121-b899-89f82d5f3fa6"), "Concerned with the ongoing support, updates, and troubleshooting of existing websites.", "Website Maintenance", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("61573fbf-9001-4534-8fa0-27fa1f1fa6ee"), "Involves the development and implementation of conversational agents for automated interactions.", "Chatbots", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("93badf9e-4c3a-47f7-a27e-257f903502d3"), "Includes miscellaneous skills or services related to the broader category of programming and technology.", "Miscellaneous", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("9c8d8f86-22a2-4bd9-b22d-03ef5d636e58"), "Involves creating and maintaining websites, focusing on design, functionality, and user experience.", "Website Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("a1da1175-1239-40a6-a937-19c2858fe3de"), "Encompasses quality assurance, testing, and review processes to ensure software reliability.", "QA & Review", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("a1dc4ee7-b879-4363-b509-05e9296a0bcd"), "Involves providing support services and addressing cybersecurity concerns for software and systems.", "Support & Cybersecurity", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("bf8302a2-1922-43af-b190-dbb0b25295d7"), "Focuses on creating interactive and engaging video games for various platforms.", "Game Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("e93437a7-dc17-4119-867a-792d3dcc60e2"), "Focuses on designing and building applications specifically for mobile devices.", "Mobile App Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("ec772874-7104-4be4-baf3-1c756681c771"), "Professionals specializing in software development, coding, and programming.", "Software Developers", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") }
                });
        }
    }
}
