using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkillSync.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RemovedSomeFieldsFromProjectTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PackageType",
                table: "ProjectFeature");

            migrationBuilder.DropColumn(
                name: "EstimatedDays",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Project");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "ProjectFeature",
                newName: "BasicSelectedValue");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Project",
                newName: "Title");

            migrationBuilder.AddColumn<string>(
                name: "PremiumSelectedValue",
                table: "ProjectFeature",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "StandardSelectedValue",
                table: "ProjectFeature",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "HasPackages",
                table: "Project",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DropdownOption",
                keyColumn: "Id",
                keyValue: new Guid("c4ebcac4-61fd-413c-bea3-d18cb18ae891"));

            migrationBuilder.DeleteData(
                table: "DropdownOption",
                keyColumn: "Id",
                keyValue: new Guid("fa428814-528a-407c-9e8a-e2547af1eed5"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("167dda74-1cec-4a9a-a871-c014e7734826"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("22373e6c-e472-4956-9094-7cd9337891a1"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("350f6dac-f0cb-4d35-bea4-c4f9ac9f98ab"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("46cb8e59-ed5c-4e98-90a0-b8c49f8b7ffb"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("48bfa35b-7121-4558-b448-1213526b0f4f"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("4afee1d2-e649-4cfd-a201-3b0004a2bff1"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("5c7fba81-07b7-4e00-8958-88508e89c3c1"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("76bcd255-884c-4e64-9a0c-ce24ff484651"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("a9d44ad8-cf87-49aa-9eac-8f60f9124124"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("c4967fdd-edb6-42c1-b3a2-e51ad192095f"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("c6398ced-8573-4caf-ac0c-3f57794345ad"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("caadc45b-e6e9-4968-b2a4-b985970e84de"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("dc48dbe3-abbe-47b8-bbf5-749ffa1028c2"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("f60a94e0-c52d-4989-8330-4e30fa454751"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("fa1fd9b4-147c-472a-920e-71e6bd8a031e"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("072c52f7-79cd-43b6-a06c-fd529495edea"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("20e124cd-9364-4665-9cc5-f42134ffaa02"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("2c770101-a625-455e-ae4f-fc62354dafeb"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("53da9ba0-71d3-43b2-89c4-e4e17f0279e1"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("c38742bc-2495-4f2d-a6bd-89dd72ed5a38"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("035cde21-9a76-4aab-a985-3124f96d2bc5"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("0adb0c91-d3f5-443d-8cb9-2b6ab5fc190c"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("1d0ead72-77df-4c63-b3ce-179c32a898b6"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("2c038305-0de9-429a-b506-692ae9074460"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("364cf763-4e6e-45e5-b583-8ab0e47fc0e0"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("4cb315bb-ad4a-475c-9d2c-88e8105094ac"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("5c0fced6-c74e-49e0-aaf0-3130238c0f9f"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("a4eb6387-0a32-4f33-96e9-3b76c38d1659"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("c35e32d1-b69a-4ef6-aa48-7fa354e840fe"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("c7b939f3-2738-446b-b820-e1d54ce249f1"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("03f940c9-c41e-46ee-be36-ff473d103d0a"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("08d42043-92ba-4d9a-a839-ba6e1e8d1165"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("2466561f-6120-419e-93ef-8be57a24d40c"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("4200a51b-5cb1-4121-b899-89f82d5f3fa6"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("61573fbf-9001-4534-8fa0-27fa1f1fa6ee"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("93badf9e-4c3a-47f7-a27e-257f903502d3"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("9c8d8f86-22a2-4bd9-b22d-03ef5d636e58"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("a1da1175-1239-40a6-a937-19c2858fe3de"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("a1dc4ee7-b879-4363-b509-05e9296a0bcd"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("bf8302a2-1922-43af-b190-dbb0b25295d7"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("e93437a7-dc17-4119-867a-792d3dcc60e2"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("ec772874-7104-4be4-baf3-1c756681c771"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategoryFeatureOption",
                keyColumns: new[] { "FeatureId", "SkillSubcategoryId" },
                keyValues: new object[] { new Guid("3837b73a-b536-4ba0-b22f-f03725b5a39d"), new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") });

            migrationBuilder.DeleteData(
                table: "SkillSubcategoryFeatureOption",
                keyColumns: new[] { "FeatureId", "SkillSubcategoryId" },
                keyValues: new object[] { new Guid("cada2850-5dfe-43bf-8073-8ead5650f98a"), new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") });

            migrationBuilder.DropColumn(
                name: "PremiumSelectedValue",
                table: "ProjectFeature");

            migrationBuilder.DropColumn(
                name: "StandardSelectedValue",
                table: "ProjectFeature");

            migrationBuilder.DropColumn(
                name: "HasPackages",
                table: "Project");

            migrationBuilder.RenameColumn(
                name: "BasicSelectedValue",
                table: "ProjectFeature",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Project",
                newName: "Name");

            migrationBuilder.AddColumn<int>(
                name: "PackageType",
                table: "ProjectFeature",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "EstimatedDays",
                table: "Project",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<float>(
                name: "Price",
                table: "Project",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddb34bfe-616a-46a0-af02-b7f29ee25daa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "c38026c0-bf91-4dbe-abfc-be5b6bd7eef0", "AQAAAAIAAYagAAAAEO6PPBF8SWy970WPIzDybaUtwBL8utUUV+bzl2IezBGBZvbrtnWA13rLcLVOxlvWsg==", "4acb72f1-adba-4b49-a268-65641589341b" });

            migrationBuilder.InsertData(
                table: "DropdownOption",
                columns: new[] { "Id", "IncrementValue", "LowerInterval", "UpperInterval" },
                values: new object[,]
                {
                    { new Guid("158f4680-e266-4af6-bc5f-f5d508faa626"), 1, 1, 50 },
                    { new Guid("41ae58b0-0175-4093-bac5-4d2caaa9c151"), 1, 1, 10 }
                });

            migrationBuilder.InsertData(
                table: "Feature",
                columns: new[] { "Id", "DropdownOptionId", "InputType", "Name" },
                values: new object[,]
                {
                    { new Guid("00f2211b-ff16-4fa8-b62d-b48f2135152f"), null, 0, "Hosting setup" },
                    { new Guid("15c7d622-832d-44be-8bbe-27408f926106"), null, 0, "Opt-in form" },
                    { new Guid("1861ff89-023b-4079-bfb2-e63205043b7a"), new Guid("8a4b9c88-1f53-4ab9-9052-f8594d732430"), 1, "Plugins/extensions " },
                    { new Guid("48353270-da63-4001-893b-b34557858ee5"), null, 0, "E-commerce functionality" },
                    { new Guid("4b787a45-707d-4f05-8c31-6b1da9345162"), null, 0, "Autoresponder" },
                    { new Guid("50b6fe2a-db77-4592-89e0-a08d1d4dc5c9"), new Guid("8a4b9c88-1f53-4ab9-9052-f8594d732430"), 1, "Number of pages" },
                    { new Guid("531a9651-4f98-4734-b0f9-2b297d1d08d4"), null, 0, "Functional website" },
                    { new Guid("63c35d87-a949-49d7-9e34-42947c11224c"), null, 0, "Speed optimization" },
                    { new Guid("64929635-e49c-44ef-ba1a-c5bdce062253"), null, 0, "Social media" },
                    { new Guid("7735f42f-be9d-48b9-91ef-a619fc56e5aa"), new Guid("e0046a44-904f-4124-8728-298394557fb6"), 1, "Number of products Dropdown" },
                    { new Guid("85c6e32c-6c29-4251-b114-1705e567ba96"), null, 0, "Content upload" },
                    { new Guid("8a627f65-53bf-41a3-993d-ff71e956e752"), null, 0, "Responsive design" },
                    { new Guid("fb8f2b42-562d-40f0-b6ed-89751197483c"), null, 0, "Payment processing" }
                });

            migrationBuilder.InsertData(
                table: "Skill",
                columns: new[] { "Id", "Description", "Name", "SkillSubcategoryId" },
                values: new object[,]
                {
                    { new Guid("3bec97b6-dcd6-4821-8147-ba5d0230fee7"), "Encompasses skills required to build fully functional and feature-rich websites.", "Build a Complete Website", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("72da57ce-33ed-42a1-a84f-f644991f2bc2"), "Skills related to designing and developing websites for business purposes.", "Business Websites", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("b1481c52-533f-46a8-bc15-ad789be80f74"), "Skills in designing and building effective landing pages for websites.", "Landing Pages", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("b7377409-3003-41f5-be43-6880e8b542f3"), "Focuses on creating websites optimized for dropshipping business models.", "Dropshipping Websites", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("bf15fe94-4f48-45df-aecf-9ace3bfd31f3"), "Involves creating online stores and platforms for e-commerce activities.", "E-Commerce Development", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") }
                });

            migrationBuilder.InsertData(
                table: "SkillCategory",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("02514f15-befa-4eb0-9d08-095267711c58"), "Skills related to content creation, writing, and translation services.", "Writing & Translation" },
                    { new Guid("2c754d2b-4693-4395-a033-55a7d279f095"), "This category involves skills related to artificial intelligence, machine learning, and AI-based services.", "AI Services" },
                    { new Guid("3de1170a-09a1-43fb-985b-57da2266b14f"), "Skills in music composition, audio production, and sound engineering.", "Music & Audio" },
                    { new Guid("4c09ec8f-6d9f-490f-bb70-dd2a8f6d702d"), "This category encompasses skills related to visual design, graphic arts, and creative visual communication.", "Graphics & Design" },
                    { new Guid("59ec5ca4-8f12-4b8f-8c4e-372143ec1cf9"), "Skills in programming, software development, and technology solutions fall under this category.", "Programming & Tech" },
                    { new Guid("6c3d7632-653f-4bcf-aede-cb9382ec6aad"), "Encompasses skills related to business strategy, management, and entrepreneurial activities.", "Business" },
                    { new Guid("6ecb7f1a-7604-4c57-8116-7526073d599f"), "Skills in capturing and editing visual images through photography.", "Photography" },
                    { new Guid("7bc22640-56ea-4564-8cb3-be1a7e969ad0"), "Skills related to online marketing, advertising, and promotion in the digital realm.", "Digital Marketing" },
                    { new Guid("d9a6b2db-a293-4f85-89f9-cd30c2610e46"), "This category covers skills in video creation, editing, and animation production.", "Video & Animation" },
                    { new Guid("df2f418f-5e9b-4d48-b097-29e0c26d04a8"), "Skills related to data analysis, management, and interpretation.", "Data" }
                });

            migrationBuilder.InsertData(
                table: "SkillSubcategory",
                columns: new[] { "Id", "Description", "Name", "SkillCategoryId" },
                values: new object[,]
                {
                    { new Guid("069c4e67-1ac1-47f8-9c3a-90f7e6461710"), "Focuses on creating interactive and engaging video games for various platforms.", "Game Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("10860381-6ee4-4c7c-8830-41f5eea7917c"), "Concerned with the ongoing support, updates, and troubleshooting of existing websites.", "Website Maintenance", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("1c79cb8d-741b-471d-9176-97fb484941d6"), "Involves the development and implementation of conversational agents for automated interactions.", "Chatbots", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("2366f47c-22e9-49b3-a626-a740f30fbcff"), "Involves creating and maintaining websites, focusing on design, functionality, and user experience.", "Website Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("24e5a983-0bd5-4062-8997-2534bd0d6961"), "Involves the creation and implementation of artificial intelligence algorithms and systems.", "AI Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("26419cef-bb22-46b6-a144-7126825a7169"), "Encompasses quality assurance, testing, and review processes to ensure software reliability.", "QA & Review", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("2d9d3164-1eee-45b5-bd1b-0ffea908620a"), "Encompasses the creation and maintenance of software applications for various platforms.", "Software Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("5c8696ef-4485-4bea-9005-dab2fc335550"), "Focuses on designing and building applications specifically for mobile devices.", "Mobile App Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("91371b15-9745-4128-ba5e-c0e7f9bd151f"), "Professionals specializing in software development, coding, and programming.", "Software Developers", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("a5f040ab-217c-4e46-a0e0-88f4f0e06f2f"), "Includes miscellaneous skills or services related to the broader category of programming and technology.", "Miscellaneous", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("ce71f8b8-5e33-4fe2-8d2c-62f511e832e9"), "Deals with understanding and utilizing various website development platforms and frameworks.", "Website Platforms", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("ea5cdf11-5855-40eb-b4ab-25d7300314d3"), "Involves providing support services and addressing cybersecurity concerns for software and systems.", "Support & Cybersecurity", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") }
                });
        }
    }
}
