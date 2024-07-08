using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkillSync.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedProjectReviewEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectReview",
                columns: table => new
                {
                    ReviewerId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Stars = table.Column<int>(type: "int", maxLength: 5, nullable: false, defaultValue: 1),
                    ReviewAt = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectReview", x => new { x.ProjectId, x.ReviewerId });
                    table.ForeignKey(
                        name: "FK_ProjectReview_AspNetUsers_ReviewerId",
                        column: x => x.ReviewerId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProjectReview_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectReview_ReviewerId",
                table: "ProjectReview",
                column: "ReviewerId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectReview");

            migrationBuilder.DeleteData(
                table: "DropdownOption",
                keyColumn: "Id",
                keyValue: new Guid("5b887f9d-c137-4641-be1c-7e7c2322b35a"));

            migrationBuilder.DeleteData(
                table: "DropdownOption",
                keyColumn: "Id",
                keyValue: new Guid("8f6797bf-82fa-4a96-be35-47e8991f24f4"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("0f30a18d-4074-4ac3-bf35-29e30afd5e89"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("45059886-4bb6-4120-a94b-78cd546bf6ed"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("4b21d6b2-88f0-46ab-8b70-40ee158c90fd"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("4c92e135-1aa9-42c8-84ba-0cb24e55395f"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("5a024545-a427-48e8-9c19-b873fe1df5e8"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("6b343d1c-5068-4d2e-90ce-3ded58ded1b1"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("6b664ebd-63c2-4539-9c5c-effba7467edb"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("6dab43b7-763f-41f4-ac95-db042b2a799b"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("83d5d0f1-ffe2-40a2-91e7-1573d87704c2"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("96f29025-77c3-480b-ba24-d4954cd68934"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("97f74157-7d71-40ec-a994-47cb7889577c"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("97f76982-c91b-4e83-8a50-b7b79a81b82c"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("baf0e89d-c7f4-4067-97d0-0fb00aff46d4"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("c2e28394-74f1-4198-b5a3-51835691ca66"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("d385ed59-ab8b-4963-9833-7e5fcb675526"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("df6456f7-9b2b-4589-ba78-762170c9c93f"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("e52a3674-04e1-42fe-b739-7245cc7df283"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("f0166c25-dec1-4086-aebe-9e65d4314dae"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("038a5ed4-a9f6-4949-a3da-35062507afcf"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("12caca20-5884-4dff-9a65-77c3ae91ea55"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("a10e77c6-2c1a-4f2f-a5a3-214e255252c2"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("ad639acf-d732-4c61-b8c6-ce028d5905c4"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("d66a01af-ce65-40f5-bf91-62c3334475a1"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("074a84b2-1d42-4e50-be47-91905d26d98a"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("141b929c-1b2b-4d9f-8e13-fcd99c6d4c82"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("2ad9ae0a-8ca6-44c0-a26f-41db79da03aa"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("4a967498-f59a-483b-8a07-92f7b2a68cca"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("583bc43c-52f4-44f6-9df4-b7d790e8cdb5"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("695ebde4-d416-4a87-982c-a198eb0883d0"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("811c8d4e-e42a-4e54-9178-0c2c3c3f6035"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("9c81cc22-1c24-430d-9099-ffdfc4ff43d3"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("b9386c93-d434-45b6-9275-a2765ea3ef0f"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("bd84a2e3-875c-4676-9600-7b7b84a33fbf"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("06074e9a-6f33-4f87-8161-6466bd62ae69"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("08b14cc0-a04a-43a1-a0cc-2ee5e96374f0"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("157bacc2-77a0-4be4-830f-e0c07ece9da8"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("29060a86-1892-4d84-8a3b-95db4cf4ea65"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("35f4113c-9705-4baf-a3dd-2c4559a280b0"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("48fdac65-6259-46a5-9677-50a1d6e4ba43"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("6242985a-5a71-46ea-be22-847ca89cbc81"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("81c75518-dd4d-4d28-be03-b4e04828faa6"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("c65e790e-a81c-43ad-bf0d-2396f0b8e1c6"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("dbd8ba95-3105-4198-8f04-0120b0c46014"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("eb7cc34f-c366-4757-ad7d-dca7bdca3c01"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("f9d32425-9b60-4a42-928d-3d2b92657808"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddb34bfe-616a-46a0-af02-b7f29ee25daa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7cae0b32-6ca9-46d7-a3cf-db323cfd4f26", "AQAAAAIAAYagAAAAENTafJKqflR27bkG7XuA8G0DKscLsJyhvoVGhMt1qhL3GoJwgM9L/ly0P1e4ux8N/A==", "30c4b0fd-0a63-4712-9e71-430de1d64817" });

            migrationBuilder.InsertData(
                table: "DropdownOption",
                columns: new[] { "Id", "IncrementValue", "LowerInterval", "UpperInterval" },
                values: new object[,]
                {
                    { new Guid("de4cc996-6367-4757-b928-b82e81781cdd"), 1, 1, 10 },
                    { new Guid("fd183520-c41f-46c7-aea2-ead656a4e063"), 1, 1, 50 }
                });

            migrationBuilder.InsertData(
                table: "Feature",
                columns: new[] { "Id", "DropdownOptionId", "InputType", "Name" },
                values: new object[,]
                {
                    { new Guid("1cd79aff-d32b-498e-8bf0-79123537463a"), null, 0, "Opt-in form" },
                    { new Guid("20b71085-0f2b-4cc4-8877-b30f15542629"), null, 2, "Package description" },
                    { new Guid("43eb646f-29f1-41e5-b223-c2045e4bed76"), null, 1, "Revisions" },
                    { new Guid("4e3e5532-403c-4996-b89f-d37a2b766b02"), null, 0, "Responsive design" },
                    { new Guid("59194a9f-6a89-4b5c-b1b1-f0b12ae2b31e"), null, 0, "Content upload" },
                    { new Guid("5cb35bc0-b526-4625-bb01-ed8b2d8ae0d7"), null, 0, "E-commerce functionality" },
                    { new Guid("60ae0ce9-de73-4dc0-9008-d372a0330139"), null, 0, "Social media" },
                    { new Guid("7067dc14-eaf3-4d6d-8dab-66f7cd93a5c5"), new Guid("e0046a44-904f-4124-8728-298394557fb6"), 1, "Number of products" },
                    { new Guid("73c85bb6-e3d5-401b-a60a-ffd0c557b604"), null, 0, "Payment processing" },
                    { new Guid("7ad91845-612f-4819-8503-8efddc864ac3"), null, 0, "Speed optimization" },
                    { new Guid("81d239f3-6d98-410f-9e67-3f820976bb5e"), new Guid("8a4b9c88-1f53-4ab9-9052-f8594d732430"), 1, "Number of pages" },
                    { new Guid("909c9d63-176e-4717-9453-078949c62bbe"), null, 2, "Package name" },
                    { new Guid("911781bf-4eb7-4d7f-8adc-fb462f9c581c"), new Guid("e0046a44-904f-4124-8728-298394557fb6"), 1, "Delivery time" },
                    { new Guid("a3e4142c-f1ec-4e32-ba2a-9b3cdf00417e"), null, 2, "Price" },
                    { new Guid("cbe26205-f167-4c42-810f-0986d9fc9f75"), new Guid("8a4b9c88-1f53-4ab9-9052-f8594d732430"), 1, "Plugins/extensions " },
                    { new Guid("d2eccd7a-fe7c-4241-95d3-7f58fc2cd11b"), null, 0, "Functional website" },
                    { new Guid("e3546cde-96bc-493a-8ed4-82099b044601"), null, 0, "Hosting setup" },
                    { new Guid("e8840d1e-d001-4cdd-8fb0-04191c7bc9bb"), null, 0, "Autoresponder" }
                });

            migrationBuilder.InsertData(
                table: "Skill",
                columns: new[] { "Id", "Description", "Name", "SkillSubcategoryId" },
                values: new object[,]
                {
                    { new Guid("17a599ea-fa83-4d41-9899-20f206138d1b"), "Focuses on creating websites optimized for dropshipping business models.", "Dropshipping Websites", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("3b0fa5b0-b6f2-40e4-8732-760588ac4c6c"), "Involves creating online stores and platforms for e-commerce activities.", "E-Commerce Development", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("464cff32-8f36-4c34-92b6-23d6e3f5b672"), "Skills in designing and building effective landing pages for websites.", "Landing Pages", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("b9766d89-8cd4-4d2a-a759-ff0edd924001"), "Encompasses skills required to build fully functional and feature-rich websites.", "Build a Complete Website", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("ed7f8d96-14d8-49c3-b1cc-a1249ca9432e"), "Skills related to designing and developing websites for business purposes.", "Business Websites", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") }
                });

            migrationBuilder.InsertData(
                table: "SkillCategory",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("23ab81aa-79e4-4a1f-ba9c-a4466e826621"), "Skills related to data analysis, management, and interpretation.", "Data" },
                    { new Guid("436931a7-5ce9-4dbd-9281-fc7edeef36b4"), "Encompasses skills related to business strategy, management, and entrepreneurial activities.", "Business" },
                    { new Guid("68001311-c576-43c3-9a1f-e56df3fe0296"), "This category covers skills in video creation, editing, and animation production.", "Video & Animation" },
                    { new Guid("84cfb2af-d3ea-451d-a874-6e8c3908702d"), "Skills in capturing and editing visual images through photography.", "Photography" },
                    { new Guid("8f3be2f9-e25b-45ec-8908-988f05509d3d"), "Skills related to content creation, writing, and translation services.", "Writing & Translation" },
                    { new Guid("9d1d880d-1988-4613-b861-bdcca72ff838"), "This category involves skills related to artificial intelligence, machine learning, and AI-based services.", "AI Services" },
                    { new Guid("c2c62613-e6e6-44bc-acc8-4814f4dd7c43"), "Skills in programming, software development, and technology solutions fall under this category.", "Programming & Tech" },
                    { new Guid("d3377ad7-28f9-4c0d-ad45-a8398a29f38e"), "This category encompasses skills related to visual design, graphic arts, and creative visual communication.", "Graphics & Design" },
                    { new Guid("e1a56522-6775-4eaa-a302-9328e9c20fd3"), "Skills related to online marketing, advertising, and promotion in the digital realm.", "Digital Marketing" },
                    { new Guid("e7c1c33a-d691-4419-9653-fb3f7ba359a9"), "Skills in music composition, audio production, and sound engineering.", "Music & Audio" }
                });

            migrationBuilder.InsertData(
                table: "SkillSubcategory",
                columns: new[] { "Id", "Description", "Name", "SkillCategoryId" },
                values: new object[,]
                {
                    { new Guid("02f713a4-d399-40b2-bdce-7198c23b6eac"), "Concerned with the ongoing support, updates, and troubleshooting of existing websites.", "Website Maintenance", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("052b4552-1996-485f-b934-1a5831948a3b"), "Involves providing support services and addressing cybersecurity concerns for software and systems.", "Support & Cybersecurity", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("12ce8ea8-aaff-4642-b998-a54cd940f8ee"), "Deals with understanding and utilizing various website development platforms and frameworks.", "Website Platforms", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("14751302-8225-4df0-a724-a825cdb2fcd1"), "Focuses on creating interactive and engaging video games for various platforms.", "Game Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("3f2a4b27-5f15-495e-b88c-e7f92c30b163"), "Involves the creation and implementation of artificial intelligence algorithms and systems.", "AI Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("3f6a4383-8b79-43b2-8429-5cae20c52bbf"), "Encompasses the creation and maintenance of software applications for various platforms.", "Software Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("4824f1d7-a462-4649-b66c-08a3aec113d9"), "Encompasses quality assurance, testing, and review processes to ensure software reliability.", "QA & Review", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("8a3559fb-eeaa-4a6e-a6b5-45d0fc65b76e"), "Professionals specializing in software development, coding, and programming.", "Software Developers", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("8aa40bb4-c47d-4716-b0a1-b12b822a7b01"), "Involves creating and maintaining websites, focusing on design, functionality, and user experience.", "Website Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("953e8791-6b9e-474a-b3f4-9422c431e576"), "Focuses on designing and building applications specifically for mobile devices.", "Mobile App Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("c92d238b-45e5-4aaf-848a-d34999c3e339"), "Includes miscellaneous skills or services related to the broader category of programming and technology.", "Miscellaneous", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("ee42102f-a2ea-4060-9c0c-5a73a1ec4ca7"), "Involves the development and implementation of conversational agents for automated interactions.", "Chatbots", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") }
                });
        }
    }
}
