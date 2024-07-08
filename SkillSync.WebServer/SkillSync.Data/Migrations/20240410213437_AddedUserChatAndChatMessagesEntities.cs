using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkillSync.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserChatAndChatMessagesEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserChat",
                columns: table => new
                {
                    FirstUserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SecondUserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserChat", x => new { x.FirstUserId, x.SecondUserId });
                    table.ForeignKey(
                        name: "FK_UserChat_AspNetUsers_FirstUserId",
                        column: x => x.FirstUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_UserChat_AspNetUsers_SecondUserId",
                        column: x => x.SecondUserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "ChatMessage",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SenderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    SentAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    UserChatFirstUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserChatSecondUserId = table.Column<string>(type: "nvarchar(450)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChatMessage", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChatMessage_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ChatMessage_UserChat_UserChatFirstUserId_UserChatSecondUserId",
                        columns: x => new { x.UserChatFirstUserId, x.UserChatSecondUserId },
                        principalTable: "UserChat",
                        principalColumns: new[] { "FirstUserId", "SecondUserId" });
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessage_SenderId",
                table: "ChatMessage",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_ChatMessage_UserChatFirstUserId_UserChatSecondUserId",
                table: "ChatMessage",
                columns: new[] { "UserChatFirstUserId", "UserChatSecondUserId" });

            migrationBuilder.CreateIndex(
                name: "IX_UserChat_SecondUserId",
                table: "UserChat",
                column: "SecondUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChatMessage");

            migrationBuilder.DropTable(
                name: "UserChat");

            migrationBuilder.DeleteData(
                table: "DropdownOption",
                keyColumn: "Id",
                keyValue: new Guid("567e43d2-5144-43c7-ac8a-34b9b0e080a9"));

            migrationBuilder.DeleteData(
                table: "DropdownOption",
                keyColumn: "Id",
                keyValue: new Guid("7b348a8b-38c2-455a-952d-9d28c8c5e9f4"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("0dcfbb6f-634b-47ad-acd7-4f8baf90949d"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("2ee6619b-191f-41d6-958e-45b5b8fed73b"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("465b8f22-b2c1-4c50-ab3a-ce645aa00948"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("499d5215-b8fa-4ec5-b094-f5af34f8be3a"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("4d861c3e-472e-4d15-a67b-59efbb3e316e"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("669b73f7-5a90-495e-a441-4fc9afafb412"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("6ae57f1d-fe04-444f-92a2-a2772e131c39"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("734ff574-45db-4d39-bde1-c75c36c1f566"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("a5916c0b-0f2b-4255-8d6d-9822f51baede"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("a8ebd229-0307-42ed-8e50-5a3e274858f6"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("b8f04ae9-e1ab-478c-ab88-35a1006b033a"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("c031c390-f949-490c-a489-2fd4c3f57fca"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("c2b010dc-591a-4000-bfad-80d7fe9a104a"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("cd8aecd9-e614-4990-ad2a-c9e9e28f8ed6"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("cf37045b-dcf3-48e6-8794-ce755355888a"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("d748b039-604f-44df-b90c-7230c82da719"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("e698f4af-71a7-4c95-a3b3-fcebb4f4a795"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("e7997637-a1e3-44f2-9253-b163175c92a8"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("033f1f06-0a73-4403-8b92-af16e5ef0bf5"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("3bacd848-a6e4-4821-8b2b-831a96c57e92"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("4813db80-3c63-42db-b128-0b3fc4378940"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("4f305e09-aca5-49cf-8c28-62d386b1e8a8"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("7eba7440-2b62-4768-ae23-77531f7e70cc"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("15284566-4a09-414b-a3ec-0b6ee3f4bba7"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("8ba0fab7-a261-4e7c-8128-23abf1cd5ed1"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("919efa26-d854-4f23-9f25-4f464f3c9914"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("92223ec8-09a4-448e-a494-8bafcfd8c057"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("b7256a8f-5794-45e8-9445-0a6a16fcc563"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("bb5ebf57-1948-48a5-8a16-5de4c192fbae"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("de115f60-140f-4bf8-9435-dfd544c8bb09"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("e3de5c7b-ab36-4a1d-ba1e-262330e67dd8"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("fd983556-7103-4143-8c6c-9b16a0e18f66"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("fdf875cd-72d1-4213-9c34-c9169585cee8"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("03af3c5a-7d62-4743-8770-611b331bf5e6"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("0c0fb731-2b30-48fc-9333-cde7eef7a5dd"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("1329c142-a7d9-42e3-9ead-f1c0fc36c90b"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("27255d5a-43a2-4e78-9093-5d32b9833d70"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("7f951e95-6c69-459b-8ac4-ff3d139cca62"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("81d9dc73-a4ef-4b49-8cbe-b854c6813e49"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("836e5d77-70db-422e-9ba0-d7540489edc0"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("9aba7cae-7520-4b33-86d2-0653fe362d4c"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("ae14349d-2940-4c45-b4f7-c516318843b4"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("b33f66b4-239d-4fcb-a132-775044ba0417"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("d3fa04ca-7620-4cb5-9b90-168a4c951b8b"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("f69ebd63-317a-4724-b92d-9eb60d2469bb"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddb34bfe-616a-46a0-af02-b7f29ee25daa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fe58b78a-4361-4146-9781-2a748c08f4bf", "AQAAAAIAAYagAAAAEMReyb44cT5sJ2u+2UwLy4p/5eVEo14n2omU56lfMeupsTkhntI/LbWd8noSXhREIA==", "d612b793-5c99-494b-8ef2-af1473cf0431" });

            migrationBuilder.InsertData(
                table: "DropdownOption",
                columns: new[] { "Id", "IncrementValue", "LowerInterval", "UpperInterval" },
                values: new object[,]
                {
                    { new Guid("cbcf6f2c-26e5-473c-a1dd-e8eabf21002d"), 1, 1, 10 },
                    { new Guid("fccda09a-fe36-4e52-9b1d-1a5db61c7eb6"), 1, 1, 50 }
                });

            migrationBuilder.InsertData(
                table: "Feature",
                columns: new[] { "Id", "DropdownOptionId", "InputType", "Name" },
                values: new object[,]
                {
                    { new Guid("0b9c10f0-8e6c-43e8-8f0a-1691c3f7ad09"), new Guid("e0046a44-904f-4124-8728-298394557fb6"), 1, "Delivery time" },
                    { new Guid("0ce70c32-d074-4cda-b0ee-abdb9b417547"), null, 1, "Revisions" },
                    { new Guid("112d36dc-653d-488c-8539-6f753260f94d"), null, 2, "Price" },
                    { new Guid("2a5c736d-8dc3-417b-be53-83d76e81a5a9"), null, 0, "Speed optimization" },
                    { new Guid("3cb68593-609a-4dbc-bfa5-82a977e5df78"), null, 0, "Hosting setup" },
                    { new Guid("419cee0e-cf92-434a-90fb-c46b216105e9"), null, 0, "Functional website" },
                    { new Guid("4b297553-b81e-4b90-9ff0-a38843ccb4ca"), new Guid("8a4b9c88-1f53-4ab9-9052-f8594d732430"), 1, "Plugins/extensions " },
                    { new Guid("66619125-eb7a-4878-be11-ffd4aeec86c1"), null, 0, "Autoresponder" },
                    { new Guid("6fe0d37a-4f06-4a7c-b3db-0d80e16aaeee"), null, 2, "Package description" },
                    { new Guid("705dd53c-6777-445b-8b5b-96b9ca4c3ffc"), null, 0, "E-commerce functionality" },
                    { new Guid("78960370-84db-4217-9f1e-2591105fda85"), null, 0, "Responsive design" },
                    { new Guid("8745207e-b84b-44af-93d7-1bb29d632bf3"), null, 0, "Opt-in form" },
                    { new Guid("8e110524-dc9d-4954-a55b-f4a4da3be41f"), null, 0, "Social media" },
                    { new Guid("af61bc5b-8435-49a6-a15a-b2d84adc04a3"), new Guid("8a4b9c88-1f53-4ab9-9052-f8594d732430"), 1, "Number of pages" },
                    { new Guid("b137340c-8031-4c1c-a796-151782123a08"), null, 0, "Payment processing" },
                    { new Guid("bbb3515c-47f6-4a30-b308-3c668fd509ed"), new Guid("e0046a44-904f-4124-8728-298394557fb6"), 1, "Number of products" },
                    { new Guid("db65ffff-4896-49da-92fa-0d2a6f4c091f"), null, 0, "Content upload" },
                    { new Guid("e034faf0-10c5-40ff-b31e-533536121ba4"), null, 2, "Package name" }
                });

            migrationBuilder.InsertData(
                table: "Skill",
                columns: new[] { "Id", "Description", "Name", "SkillSubcategoryId" },
                values: new object[,]
                {
                    { new Guid("025ff596-7a5a-4a97-a40f-29c66c0cab31"), "Skills in designing and building effective landing pages for websites.", "Landing Pages", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("2072ca2c-69ed-4625-9117-8738f8e6fe56"), "Involves creating online stores and platforms for e-commerce activities.", "E-Commerce Development", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("88a16547-84e6-423f-8949-0b0b195192e8"), "Focuses on creating websites optimized for dropshipping business models.", "Dropshipping Websites", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("dd5fcb66-dbe8-4541-9535-b7c0c69b558d"), "Encompasses skills required to build fully functional and feature-rich websites.", "Build a Complete Website", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("f706b94e-776c-461a-b54b-e3110c2243b4"), "Skills related to designing and developing websites for business purposes.", "Business Websites", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") }
                });

            migrationBuilder.InsertData(
                table: "SkillCategory",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("0d790d03-54b7-4011-8732-9e192c101797"), "Encompasses skills related to business strategy, management, and entrepreneurial activities.", "Business" },
                    { new Guid("2213841b-0c10-4f9c-acec-d23d775053cc"), "Skills in capturing and editing visual images through photography.", "Photography" },
                    { new Guid("386c040e-2e52-4653-9f67-65e46f02bfae"), "This category involves skills related to artificial intelligence, machine learning, and AI-based services.", "AI Services" },
                    { new Guid("3d25faa5-5e20-4242-a78b-85f798e96ad4"), "This category encompasses skills related to visual design, graphic arts, and creative visual communication.", "Graphics & Design" },
                    { new Guid("4639595b-1c76-4bbc-a3dc-5c6c122936e6"), "Skills related to data analysis, management, and interpretation.", "Data" },
                    { new Guid("63afaff6-9721-4004-8ee8-36e2f3eb999f"), "Skills in music composition, audio production, and sound engineering.", "Music & Audio" },
                    { new Guid("a3a24873-39c7-4567-a8d2-2a36c2adee8c"), "Skills related to online marketing, advertising, and promotion in the digital realm.", "Digital Marketing" },
                    { new Guid("e2f32885-984c-4df9-b9bc-ff18ae4c6a09"), "This category covers skills in video creation, editing, and animation production.", "Video & Animation" },
                    { new Guid("eec76905-2d1a-4cdd-9f1c-084904621868"), "Skills in programming, software development, and technology solutions fall under this category.", "Programming & Tech" },
                    { new Guid("f7e72361-09b3-4a60-af02-92e170912b95"), "Skills related to content creation, writing, and translation services.", "Writing & Translation" }
                });

            migrationBuilder.InsertData(
                table: "SkillSubcategory",
                columns: new[] { "Id", "Description", "Name", "SkillCategoryId" },
                values: new object[,]
                {
                    { new Guid("004d3473-819f-4373-876c-baab95fc27fe"), "Involves creating and maintaining websites, focusing on design, functionality, and user experience.", "Website Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("03be9f36-dc77-4cbc-b243-de4f88be1e54"), "Professionals specializing in software development, coding, and programming.", "Software Developers", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("0fb84244-15e8-4992-a026-62a5ffcc3607"), "Involves the development and implementation of conversational agents for automated interactions.", "Chatbots", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("2f6198dd-d87b-45c5-bb28-9f501071b81b"), "Includes miscellaneous skills or services related to the broader category of programming and technology.", "Miscellaneous", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("4757f334-5e24-471d-b64f-f89014759a2d"), "Encompasses quality assurance, testing, and review processes to ensure software reliability.", "QA & Review", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("68c6f6d0-50bf-4590-8112-02f996e62b51"), "Involves the creation and implementation of artificial intelligence algorithms and systems.", "AI Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("7b2f3780-0739-41d6-9bac-ebf71927d6c8"), "Encompasses the creation and maintenance of software applications for various platforms.", "Software Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("c4b06971-75fd-42de-aa5b-95642e74701d"), "Concerned with the ongoing support, updates, and troubleshooting of existing websites.", "Website Maintenance", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("c5885b6a-ac1d-4427-b2af-18c98fa73f89"), "Focuses on creating interactive and engaging video games for various platforms.", "Game Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("d775f149-e725-4c57-9694-26d806c53463"), "Focuses on designing and building applications specifically for mobile devices.", "Mobile App Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("e377fd92-3420-4456-b3b0-86d5a419eeca"), "Involves providing support services and addressing cybersecurity concerns for software and systems.", "Support & Cybersecurity", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("e86f9a52-02ac-4593-97b2-0ce594661602"), "Deals with understanding and utilizing various website development platforms and frameworks.", "Website Platforms", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") }
                });
        }
    }
}
