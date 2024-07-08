using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkillSync.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class ChangedProjectTitleMaxLenght : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Project",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddb34bfe-616a-46a0-af02-b7f29ee25daa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "83480d82-edc7-40e2-a4dd-448571ed422c", "AQAAAAIAAYagAAAAEBM3GcPeD52vNtzh6dShlPU1BQT0xvmiQykv9CfPtOgMKrC9sYtnCHSqjSHy+WNLxA==", "10c6a5a1-b75c-436d-b78e-126cb20c1de8" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DropdownOption",
                keyColumn: "Id",
                keyValue: new Guid("1127ea0f-54ff-41d1-9356-0a28b9e8e64c"));

            migrationBuilder.DeleteData(
                table: "DropdownOption",
                keyColumn: "Id",
                keyValue: new Guid("a77d1c62-b5cd-4a58-b118-a204381a297e"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("043b9933-6280-4f23-9078-6c0a6ef70ef2"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("0c2a2958-d312-4660-a88a-68e8464f5a7c"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("1a8699cd-3f89-46c5-880a-2e36796aeacc"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("609333f1-4e90-4e41-8b35-7ff12e4167a2"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("823c2ba6-754b-44b0-93ae-047785704f32"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("a3e7ba6d-6a3d-4bcc-b56f-53b810ad95e1"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("a9b1b13e-dc2c-41d7-99f0-ae38bc2ef419"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("b5f8b6f3-a6e4-40c1-8548-98e791f3a7ad"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("cde51f64-4da8-4b7c-9827-12246d5cbaa7"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("d040306c-24dd-49aa-ae4d-e0fb95842978"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("d49ae00b-3000-4502-82aa-da1328b9bafc"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("d4e754ae-45ee-46a1-9c09-b2aa0275306a"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("e0e881ab-bd31-4078-9efa-df6c56aced16"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("e8c54c33-73fc-41d8-88a8-70ecb380423f"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("edd4081e-ed6d-468c-8dd7-ae80ebd5d9bf"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("8ee8b0c3-27a4-412e-95f3-259c2f0142ac"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("aeb62221-d5bd-43dc-88b7-fe30f9b0fae0"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("c1f27d69-c694-47c4-aa55-b0f3643d8261"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("dec6f4cd-0a90-4d38-a8d9-483f1f1208e1"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("fd846cd5-0147-4d63-8fda-91d811d0ab38"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("0e5d0d72-ee6f-4dcd-a4a7-298793a18a55"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("374bdbc7-aa1d-4930-8476-8e08ed248db7"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("4ac52214-d818-46b2-8da4-e1590920a81b"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("72afde51-04b0-4d14-9633-ca4dbde50228"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("8c8bd49c-09e1-4de7-b0ec-8b77533e20ce"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("8fbfe504-4f25-4dde-8c27-53edf0f68f54"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("9943adfd-e4cf-4330-985b-77e74bff6d0e"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("bd84f14d-46e9-4cf4-bd27-25b5f9f12084"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("c673ab19-6e9f-4763-86b3-830446947ccb"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("cf916ff3-eb8c-4cec-baf0-4b4b01940f98"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("2b5ddf08-fe51-4d09-b02b-96e0e258515a"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("320e6a7a-e06f-4e4e-8cae-f40453efd24a"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("539286df-9999-4117-9f6e-e8456f22e0f7"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("57be7b45-ae6d-40a0-a1c0-6816d42afc26"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("67e87bd9-b9cf-4582-99fd-ed4e1b9142d5"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("6878a3ee-0f17-47d5-b50c-f2690d6934f2"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("a9fb6842-2841-407f-8152-d139ab18cca9"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("cf166cac-f04c-4d21-b3e7-35b50c570a45"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("d55904fb-cf97-49c9-ac49-141ea80f1c5e"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("d9810de3-8a34-43e7-828d-23a6067a1786"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("f0944f78-9173-4d16-8d61-7f64e6afea4f"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("f9755d23-7cf8-49cb-8831-17c7c2b4d0e1"));

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Project",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddb34bfe-616a-46a0-af02-b7f29ee25daa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "7dbf8a20-8eac-4050-84c6-f8a530661413", "AQAAAAIAAYagAAAAEMN99U0qrpZaUvqyCK1vOwEyLZj4fh6PF2Zhlo0SBiqSshbJIcJa/C5CnS/k5AHSlw==", "531743b2-0d41-414e-80a5-572967485873" });

            migrationBuilder.InsertData(
                table: "DropdownOption",
                columns: new[] { "Id", "IncrementValue", "LowerInterval", "UpperInterval" },
                values: new object[,]
                {
                    { new Guid("cdced4f9-cb92-4e5b-9a10-7c4aac4620ca"), 1, 1, 50 },
                    { new Guid("dcf0c58f-aff5-4257-92ef-600a2361ff61"), 1, 1, 10 }
                });

            migrationBuilder.InsertData(
                table: "Feature",
                columns: new[] { "Id", "DropdownOptionId", "InputType", "Name" },
                values: new object[,]
                {
                    { new Guid("15d76385-196e-4bb3-a2cb-d5647d89b1e6"), null, 1, "Revisions" },
                    { new Guid("18bc4a66-088d-4482-afa1-251c30ff5227"), new Guid("e0046a44-904f-4124-8728-298394557fb6"), 1, "Number of products" },
                    { new Guid("425c85df-df4e-4264-afe9-c99129d3498e"), null, 0, "E-commerce functionality" },
                    { new Guid("4e8f7c35-440e-47da-9c21-b0cbd3392a32"), null, 0, "Speed optimization" },
                    { new Guid("705107f1-65ad-4f29-b558-1be299a63086"), null, 0, "Opt-in form" },
                    { new Guid("75d7ae2e-86d0-4546-a162-2560a2147602"), null, 0, "Functional website" },
                    { new Guid("c7b6db55-2bbd-4b0f-bdd8-9445713e3cfc"), null, 0, "Social media" },
                    { new Guid("d401de00-34f0-468e-8a92-ff0ec316c19d"), null, 2, "Price" },
                    { new Guid("d51f93d2-2eaa-4964-86dc-528604e3220a"), null, 0, "Content upload" },
                    { new Guid("d948e9f4-2f85-49e7-ae11-8b51c4a0ac44"), null, 0, "Responsive design" },
                    { new Guid("e2a530b6-8e7a-4fd8-8137-4cd47a10a49e"), null, 0, "Payment processing" },
                    { new Guid("e59082e9-61bc-4ac8-bb47-91643063b30d"), null, 0, "Hosting setup" },
                    { new Guid("e6b2d7b5-1d47-435d-b9b1-9ab9372de65c"), new Guid("8a4b9c88-1f53-4ab9-9052-f8594d732430"), 1, "Number of pages" },
                    { new Guid("eb115f3f-a4b4-4908-9ecd-bcde40b0dfe8"), null, 0, "Autoresponder" },
                    { new Guid("fe986053-ce59-45d9-bbb7-fee860c3b251"), new Guid("8a4b9c88-1f53-4ab9-9052-f8594d732430"), 1, "Plugins/extensions " }
                });

            migrationBuilder.InsertData(
                table: "Skill",
                columns: new[] { "Id", "Description", "Name", "SkillSubcategoryId" },
                values: new object[,]
                {
                    { new Guid("030c6462-e9a7-48a0-a67c-00f69e57c321"), "Involves creating online stores and platforms for e-commerce activities.", "E-Commerce Development", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("1508b058-d81b-442e-bdc4-6b65c026c92d"), "Skills in designing and building effective landing pages for websites.", "Landing Pages", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("98872ff6-42d6-4484-8e71-9846915a12db"), "Skills related to designing and developing websites for business purposes.", "Business Websites", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("caa8771f-edbe-4cef-b6a0-963dcf56aff7"), "Focuses on creating websites optimized for dropshipping business models.", "Dropshipping Websites", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("da66de90-97f9-43b7-bfa6-35e8b0b87322"), "Encompasses skills required to build fully functional and feature-rich websites.", "Build a Complete Website", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") }
                });

            migrationBuilder.InsertData(
                table: "SkillCategory",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("15b541e5-6a85-4dba-b270-9621607f3cac"), "Skills related to content creation, writing, and translation services.", "Writing & Translation" },
                    { new Guid("36094a07-1578-4bcd-94ce-6abc505306f6"), "This category encompasses skills related to visual design, graphic arts, and creative visual communication.", "Graphics & Design" },
                    { new Guid("55913185-5a16-4f12-b3d1-675878974681"), "Encompasses skills related to business strategy, management, and entrepreneurial activities.", "Business" },
                    { new Guid("83cf705a-0b78-4c23-8516-0157b4d518d1"), "Skills in programming, software development, and technology solutions fall under this category.", "Programming & Tech" },
                    { new Guid("971fa16c-864c-45cb-9ded-fc368f80990b"), "Skills in capturing and editing visual images through photography.", "Photography" },
                    { new Guid("b4f2b24a-0da7-4337-bcb6-0f178c26c894"), "This category covers skills in video creation, editing, and animation production.", "Video & Animation" },
                    { new Guid("cc493f69-bfb5-4fac-bc56-fa1411e1e430"), "Skills in music composition, audio production, and sound engineering.", "Music & Audio" },
                    { new Guid("dda8826a-6564-4719-9340-bf7e390ea32b"), "This category involves skills related to artificial intelligence, machine learning, and AI-based services.", "AI Services" },
                    { new Guid("ecda4a7f-742d-437d-99ee-e4bfedd4c049"), "Skills related to data analysis, management, and interpretation.", "Data" },
                    { new Guid("ff482544-d763-4f2d-848e-6d16307450a9"), "Skills related to online marketing, advertising, and promotion in the digital realm.", "Digital Marketing" }
                });

            migrationBuilder.InsertData(
                table: "SkillSubcategory",
                columns: new[] { "Id", "Description", "Name", "SkillCategoryId" },
                values: new object[,]
                {
                    { new Guid("19f0c18c-674a-492c-9eb0-8e693b0d71b8"), "Professionals specializing in software development, coding, and programming.", "Software Developers", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("32aed4f5-1077-47ea-8f49-1fe5b4a099ea"), "Focuses on creating interactive and engaging video games for various platforms.", "Game Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("4d458de9-f673-43dc-af03-8fac8b51ef92"), "Focuses on designing and building applications specifically for mobile devices.", "Mobile App Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("650bbf0f-1f0e-4f63-b235-cea1a8ce85f4"), "Involves the creation and implementation of artificial intelligence algorithms and systems.", "AI Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("722a76ad-68fe-47a0-96d1-92c5322cedae"), "Encompasses quality assurance, testing, and review processes to ensure software reliability.", "QA & Review", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("7c6b6440-1944-4f78-86e7-7e62616730ce"), "Concerned with the ongoing support, updates, and troubleshooting of existing websites.", "Website Maintenance", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("94355d67-e6a9-48f0-9abb-495f97add762"), "Involves the development and implementation of conversational agents for automated interactions.", "Chatbots", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("9a159fa0-4c2c-401e-afd7-e3a802c8da79"), "Involves creating and maintaining websites, focusing on design, functionality, and user experience.", "Website Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("bbcbce17-e819-4b41-9415-a431975e51f4"), "Encompasses the creation and maintenance of software applications for various platforms.", "Software Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("c057f837-6077-45e6-b47c-f28f964e34b2"), "Deals with understanding and utilizing various website development platforms and frameworks.", "Website Platforms", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("c4a7e908-4710-4e9b-b15c-d4847165c397"), "Involves providing support services and addressing cybersecurity concerns for software and systems.", "Support & Cybersecurity", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("e44dacc1-d953-4dc3-84a1-7724ad515dde"), "Includes miscellaneous skills or services related to the broader category of programming and technology.", "Miscellaneous", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") }
                });
        }
    }
}
