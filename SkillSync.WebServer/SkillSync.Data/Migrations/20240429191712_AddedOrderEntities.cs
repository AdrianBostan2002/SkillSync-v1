using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkillSync.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedOrderEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CustomerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Status = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UntilTo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CompletedAt = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Order_AspNetUsers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Order_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderContent",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OrderId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Purpose = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderContent", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderContent_Order_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Order",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Order_CustomerId",
                table: "Order",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ProjectId",
                table: "Order",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderContent_OrderId",
                table: "OrderContent",
                column: "OrderId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserNotification_AspNetUsers_ReceiverId",
                table: "UserNotification");

            migrationBuilder.DropForeignKey(
                name: "FK_UserNotification_AspNetUsers_SenderId",
                table: "UserNotification");

            migrationBuilder.DropTable(
                name: "OrderContent");

            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DeleteData(
                table: "DropdownOption",
                keyColumn: "Id",
                keyValue: new Guid("2eab09aa-d20e-4488-814b-7aef7b5e060d"));

            migrationBuilder.DeleteData(
                table: "DropdownOption",
                keyColumn: "Id",
                keyValue: new Guid("cef1346d-e4e9-4c00-8df2-da0fdea77738"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("008fde91-47f2-4646-be00-9737e21b9200"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("042197e1-497f-4c8d-8205-89d96d7b9625"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("0f8a8362-a095-4b30-bfbd-0d5f99afeddd"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("133e56ad-270b-4979-948d-7f908519c2e5"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("154ed73b-990a-4243-badd-6ef7345df485"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("19779139-3811-41ee-9f6e-d586f854d83b"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("360e8150-eee1-40d2-abf2-a66e82dee391"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("3d3e2ada-6551-463b-b8f1-96c208833b66"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("585b3ff6-7e9b-40c5-939b-2b280f635d26"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("59b54baa-ef2d-4752-a10c-0396d89a6f3b"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("88648780-448c-4db5-8296-dcd759a5ae32"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("918f2360-6613-43b2-9f42-7cc182c49862"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("abfadeb7-232b-4528-99fd-f1e30daf7c6d"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("b5ca34e3-7fc2-4598-b585-59b21829f022"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("b67353ea-a325-4417-a5fe-c67a8ccab714"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("d31fb5cc-4dd2-4e97-9ead-c1eed76c122a"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("e202ebed-7c3c-4639-8691-e1eabe714f17"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("e532a1ef-5c9b-42e7-97d4-b04ec1c84861"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("028c59b5-bc28-452e-beb5-c4d15bafd873"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("0409eb99-0b12-4243-9f84-dfc69798d755"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("816c8d4d-b6c7-4a0a-8d76-3dff6e395b26"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("cfb80acc-03ce-4d3c-a1a4-427abbb9f93a"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("d5c22c51-4de6-4877-92f6-502ed76269b8"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("07d3d424-55a3-41df-a2f0-f15354294cfd"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("4a596ad2-e3d1-4ee3-9e30-a0538c914df9"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("554f07e0-94da-4744-8827-6f39ea22a75d"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("6c29a308-7b5b-4e84-afd8-4ecd8e3924b3"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("753d0c92-fb7b-4295-9c17-6061550ed54e"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("851f5c9f-37f4-4a59-8ab0-a479aa7de028"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("87eac28b-463f-4971-b89a-d768bb17a3b9"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("e5c39090-d287-46d6-ac54-3f8a9f5eeb0d"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("ea142354-6ae9-4b09-9eeb-de08b785af51"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("feb75e26-3be2-49ee-a325-c00dd99f96ea"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("0188a931-b93b-4c23-b5ea-bef96e94d551"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("0a1945f3-b824-44cb-b304-900f5dbc1900"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("4aa1ba5a-bb9e-4d01-93b4-bece642c4f50"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("6ac4d5b2-8a63-4c29-89c9-2fd0605e2b6d"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("74b4dd68-0c1f-4a44-80a2-4719f4d1bff6"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("988ae729-4c9f-4fb1-9fc5-d62605950e77"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("9a3be120-b408-49da-a403-6936e186b2cc"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("b341b805-9455-45bf-975e-6611fc2e6b39"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("b8f78954-ef50-4709-8693-0282f2219f3a"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("d19915de-40da-4c01-88f3-4bd2d136e96c"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("e3dd1b8f-58dd-4df2-be29-a7113904cb03"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("fcf284b4-afcf-4718-9a55-6537924a886d"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddb34bfe-616a-46a0-af02-b7f29ee25daa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f61cd93e-b7ce-45ae-957e-58a94028d9b3", "AQAAAAIAAYagAAAAEBlRyclkX+7h3iVEs2ICqac5ggPG3wy3KEvH2g42fus7kTfCAE5BdXNdT4iNbUIv5g==", "abd4d0c3-bb5f-42f3-9766-be518d538be6" });

            migrationBuilder.InsertData(
                table: "DropdownOption",
                columns: new[] { "Id", "IncrementValue", "LowerInterval", "UpperInterval" },
                values: new object[,]
                {
                    { new Guid("4fe80be1-bd4d-4e17-b86e-c171d1cd3043"), 1, 1, 50 },
                    { new Guid("e4361952-275b-456a-8378-ccab0ece7ffc"), 1, 1, 10 }
                });

            migrationBuilder.InsertData(
                table: "Feature",
                columns: new[] { "Id", "DropdownOptionId", "InputType", "Name" },
                values: new object[,]
                {
                    { new Guid("08455e11-fff8-46a6-bf82-e6c25c64530b"), new Guid("8a4b9c88-1f53-4ab9-9052-f8594d732430"), 1, "Plugins/extensions " },
                    { new Guid("1ea9f26b-21d2-4ea6-94c2-0bbb08b161e7"), new Guid("e0046a44-904f-4124-8728-298394557fb6"), 1, "Number of products" },
                    { new Guid("3746b3ff-f028-4744-b18d-e2c61770dc0b"), null, 0, "Hosting setup" },
                    { new Guid("3e2c1483-e91f-4bd0-97ba-f1ffe0df7f87"), null, 0, "Social media" },
                    { new Guid("418a7cfe-4735-4131-a0aa-e7c4022bc872"), null, 2, "Package name" },
                    { new Guid("46f3c054-6b49-4911-95de-240e9637d242"), null, 1, "Revisions" },
                    { new Guid("4aeca06b-f100-455c-8e63-a5df445121e3"), null, 0, "Autoresponder" },
                    { new Guid("6c8b9526-10b5-41fe-aedc-08ed9538ec48"), new Guid("8a4b9c88-1f53-4ab9-9052-f8594d732430"), 1, "Number of pages" },
                    { new Guid("933045da-4ebf-4c2c-b2b8-eabba1aaba43"), null, 0, "E-commerce functionality" },
                    { new Guid("9d86e03a-4586-4fd1-a3d2-1a84ddcf934a"), new Guid("e0046a44-904f-4124-8728-298394557fb6"), 1, "Delivery time" },
                    { new Guid("ae24aed4-a998-4a36-9942-b19d98454f67"), null, 0, "Functional website" },
                    { new Guid("b0eccba5-1b05-4964-96a0-a288fa3a6674"), null, 0, "Opt-in form" },
                    { new Guid("b202da7d-3bd5-42ce-8b1e-44637696d003"), null, 0, "Responsive design" },
                    { new Guid("bcd12434-07d3-45c1-92d7-88d53c2d1113"), null, 0, "Payment processing" },
                    { new Guid("c9880184-d998-4929-8b38-c5aed2d1a180"), null, 0, "Speed optimization" },
                    { new Guid("d6fc6902-0a5a-43b5-9af3-0277fa28544b"), null, 0, "Content upload" },
                    { new Guid("ee10af35-cd32-4d36-aeb5-3e2e404071c0"), null, 2, "Price" },
                    { new Guid("f3fd4ef9-425b-4eb0-b46a-4736f9638ca0"), null, 2, "Package description" }
                });

            migrationBuilder.InsertData(
                table: "Skill",
                columns: new[] { "Id", "Description", "Name", "SkillSubcategoryId" },
                values: new object[,]
                {
                    { new Guid("1ff02336-56c7-4e47-bf9b-2c3e59b0393e"), "Skills in designing and building effective landing pages for websites.", "Landing Pages", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("47d09f38-fece-4137-add3-e944941382b3"), "Skills related to designing and developing websites for business purposes.", "Business Websites", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("5124bb56-5560-478b-86e3-003ad35e57fc"), "Focuses on creating websites optimized for dropshipping business models.", "Dropshipping Websites", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("70d79041-9b0a-433a-9164-14911679a827"), "Involves creating online stores and platforms for e-commerce activities.", "E-Commerce Development", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("97e07e65-31bf-4928-b9f8-224012b24e1a"), "Encompasses skills required to build fully functional and feature-rich websites.", "Build a Complete Website", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") }
                });

            migrationBuilder.InsertData(
                table: "SkillCategory",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("34712620-679f-48aa-b478-4561747bf2e9"), "Skills in music composition, audio production, and sound engineering.", "Music & Audio" },
                    { new Guid("40f240ec-8e5f-454a-b17f-e74084c6121d"), "This category covers skills in video creation, editing, and animation production.", "Video & Animation" },
                    { new Guid("72a5a6c6-d62d-404e-a1bb-b938f28aaf02"), "This category encompasses skills related to visual design, graphic arts, and creative visual communication.", "Graphics & Design" },
                    { new Guid("8b5fcf34-e4ea-4f21-bdb5-038ffa1ffbe7"), "Encompasses skills related to business strategy, management, and entrepreneurial activities.", "Business" },
                    { new Guid("8cf4ce8c-6f68-42c4-850a-35cfd3e52189"), "Skills related to content creation, writing, and translation services.", "Writing & Translation" },
                    { new Guid("9321b761-9264-40d2-9020-856200c3d7fb"), "Skills in capturing and editing visual images through photography.", "Photography" },
                    { new Guid("9b0c40bb-e7fb-4ebf-8fb8-50e549a694af"), "Skills related to online marketing, advertising, and promotion in the digital realm.", "Digital Marketing" },
                    { new Guid("c60d2d97-eda3-4a66-acac-e90402a89ce8"), "This category involves skills related to artificial intelligence, machine learning, and AI-based services.", "AI Services" },
                    { new Guid("c7fe2560-e81b-4a57-857f-e49874c34529"), "Skills in programming, software development, and technology solutions fall under this category.", "Programming & Tech" },
                    { new Guid("e36ec5b5-6a1e-4371-96e9-6a18b05b1526"), "Skills related to data analysis, management, and interpretation.", "Data" }
                });

            migrationBuilder.InsertData(
                table: "SkillSubcategory",
                columns: new[] { "Id", "Description", "Name", "SkillCategoryId" },
                values: new object[,]
                {
                    { new Guid("25a57893-c60f-436d-9064-61943ecbd2ee"), "Professionals specializing in software development, coding, and programming.", "Software Developers", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("2cefccc7-d845-48a0-9b42-cd74a4bb62e0"), "Involves the creation and implementation of artificial intelligence algorithms and systems.", "AI Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("4cd8d2b7-0c0c-4153-b99c-9cb5dffa62e2"), "Involves the development and implementation of conversational agents for automated interactions.", "Chatbots", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("519ff938-994e-4e11-8e65-30992d5c89eb"), "Encompasses quality assurance, testing, and review processes to ensure software reliability.", "QA & Review", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("5542f2bd-a8ec-474d-942b-f524212d0d39"), "Involves providing support services and addressing cybersecurity concerns for software and systems.", "Support & Cybersecurity", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("81b06e13-a2dc-4275-be48-607192feef40"), "Focuses on designing and building applications specifically for mobile devices.", "Mobile App Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("8223d6db-c16f-4f1d-90cc-76951988ce0f"), "Concerned with the ongoing support, updates, and troubleshooting of existing websites.", "Website Maintenance", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("99182ebc-efaa-4767-86d6-d02d0563ddfb"), "Deals with understanding and utilizing various website development platforms and frameworks.", "Website Platforms", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("afd9646e-985c-4520-9c38-fde23a446f43"), "Focuses on creating interactive and engaging video games for various platforms.", "Game Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("ddeebca8-0131-4bd1-ab65-7b90b0ff27b6"), "Encompasses the creation and maintenance of software applications for various platforms.", "Software Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("f0242954-c9ef-4ac4-bbe6-34fd8ced0fac"), "Involves creating and maintaining websites, focusing on design, functionality, and user experience.", "Website Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("f67ffaa3-2b75-46a4-b930-4316e8d729bc"), "Includes miscellaneous skills or services related to the broader category of programming and technology.", "Miscellaneous", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_UserNotification_AspNetUsers_ReceiverId",
                table: "UserNotification",
                column: "ReceiverId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserNotification_AspNetUsers_SenderId",
                table: "UserNotification",
                column: "SenderId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
