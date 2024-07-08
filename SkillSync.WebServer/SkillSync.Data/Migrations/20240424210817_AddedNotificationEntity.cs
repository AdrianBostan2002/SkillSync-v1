using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkillSync.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedNotificationEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Notification",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SenderId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SentAt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsRead = table.Column<bool>(type: "bit", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    AdditionalData = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notification_AspNetUsers_SenderId",
                        column: x => x.SenderId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserNotification",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    NotificationId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserNotification", x => new { x.UserId, x.NotificationId });
                    table.ForeignKey(
                        name: "FK_UserNotification_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserNotification_Notification_NotificationId",
                        column: x => x.NotificationId,
                        principalTable: "Notification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddb34bfe-616a-46a0-af02-b7f29ee25daa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ba166c9e-453e-42b1-8b22-060832fb79eb", "AQAAAAIAAYagAAAAEOpCDCk//njVu1thhCUd4fxkHe9MkgBEnyfhUhZGkOlF73pw2SvJIHovRcf31TpQsw==", "c94b5c21-05b1-474a-b6cc-da6493a44ca7" });

            migrationBuilder.CreateIndex(
                name: "IX_Notification_SenderId",
                table: "Notification",
                column: "SenderId");

            migrationBuilder.CreateIndex(
                name: "IX_UserNotification_NotificationId",
                table: "UserNotification",
                column: "NotificationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserNotification");

            migrationBuilder.DropTable(
                name: "Notification");

            migrationBuilder.DeleteData(
                table: "DropdownOption",
                keyColumn: "Id",
                keyValue: new Guid("67d72f87-2b6b-4e70-9682-db9b646c3e69"));

            migrationBuilder.DeleteData(
                table: "DropdownOption",
                keyColumn: "Id",
                keyValue: new Guid("932801ea-209f-4bf4-a9d9-469e39a4d4ef"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("083c6345-040a-4a2d-a5f2-9e9e8d2c25b1"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("0f16650f-f429-4645-ab02-3bd62a71d366"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("111a0ec3-9c73-4fe5-8c18-50b91238d6c9"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("14731b3c-2dc9-4f45-bdfe-7c3f8a6f004d"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("349a1286-76e7-4fc2-881c-fe3f4caf80ff"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("38432333-54fc-448e-aa71-4e9145794290"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("38d6d3e7-eb94-47a8-8e4b-f5c5e25f76eb"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("3d67058a-1c33-4ea2-bf22-17371df1ca29"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("4161d766-5873-4c33-9eed-455ce9b5d929"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("571e7007-2fa4-4852-85cf-83757767169f"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("61c9da45-9cec-4ee6-a103-30716f4a8e22"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("9d31ac91-2f23-4fb5-9db6-33af7732e0e7"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("9f009a76-0b77-47a3-b9f1-33087b80d739"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("a51180c6-e6bc-4685-99d4-00463136bd51"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("a5837702-9f4d-48e1-bf87-fbf4465b6f07"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("d96ff989-2f8a-447f-94bf-644868218107"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("f0f7a950-d552-494a-b8a8-2f691c70fd56"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("f2b9de5c-8a5d-4615-80b0-b6b093007591"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("64a09461-f6a0-4939-a82c-e881013c1d56"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("67e75e7f-3650-4185-89d6-6d8b40047097"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("6c3f127e-c595-429c-807e-074833a17427"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("a25caa6a-3327-4b26-a58a-762499422de9"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("eb2ac5d7-02c8-4e89-a84a-2ce701fb7796"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("24137a2b-b51e-49e3-a541-d782a3d10c4f"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("279c68b7-8ff8-48f2-919d-70d85867f667"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("53747475-a312-45ea-9b73-a490466e5ec4"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("611d7230-bcf2-4dbc-b6c6-9c428ee128b0"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("790ff549-a0f0-4294-b476-d96a16079acd"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("7db5814a-0689-48e6-86a1-e4c8e52ba70e"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("9295939b-e9a3-4720-bec5-0983b0e4fbd8"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("9f23dda1-447b-4151-9c32-1847b03800fb"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("b2b275a5-4e5f-4936-8c79-918aaa98a8cb"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("fcb14d52-6e95-4ebc-a862-cd28bacbc86d"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("0113c75f-ca0d-4b8c-8cd9-2186ec7676a7"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("054e9a6d-86a3-4784-b713-29acc654b080"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("1d20a6c8-ed40-4136-9225-d3fda08234be"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("25898e96-1a38-40aa-86c2-36b3fc41b641"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("2bd9a64f-3780-4d7c-8839-15228d794db0"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("343af1fc-1072-4d4d-bf15-6a43c4d32e7b"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("473f2b4d-7758-4f6e-a9c4-87d651bd78c7"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("6e400845-6456-485b-9438-ac8c6cc04c87"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("831ed0fc-b87b-4847-8eb1-861c9fa5d93d"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("8afb1888-d817-4e40-839a-3e9b0e6091d6"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("d8404f6d-1576-4f60-a738-0206b7c2089d"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("da8140d3-9952-414f-8d1e-c44407e81f78"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddb34bfe-616a-46a0-af02-b7f29ee25daa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "e7f13907-5f7e-4fd1-9bbc-49673dce91ee", "AQAAAAIAAYagAAAAEHdbMHD0N9OmQk/2JAtWy8B4DxakiCaOxje3P9UkEIq/7QBMhpitSBxM8NS6uR6yBQ==", "df2d66fd-b26e-41cb-99c8-3ee798c7bf24" });

            migrationBuilder.InsertData(
                table: "DropdownOption",
                columns: new[] { "Id", "IncrementValue", "LowerInterval", "UpperInterval" },
                values: new object[,]
                {
                    { new Guid("567e43d2-5144-43c7-ac8a-34b9b0e080a9"), 1, 1, 10 },
                    { new Guid("7b348a8b-38c2-455a-952d-9d28c8c5e9f4"), 1, 1, 50 }
                });

            migrationBuilder.InsertData(
                table: "Feature",
                columns: new[] { "Id", "DropdownOptionId", "InputType", "Name" },
                values: new object[,]
                {
                    { new Guid("0dcfbb6f-634b-47ad-acd7-4f8baf90949d"), new Guid("8a4b9c88-1f53-4ab9-9052-f8594d732430"), 1, "Plugins/extensions " },
                    { new Guid("2ee6619b-191f-41d6-958e-45b5b8fed73b"), null, 0, "Functional website" },
                    { new Guid("465b8f22-b2c1-4c50-ab3a-ce645aa00948"), null, 2, "Package description" },
                    { new Guid("499d5215-b8fa-4ec5-b094-f5af34f8be3a"), null, 0, "Payment processing" },
                    { new Guid("4d861c3e-472e-4d15-a67b-59efbb3e316e"), null, 0, "Speed optimization" },
                    { new Guid("669b73f7-5a90-495e-a441-4fc9afafb412"), null, 2, "Package name" },
                    { new Guid("6ae57f1d-fe04-444f-92a2-a2772e131c39"), null, 0, "Opt-in form" },
                    { new Guid("734ff574-45db-4d39-bde1-c75c36c1f566"), null, 0, "Autoresponder" },
                    { new Guid("a5916c0b-0f2b-4255-8d6d-9822f51baede"), null, 1, "Revisions" },
                    { new Guid("a8ebd229-0307-42ed-8e50-5a3e274858f6"), new Guid("e0046a44-904f-4124-8728-298394557fb6"), 1, "Number of products" },
                    { new Guid("b8f04ae9-e1ab-478c-ab88-35a1006b033a"), null, 0, "E-commerce functionality" },
                    { new Guid("c031c390-f949-490c-a489-2fd4c3f57fca"), null, 0, "Hosting setup" },
                    { new Guid("c2b010dc-591a-4000-bfad-80d7fe9a104a"), null, 0, "Social media" },
                    { new Guid("cd8aecd9-e614-4990-ad2a-c9e9e28f8ed6"), new Guid("e0046a44-904f-4124-8728-298394557fb6"), 1, "Delivery time" },
                    { new Guid("cf37045b-dcf3-48e6-8794-ce755355888a"), null, 2, "Price" },
                    { new Guid("d748b039-604f-44df-b90c-7230c82da719"), new Guid("8a4b9c88-1f53-4ab9-9052-f8594d732430"), 1, "Number of pages" },
                    { new Guid("e698f4af-71a7-4c95-a3b3-fcebb4f4a795"), null, 0, "Content upload" },
                    { new Guid("e7997637-a1e3-44f2-9253-b163175c92a8"), null, 0, "Responsive design" }
                });

            migrationBuilder.InsertData(
                table: "Skill",
                columns: new[] { "Id", "Description", "Name", "SkillSubcategoryId" },
                values: new object[,]
                {
                    { new Guid("033f1f06-0a73-4403-8b92-af16e5ef0bf5"), "Skills related to designing and developing websites for business purposes.", "Business Websites", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("3bacd848-a6e4-4821-8b2b-831a96c57e92"), "Focuses on creating websites optimized for dropshipping business models.", "Dropshipping Websites", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("4813db80-3c63-42db-b128-0b3fc4378940"), "Skills in designing and building effective landing pages for websites.", "Landing Pages", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("4f305e09-aca5-49cf-8c28-62d386b1e8a8"), "Encompasses skills required to build fully functional and feature-rich websites.", "Build a Complete Website", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("7eba7440-2b62-4768-ae23-77531f7e70cc"), "Involves creating online stores and platforms for e-commerce activities.", "E-Commerce Development", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") }
                });

            migrationBuilder.InsertData(
                table: "SkillCategory",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("15284566-4a09-414b-a3ec-0b6ee3f4bba7"), "This category encompasses skills related to visual design, graphic arts, and creative visual communication.", "Graphics & Design" },
                    { new Guid("8ba0fab7-a261-4e7c-8128-23abf1cd5ed1"), "Skills in capturing and editing visual images through photography.", "Photography" },
                    { new Guid("919efa26-d854-4f23-9f25-4f464f3c9914"), "This category involves skills related to artificial intelligence, machine learning, and AI-based services.", "AI Services" },
                    { new Guid("92223ec8-09a4-448e-a494-8bafcfd8c057"), "Skills in programming, software development, and technology solutions fall under this category.", "Programming & Tech" },
                    { new Guid("b7256a8f-5794-45e8-9445-0a6a16fcc563"), "Skills related to content creation, writing, and translation services.", "Writing & Translation" },
                    { new Guid("bb5ebf57-1948-48a5-8a16-5de4c192fbae"), "Skills related to data analysis, management, and interpretation.", "Data" },
                    { new Guid("de115f60-140f-4bf8-9435-dfd544c8bb09"), "Skills in music composition, audio production, and sound engineering.", "Music & Audio" },
                    { new Guid("e3de5c7b-ab36-4a1d-ba1e-262330e67dd8"), "This category covers skills in video creation, editing, and animation production.", "Video & Animation" },
                    { new Guid("fd983556-7103-4143-8c6c-9b16a0e18f66"), "Skills related to online marketing, advertising, and promotion in the digital realm.", "Digital Marketing" },
                    { new Guid("fdf875cd-72d1-4213-9c34-c9169585cee8"), "Encompasses skills related to business strategy, management, and entrepreneurial activities.", "Business" }
                });

            migrationBuilder.InsertData(
                table: "SkillSubcategory",
                columns: new[] { "Id", "Description", "Name", "SkillCategoryId" },
                values: new object[,]
                {
                    { new Guid("03af3c5a-7d62-4743-8770-611b331bf5e6"), "Focuses on designing and building applications specifically for mobile devices.", "Mobile App Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("0c0fb731-2b30-48fc-9333-cde7eef7a5dd"), "Involves the creation and implementation of artificial intelligence algorithms and systems.", "AI Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("1329c142-a7d9-42e3-9ead-f1c0fc36c90b"), "Involves creating and maintaining websites, focusing on design, functionality, and user experience.", "Website Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("27255d5a-43a2-4e78-9093-5d32b9833d70"), "Encompasses the creation and maintenance of software applications for various platforms.", "Software Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("7f951e95-6c69-459b-8ac4-ff3d139cca62"), "Involves the development and implementation of conversational agents for automated interactions.", "Chatbots", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("81d9dc73-a4ef-4b49-8cbe-b854c6813e49"), "Includes miscellaneous skills or services related to the broader category of programming and technology.", "Miscellaneous", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("836e5d77-70db-422e-9ba0-d7540489edc0"), "Professionals specializing in software development, coding, and programming.", "Software Developers", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("9aba7cae-7520-4b33-86d2-0653fe362d4c"), "Encompasses quality assurance, testing, and review processes to ensure software reliability.", "QA & Review", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("ae14349d-2940-4c45-b4f7-c516318843b4"), "Involves providing support services and addressing cybersecurity concerns for software and systems.", "Support & Cybersecurity", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("b33f66b4-239d-4fcb-a132-775044ba0417"), "Focuses on creating interactive and engaging video games for various platforms.", "Game Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("d3fa04ca-7620-4cb5-9b90-168a4c951b8b"), "Concerned with the ongoing support, updates, and troubleshooting of existing websites.", "Website Maintenance", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("f69ebd63-317a-4724-b92d-9eb60d2469bb"), "Deals with understanding and utilizing various website development platforms and frameworks.", "Website Platforms", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") }
                });
        }
    }
}
