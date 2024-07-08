using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkillSync.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserFavoriteProjectsEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserFavoriteProject",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserFavoriteProject", x => new { x.UserId, x.ProjectId });
                    table.ForeignKey(
                        name: "FK_UserFavoriteProject_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserFavoriteProject_Project_ProjectId",
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
                values: new object[] { "558237b5-71f4-4924-bad5-13f34f9692d7", "AQAAAAIAAYagAAAAECwtdSJQM4hKz724yYnmljEf7Z44HUgHnB8/6yRi+waeysp7uLExBJz6WM/M/eWE7A==", "49f03d94-c2b4-4385-831a-2db3ca016e47" });

            migrationBuilder.CreateIndex(
                name: "IX_UserFavoriteProject_ProjectId",
                table: "UserFavoriteProject",
                column: "ProjectId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserFavoriteProject");

            migrationBuilder.DeleteData(
                table: "DropdownOption",
                keyColumn: "Id",
                keyValue: new Guid("7bc6ffc0-83de-4262-9fd4-b1a1a3b3b0cf"));

            migrationBuilder.DeleteData(
                table: "DropdownOption",
                keyColumn: "Id",
                keyValue: new Guid("da90b4d1-7663-4955-93c3-10f9255444e9"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("0160686a-da8e-492f-b327-39ba5e755b19"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("100548e9-d51b-4486-a253-1516ff927626"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("18238a5a-a6a9-4434-a149-d557b63989ae"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("3102b202-cb6a-46fe-b68d-2b5c02fe8ea2"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("3973d186-6815-4fab-ad76-21e9afacc2b4"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("3d3870f9-68e6-4c22-a360-09cf08e70348"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("6a4f000e-f61e-4180-b22e-b34ca6d19f8c"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("744b5596-2e26-493e-aaab-927e96101c00"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("7c06dd2a-3f8c-41f0-80fd-b691fbc0a910"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("83ae8a7a-bf04-430d-bd77-e73a91f99dfa"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("90ef0114-a89b-4d18-aae8-70d9f0e12648"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("a0d58927-77d0-4a53-8ca6-3ed83d4b1c0e"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("afb5bcc7-1d6f-4872-88a5-fe8dccabba7d"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("b3afe9a5-9076-47c4-bb37-cee49109ec37"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("e7cacbd2-7669-4476-993f-64e98263e219"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("0b022128-7eb4-4499-8013-09294c4ddcf2"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("25e99a95-45da-4465-8981-b5dd19c7386b"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("5202027f-ef3b-4dfe-a7dd-765fe5ccf5aa"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("903e0447-c479-49cc-a29f-93cd9ea1aa93"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("98db778a-81bc-42c4-b93e-e9d64f995b65"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("01f5840b-b6f9-463d-9cf3-8c786172202b"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("3b1c084a-b9bf-4ee5-8539-7074853fb904"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("4920d2dd-e6af-4d11-83ac-becfc87f3681"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("5b390391-4f39-4b81-b6fb-e39b34b30fe0"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("5ce620e7-0ecb-473d-b630-f50bd2bcda20"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("640c288a-9a9c-476b-90b5-f73aea91551a"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("70385480-db66-4595-a0e3-28dddd4c1109"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("7cb2b40c-3f53-4f7a-95a7-a807acaae9c5"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("846ffab6-c4f2-4ba9-aa98-fd4ca114441b"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("e8ba438c-6a5b-404b-ac87-74fe2388fa8a"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("35c207cc-c220-4f82-9dc8-9fc0ccf8219f"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("4e0af15c-2956-4b26-ad86-3162f714cf62"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("66efb135-8768-4cba-b1d4-3994e0f098c2"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("7301d5e5-92b4-4385-ad4c-4ed31e163e54"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("78f094bd-2351-4388-9be5-5a2f278cdc8f"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("7f4ed4b1-53e9-43b6-b5b3-1ee1cd7ced2e"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("80546c21-1f14-489f-8f29-133f6a5dd437"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("842aa415-5623-491a-a73f-6e6de2508d4c"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("c5ad0b41-d270-4f21-b221-14134efc260a"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("d2a9fc50-883a-4f75-81bc-32ddd5e31a07"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("dca2aabf-c516-4d24-86d4-5f3847b3d9aa"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("e7a96c5e-60be-45bf-b490-263cc3005744"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddb34bfe-616a-46a0-af02-b7f29ee25daa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "83480d82-edc7-40e2-a4dd-448571ed422c", "AQAAAAIAAYagAAAAEBM3GcPeD52vNtzh6dShlPU1BQT0xvmiQykv9CfPtOgMKrC9sYtnCHSqjSHy+WNLxA==", "10c6a5a1-b75c-436d-b78e-126cb20c1de8" });

            migrationBuilder.InsertData(
                table: "DropdownOption",
                columns: new[] { "Id", "IncrementValue", "LowerInterval", "UpperInterval" },
                values: new object[,]
                {
                    { new Guid("1127ea0f-54ff-41d1-9356-0a28b9e8e64c"), 1, 1, 10 },
                    { new Guid("a77d1c62-b5cd-4a58-b118-a204381a297e"), 1, 1, 50 }
                });

            migrationBuilder.InsertData(
                table: "Feature",
                columns: new[] { "Id", "DropdownOptionId", "InputType", "Name" },
                values: new object[,]
                {
                    { new Guid("043b9933-6280-4f23-9078-6c0a6ef70ef2"), null, 0, "E-commerce functionality" },
                    { new Guid("0c2a2958-d312-4660-a88a-68e8464f5a7c"), null, 0, "Autoresponder" },
                    { new Guid("1a8699cd-3f89-46c5-880a-2e36796aeacc"), null, 0, "Content upload" },
                    { new Guid("609333f1-4e90-4e41-8b35-7ff12e4167a2"), null, 0, "Functional website" },
                    { new Guid("823c2ba6-754b-44b0-93ae-047785704f32"), null, 0, "Payment processing" },
                    { new Guid("a3e7ba6d-6a3d-4bcc-b56f-53b810ad95e1"), null, 0, "Responsive design" },
                    { new Guid("a9b1b13e-dc2c-41d7-99f0-ae38bc2ef419"), new Guid("e0046a44-904f-4124-8728-298394557fb6"), 1, "Number of products" },
                    { new Guid("b5f8b6f3-a6e4-40c1-8548-98e791f3a7ad"), null, 0, "Hosting setup" },
                    { new Guid("cde51f64-4da8-4b7c-9827-12246d5cbaa7"), null, 1, "Revisions" },
                    { new Guid("d040306c-24dd-49aa-ae4d-e0fb95842978"), new Guid("8a4b9c88-1f53-4ab9-9052-f8594d732430"), 1, "Number of pages" },
                    { new Guid("d49ae00b-3000-4502-82aa-da1328b9bafc"), null, 0, "Speed optimization" },
                    { new Guid("d4e754ae-45ee-46a1-9c09-b2aa0275306a"), null, 2, "Price" },
                    { new Guid("e0e881ab-bd31-4078-9efa-df6c56aced16"), new Guid("8a4b9c88-1f53-4ab9-9052-f8594d732430"), 1, "Plugins/extensions " },
                    { new Guid("e8c54c33-73fc-41d8-88a8-70ecb380423f"), null, 0, "Social media" },
                    { new Guid("edd4081e-ed6d-468c-8dd7-ae80ebd5d9bf"), null, 0, "Opt-in form" }
                });

            migrationBuilder.InsertData(
                table: "Skill",
                columns: new[] { "Id", "Description", "Name", "SkillSubcategoryId" },
                values: new object[,]
                {
                    { new Guid("8ee8b0c3-27a4-412e-95f3-259c2f0142ac"), "Skills in designing and building effective landing pages for websites.", "Landing Pages", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("aeb62221-d5bd-43dc-88b7-fe30f9b0fae0"), "Focuses on creating websites optimized for dropshipping business models.", "Dropshipping Websites", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("c1f27d69-c694-47c4-aa55-b0f3643d8261"), "Involves creating online stores and platforms for e-commerce activities.", "E-Commerce Development", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("dec6f4cd-0a90-4d38-a8d9-483f1f1208e1"), "Encompasses skills required to build fully functional and feature-rich websites.", "Build a Complete Website", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("fd846cd5-0147-4d63-8fda-91d811d0ab38"), "Skills related to designing and developing websites for business purposes.", "Business Websites", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") }
                });

            migrationBuilder.InsertData(
                table: "SkillCategory",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("0e5d0d72-ee6f-4dcd-a4a7-298793a18a55"), "This category involves skills related to artificial intelligence, machine learning, and AI-based services.", "AI Services" },
                    { new Guid("374bdbc7-aa1d-4930-8476-8e08ed248db7"), "Skills in music composition, audio production, and sound engineering.", "Music & Audio" },
                    { new Guid("4ac52214-d818-46b2-8da4-e1590920a81b"), "Skills in programming, software development, and technology solutions fall under this category.", "Programming & Tech" },
                    { new Guid("72afde51-04b0-4d14-9633-ca4dbde50228"), "Skills in capturing and editing visual images through photography.", "Photography" },
                    { new Guid("8c8bd49c-09e1-4de7-b0ec-8b77533e20ce"), "Skills related to content creation, writing, and translation services.", "Writing & Translation" },
                    { new Guid("8fbfe504-4f25-4dde-8c27-53edf0f68f54"), "Encompasses skills related to business strategy, management, and entrepreneurial activities.", "Business" },
                    { new Guid("9943adfd-e4cf-4330-985b-77e74bff6d0e"), "Skills related to online marketing, advertising, and promotion in the digital realm.", "Digital Marketing" },
                    { new Guid("bd84f14d-46e9-4cf4-bd27-25b5f9f12084"), "This category covers skills in video creation, editing, and animation production.", "Video & Animation" },
                    { new Guid("c673ab19-6e9f-4763-86b3-830446947ccb"), "Skills related to data analysis, management, and interpretation.", "Data" },
                    { new Guid("cf916ff3-eb8c-4cec-baf0-4b4b01940f98"), "This category encompasses skills related to visual design, graphic arts, and creative visual communication.", "Graphics & Design" }
                });

            migrationBuilder.InsertData(
                table: "SkillSubcategory",
                columns: new[] { "Id", "Description", "Name", "SkillCategoryId" },
                values: new object[,]
                {
                    { new Guid("2b5ddf08-fe51-4d09-b02b-96e0e258515a"), "Involves the creation and implementation of artificial intelligence algorithms and systems.", "AI Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("320e6a7a-e06f-4e4e-8cae-f40453efd24a"), "Concerned with the ongoing support, updates, and troubleshooting of existing websites.", "Website Maintenance", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("539286df-9999-4117-9f6e-e8456f22e0f7"), "Focuses on designing and building applications specifically for mobile devices.", "Mobile App Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("57be7b45-ae6d-40a0-a1c0-6816d42afc26"), "Involves creating and maintaining websites, focusing on design, functionality, and user experience.", "Website Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("67e87bd9-b9cf-4582-99fd-ed4e1b9142d5"), "Includes miscellaneous skills or services related to the broader category of programming and technology.", "Miscellaneous", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("6878a3ee-0f17-47d5-b50c-f2690d6934f2"), "Focuses on creating interactive and engaging video games for various platforms.", "Game Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("a9fb6842-2841-407f-8152-d139ab18cca9"), "Encompasses the creation and maintenance of software applications for various platforms.", "Software Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("cf166cac-f04c-4d21-b3e7-35b50c570a45"), "Deals with understanding and utilizing various website development platforms and frameworks.", "Website Platforms", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("d55904fb-cf97-49c9-ac49-141ea80f1c5e"), "Professionals specializing in software development, coding, and programming.", "Software Developers", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("d9810de3-8a34-43e7-828d-23a6067a1786"), "Involves providing support services and addressing cybersecurity concerns for software and systems.", "Support & Cybersecurity", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("f0944f78-9173-4d16-8d61-7f64e6afea4f"), "Involves the development and implementation of conversational agents for automated interactions.", "Chatbots", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("f9755d23-7cf8-49cb-8831-17c7c2b4d0e1"), "Encompasses quality assurance, testing, and review processes to ensure software reliability.", "QA & Review", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") }
                });
        }
    }
}
