using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkillSync.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserProfilePictureColumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ProfilePicture",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddb34bfe-616a-46a0-af02-b7f29ee25daa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "ProfilePicture", "SecurityStamp" },
                values: new object[] { "a7037414-4a85-48cb-a9ae-3ea710725e9b", "AQAAAAIAAYagAAAAEO3ycKqu14q5+iTg++3uWC9ObHZZOtIz8/MTd/2sZxZ4z6yrLmZNYLdrIyAwZNKa9w==", "admin-pf", "d985294b-c25b-463c-b4de-1a4b2eeec152" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("0ed8c559-5727-469f-a576-a3987cae8309"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("13da805e-4b46-4088-8d1e-f7e6efc594ed"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("64781721-084d-40e8-a271-2c8edeb5742d"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("b5b86f40-8118-472c-a486-9689846ccf20"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("de72a6ec-c427-499c-9d8b-2887e75fbe5c"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("09d0ee86-f3bc-4681-8472-e6e5268ddc15"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("0faeb2db-bb05-4130-915a-3c18d43f460f"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("29c17797-67d6-45f4-8916-5406590915d4"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("66bfaf68-1036-461f-a977-aa49d1499fbf"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("8b2539e5-a7ae-4fe0-8713-31320579156c"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("8e20c093-8ee2-42e3-bcb5-79155387f326"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("aa5cffec-7c81-409f-b658-12255df85a5f"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("b466e69c-e086-4ea9-a20d-c7b94a25aa46"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("b4ae1ccf-1db8-4dc9-a626-da15589b331c"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("e8787628-8a6c-4f13-9438-c6975edc12ec"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("15f61fdc-9ecd-4fd0-ab04-692f1586a7d6"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("24add0bd-b00a-4aa2-b25c-35578962df04"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("2f188d9f-54db-4978-85ab-89318369d2d9"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("3c618ac8-ef5d-49f3-81f8-cb4e82b3e6c3"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("533206e0-7ba1-4808-8b92-95e91e46787d"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("552b75fd-becb-4a40-9c4c-7f83b38e4bd0"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("6e19b85d-10a7-4bff-8d45-d58accde7b23"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("78b5e6ea-0458-4da8-875c-e7adc87aff69"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("7927082a-6a27-4c51-a362-ad66a0a5e05c"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("9bb1e550-c85a-45f8-881f-6dd33b8c01c1"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("c150babb-0b75-41b9-9f27-8633661a6d29"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("d6649ae6-5019-4890-855d-33219994292a"));

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddb34bfe-616a-46a0-af02-b7f29ee25daa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "394fbd77-a26b-43c1-aaf6-11474f040918", "AQAAAAIAAYagAAAAEO8U98mDVFR9YDntx0lZIw//7hwGSFideno44PNWL8iAYHmV/P0oN6LACFz5O8n6kA==", "4266113c-1ed6-49ef-bb45-c3dd184b69b2" });

            migrationBuilder.InsertData(
                table: "Skill",
                columns: new[] { "Id", "Description", "Name", "SkillSubcategoryId" },
                values: new object[,]
                {
                    { new Guid("48de3f58-a73a-4068-b12d-69f826428851"), "Encompasses skills required to build fully functional and feature-rich websites.", "Build a Complete Website", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("81c60894-c4e1-4d71-ab2f-338d0c30dc3e"), "Skills related to designing and developing websites for business purposes.", "Business Websites", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("a5bce1d1-fe11-44d8-b0fd-971894d23f14"), "Focuses on creating websites optimized for dropshipping business models.", "Dropshipping Websites", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("af19d6f7-18d6-459c-9549-83725c84acb2"), "Involves creating online stores and platforms for e-commerce activities.", "E-Commerce Development", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("d25c6f41-cbb6-493d-bf50-106aab96ea90"), "Skills in designing and building effective landing pages for websites.", "Landing Pages", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") }
                });

            migrationBuilder.InsertData(
                table: "SkillCategory",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("0eaec7ce-553b-488d-ba30-1c1b040a958f"), "Skills related to data analysis, management, and interpretation.", "Data" },
                    { new Guid("3ad7f29b-c84a-4e66-88bf-a22d33063d73"), "This category involves skills related to artificial intelligence, machine learning, and AI-based services.", "AI Services" },
                    { new Guid("7f131c1a-7fd8-4bd8-934f-11a6e040a5ba"), "Skills in programming, software development, and technology solutions fall under this category.", "Programming & Tech" },
                    { new Guid("9cb80625-a136-4293-8b0b-de94f81d4b1c"), "Skills related to content creation, writing, and translation services.", "Writing & Translation" },
                    { new Guid("a8b0c8ad-85b0-4a0a-8960-0119a8db8859"), "Skills related to online marketing, advertising, and promotion in the digital realm.", "Digital Marketing" },
                    { new Guid("b26d1f07-3361-4e02-8274-874c060cc14d"), "This category covers skills in video creation, editing, and animation production.", "Video & Animation" },
                    { new Guid("b6bf396d-afb8-4f09-999b-263aa5e760bc"), "Skills in capturing and editing visual images through photography.", "Photography" },
                    { new Guid("cb687c42-81ad-46e0-8d3e-e3a9fa1229c6"), "Skills in music composition, audio production, and sound engineering.", "Music & Audio" },
                    { new Guid("d6d4f3bd-d493-4bdf-8fee-e8280f74b5af"), "This category encompasses skills related to visual design, graphic arts, and creative visual communication.", "Graphics & Design" },
                    { new Guid("dad7844b-243d-48c2-ae66-583b09c7173b"), "Encompasses skills related to business strategy, management, and entrepreneurial activities.", "Business" }
                });

            migrationBuilder.InsertData(
                table: "SkillSubcategory",
                columns: new[] { "Id", "Description", "Name", "SkillCategoryId" },
                values: new object[,]
                {
                    { new Guid("02fa9d33-60ac-49e2-a629-726817323419"), "Focuses on designing and building applications specifically for mobile devices.", "Mobile App Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("09cbecde-f4e0-48c0-a96c-4406a76cdfab"), "Involves the creation and implementation of artificial intelligence algorithms and systems.", "AI Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("3a776973-2d13-4d6e-9ca8-ac319e1e0618"), "Involves the development and implementation of conversational agents for automated interactions.", "Chatbots", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("4f90f6a7-9009-46b9-8af8-e590c2843b5c"), "Deals with understanding and utilizing various website development platforms and frameworks.", "Website Platforms", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("5263e308-e1ea-45c5-97ce-e20d7a84b33c"), "Involves providing support services and addressing cybersecurity concerns for software and systems.", "Support & Cybersecurity", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("75e4395e-1f2d-4974-8d5f-5051ecfe34c8"), "Concerned with the ongoing support, updates, and troubleshooting of existing websites.", "Website Maintenance", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("81304286-49ad-4401-8966-a5115403a19f"), "Involves creating and maintaining websites, focusing on design, functionality, and user experience.", "Website Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("8891c6d9-b8f5-402b-875e-a9ca08773b09"), "Includes miscellaneous skills or services related to the broader category of programming and technology.", "Miscellaneous", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("bf3a9aa6-1fa9-47d3-be42-c9a3b532e14d"), "Encompasses the creation and maintenance of software applications for various platforms.", "Software Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("d2029726-4ff2-4120-a395-dc4f02c2284a"), "Encompasses quality assurance, testing, and review processes to ensure software reliability.", "QA & Review", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("e1df5bc8-d274-467a-a967-9847d6d51b06"), "Focuses on creating interactive and engaging video games for various platforms.", "Game Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("e477bec8-32ec-4b21-b881-3eb9e868ed97"), "Professionals specializing in software development, coding, and programming.", "Software Developers", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") }
                });
        }
    }
}
