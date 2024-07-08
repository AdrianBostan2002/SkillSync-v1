using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkillSync.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedSkillFeatureOption : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SkillFeatureOption",
                columns: table => new
                {
                    SkillId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FeatureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillFeatureOption", x => new { x.SkillId, x.FeatureId });
                    table.ForeignKey(
                        name: "FK_SkillFeatureOption_Feature_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Feature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillFeatureOption_Skill_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skill",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddb34bfe-616a-46a0-af02-b7f29ee25daa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "904e43a0-fd39-4420-a4be-f4ca5f050327", "AQAAAAIAAYagAAAAEGk5/zNlqeIPot97LTw6qayTnJF63YvD+VI7A4Mw19UBbqlYbfxB1EkXhum9xkczEg==", "ee17805d-692d-4ddc-b17b-358e33747f29" });

            migrationBuilder.CreateIndex(
                name: "IX_SkillFeatureOption_FeatureId",
                table: "SkillFeatureOption",
                column: "FeatureId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkillFeatureOption");

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("55d9a517-e3b5-41aa-9bf6-7608b17077e6"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("56c0873f-621b-48d7-a244-7cb90c46b1ad"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("9c3f2905-d3e5-4acf-9865-fddb1b6e903c"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("b2f08378-8448-4866-a534-ffbc9773fc43"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("ba2ba298-2b86-43f1-b5a5-53008611a3a3"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("05e7b715-e8d4-4571-9139-830b1a0ceb5e"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("117350eb-58e3-4362-a3bf-6072f2554d35"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("129a4b6a-6bb0-4f9e-8232-9890d02d2d16"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("22579454-07cc-4879-81cf-5d7e3ef48105"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("38da572e-5062-48e4-8f4b-d3051c7cc8a1"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("99e04460-a1a6-480c-ba06-4be4fa6dba52"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("a947bf7b-a792-4187-b9bc-836c3da49943"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("aea7eae9-cf9a-4a20-ad18-557f3856096b"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("c8f94bb6-b09a-4342-aced-69b95ec092cc"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("e92de29b-ce6e-412d-9ae7-aad9aba3430f"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("45b5556e-5de3-4a97-8a2a-f003b0176614"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("4866340f-fc06-4b33-81ab-f96e592a7a41"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("503d0d72-229a-438c-b084-11219964868c"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("6daca3f0-0642-4673-bd25-2de7522923e7"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("726fb970-4beb-4b4e-9fff-eddda3e1d2b6"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("73420c45-8283-48ee-a5c4-3bb4e3e98aa6"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("a3679979-f1c2-4907-9ab6-cb2ec2e26c2e"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("a63d0b7a-5442-499c-ae97-62546f6c7cf9"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("a9b9f879-0bbc-45b7-9a2d-2be77de7e803"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("c2631b1e-518e-43bc-b584-e98159da0ec6"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("d9530011-3714-401b-8645-b3047488d1c6"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("ed723c6c-ae8f-4c9e-8ba6-7026635f2f32"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddb34bfe-616a-46a0-af02-b7f29ee25daa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a40d70a9-51af-409b-b8a3-b89ffeeb28b0", "AQAAAAIAAYagAAAAEMoU2cMHokI6ZfQUF5TtsTkoOXaGrVrJh2dl0KdpZh6wZW4mABTDFHqAhZAc9E7j/Q==", "c05a6fb2-96d8-4e03-9ad9-61245894b457" });

            migrationBuilder.InsertData(
                table: "Skill",
                columns: new[] { "Id", "Description", "Name", "SkillSubcategoryId" },
                values: new object[,]
                {
                    { new Guid("68323a81-34c5-4668-936a-c6ff47d3d73c"), "Involves creating online stores and platforms for e-commerce activities.", "E-Commerce Development", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("99a449ed-bc43-47e0-b6a9-09483d16c432"), "Skills related to designing and developing websites for business purposes.", "Business Websites", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("a1dc20d6-59d0-4b42-94e5-790ac3a01154"), "Encompasses skills required to build fully functional and feature-rich websites.", "Build a Complete Website", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("bd90bcc6-9d94-4170-b709-8166c5363393"), "Focuses on creating websites optimized for dropshipping business models.", "Dropshipping Websites", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("f5692b89-1719-47a8-92e5-3f6e48ea0d77"), "Skills in designing and building effective landing pages for websites.", "Landing Pages", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") }
                });

            migrationBuilder.InsertData(
                table: "SkillCategory",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("269f0dbc-fca4-4248-bac9-00d5ecc83ef6"), "This category involves skills related to artificial intelligence, machine learning, and AI-based services.", "AI Services" },
                    { new Guid("2afac680-ec50-4d8e-9b67-24f5b99e7eff"), "Skills related to data analysis, management, and interpretation.", "Data" },
                    { new Guid("5037c6de-bc04-4c1a-bf57-c37aa480df22"), "Encompasses skills related to business strategy, management, and entrepreneurial activities.", "Business" },
                    { new Guid("5d51fdb4-9069-4633-a0bb-724bcb7701f4"), "Skills related to content creation, writing, and translation services.", "Writing & Translation" },
                    { new Guid("b2019ee9-fe05-4291-a55f-c1771fb04f88"), "Skills related to online marketing, advertising, and promotion in the digital realm.", "Digital Marketing" },
                    { new Guid("b5928161-d751-4563-8ffa-04c7f62f1c59"), "This category encompasses skills related to visual design, graphic arts, and creative visual communication.", "Graphics & Design" },
                    { new Guid("ba922266-9790-4c8c-9a8e-e3325a2edb93"), "Skills in capturing and editing visual images through photography.", "Photography" },
                    { new Guid("e06ca9f9-9724-475d-a894-969645112df4"), "This category covers skills in video creation, editing, and animation production.", "Video & Animation" },
                    { new Guid("e9c6bc91-234b-42a2-b7c5-231aa2bfca27"), "Skills in music composition, audio production, and sound engineering.", "Music & Audio" },
                    { new Guid("ebcf02d0-c013-4801-ad74-939e9fea21e7"), "Skills in programming, software development, and technology solutions fall under this category.", "Programming & Tech" }
                });

            migrationBuilder.InsertData(
                table: "SkillSubcategory",
                columns: new[] { "Id", "Description", "Name", "SkillCategoryId" },
                values: new object[,]
                {
                    { new Guid("0246daa6-29d5-4332-a318-be802f1896ef"), "Focuses on creating interactive and engaging video games for various platforms.", "Game Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("2db1f812-bfae-433d-aea7-b72053ca672b"), "Involves creating and maintaining websites, focusing on design, functionality, and user experience.", "Website Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("431b5b53-39c4-4f46-ab2d-b21405e0298a"), "Professionals specializing in software development, coding, and programming.", "Software Developers", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("4840d905-040d-439a-870a-d0ae6cadbcd2"), "Includes miscellaneous skills or services related to the broader category of programming and technology.", "Miscellaneous", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("62611690-def9-4ffc-b30b-919edcc98499"), "Concerned with the ongoing support, updates, and troubleshooting of existing websites.", "Website Maintenance", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("647a331c-9e09-4849-bcf6-b41ad5ae7fe0"), "Deals with understanding and utilizing various website development platforms and frameworks.", "Website Platforms", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("66a8cac4-4733-4772-a762-dcc9524d452c"), "Focuses on designing and building applications specifically for mobile devices.", "Mobile App Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("6d47bbd3-6ea3-4a78-9699-aadc00fab349"), "Encompasses quality assurance, testing, and review processes to ensure software reliability.", "QA & Review", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("7b8e7ee9-0f26-43fb-9bdc-0250675f1df7"), "Encompasses the creation and maintenance of software applications for various platforms.", "Software Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("a1eaa387-d663-4dd0-9883-12a7e4e1c804"), "Involves the creation and implementation of artificial intelligence algorithms and systems.", "AI Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("b10357d0-8b3e-4689-a9e6-dafad35a4660"), "Involves the development and implementation of conversational agents for automated interactions.", "Chatbots", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("cf03e1b2-d149-41fe-9a28-755f6fd53cd7"), "Involves providing support services and addressing cybersecurity concerns for software and systems.", "Support & Cybersecurity", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") }
                });
        }
    }
}
