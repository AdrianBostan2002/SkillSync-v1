using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkillSync.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedFreelancerScopeDescriptionColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ScopeDescription",
                table: "Freelancer",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddb34bfe-616a-46a0-af02-b7f29ee25daa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "394fbd77-a26b-43c1-aaf6-11474f040918", "AQAAAAIAAYagAAAAEO8U98mDVFR9YDntx0lZIw//7hwGSFideno44PNWL8iAYHmV/P0oN6LACFz5O8n6kA==", "4266113c-1ed6-49ef-bb45-c3dd184b69b2" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("48de3f58-a73a-4068-b12d-69f826428851"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("81c60894-c4e1-4d71-ab2f-338d0c30dc3e"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("a5bce1d1-fe11-44d8-b0fd-971894d23f14"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("af19d6f7-18d6-459c-9549-83725c84acb2"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("d25c6f41-cbb6-493d-bf50-106aab96ea90"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("0eaec7ce-553b-488d-ba30-1c1b040a958f"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("3ad7f29b-c84a-4e66-88bf-a22d33063d73"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("7f131c1a-7fd8-4bd8-934f-11a6e040a5ba"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("9cb80625-a136-4293-8b0b-de94f81d4b1c"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("a8b0c8ad-85b0-4a0a-8960-0119a8db8859"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("b26d1f07-3361-4e02-8274-874c060cc14d"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("b6bf396d-afb8-4f09-999b-263aa5e760bc"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("cb687c42-81ad-46e0-8d3e-e3a9fa1229c6"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("d6d4f3bd-d493-4bdf-8fee-e8280f74b5af"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("dad7844b-243d-48c2-ae66-583b09c7173b"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("02fa9d33-60ac-49e2-a629-726817323419"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("09cbecde-f4e0-48c0-a96c-4406a76cdfab"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("3a776973-2d13-4d6e-9ca8-ac319e1e0618"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("4f90f6a7-9009-46b9-8af8-e590c2843b5c"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("5263e308-e1ea-45c5-97ce-e20d7a84b33c"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("75e4395e-1f2d-4974-8d5f-5051ecfe34c8"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("81304286-49ad-4401-8966-a5115403a19f"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("8891c6d9-b8f5-402b-875e-a9ca08773b09"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("bf3a9aa6-1fa9-47d3-be42-c9a3b532e14d"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("d2029726-4ff2-4120-a395-dc4f02c2284a"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("e1df5bc8-d274-467a-a967-9847d6d51b06"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("e477bec8-32ec-4b21-b881-3eb9e868ed97"));

            migrationBuilder.DropColumn(
                name: "ScopeDescription",
                table: "Freelancer");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddb34bfe-616a-46a0-af02-b7f29ee25daa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "a6afde88-ef9a-40db-a445-29ff3a682800", "AQAAAAIAAYagAAAAEIAxfTQ+HJzpDeyTZ+gjTQRjemGZerRhMmpXqHpqLMtdBrlfaP6blVsJa+O2K05ipQ==", "da115192-2c93-4be4-b63b-e494acacb174" });

            migrationBuilder.InsertData(
                table: "Skill",
                columns: new[] { "Id", "Description", "Name", "SkillSubcategoryId" },
                values: new object[,]
                {
                    { new Guid("8a560536-5ad6-492d-82b5-db534e362db3"), "Involves creating online stores and platforms for e-commerce activities.", "E-Commerce Development", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("ae8515a5-3ec8-4697-89fe-3186c25d217f"), "Skills related to designing and developing websites for business purposes.", "Business Websites", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("b14d4706-eac8-488d-847d-5633f9355dbb"), "Skills in designing and building effective landing pages for websites.", "Landing Pages", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("d5dcf1b2-e057-4911-b2b5-d48fe5bdd0f4"), "Encompasses skills required to build fully functional and feature-rich websites.", "Build a Complete Website", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("fb312e41-e44e-4789-bb7f-20466b3a6b85"), "Focuses on creating websites optimized for dropshipping business models.", "Dropshipping Websites", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") }
                });

            migrationBuilder.InsertData(
                table: "SkillCategory",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("2da2af86-67f0-47cb-83a2-1d7ac26f2b9c"), "Skills in capturing and editing visual images through photography.", "Photography" },
                    { new Guid("39f74ce4-6720-4e66-a86e-b7936e2634ef"), "Skills related to online marketing, advertising, and promotion in the digital realm.", "Digital Marketing" },
                    { new Guid("4450584e-3129-4c88-aecd-f3a07daba4c3"), "Skills related to content creation, writing, and translation services.", "Writing & Translation" },
                    { new Guid("48da7e1a-2f15-456b-bd1c-120e9a4d8e66"), "Skills in programming, software development, and technology solutions fall under this category.", "Programming & Tech" },
                    { new Guid("5a2229cf-c5d4-40a5-8507-492527cc8029"), "This category covers skills in video creation, editing, and animation production.", "Video & Animation" },
                    { new Guid("817c780e-0a6f-42ff-b727-1ddb8ad8468e"), "Skills in music composition, audio production, and sound engineering.", "Music & Audio" },
                    { new Guid("8d65ece5-a821-4e18-aad0-286cd86558e7"), "Skills related to data analysis, management, and interpretation.", "Data" },
                    { new Guid("dad830b2-7538-41d8-9e0e-34963d0cf41e"), "This category encompasses skills related to visual design, graphic arts, and creative visual communication.", "Graphics & Design" },
                    { new Guid("efb5f428-86dd-4de2-bd85-99f782043ecd"), "Encompasses skills related to business strategy, management, and entrepreneurial activities.", "Business" },
                    { new Guid("f158e34f-22b5-425f-9ed8-bd498a4b4107"), "This category involves skills related to artificial intelligence, machine learning, and AI-based services.", "AI Services" }
                });

            migrationBuilder.InsertData(
                table: "SkillSubcategory",
                columns: new[] { "Id", "Description", "Name", "SkillCategoryId" },
                values: new object[,]
                {
                    { new Guid("11fa9ce0-6415-457c-81dd-3df160e8bde1"), "Involves the development and implementation of conversational agents for automated interactions.", "Chatbots", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("126a54f1-79e0-412d-909e-4746e45f8361"), "Involves providing support services and addressing cybersecurity concerns for software and systems.", "Support & Cybersecurity", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("4ad06657-8088-478e-b34e-15f6bdbd2c0e"), "Encompasses quality assurance, testing, and review processes to ensure software reliability.", "QA & Review", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("69e89acb-83e8-4f23-8d0d-07ffca286de1"), "Focuses on creating interactive and engaging video games for various platforms.", "Game Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("8174fdd3-7163-46b1-bc07-5ae71294ae93"), "Professionals specializing in software development, coding, and programming.", "Software Developers", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("980927e3-cf79-456c-b995-584a56656e4c"), "Focuses on designing and building applications specifically for mobile devices.", "Mobile App Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("ae11b271-6273-49cb-9e25-55386a907b03"), "Involves the creation and implementation of artificial intelligence algorithms and systems.", "AI Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("ae3e8ede-b59a-4a56-815d-a7edf4a1cf20"), "Involves creating and maintaining websites, focusing on design, functionality, and user experience.", "Website Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("b02fe0b8-c101-4cba-ae00-2bc3d2451eae"), "Concerned with the ongoing support, updates, and troubleshooting of existing websites.", "Website Maintenance", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("d114165a-5f31-4810-8276-1232ec8683ae"), "Deals with understanding and utilizing various website development platforms and frameworks.", "Website Platforms", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("d17f7f13-377f-465e-aa9a-0f05c1e250e9"), "Encompasses the creation and maintenance of software applications for various platforms.", "Software Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("e4b61bb2-7d1f-4540-8580-621b1cbb0f26"), "Includes miscellaneous skills or services related to the broader category of programming and technology.", "Miscellaneous", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") }
                });
        }
    }
}
