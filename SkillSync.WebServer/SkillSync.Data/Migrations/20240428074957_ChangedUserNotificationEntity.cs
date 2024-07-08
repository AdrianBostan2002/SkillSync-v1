using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkillSync.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangedUserNotificationEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notification_AspNetUsers_SenderId",
                table: "Notification");

            migrationBuilder.DropForeignKey(
                name: "FK_UserNotification_AspNetUsers_UserId",
                table: "UserNotification");

            migrationBuilder.DropForeignKey(
                name: "FK_UserNotification_Notification_NotificationId",
                table: "UserNotification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserNotification",
                table: "UserNotification");

            migrationBuilder.DropIndex(
                name: "IX_UserNotification_NotificationId",
                table: "UserNotification");

            migrationBuilder.DropIndex(
                name: "IX_Notification_SenderId",
                table: "Notification");

            migrationBuilder.DropColumn(
                name: "NotificationId",
                table: "UserNotification");

            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "Notification");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "UserNotification",
                newName: "ReceiverId");

            migrationBuilder.AddColumn<string>(
                name: "SenderId",
                table: "UserNotification",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserNotificationReceiverId",
                table: "Notification",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UserNotificationSenderId",
                table: "Notification",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserNotification",
                table: "UserNotification",
                columns: new[] { "SenderId", "ReceiverId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddb34bfe-616a-46a0-af02-b7f29ee25daa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f61cd93e-b7ce-45ae-957e-58a94028d9b3", "AQAAAAIAAYagAAAAEBlRyclkX+7h3iVEs2ICqac5ggPG3wy3KEvH2g42fus7kTfCAE5BdXNdT4iNbUIv5g==", "abd4d0c3-bb5f-42f3-9766-be518d538be6" });

            migrationBuilder.CreateIndex(
                name: "IX_UserNotification_ReceiverId",
                table: "UserNotification",
                column: "ReceiverId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_UserNotificationSenderId_UserNotificationReceiverId",
                table: "Notification",
                columns: new[] { "UserNotificationSenderId", "UserNotificationReceiverId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_UserNotification_UserNotificationSenderId_UserNotificationReceiverId",
                table: "Notification",
                columns: new[] { "UserNotificationSenderId", "UserNotificationReceiverId" },
                principalTable: "UserNotification",
                principalColumns: new[] { "SenderId", "ReceiverId" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserNotification_AspNetUsers_ReceiverId",
                table: "UserNotification",
                column: "ReceiverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_UserNotification_AspNetUsers_SenderId",
                table: "UserNotification",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notification_UserNotification_UserNotificationSenderId_UserNotificationReceiverId",
                table: "Notification");

            migrationBuilder.DropForeignKey(
                name: "FK_UserNotification_AspNetUsers_ReceiverId",
                table: "UserNotification");

            migrationBuilder.DropForeignKey(
                name: "FK_UserNotification_AspNetUsers_SenderId",
                table: "UserNotification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserNotification",
                table: "UserNotification");

            migrationBuilder.DropIndex(
                name: "IX_UserNotification_ReceiverId",
                table: "UserNotification");

            migrationBuilder.DropIndex(
                name: "IX_Notification_UserNotificationSenderId_UserNotificationReceiverId",
                table: "Notification");

            migrationBuilder.DeleteData(
                table: "DropdownOption",
                keyColumn: "Id",
                keyValue: new Guid("4fe80be1-bd4d-4e17-b86e-c171d1cd3043"));

            migrationBuilder.DeleteData(
                table: "DropdownOption",
                keyColumn: "Id",
                keyValue: new Guid("e4361952-275b-456a-8378-ccab0ece7ffc"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("08455e11-fff8-46a6-bf82-e6c25c64530b"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("1ea9f26b-21d2-4ea6-94c2-0bbb08b161e7"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("3746b3ff-f028-4744-b18d-e2c61770dc0b"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("3e2c1483-e91f-4bd0-97ba-f1ffe0df7f87"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("418a7cfe-4735-4131-a0aa-e7c4022bc872"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("46f3c054-6b49-4911-95de-240e9637d242"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("4aeca06b-f100-455c-8e63-a5df445121e3"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("6c8b9526-10b5-41fe-aedc-08ed9538ec48"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("933045da-4ebf-4c2c-b2b8-eabba1aaba43"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("9d86e03a-4586-4fd1-a3d2-1a84ddcf934a"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("ae24aed4-a998-4a36-9942-b19d98454f67"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("b0eccba5-1b05-4964-96a0-a288fa3a6674"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("b202da7d-3bd5-42ce-8b1e-44637696d003"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("bcd12434-07d3-45c1-92d7-88d53c2d1113"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("c9880184-d998-4929-8b38-c5aed2d1a180"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("d6fc6902-0a5a-43b5-9af3-0277fa28544b"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("ee10af35-cd32-4d36-aeb5-3e2e404071c0"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("f3fd4ef9-425b-4eb0-b46a-4736f9638ca0"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("1ff02336-56c7-4e47-bf9b-2c3e59b0393e"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("47d09f38-fece-4137-add3-e944941382b3"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("5124bb56-5560-478b-86e3-003ad35e57fc"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("70d79041-9b0a-433a-9164-14911679a827"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("97e07e65-31bf-4928-b9f8-224012b24e1a"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("34712620-679f-48aa-b478-4561747bf2e9"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("40f240ec-8e5f-454a-b17f-e74084c6121d"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("72a5a6c6-d62d-404e-a1bb-b938f28aaf02"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("8b5fcf34-e4ea-4f21-bdb5-038ffa1ffbe7"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("8cf4ce8c-6f68-42c4-850a-35cfd3e52189"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("9321b761-9264-40d2-9020-856200c3d7fb"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("9b0c40bb-e7fb-4ebf-8fb8-50e549a694af"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("c60d2d97-eda3-4a66-acac-e90402a89ce8"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("c7fe2560-e81b-4a57-857f-e49874c34529"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("e36ec5b5-6a1e-4371-96e9-6a18b05b1526"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("25a57893-c60f-436d-9064-61943ecbd2ee"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("2cefccc7-d845-48a0-9b42-cd74a4bb62e0"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("4cd8d2b7-0c0c-4153-b99c-9cb5dffa62e2"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("519ff938-994e-4e11-8e65-30992d5c89eb"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("5542f2bd-a8ec-474d-942b-f524212d0d39"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("81b06e13-a2dc-4275-be48-607192feef40"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("8223d6db-c16f-4f1d-90cc-76951988ce0f"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("99182ebc-efaa-4767-86d6-d02d0563ddfb"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("afd9646e-985c-4520-9c38-fde23a446f43"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("ddeebca8-0131-4bd1-ab65-7b90b0ff27b6"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("f0242954-c9ef-4ac4-bbe6-34fd8ced0fac"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("f67ffaa3-2b75-46a4-b930-4316e8d729bc"));

            migrationBuilder.DropColumn(
                name: "SenderId",
                table: "UserNotification");

            migrationBuilder.DropColumn(
                name: "UserNotificationReceiverId",
                table: "Notification");

            migrationBuilder.DropColumn(
                name: "UserNotificationSenderId",
                table: "Notification");

            migrationBuilder.RenameColumn(
                name: "ReceiverId",
                table: "UserNotification",
                newName: "UserId");

            migrationBuilder.AddColumn<Guid>(
                name: "NotificationId",
                table: "UserNotification",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "SenderId",
                table: "Notification",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserNotification",
                table: "UserNotification",
                columns: new[] { "UserId", "NotificationId" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddb34bfe-616a-46a0-af02-b7f29ee25daa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "ba166c9e-453e-42b1-8b22-060832fb79eb", "AQAAAAIAAYagAAAAEOpCDCk//njVu1thhCUd4fxkHe9MkgBEnyfhUhZGkOlF73pw2SvJIHovRcf31TpQsw==", "c94b5c21-05b1-474a-b6cc-da6493a44ca7" });

            migrationBuilder.InsertData(
                table: "DropdownOption",
                columns: new[] { "Id", "IncrementValue", "LowerInterval", "UpperInterval" },
                values: new object[,]
                {
                    { new Guid("67d72f87-2b6b-4e70-9682-db9b646c3e69"), 1, 1, 50 },
                    { new Guid("932801ea-209f-4bf4-a9d9-469e39a4d4ef"), 1, 1, 10 }
                });

            migrationBuilder.InsertData(
                table: "Feature",
                columns: new[] { "Id", "DropdownOptionId", "InputType", "Name" },
                values: new object[,]
                {
                    { new Guid("083c6345-040a-4a2d-a5f2-9e9e8d2c25b1"), null, 0, "Autoresponder" },
                    { new Guid("0f16650f-f429-4645-ab02-3bd62a71d366"), null, 0, "Functional website" },
                    { new Guid("111a0ec3-9c73-4fe5-8c18-50b91238d6c9"), new Guid("8a4b9c88-1f53-4ab9-9052-f8594d732430"), 1, "Plugins/extensions " },
                    { new Guid("14731b3c-2dc9-4f45-bdfe-7c3f8a6f004d"), null, 2, "Price" },
                    { new Guid("349a1286-76e7-4fc2-881c-fe3f4caf80ff"), new Guid("8a4b9c88-1f53-4ab9-9052-f8594d732430"), 1, "Number of pages" },
                    { new Guid("38432333-54fc-448e-aa71-4e9145794290"), new Guid("e0046a44-904f-4124-8728-298394557fb6"), 1, "Number of products" },
                    { new Guid("38d6d3e7-eb94-47a8-8e4b-f5c5e25f76eb"), null, 0, "Social media" },
                    { new Guid("3d67058a-1c33-4ea2-bf22-17371df1ca29"), null, 0, "Opt-in form" },
                    { new Guid("4161d766-5873-4c33-9eed-455ce9b5d929"), null, 0, "Payment processing" },
                    { new Guid("571e7007-2fa4-4852-85cf-83757767169f"), null, 1, "Revisions" },
                    { new Guid("61c9da45-9cec-4ee6-a103-30716f4a8e22"), null, 0, "Responsive design" },
                    { new Guid("9d31ac91-2f23-4fb5-9db6-33af7732e0e7"), null, 2, "Package name" },
                    { new Guid("9f009a76-0b77-47a3-b9f1-33087b80d739"), null, 2, "Package description" },
                    { new Guid("a51180c6-e6bc-4685-99d4-00463136bd51"), null, 0, "Speed optimization" },
                    { new Guid("a5837702-9f4d-48e1-bf87-fbf4465b6f07"), new Guid("e0046a44-904f-4124-8728-298394557fb6"), 1, "Delivery time" },
                    { new Guid("d96ff989-2f8a-447f-94bf-644868218107"), null, 0, "E-commerce functionality" },
                    { new Guid("f0f7a950-d552-494a-b8a8-2f691c70fd56"), null, 0, "Content upload" },
                    { new Guid("f2b9de5c-8a5d-4615-80b0-b6b093007591"), null, 0, "Hosting setup" }
                });

            migrationBuilder.InsertData(
                table: "Skill",
                columns: new[] { "Id", "Description", "Name", "SkillSubcategoryId" },
                values: new object[,]
                {
                    { new Guid("64a09461-f6a0-4939-a82c-e881013c1d56"), "Involves creating online stores and platforms for e-commerce activities.", "E-Commerce Development", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("67e75e7f-3650-4185-89d6-6d8b40047097"), "Skills in designing and building effective landing pages for websites.", "Landing Pages", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("6c3f127e-c595-429c-807e-074833a17427"), "Focuses on creating websites optimized for dropshipping business models.", "Dropshipping Websites", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("a25caa6a-3327-4b26-a58a-762499422de9"), "Skills related to designing and developing websites for business purposes.", "Business Websites", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("eb2ac5d7-02c8-4e89-a84a-2ce701fb7796"), "Encompasses skills required to build fully functional and feature-rich websites.", "Build a Complete Website", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") }
                });

            migrationBuilder.InsertData(
                table: "SkillCategory",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("24137a2b-b51e-49e3-a541-d782a3d10c4f"), "Skills in programming, software development, and technology solutions fall under this category.", "Programming & Tech" },
                    { new Guid("279c68b7-8ff8-48f2-919d-70d85867f667"), "This category encompasses skills related to visual design, graphic arts, and creative visual communication.", "Graphics & Design" },
                    { new Guid("53747475-a312-45ea-9b73-a490466e5ec4"), "Encompasses skills related to business strategy, management, and entrepreneurial activities.", "Business" },
                    { new Guid("611d7230-bcf2-4dbc-b6c6-9c428ee128b0"), "Skills related to online marketing, advertising, and promotion in the digital realm.", "Digital Marketing" },
                    { new Guid("790ff549-a0f0-4294-b476-d96a16079acd"), "Skills related to data analysis, management, and interpretation.", "Data" },
                    { new Guid("7db5814a-0689-48e6-86a1-e4c8e52ba70e"), "Skills in music composition, audio production, and sound engineering.", "Music & Audio" },
                    { new Guid("9295939b-e9a3-4720-bec5-0983b0e4fbd8"), "This category involves skills related to artificial intelligence, machine learning, and AI-based services.", "AI Services" },
                    { new Guid("9f23dda1-447b-4151-9c32-1847b03800fb"), "This category covers skills in video creation, editing, and animation production.", "Video & Animation" },
                    { new Guid("b2b275a5-4e5f-4936-8c79-918aaa98a8cb"), "Skills in capturing and editing visual images through photography.", "Photography" },
                    { new Guid("fcb14d52-6e95-4ebc-a862-cd28bacbc86d"), "Skills related to content creation, writing, and translation services.", "Writing & Translation" }
                });

            migrationBuilder.InsertData(
                table: "SkillSubcategory",
                columns: new[] { "Id", "Description", "Name", "SkillCategoryId" },
                values: new object[,]
                {
                    { new Guid("0113c75f-ca0d-4b8c-8cd9-2186ec7676a7"), "Deals with understanding and utilizing various website development platforms and frameworks.", "Website Platforms", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("054e9a6d-86a3-4784-b713-29acc654b080"), "Includes miscellaneous skills or services related to the broader category of programming and technology.", "Miscellaneous", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("1d20a6c8-ed40-4136-9225-d3fda08234be"), "Focuses on designing and building applications specifically for mobile devices.", "Mobile App Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("25898e96-1a38-40aa-86c2-36b3fc41b641"), "Involves creating and maintaining websites, focusing on design, functionality, and user experience.", "Website Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("2bd9a64f-3780-4d7c-8839-15228d794db0"), "Involves the development and implementation of conversational agents for automated interactions.", "Chatbots", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("343af1fc-1072-4d4d-bf15-6a43c4d32e7b"), "Encompasses the creation and maintenance of software applications for various platforms.", "Software Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("473f2b4d-7758-4f6e-a9c4-87d651bd78c7"), "Involves providing support services and addressing cybersecurity concerns for software and systems.", "Support & Cybersecurity", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("6e400845-6456-485b-9438-ac8c6cc04c87"), "Encompasses quality assurance, testing, and review processes to ensure software reliability.", "QA & Review", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("831ed0fc-b87b-4847-8eb1-861c9fa5d93d"), "Concerned with the ongoing support, updates, and troubleshooting of existing websites.", "Website Maintenance", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("8afb1888-d817-4e40-839a-3e9b0e6091d6"), "Focuses on creating interactive and engaging video games for various platforms.", "Game Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("d8404f6d-1576-4f60-a738-0206b7c2089d"), "Involves the creation and implementation of artificial intelligence algorithms and systems.", "AI Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("da8140d3-9952-414f-8d1e-c44407e81f78"), "Professionals specializing in software development, coding, and programming.", "Software Developers", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_UserNotification_NotificationId",
                table: "UserNotification",
                column: "NotificationId");

            migrationBuilder.CreateIndex(
                name: "IX_Notification_SenderId",
                table: "Notification",
                column: "SenderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notification_AspNetUsers_SenderId",
                table: "Notification",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserNotification_AspNetUsers_UserId",
                table: "UserNotification",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserNotification_Notification_NotificationId",
                table: "UserNotification",
                column: "NotificationId",
                principalTable: "Notification",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }
    }
}
