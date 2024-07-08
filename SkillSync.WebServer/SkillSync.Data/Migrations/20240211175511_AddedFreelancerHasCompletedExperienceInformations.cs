using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkillSync.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedFreelancerHasCompletedExperienceInformations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasCompletedExperienceInformations",
                table: "Freelancer",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddb34bfe-616a-46a0-af02-b7f29ee25daa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a6afde88-ef9a-40db-a445-29ff3a682800", "AQAAAAIAAYagAAAAEIAxfTQ+HJzpDeyTZ+gjTQRjemGZerRhMmpXqHpqLMtdBrlfaP6blVsJa+O2K05ipQ==", "da115192-2c93-4be4-b63b-e494acacb174" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("8a560536-5ad6-492d-82b5-db534e362db3"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("ae8515a5-3ec8-4697-89fe-3186c25d217f"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("b14d4706-eac8-488d-847d-5633f9355dbb"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("d5dcf1b2-e057-4911-b2b5-d48fe5bdd0f4"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("fb312e41-e44e-4789-bb7f-20466b3a6b85"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("2da2af86-67f0-47cb-83a2-1d7ac26f2b9c"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("39f74ce4-6720-4e66-a86e-b7936e2634ef"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("4450584e-3129-4c88-aecd-f3a07daba4c3"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("48da7e1a-2f15-456b-bd1c-120e9a4d8e66"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("5a2229cf-c5d4-40a5-8507-492527cc8029"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("817c780e-0a6f-42ff-b727-1ddb8ad8468e"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("8d65ece5-a821-4e18-aad0-286cd86558e7"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("dad830b2-7538-41d8-9e0e-34963d0cf41e"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("efb5f428-86dd-4de2-bd85-99f782043ecd"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("f158e34f-22b5-425f-9ed8-bd498a4b4107"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("11fa9ce0-6415-457c-81dd-3df160e8bde1"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("126a54f1-79e0-412d-909e-4746e45f8361"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("4ad06657-8088-478e-b34e-15f6bdbd2c0e"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("69e89acb-83e8-4f23-8d0d-07ffca286de1"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("8174fdd3-7163-46b1-bc07-5ae71294ae93"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("980927e3-cf79-456c-b995-584a56656e4c"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("ae11b271-6273-49cb-9e25-55386a907b03"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("ae3e8ede-b59a-4a56-815d-a7edf4a1cf20"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("b02fe0b8-c101-4cba-ae00-2bc3d2451eae"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("d114165a-5f31-4810-8276-1232ec8683ae"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("d17f7f13-377f-465e-aa9a-0f05c1e250e9"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("e4b61bb2-7d1f-4540-8580-621b1cbb0f26"));

            migrationBuilder.DropColumn(
                name: "HasCompletedExperienceInformations",
                table: "Freelancer");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddb34bfe-616a-46a0-af02-b7f29ee25daa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "788363c7-6927-42ca-9985-c0c52797f48d", "AQAAAAIAAYagAAAAEI3Rdg6jke6pv6IBxcmQfdWP/3vemZjPRDF/Q2+ERyelisJUzArJK8aWCeS/n7qfGg==", "b86f30b8-3938-4a73-8598-f4c77ca40540" });

            migrationBuilder.InsertData(
                table: "Skill",
                columns: new[] { "Id", "Description", "Name", "SkillSubcategoryId" },
                values: new object[,]
                {
                    { new Guid("4c6e20ea-36cb-4562-938a-ec154f72962e"), "Encompasses skills required to build fully functional and feature-rich websites.", "Build a Complete Website", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("51731ffa-f8d4-4959-b9f3-109f9d9de6be"), "Skills related to designing and developing websites for business purposes.", "Business Websites", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("76129785-91f1-4ab5-b2e4-983d01e74fba"), "Involves creating online stores and platforms for e-commerce activities.", "E-Commerce Development", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("8f8f2d8e-8554-4d48-a1b4-518ddb494fae"), "Focuses on creating websites optimized for dropshipping business models.", "Dropshipping Websites", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("c0eabaee-44ef-4456-aede-08775c74dbde"), "Skills in designing and building effective landing pages for websites.", "Landing Pages", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") }
                });

            migrationBuilder.InsertData(
                table: "SkillCategory",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("05e32d9c-da27-454e-8cec-a6fc19337a0f"), "This category covers skills in video creation, editing, and animation production.", "Video & Animation" },
                    { new Guid("15dd8634-e83c-40a1-a010-a22c37742279"), "Skills in music composition, audio production, and sound engineering.", "Music & Audio" },
                    { new Guid("577135f8-baee-4aae-b383-559f22d765d6"), "Skills related to content creation, writing, and translation services.", "Writing & Translation" },
                    { new Guid("6a32a035-a9fd-48ba-950d-54d1fc5766a4"), "Skills related to data analysis, management, and interpretation.", "Data" },
                    { new Guid("77c605c7-fe8c-4e08-8924-62b8d75d7e2e"), "Skills related to online marketing, advertising, and promotion in the digital realm.", "Digital Marketing" },
                    { new Guid("879021d5-d241-4b98-b287-610daff4a922"), "Skills in capturing and editing visual images through photography.", "Photography" },
                    { new Guid("941f4362-b90b-4fb0-95dc-bb5c479075c0"), "Skills in programming, software development, and technology solutions fall under this category.", "Programming & Tech" },
                    { new Guid("98ec0423-ee89-4080-a235-7e584b36d515"), "This category encompasses skills related to visual design, graphic arts, and creative visual communication.", "Graphics & Design" },
                    { new Guid("9bef0605-b311-4e80-b6e4-ad01f5ae967d"), "Encompasses skills related to business strategy, management, and entrepreneurial activities.", "Business" },
                    { new Guid("ea065843-56d6-4fe5-9b20-cb0ec07d94be"), "This category involves skills related to artificial intelligence, machine learning, and AI-based services.", "AI Services" }
                });

            migrationBuilder.InsertData(
                table: "SkillSubcategory",
                columns: new[] { "Id", "Description", "Name", "SkillCategoryId" },
                values: new object[,]
                {
                    { new Guid("00077880-2b41-4bb3-918a-a4b7ee51d5d0"), "Includes miscellaneous skills or services related to the broader category of programming and technology.", "Miscellaneous", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("38243d46-ad9a-4b64-a136-34891399ab1e"), "Concerned with the ongoing support, updates, and troubleshooting of existing websites.", "Website Maintenance", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("4091911a-5bac-469a-8cf6-ed7d41704449"), "Involves providing support services and addressing cybersecurity concerns for software and systems.", "Support & Cybersecurity", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("433b318d-0d0a-46ff-8456-0e5e94ee06d1"), "Encompasses the creation and maintenance of software applications for various platforms.", "Software Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("663d78dc-e632-4f1c-ba6d-ad3bd752b0dd"), "Professionals specializing in software development, coding, and programming.", "Software Developers", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("66d07342-5750-413d-9563-9a4350d3f175"), "Focuses on designing and building applications specifically for mobile devices.", "Mobile App Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("6b0a960c-fcf9-4d1f-b3c1-eb28b24e4bcb"), "Involves the creation and implementation of artificial intelligence algorithms and systems.", "AI Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("867f32ee-8ecd-4248-a995-d8a60117fb1a"), "Encompasses quality assurance, testing, and review processes to ensure software reliability.", "QA & Review", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("af6ac843-1139-4dcc-bcb0-56be93f4127b"), "Deals with understanding and utilizing various website development platforms and frameworks.", "Website Platforms", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("c43436d7-a1cf-45b7-a4b7-31962a4842d6"), "Involves the development and implementation of conversational agents for automated interactions.", "Chatbots", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("cf187e2b-f62b-4f06-9869-5168e01b4497"), "Focuses on creating interactive and engaging video games for various platforms.", "Game Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("d9929376-0e97-4a3d-9a6d-eb10a5bae1bd"), "Involves creating and maintaining websites, focusing on design, functionality, and user experience.", "Website Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") }
                });
        }
    }
}
