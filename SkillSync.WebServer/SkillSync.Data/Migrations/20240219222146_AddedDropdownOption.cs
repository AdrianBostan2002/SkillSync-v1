using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkillSync.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedDropdownOption : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkillFeatureOption");

            migrationBuilder.AddColumn<Guid>(
                name: "DropdownOptionId",
                table: "Feature",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "DropdownOption",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LowerInterval = table.Column<int>(type: "int", nullable: false),
                    UpperInterval = table.Column<int>(type: "int", nullable: false),
                    IncrementValue = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DropdownOption", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SkillSubcategoryFeatureOption",
                columns: table => new
                {
                    SkillSubcategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FeatureId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillSubcategoryFeatureOption", x => new { x.SkillSubcategoryId, x.FeatureId });
                    table.ForeignKey(
                        name: "FK_SkillSubcategoryFeatureOption_Feature_FeatureId",
                        column: x => x.FeatureId,
                        principalTable: "Feature",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillSubcategoryFeatureOption_SkillSubcategory_SkillSubcategoryId",
                        column: x => x.SkillSubcategoryId,
                        principalTable: "SkillSubcategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddb34bfe-616a-46a0-af02-b7f29ee25daa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "125da973-2da6-463d-a22c-8bbdb69359f0", "AQAAAAIAAYagAAAAEOK7ZNKoMMoyvbmkVfD0F2v4jketwiJ70Wb91JXye/Z3tcTOBGkCAwzJsUjOJBCXug==", "8fabb8f4-705a-4ea6-8553-bd741241b020" });

            migrationBuilder.InsertData(
                table: "DropdownOption",
                columns: new[] { "Id", "IncrementValue", "LowerInterval", "UpperInterval" },
                values: new object[,]
                {
                    { new Guid("8a4b9c88-1f53-4ab9-9052-f8594d732430"), 1, 1, 10 },
                    { new Guid("e0046a44-904f-4124-8728-298394557fb6"), 1, 1, 50 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Feature_DropdownOptionId",
                table: "Feature",
                column: "DropdownOptionId");

            migrationBuilder.CreateIndex(
                name: "IX_SkillSubcategoryFeatureOption_FeatureId",
                table: "SkillSubcategoryFeatureOption",
                column: "FeatureId");

            migrationBuilder.AddForeignKey(
                name: "FK_Feature_DropdownOption_DropdownOptionId",
                table: "Feature",
                column: "DropdownOptionId",
                principalTable: "DropdownOption",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feature_DropdownOption_DropdownOptionId",
                table: "Feature");

            migrationBuilder.DropTable(
                name: "DropdownOption");

            migrationBuilder.DropTable(
                name: "SkillSubcategoryFeatureOption");

            migrationBuilder.DropIndex(
                name: "IX_Feature_DropdownOptionId",
                table: "Feature");

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("2cf10f18-a49f-43f9-a45f-a2a8b239941d"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("3e00549b-aa8c-4f7a-8925-a8335c9b194d"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("44a3d9a6-844d-464a-aae7-73888f9fe850"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("c5c7abe1-7135-4b1d-b67b-90b9594a0b84"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("f610859a-8a31-46e4-a43e-bca2d52ad1ef"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("01d4edc2-7b40-4893-8a5f-748f66406815"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("30e41b07-fef7-4e89-8daa-f349a9237514"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("3d976708-8fd4-467b-9187-35f180a167cc"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("659cf1f8-adc8-4ed9-bb40-3db2fcf4753b"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("6bd79f58-bd24-4d52-a5f7-d9f6dee02bba"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("6f0afc4c-9f30-4fca-91fb-872aec998f16"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("6fed689f-cc98-4312-bfde-023bb928569e"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("87f7baa8-4ff3-4434-bc06-e475e81eea7c"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("a23daeb8-d51b-4726-a564-78c9fe577927"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("d53b21c0-aa3f-4424-84b4-5d7ce6bcf84b"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("2e9ad031-7908-4d97-9ebd-4b4373d2d04c"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("51a4ff21-35c8-43f2-948f-dfdaba3e031d"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("5fda8218-996f-48bc-ab1a-ac91886c9367"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("9d7b7fb0-98c0-4fff-b685-cf4b8d9e476b"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("a4214804-b660-4204-8afc-fb718b50b306"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("a72985d0-c6b4-4f27-8cb0-debbdc1639fc"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("bf4782ba-e303-4399-bfb0-5a0cb89c7ab3"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("c39aa61b-600b-4f57-9c2c-a8edb902d8ce"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("c72ef2e8-cc6e-4e8d-820a-91f28d3bcafa"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("db3ecf1e-99b8-42f3-8fba-74784085014f"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("e0d789d2-d7c3-408e-91e5-4c6f623c399e"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("e98360b3-419c-47e9-962f-62fd825dbf7e"));

            migrationBuilder.DropColumn(
                name: "DropdownOptionId",
                table: "Feature");

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

            migrationBuilder.InsertData(
                table: "Skill",
                columns: new[] { "Id", "Description", "Name", "SkillSubcategoryId" },
                values: new object[,]
                {
                    { new Guid("55d9a517-e3b5-41aa-9bf6-7608b17077e6"), "Skills related to designing and developing websites for business purposes.", "Business Websites", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("56c0873f-621b-48d7-a244-7cb90c46b1ad"), "Focuses on creating websites optimized for dropshipping business models.", "Dropshipping Websites", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("9c3f2905-d3e5-4acf-9865-fddb1b6e903c"), "Involves creating online stores and platforms for e-commerce activities.", "E-Commerce Development", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("b2f08378-8448-4866-a534-ffbc9773fc43"), "Encompasses skills required to build fully functional and feature-rich websites.", "Build a Complete Website", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("ba2ba298-2b86-43f1-b5a5-53008611a3a3"), "Skills in designing and building effective landing pages for websites.", "Landing Pages", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") }
                });

            migrationBuilder.InsertData(
                table: "SkillCategory",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("05e7b715-e8d4-4571-9139-830b1a0ceb5e"), "Skills related to content creation, writing, and translation services.", "Writing & Translation" },
                    { new Guid("117350eb-58e3-4362-a3bf-6072f2554d35"), "This category covers skills in video creation, editing, and animation production.", "Video & Animation" },
                    { new Guid("129a4b6a-6bb0-4f9e-8232-9890d02d2d16"), "Skills related to data analysis, management, and interpretation.", "Data" },
                    { new Guid("22579454-07cc-4879-81cf-5d7e3ef48105"), "Skills related to online marketing, advertising, and promotion in the digital realm.", "Digital Marketing" },
                    { new Guid("38da572e-5062-48e4-8f4b-d3051c7cc8a1"), "Skills in music composition, audio production, and sound engineering.", "Music & Audio" },
                    { new Guid("99e04460-a1a6-480c-ba06-4be4fa6dba52"), "Skills in capturing and editing visual images through photography.", "Photography" },
                    { new Guid("a947bf7b-a792-4187-b9bc-836c3da49943"), "This category involves skills related to artificial intelligence, machine learning, and AI-based services.", "AI Services" },
                    { new Guid("aea7eae9-cf9a-4a20-ad18-557f3856096b"), "This category encompasses skills related to visual design, graphic arts, and creative visual communication.", "Graphics & Design" },
                    { new Guid("c8f94bb6-b09a-4342-aced-69b95ec092cc"), "Skills in programming, software development, and technology solutions fall under this category.", "Programming & Tech" },
                    { new Guid("e92de29b-ce6e-412d-9ae7-aad9aba3430f"), "Encompasses skills related to business strategy, management, and entrepreneurial activities.", "Business" }
                });

            migrationBuilder.InsertData(
                table: "SkillSubcategory",
                columns: new[] { "Id", "Description", "Name", "SkillCategoryId" },
                values: new object[,]
                {
                    { new Guid("45b5556e-5de3-4a97-8a2a-f003b0176614"), "Professionals specializing in software development, coding, and programming.", "Software Developers", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("4866340f-fc06-4b33-81ab-f96e592a7a41"), "Involves the creation and implementation of artificial intelligence algorithms and systems.", "AI Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("503d0d72-229a-438c-b084-11219964868c"), "Deals with understanding and utilizing various website development platforms and frameworks.", "Website Platforms", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("6daca3f0-0642-4673-bd25-2de7522923e7"), "Involves creating and maintaining websites, focusing on design, functionality, and user experience.", "Website Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("726fb970-4beb-4b4e-9fff-eddda3e1d2b6"), "Encompasses quality assurance, testing, and review processes to ensure software reliability.", "QA & Review", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("73420c45-8283-48ee-a5c4-3bb4e3e98aa6"), "Encompasses the creation and maintenance of software applications for various platforms.", "Software Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("a3679979-f1c2-4907-9ab6-cb2ec2e26c2e"), "Includes miscellaneous skills or services related to the broader category of programming and technology.", "Miscellaneous", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("a63d0b7a-5442-499c-ae97-62546f6c7cf9"), "Focuses on designing and building applications specifically for mobile devices.", "Mobile App Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("a9b9f879-0bbc-45b7-9a2d-2be77de7e803"), "Involves providing support services and addressing cybersecurity concerns for software and systems.", "Support & Cybersecurity", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("c2631b1e-518e-43bc-b584-e98159da0ec6"), "Involves the development and implementation of conversational agents for automated interactions.", "Chatbots", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("d9530011-3714-401b-8645-b3047488d1c6"), "Focuses on creating interactive and engaging video games for various platforms.", "Game Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("ed723c6c-ae8f-4c9e-8ba6-7026635f2f32"), "Concerned with the ongoing support, updates, and troubleshooting of existing websites.", "Website Maintenance", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SkillFeatureOption_FeatureId",
                table: "SkillFeatureOption",
                column: "FeatureId");
        }
    }
}
