using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkillSync.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedSkillCategoryFrequentlyAskedQuestionEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SkillCategoryFrequentlyAskedQuestion",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SkillCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Question = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Answer = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillCategoryFrequentlyAskedQuestion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkillCategoryFrequentlyAskedQuestion_SkillCategory_SkillCategoryId",
                        column: x => x.SkillCategoryId,
                        principalTable: "SkillCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddb34bfe-616a-46a0-af02-b7f29ee25daa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7dbf8a20-8eac-4050-84c6-f8a530661413", "AQAAAAIAAYagAAAAEMN99U0qrpZaUvqyCK1vOwEyLZj4fh6PF2Zhlo0SBiqSshbJIcJa/C5CnS/k5AHSlw==", "531743b2-0d41-414e-80a5-572967485873" });

            migrationBuilder.CreateIndex(
                name: "IX_SkillCategoryFrequentlyAskedQuestion_SkillCategoryId",
                table: "SkillCategoryFrequentlyAskedQuestion",
                column: "SkillCategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkillCategoryFrequentlyAskedQuestion");

            migrationBuilder.DeleteData(
                table: "DropdownOption",
                keyColumn: "Id",
                keyValue: new Guid("cdced4f9-cb92-4e5b-9a10-7c4aac4620ca"));

            migrationBuilder.DeleteData(
                table: "DropdownOption",
                keyColumn: "Id",
                keyValue: new Guid("dcf0c58f-aff5-4257-92ef-600a2361ff61"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("15d76385-196e-4bb3-a2cb-d5647d89b1e6"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("18bc4a66-088d-4482-afa1-251c30ff5227"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("425c85df-df4e-4264-afe9-c99129d3498e"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("4e8f7c35-440e-47da-9c21-b0cbd3392a32"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("705107f1-65ad-4f29-b558-1be299a63086"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("75d7ae2e-86d0-4546-a162-2560a2147602"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("c7b6db55-2bbd-4b0f-bdd8-9445713e3cfc"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("d401de00-34f0-468e-8a92-ff0ec316c19d"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("d51f93d2-2eaa-4964-86dc-528604e3220a"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("d948e9f4-2f85-49e7-ae11-8b51c4a0ac44"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("e2a530b6-8e7a-4fd8-8137-4cd47a10a49e"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("e59082e9-61bc-4ac8-bb47-91643063b30d"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("e6b2d7b5-1d47-435d-b9b1-9ab9372de65c"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("eb115f3f-a4b4-4908-9ecd-bcde40b0dfe8"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("fe986053-ce59-45d9-bbb7-fee860c3b251"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("030c6462-e9a7-48a0-a67c-00f69e57c321"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("1508b058-d81b-442e-bdc4-6b65c026c92d"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("98872ff6-42d6-4484-8e71-9846915a12db"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("caa8771f-edbe-4cef-b6a0-963dcf56aff7"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("da66de90-97f9-43b7-bfa6-35e8b0b87322"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("15b541e5-6a85-4dba-b270-9621607f3cac"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("36094a07-1578-4bcd-94ce-6abc505306f6"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("55913185-5a16-4f12-b3d1-675878974681"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("83cf705a-0b78-4c23-8516-0157b4d518d1"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("971fa16c-864c-45cb-9ded-fc368f80990b"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("b4f2b24a-0da7-4337-bcb6-0f178c26c894"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("cc493f69-bfb5-4fac-bc56-fa1411e1e430"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("dda8826a-6564-4719-9340-bf7e390ea32b"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("ecda4a7f-742d-437d-99ee-e4bfedd4c049"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("ff482544-d763-4f2d-848e-6d16307450a9"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("19f0c18c-674a-492c-9eb0-8e693b0d71b8"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("32aed4f5-1077-47ea-8f49-1fe5b4a099ea"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("4d458de9-f673-43dc-af03-8fac8b51ef92"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("650bbf0f-1f0e-4f63-b235-cea1a8ce85f4"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("722a76ad-68fe-47a0-96d1-92c5322cedae"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("7c6b6440-1944-4f78-86e7-7e62616730ce"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("94355d67-e6a9-48f0-9abb-495f97add762"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("9a159fa0-4c2c-401e-afd7-e3a802c8da79"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("bbcbce17-e819-4b41-9415-a431975e51f4"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("c057f837-6077-45e6-b47c-f28f964e34b2"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("c4a7e908-4710-4e9b-b15c-d4847165c397"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("e44dacc1-d953-4dc3-84a1-7724ad515dde"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddb34bfe-616a-46a0-af02-b7f29ee25daa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "919a85db-a713-49bb-8820-406d428fbaf2", "AQAAAAIAAYagAAAAEDa68KM0U/uYU+4M3EBSI+I2ti+vgSRbOScNzr3QEwms034h10zFJ596YYYq6eQNkA==", "eabe98b8-36cb-4146-8c4f-2e7fa986e929" });

            migrationBuilder.InsertData(
                table: "DropdownOption",
                columns: new[] { "Id", "IncrementValue", "LowerInterval", "UpperInterval" },
                values: new object[,]
                {
                    { new Guid("5735ef60-c31f-4275-b7cf-b918239ef5c4"), 1, 1, 50 },
                    { new Guid("b455b7bf-b66d-4e79-be47-7be1eafd3b1a"), 1, 1, 10 }
                });

            migrationBuilder.InsertData(
                table: "Feature",
                columns: new[] { "Id", "DropdownOptionId", "InputType", "Name" },
                values: new object[,]
                {
                    { new Guid("139e534f-2a62-43af-9585-b27022d39321"), null, 0, "Autoresponder" },
                    { new Guid("23472e43-19ae-47fc-91df-edcac42743ee"), null, 0, "Hosting setup" },
                    { new Guid("382d90de-54c2-43f6-9f5b-a96f977e7779"), new Guid("8a4b9c88-1f53-4ab9-9052-f8594d732430"), 1, "Number of pages" },
                    { new Guid("477fcdac-39be-4043-9b87-7e778801dde5"), null, 2, "Price" },
                    { new Guid("5333e4ab-c761-4fb4-903a-017fc0527de9"), null, 0, "Functional website" },
                    { new Guid("6174d4d0-1a4c-4fe9-890e-bb8d81bc0594"), null, 1, "Revisions" },
                    { new Guid("621b15f0-6cc5-4f6d-821b-744525064ae8"), null, 0, "Payment processing" },
                    { new Guid("65ffad7e-020f-4a48-864a-8de905217860"), null, 0, "Content upload" },
                    { new Guid("722f19ab-c3d1-4231-8f86-73858e672b1e"), null, 0, "Speed optimization" },
                    { new Guid("a29db899-d12b-4bcd-b368-cebcef99bc92"), new Guid("e0046a44-904f-4124-8728-298394557fb6"), 1, "Number of products" },
                    { new Guid("a765272b-a3cf-40bf-94d8-17f90003c1f9"), new Guid("8a4b9c88-1f53-4ab9-9052-f8594d732430"), 1, "Plugins/extensions " },
                    { new Guid("bfbf0457-5957-40db-b381-2131f9cf2188"), null, 0, "Opt-in form" },
                    { new Guid("c64c4b69-41cd-494e-b588-6039a919f606"), null, 0, "Responsive design" },
                    { new Guid("cf88b7f1-e303-41cc-b9ab-89022d2b163c"), null, 0, "E-commerce functionality" },
                    { new Guid("ee38c180-5136-49be-b2a5-b7f964acd082"), null, 0, "Social media" }
                });

            migrationBuilder.InsertData(
                table: "Skill",
                columns: new[] { "Id", "Description", "Name", "SkillSubcategoryId" },
                values: new object[,]
                {
                    { new Guid("61f5f9dc-2e31-46ac-aff3-a15ae7390746"), "Focuses on creating websites optimized for dropshipping business models.", "Dropshipping Websites", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("6d56bc54-c8ea-4f0d-96e3-c0a5458de165"), "Skills related to designing and developing websites for business purposes.", "Business Websites", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("a2befd7a-919d-4a37-ad82-50ff95a0a6d7"), "Encompasses skills required to build fully functional and feature-rich websites.", "Build a Complete Website", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("b9c0d5ca-45a8-4b2a-acc8-98fdce0c70a2"), "Involves creating online stores and platforms for e-commerce activities.", "E-Commerce Development", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("dd9f9b21-146b-47e7-8b17-6e943cd877ac"), "Skills in designing and building effective landing pages for websites.", "Landing Pages", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") }
                });

            migrationBuilder.InsertData(
                table: "SkillCategory",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("0d8bdf66-5e82-4f16-b0ca-238f4e27fc62"), "This category encompasses skills related to visual design, graphic arts, and creative visual communication.", "Graphics & Design" },
                    { new Guid("0edb8be8-703b-4f36-8c1f-65b899caae9f"), "Skills related to content creation, writing, and translation services.", "Writing & Translation" },
                    { new Guid("5d0ed3ce-e5ca-4942-a1f8-181fad390f86"), "Skills in music composition, audio production, and sound engineering.", "Music & Audio" },
                    { new Guid("74fb526c-4b06-4dcf-b325-2455350d31ce"), "This category covers skills in video creation, editing, and animation production.", "Video & Animation" },
                    { new Guid("8a206920-2511-468e-9fa0-6b4dcd14274c"), "This category involves skills related to artificial intelligence, machine learning, and AI-based services.", "AI Services" },
                    { new Guid("8ba73564-8bc7-4119-bc98-43e3d2ca2176"), "Skills in capturing and editing visual images through photography.", "Photography" },
                    { new Guid("df8b46b3-f1fe-414c-af0a-2c58e6c60e6e"), "Skills related to online marketing, advertising, and promotion in the digital realm.", "Digital Marketing" },
                    { new Guid("e2e331dd-f30a-44fe-902a-62eaec6037b6"), "Encompasses skills related to business strategy, management, and entrepreneurial activities.", "Business" },
                    { new Guid("f51afbec-9eb8-4ade-919e-359cab8fa6bc"), "Skills related to data analysis, management, and interpretation.", "Data" },
                    { new Guid("fa80e457-bb6a-4f35-9e0b-5800c8bc6be5"), "Skills in programming, software development, and technology solutions fall under this category.", "Programming & Tech" }
                });

            migrationBuilder.InsertData(
                table: "SkillSubcategory",
                columns: new[] { "Id", "Description", "Name", "SkillCategoryId" },
                values: new object[,]
                {
                    { new Guid("1251d5bb-7761-4ee5-8904-4a37c7e46150"), "Involves the creation and implementation of artificial intelligence algorithms and systems.", "AI Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("15fad048-7022-4179-ad19-b5e5ae457bd1"), "Focuses on designing and building applications specifically for mobile devices.", "Mobile App Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("2b0accc7-4c9c-4192-98b4-8bd99b8e23aa"), "Encompasses the creation and maintenance of software applications for various platforms.", "Software Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("2d0ac188-e17a-41f3-80b0-1965dd9ed730"), "Professionals specializing in software development, coding, and programming.", "Software Developers", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("3aa10986-a952-4d85-8e10-145e075d7455"), "Involves creating and maintaining websites, focusing on design, functionality, and user experience.", "Website Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("50089c00-ea58-4db1-91a1-a8427b550135"), "Encompasses quality assurance, testing, and review processes to ensure software reliability.", "QA & Review", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("63f99aaf-dd51-4f8c-b8a6-ba1b44496b95"), "Includes miscellaneous skills or services related to the broader category of programming and technology.", "Miscellaneous", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("85e81e68-bc36-4565-838f-c9c25dbe53ef"), "Deals with understanding and utilizing various website development platforms and frameworks.", "Website Platforms", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("94e44b0d-2628-4cdd-8b5b-5b41383ff7d8"), "Focuses on creating interactive and engaging video games for various platforms.", "Game Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("9910f1e4-0561-4ac5-93c6-d07636aa7fb9"), "Involves providing support services and addressing cybersecurity concerns for software and systems.", "Support & Cybersecurity", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("aea59137-a676-491f-a80e-a2ad7e7492d8"), "Involves the development and implementation of conversational agents for automated interactions.", "Chatbots", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("b4d537f1-f8cd-4575-918b-1e48ae7b0b32"), "Concerned with the ongoing support, updates, and troubleshooting of existing websites.", "Website Maintenance", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") }
                });
        }
    }
}
