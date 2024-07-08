using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkillSync.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeededFeatureConfigurationValues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feature_DropdownOption_DropdownOptionId",
                table: "Feature");

            migrationBuilder.AlterColumn<Guid>(
                name: "DropdownOptionId",
                table: "Feature",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddb34bfe-616a-46a0-af02-b7f29ee25daa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8165821a-388d-4a66-bd83-3a4706258c05", "AQAAAAIAAYagAAAAEK5L2IjfoKx8Qbzd88alMp+xiA1Zno6ab/fW84UfSqA73JEZiApqvl5taFaoyUlCHw==", "15694c77-d565-486f-b95b-13704640642d" });

            migrationBuilder.InsertData(
                table: "Feature",
                columns: new[] { "Id", "DropdownOptionId", "InputType", "Name" },
                values: new object[,]
                {
                    { new Guid("0a6ea85a-da41-4cab-917d-60402a960977"), null, 0, "Social media" },
                    { new Guid("0f462b41-bb48-42bd-abfa-cb4f72ec1b81"), new Guid("8a4b9c88-1f53-4ab9-9052-f8594d732430"), 1, "Plugins/extensions " },
                    { new Guid("3b4c9453-d434-4b82-8d68-e35253006b75"), new Guid("8a4b9c88-1f53-4ab9-9052-f8594d732430"), 1, "Number of pages" },
                    { new Guid("462b11f3-caea-46f7-8046-855d54eadc26"), null, 0, "Autoresponder" },
                    { new Guid("673ffae4-103d-4380-a4e0-c17087bf0312"), null, 0, "Functional website" },
                    { new Guid("6d5ef352-bd44-4fb9-8f69-2bc5f7b35110"), null, 0, "E-commerce functionality" },
                    { new Guid("885fedc2-0997-47a0-a019-02e8912d60ac"), new Guid("e0046a44-904f-4124-8728-298394557fb6"), 1, "Number of products Dropdown" },
                    { new Guid("aabb1612-8c9b-4d29-aac9-529957386d7b"), null, 0, "Responsive design" },
                    { new Guid("b9f4986e-33aa-4f2c-bcfe-bdb4f66b6635"), null, 0, "Hosting setup" },
                    { new Guid("dd2dda79-ea1a-4c0c-8bde-7304f23d1208"), null, 0, "Speed optimization" },
                    { new Guid("fc434379-0b67-4e39-8cf3-d0383ca62571"), null, 0, "Payment processing" },
                    { new Guid("fd5c869d-2533-4316-8ee9-78f2eb8dde23"), null, 0, "Content upload" },
                    { new Guid("fe16d65c-dbbf-42cf-b416-d1da153094eb"), null, 0, "Opt-in form" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Feature_DropdownOption_DropdownOptionId",
                table: "Feature",
                column: "DropdownOptionId",
                principalTable: "DropdownOption",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Feature_DropdownOption_DropdownOptionId",
                table: "Feature");

            migrationBuilder.DeleteData(
                table: "DropdownOption",
                keyColumn: "Id",
                keyValue: new Guid("dbcc3ec4-846f-4b01-9491-779c6b74adf0"));

            migrationBuilder.DeleteData(
                table: "DropdownOption",
                keyColumn: "Id",
                keyValue: new Guid("fb0f11ec-44e1-464e-9dfe-fc6c831096bc"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("0a6ea85a-da41-4cab-917d-60402a960977"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("0f462b41-bb48-42bd-abfa-cb4f72ec1b81"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("3b4c9453-d434-4b82-8d68-e35253006b75"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("462b11f3-caea-46f7-8046-855d54eadc26"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("673ffae4-103d-4380-a4e0-c17087bf0312"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("6d5ef352-bd44-4fb9-8f69-2bc5f7b35110"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("885fedc2-0997-47a0-a019-02e8912d60ac"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("aabb1612-8c9b-4d29-aac9-529957386d7b"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("b9f4986e-33aa-4f2c-bcfe-bdb4f66b6635"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("dd2dda79-ea1a-4c0c-8bde-7304f23d1208"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("fc434379-0b67-4e39-8cf3-d0383ca62571"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("fd5c869d-2533-4316-8ee9-78f2eb8dde23"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("fe16d65c-dbbf-42cf-b416-d1da153094eb"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("5b8ed014-d8c0-48b0-8541-b1ab28c7468b"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("afdbfef9-64b1-476a-873f-da1509ac6bf8"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("db4e156c-5f93-40f5-98df-c43c38f05c1a"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("df83f510-2bd2-4c61-b72a-009b06a17d5b"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("fea5efa8-4dfb-446b-9314-945e88d57b20"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("14170649-e2d6-4783-ba9d-2768665b8970"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("7c7475af-99fc-456c-8884-043b4d0645df"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("a1cbe52e-91cb-458f-a28f-9b10c2ead52c"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("ab31e316-633e-4030-ab84-c5732df1d513"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("be46eaad-1eb3-40db-b1a3-cb520424a89c"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("d59e8388-b43b-4061-a254-13c672591a1e"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("d75e19d6-52ee-45c6-9b53-0eea893ea725"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("d8d419b2-5a33-4461-a645-28ee3a29b045"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("e03c9e79-4633-46fa-9741-af6ac80ce19f"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("e607fefe-4370-4531-8a90-246a8627a437"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("10ea1de4-bf3e-4911-88e5-8b01b1d00685"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("156a9737-b4bd-431b-99b4-bf611cf79115"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("17f56b73-5e69-45f0-9dce-01a1b8c4ff6c"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("18fb8d2d-56a6-4d67-ad08-54b85d3c652b"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("3564fb7d-b725-45bd-9ddd-a6e04b74b7c2"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("53292e6d-9927-40f9-b237-ad1d4d47c24e"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("6af58c56-feb4-4013-9ad2-70fdfd0de067"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("ba2c7839-7c76-4a1c-a684-c9f2fd6cee31"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("bd78ce1f-aa9d-42ea-802e-86d168c3d67b"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("d04a2a53-8f07-4807-8937-1006b1b92738"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("f3647376-1ab2-4a5f-b837-2cc7409a41e2"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("f78aeb7c-0814-4036-b812-c65ae54765b7"));

            migrationBuilder.AlterColumn<Guid>(
                name: "DropdownOptionId",
                table: "Feature",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

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

            migrationBuilder.InsertData(
                table: "Skill",
                columns: new[] { "Id", "Description", "Name", "SkillSubcategoryId" },
                values: new object[,]
                {
                    { new Guid("2cf10f18-a49f-43f9-a45f-a2a8b239941d"), "Skills in designing and building effective landing pages for websites.", "Landing Pages", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("3e00549b-aa8c-4f7a-8925-a8335c9b194d"), "Encompasses skills required to build fully functional and feature-rich websites.", "Build a Complete Website", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("44a3d9a6-844d-464a-aae7-73888f9fe850"), "Skills related to designing and developing websites for business purposes.", "Business Websites", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("c5c7abe1-7135-4b1d-b67b-90b9594a0b84"), "Involves creating online stores and platforms for e-commerce activities.", "E-Commerce Development", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("f610859a-8a31-46e4-a43e-bca2d52ad1ef"), "Focuses on creating websites optimized for dropshipping business models.", "Dropshipping Websites", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") }
                });

            migrationBuilder.InsertData(
                table: "SkillCategory",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("01d4edc2-7b40-4893-8a5f-748f66406815"), "Skills in music composition, audio production, and sound engineering.", "Music & Audio" },
                    { new Guid("30e41b07-fef7-4e89-8daa-f349a9237514"), "Skills related to content creation, writing, and translation services.", "Writing & Translation" },
                    { new Guid("3d976708-8fd4-467b-9187-35f180a167cc"), "This category encompasses skills related to visual design, graphic arts, and creative visual communication.", "Graphics & Design" },
                    { new Guid("659cf1f8-adc8-4ed9-bb40-3db2fcf4753b"), "Encompasses skills related to business strategy, management, and entrepreneurial activities.", "Business" },
                    { new Guid("6bd79f58-bd24-4d52-a5f7-d9f6dee02bba"), "Skills in programming, software development, and technology solutions fall under this category.", "Programming & Tech" },
                    { new Guid("6f0afc4c-9f30-4fca-91fb-872aec998f16"), "Skills related to online marketing, advertising, and promotion in the digital realm.", "Digital Marketing" },
                    { new Guid("6fed689f-cc98-4312-bfde-023bb928569e"), "Skills in capturing and editing visual images through photography.", "Photography" },
                    { new Guid("87f7baa8-4ff3-4434-bc06-e475e81eea7c"), "Skills related to data analysis, management, and interpretation.", "Data" },
                    { new Guid("a23daeb8-d51b-4726-a564-78c9fe577927"), "This category covers skills in video creation, editing, and animation production.", "Video & Animation" },
                    { new Guid("d53b21c0-aa3f-4424-84b4-5d7ce6bcf84b"), "This category involves skills related to artificial intelligence, machine learning, and AI-based services.", "AI Services" }
                });

            migrationBuilder.InsertData(
                table: "SkillSubcategory",
                columns: new[] { "Id", "Description", "Name", "SkillCategoryId" },
                values: new object[,]
                {
                    { new Guid("2e9ad031-7908-4d97-9ebd-4b4373d2d04c"), "Involves providing support services and addressing cybersecurity concerns for software and systems.", "Support & Cybersecurity", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("51a4ff21-35c8-43f2-948f-dfdaba3e031d"), "Focuses on creating interactive and engaging video games for various platforms.", "Game Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("5fda8218-996f-48bc-ab1a-ac91886c9367"), "Focuses on designing and building applications specifically for mobile devices.", "Mobile App Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("9d7b7fb0-98c0-4fff-b685-cf4b8d9e476b"), "Deals with understanding and utilizing various website development platforms and frameworks.", "Website Platforms", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("a4214804-b660-4204-8afc-fb718b50b306"), "Involves the creation and implementation of artificial intelligence algorithms and systems.", "AI Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("a72985d0-c6b4-4f27-8cb0-debbdc1639fc"), "Encompasses the creation and maintenance of software applications for various platforms.", "Software Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("bf4782ba-e303-4399-bfb0-5a0cb89c7ab3"), "Concerned with the ongoing support, updates, and troubleshooting of existing websites.", "Website Maintenance", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("c39aa61b-600b-4f57-9c2c-a8edb902d8ce"), "Professionals specializing in software development, coding, and programming.", "Software Developers", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("c72ef2e8-cc6e-4e8d-820a-91f28d3bcafa"), "Involves creating and maintaining websites, focusing on design, functionality, and user experience.", "Website Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("db3ecf1e-99b8-42f3-8fba-74784085014f"), "Involves the development and implementation of conversational agents for automated interactions.", "Chatbots", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("e0d789d2-d7c3-408e-91e5-4c6f623c399e"), "Encompasses quality assurance, testing, and review processes to ensure software reliability.", "QA & Review", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("e98360b3-419c-47e9-962f-62fd825dbf7e"), "Includes miscellaneous skills or services related to the broader category of programming and technology.", "Miscellaneous", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Feature_DropdownOption_DropdownOptionId",
                table: "Feature",
                column: "DropdownOptionId",
                principalTable: "DropdownOption",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
