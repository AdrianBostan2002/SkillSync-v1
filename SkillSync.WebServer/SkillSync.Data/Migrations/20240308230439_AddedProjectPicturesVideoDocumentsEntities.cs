using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkillSync.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedProjectPicturesVideoDocumentsEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProjectDocument",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectDocument", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectDocument_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectPicture",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectPicture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectPicture_Project_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Project",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProjectVideo",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProjectId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectVideo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProjectVideo_Project_ProjectId",
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
                values: new object[] { "919a85db-a713-49bb-8820-406d428fbaf2", "AQAAAAIAAYagAAAAEDa68KM0U/uYU+4M3EBSI+I2ti+vgSRbOScNzr3QEwms034h10zFJ596YYYq6eQNkA==", "eabe98b8-36cb-4146-8c4f-2e7fa986e929" });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectDocument_ProjectId",
                table: "ProjectDocument",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectPicture_ProjectId",
                table: "ProjectPicture",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectVideo_ProjectId",
                table: "ProjectVideo",
                column: "ProjectId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProjectDocument");

            migrationBuilder.DropTable(
                name: "ProjectPicture");

            migrationBuilder.DropTable(
                name: "ProjectVideo");

            migrationBuilder.DeleteData(
                table: "DropdownOption",
                keyColumn: "Id",
                keyValue: new Guid("5735ef60-c31f-4275-b7cf-b918239ef5c4"));

            migrationBuilder.DeleteData(
                table: "DropdownOption",
                keyColumn: "Id",
                keyValue: new Guid("b455b7bf-b66d-4e79-be47-7be1eafd3b1a"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("139e534f-2a62-43af-9585-b27022d39321"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("23472e43-19ae-47fc-91df-edcac42743ee"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("382d90de-54c2-43f6-9f5b-a96f977e7779"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("477fcdac-39be-4043-9b87-7e778801dde5"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("5333e4ab-c761-4fb4-903a-017fc0527de9"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("6174d4d0-1a4c-4fe9-890e-bb8d81bc0594"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("621b15f0-6cc5-4f6d-821b-744525064ae8"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("65ffad7e-020f-4a48-864a-8de905217860"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("722f19ab-c3d1-4231-8f86-73858e672b1e"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("a29db899-d12b-4bcd-b368-cebcef99bc92"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("a765272b-a3cf-40bf-94d8-17f90003c1f9"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("bfbf0457-5957-40db-b381-2131f9cf2188"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("c64c4b69-41cd-494e-b588-6039a919f606"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("cf88b7f1-e303-41cc-b9ab-89022d2b163c"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("ee38c180-5136-49be-b2a5-b7f964acd082"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("61f5f9dc-2e31-46ac-aff3-a15ae7390746"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("6d56bc54-c8ea-4f0d-96e3-c0a5458de165"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("a2befd7a-919d-4a37-ad82-50ff95a0a6d7"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("b9c0d5ca-45a8-4b2a-acc8-98fdce0c70a2"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("dd9f9b21-146b-47e7-8b17-6e943cd877ac"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("0d8bdf66-5e82-4f16-b0ca-238f4e27fc62"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("0edb8be8-703b-4f36-8c1f-65b899caae9f"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("5d0ed3ce-e5ca-4942-a1f8-181fad390f86"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("74fb526c-4b06-4dcf-b325-2455350d31ce"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("8a206920-2511-468e-9fa0-6b4dcd14274c"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("8ba73564-8bc7-4119-bc98-43e3d2ca2176"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("df8b46b3-f1fe-414c-af0a-2c58e6c60e6e"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("e2e331dd-f30a-44fe-902a-62eaec6037b6"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("f51afbec-9eb8-4ade-919e-359cab8fa6bc"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("fa80e457-bb6a-4f35-9e0b-5800c8bc6be5"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("1251d5bb-7761-4ee5-8904-4a37c7e46150"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("15fad048-7022-4179-ad19-b5e5ae457bd1"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("2b0accc7-4c9c-4192-98b4-8bd99b8e23aa"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("2d0ac188-e17a-41f3-80b0-1965dd9ed730"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("3aa10986-a952-4d85-8e10-145e075d7455"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("50089c00-ea58-4db1-91a1-a8427b550135"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("63f99aaf-dd51-4f8c-b8a6-ba1b44496b95"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("85e81e68-bc36-4565-838f-c9c25dbe53ef"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("94e44b0d-2628-4cdd-8b5b-5b41383ff7d8"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("9910f1e4-0561-4ac5-93c6-d07636aa7fb9"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("aea59137-a676-491f-a80e-a2ad7e7492d8"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("b4d537f1-f8cd-4575-918b-1e48ae7b0b32"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddb34bfe-616a-46a0-af02-b7f29ee25daa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "9e515fda-6763-40fa-ad97-9dd429f1c11f", "AQAAAAIAAYagAAAAEIcTkvFfE1wZ4tK2AoUkt29PBuQ+8vuBwfBExBjCDQWIZ4Kx40WATucuCZ3/nANGEg==", "b6d132e4-bd00-4f40-a8ce-5d83ba0f4bd7" });

            migrationBuilder.InsertData(
                table: "DropdownOption",
                columns: new[] { "Id", "IncrementValue", "LowerInterval", "UpperInterval" },
                values: new object[,]
                {
                    { new Guid("cf8fe3f6-74c7-43d4-bfb6-b5d016a89b02"), 1, 1, 50 },
                    { new Guid("ee5787ea-fd88-4f12-bee6-a5775d9151a9"), 1, 1, 10 }
                });

            migrationBuilder.InsertData(
                table: "Feature",
                columns: new[] { "Id", "DropdownOptionId", "InputType", "Name" },
                values: new object[,]
                {
                    { new Guid("0ca05154-ba88-467c-b821-8c42f9fea5c2"), null, 0, "Speed optimization" },
                    { new Guid("0ee53df1-15e9-4962-82e7-bb247622f321"), null, 0, "Responsive design" },
                    { new Guid("17dcaf3d-2c86-4d97-b5b7-560f34dd74eb"), null, 0, "Content upload" },
                    { new Guid("1f3618b1-a3cc-4a6e-8cbb-8c29ddbb4922"), null, 0, "Hosting setup" },
                    { new Guid("253df5dc-8d8e-40db-aa6d-a12f94e4f74e"), null, 0, "E-commerce functionality" },
                    { new Guid("37d68708-81ec-46c3-b41f-f74a8490c85f"), null, 1, "Revisions" },
                    { new Guid("38782b20-8635-416b-a294-f07d74724640"), null, 0, "Payment processing" },
                    { new Guid("4d065daf-a013-4d92-a5ca-86594be75ae4"), new Guid("8a4b9c88-1f53-4ab9-9052-f8594d732430"), 1, "Number of pages" },
                    { new Guid("63d26668-1f3a-4957-8af6-3ed6b1bba971"), null, 0, "Social media" },
                    { new Guid("7882a3a8-3cd3-47fe-ae77-89b70f6723c4"), null, 2, "Price" },
                    { new Guid("7d3f526a-96d3-4557-be38-f92878cfb31a"), null, 0, "Opt-in form" },
                    { new Guid("89eb1f5b-6c03-44ec-9846-7db644780b36"), new Guid("e0046a44-904f-4124-8728-298394557fb6"), 1, "Number of products" },
                    { new Guid("8f77a65f-51c7-493f-842b-8d28960d841c"), null, 0, "Autoresponder" },
                    { new Guid("9f7cb17b-4763-430d-b90e-522e1160a9ef"), null, 0, "Functional website" },
                    { new Guid("b9c6be18-b113-4489-bb32-6400f1f2643e"), new Guid("8a4b9c88-1f53-4ab9-9052-f8594d732430"), 1, "Plugins/extensions " }
                });

            migrationBuilder.InsertData(
                table: "Skill",
                columns: new[] { "Id", "Description", "Name", "SkillSubcategoryId" },
                values: new object[,]
                {
                    { new Guid("6ff8b24d-c146-4676-a393-a65ba5c58065"), "Involves creating online stores and platforms for e-commerce activities.", "E-Commerce Development", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("ab8bc867-ef81-4808-b250-d06960309f4a"), "Encompasses skills required to build fully functional and feature-rich websites.", "Build a Complete Website", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("dc8347e6-599a-4a01-9f1f-32f76767ae5c"), "Skills related to designing and developing websites for business purposes.", "Business Websites", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("f3b854a1-def5-44c0-abd7-bc4470474048"), "Skills in designing and building effective landing pages for websites.", "Landing Pages", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("fce4534b-535b-4558-9de9-24d24c630766"), "Focuses on creating websites optimized for dropshipping business models.", "Dropshipping Websites", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") }
                });

            migrationBuilder.InsertData(
                table: "SkillCategory",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("0983fded-e262-43d7-a485-e5f1a1ca5c87"), "This category involves skills related to artificial intelligence, machine learning, and AI-based services.", "AI Services" },
                    { new Guid("16cdb431-1f7d-447c-9a99-c4bc3e85f46f"), "Skills in music composition, audio production, and sound engineering.", "Music & Audio" },
                    { new Guid("1ede11ab-7308-4191-b777-ff403244ba1b"), "Skills in capturing and editing visual images through photography.", "Photography" },
                    { new Guid("6fd34255-00b6-450e-8a85-939368dd9f94"), "Encompasses skills related to business strategy, management, and entrepreneurial activities.", "Business" },
                    { new Guid("a397ee70-15da-4c02-94e8-325ef2ae1f42"), "This category covers skills in video creation, editing, and animation production.", "Video & Animation" },
                    { new Guid("a3a522fb-117a-4cfb-8213-0ca8343e26b1"), "Skills related to online marketing, advertising, and promotion in the digital realm.", "Digital Marketing" },
                    { new Guid("a90acf25-123c-4530-aa8f-31bdc1299c5d"), "Skills in programming, software development, and technology solutions fall under this category.", "Programming & Tech" },
                    { new Guid("d22915dc-5a69-492b-a5b7-3462b9751b7a"), "Skills related to data analysis, management, and interpretation.", "Data" },
                    { new Guid("d98055c8-6ab4-49f8-a47f-f1bd1593a2db"), "This category encompasses skills related to visual design, graphic arts, and creative visual communication.", "Graphics & Design" },
                    { new Guid("fcb6afce-a79d-49bf-a254-919e4a3d2f34"), "Skills related to content creation, writing, and translation services.", "Writing & Translation" }
                });

            migrationBuilder.InsertData(
                table: "SkillSubcategory",
                columns: new[] { "Id", "Description", "Name", "SkillCategoryId" },
                values: new object[,]
                {
                    { new Guid("1c4e1c08-29d4-41f9-831b-5db779d83a7e"), "Involves the creation and implementation of artificial intelligence algorithms and systems.", "AI Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("265ea8d5-f503-4aa6-a39c-642cd72b22d5"), "Involves the development and implementation of conversational agents for automated interactions.", "Chatbots", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("31aa27be-c0d7-4371-abac-c28103ffb316"), "Focuses on creating interactive and engaging video games for various platforms.", "Game Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("3c9c71a1-3a0a-4d9e-bbb3-24f34bf52f6d"), "Involves creating and maintaining websites, focusing on design, functionality, and user experience.", "Website Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("3ca38b5a-2940-4c2b-9580-4451d64a1c20"), "Includes miscellaneous skills or services related to the broader category of programming and technology.", "Miscellaneous", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("4d80e4fa-8f6d-4c59-a028-dd16b93e0952"), "Concerned with the ongoing support, updates, and troubleshooting of existing websites.", "Website Maintenance", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("a216406e-0b98-4613-8dda-df6aa3593056"), "Encompasses quality assurance, testing, and review processes to ensure software reliability.", "QA & Review", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("badf1460-3e31-401c-b880-558faa75f94f"), "Involves providing support services and addressing cybersecurity concerns for software and systems.", "Support & Cybersecurity", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("ce4d37cb-888a-4369-86e5-3fbe6b3b377e"), "Deals with understanding and utilizing various website development platforms and frameworks.", "Website Platforms", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("db815348-b3a6-4313-b062-3ef908f9385d"), "Encompasses the creation and maintenance of software applications for various platforms.", "Software Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("e52caddb-2b11-4ff7-80b1-d374be1a709f"), "Professionals specializing in software development, coding, and programming.", "Software Developers", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("ffc4264b-55ac-43b2-87e8-154fe4169ac5"), "Focuses on designing and building applications specifically for mobile devices.", "Mobile App Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") }
                });
        }
    }
}
