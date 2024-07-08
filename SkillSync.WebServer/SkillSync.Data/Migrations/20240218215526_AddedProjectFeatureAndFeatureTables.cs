using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkillSync.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedProjectFeatureAndFeatureTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Feature",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InputType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Feature", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProjectFeature",
                columns: table => new
                {
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FeatureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PackageType = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectFeature", x => new { x.ProjectId, x.FeatureId });
                    table.ForeignKey(
                        name: "FK_ProjectFeature_Feature_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Feature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectFeature_Project_ProjectId",
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
                values: new object[] { "a40d70a9-51af-409b-b8a3-b89ffeeb28b0", "AQAAAAIAAYagAAAAEMoU2cMHokI6ZfQUF5TtsTkoOXaGrVrJh2dl0KdpZh6wZW4mABTDFHqAhZAc9E7j/Q==", "c05a6fb2-96d8-4e03-9ad9-61245894b457" });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectFeature_FeatureId",
                table: "ProjectFeature",
                column: "FeatureId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectFeature");

            migrationBuilder.DropTable(
                name: "Feature");

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("68323a81-34c5-4668-936a-c6ff47d3d73c"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("99a449ed-bc43-47e0-b6a9-09483d16c432"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("a1dc20d6-59d0-4b42-94e5-790ac3a01154"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("bd90bcc6-9d94-4170-b709-8166c5363393"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("f5692b89-1719-47a8-92e5-3f6e48ea0d77"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("269f0dbc-fca4-4248-bac9-00d5ecc83ef6"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("2afac680-ec50-4d8e-9b67-24f5b99e7eff"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("5037c6de-bc04-4c1a-bf57-c37aa480df22"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("5d51fdb4-9069-4633-a0bb-724bcb7701f4"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("b2019ee9-fe05-4291-a55f-c1771fb04f88"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("b5928161-d751-4563-8ffa-04c7f62f1c59"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("ba922266-9790-4c8c-9a8e-e3325a2edb93"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("e06ca9f9-9724-475d-a894-969645112df4"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("e9c6bc91-234b-42a2-b7c5-231aa2bfca27"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("ebcf02d0-c013-4801-ad74-939e9fea21e7"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("0246daa6-29d5-4332-a318-be802f1896ef"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("2db1f812-bfae-433d-aea7-b72053ca672b"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("431b5b53-39c4-4f46-ab2d-b21405e0298a"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("4840d905-040d-439a-870a-d0ae6cadbcd2"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("62611690-def9-4ffc-b30b-919edcc98499"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("647a331c-9e09-4849-bcf6-b41ad5ae7fe0"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("66a8cac4-4733-4772-a762-dcc9524d452c"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("6d47bbd3-6ea3-4a78-9699-aadc00fab349"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("7b8e7ee9-0f26-43fb-9bdc-0250675f1df7"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("a1eaa387-d663-4dd0-9883-12a7e4e1c804"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("b10357d0-8b3e-4689-a9e6-dafad35a4660"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("cf03e1b2-d149-41fe-9a28-755f6fd53cd7"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddb34bfe-616a-46a0-af02-b7f29ee25daa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a7037414-4a85-48cb-a9ae-3ea710725e9b", "AQAAAAIAAYagAAAAEO3ycKqu14q5+iTg++3uWC9ObHZZOtIz8/MTd/2sZxZ4z6yrLmZNYLdrIyAwZNKa9w==", "d985294b-c25b-463c-b4de-1a4b2eeec152" });

            migrationBuilder.InsertData(
                table: "Skill",
                columns: new[] { "Id", "Description", "Name", "SkillSubcategoryId" },
                values: new object[,]
                {
                    { new Guid("0ed8c559-5727-469f-a576-a3987cae8309"), "Encompasses skills required to build fully functional and feature-rich websites.", "Build a Complete Website", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("13da805e-4b46-4088-8d1e-f7e6efc594ed"), "Skills related to designing and developing websites for business purposes.", "Business Websites", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("64781721-084d-40e8-a271-2c8edeb5742d"), "Involves creating online stores and platforms for e-commerce activities.", "E-Commerce Development", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("b5b86f40-8118-472c-a486-9689846ccf20"), "Focuses on creating websites optimized for dropshipping business models.", "Dropshipping Websites", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("de72a6ec-c427-499c-9d8b-2887e75fbe5c"), "Skills in designing and building effective landing pages for websites.", "Landing Pages", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") }
                });

            migrationBuilder.InsertData(
                table: "SkillCategory",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("09d0ee86-f3bc-4681-8472-e6e5268ddc15"), "Skills related to data analysis, management, and interpretation.", "Data" },
                    { new Guid("0faeb2db-bb05-4130-915a-3c18d43f460f"), "Skills in capturing and editing visual images through photography.", "Photography" },
                    { new Guid("29c17797-67d6-45f4-8916-5406590915d4"), "Skills related to online marketing, advertising, and promotion in the digital realm.", "Digital Marketing" },
                    { new Guid("66bfaf68-1036-461f-a977-aa49d1499fbf"), "This category involves skills related to artificial intelligence, machine learning, and AI-based services.", "AI Services" },
                    { new Guid("8b2539e5-a7ae-4fe0-8713-31320579156c"), "Skills in music composition, audio production, and sound engineering.", "Music & Audio" },
                    { new Guid("8e20c093-8ee2-42e3-bcb5-79155387f326"), "Encompasses skills related to business strategy, management, and entrepreneurial activities.", "Business" },
                    { new Guid("aa5cffec-7c81-409f-b658-12255df85a5f"), "Skills related to content creation, writing, and translation services.", "Writing & Translation" },
                    { new Guid("b466e69c-e086-4ea9-a20d-c7b94a25aa46"), "This category encompasses skills related to visual design, graphic arts, and creative visual communication.", "Graphics & Design" },
                    { new Guid("b4ae1ccf-1db8-4dc9-a626-da15589b331c"), "Skills in programming, software development, and technology solutions fall under this category.", "Programming & Tech" },
                    { new Guid("e8787628-8a6c-4f13-9438-c6975edc12ec"), "This category covers skills in video creation, editing, and animation production.", "Video & Animation" }
                });

            migrationBuilder.InsertData(
                table: "SkillSubcategory",
                columns: new[] { "Id", "Description", "Name", "SkillCategoryId" },
                values: new object[,]
                {
                    { new Guid("15f61fdc-9ecd-4fd0-ab04-692f1586a7d6"), "Encompasses the creation and maintenance of software applications for various platforms.", "Software Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("24add0bd-b00a-4aa2-b25c-35578962df04"), "Focuses on creating interactive and engaging video games for various platforms.", "Game Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("2f188d9f-54db-4978-85ab-89318369d2d9"), "Involves creating and maintaining websites, focusing on design, functionality, and user experience.", "Website Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("3c618ac8-ef5d-49f3-81f8-cb4e82b3e6c3"), "Involves the development and implementation of conversational agents for automated interactions.", "Chatbots", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("533206e0-7ba1-4808-8b92-95e91e46787d"), "Focuses on designing and building applications specifically for mobile devices.", "Mobile App Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("552b75fd-becb-4a40-9c4c-7f83b38e4bd0"), "Includes miscellaneous skills or services related to the broader category of programming and technology.", "Miscellaneous", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("6e19b85d-10a7-4bff-8d45-d58accde7b23"), "Involves providing support services and addressing cybersecurity concerns for software and systems.", "Support & Cybersecurity", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("78b5e6ea-0458-4da8-875c-e7adc87aff69"), "Involves the creation and implementation of artificial intelligence algorithms and systems.", "AI Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("7927082a-6a27-4c51-a362-ad66a0a5e05c"), "Deals with understanding and utilizing various website development platforms and frameworks.", "Website Platforms", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("9bb1e550-c85a-45f8-881f-6dd33b8c01c1"), "Encompasses quality assurance, testing, and review processes to ensure software reliability.", "QA & Review", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("c150babb-0b75-41b9-9f27-8633661a6d29"), "Professionals specializing in software development, coding, and programming.", "Software Developers", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("d6649ae6-5019-4890-855d-33219994292a"), "Concerned with the ongoing support, updates, and troubleshooting of existing websites.", "Website Maintenance", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") }
                });
        }
    }
}
