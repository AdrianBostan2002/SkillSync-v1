using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkillSync.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedDescriptionFieldToOrderContentEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "OrderContent",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DropdownOption",
                keyColumn: "Id",
                keyValue: new Guid("de4cc996-6367-4757-b928-b82e81781cdd"));

            migrationBuilder.DeleteData(
                table: "DropdownOption",
                keyColumn: "Id",
                keyValue: new Guid("fd183520-c41f-46c7-aea2-ead656a4e063"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("1cd79aff-d32b-498e-8bf0-79123537463a"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("20b71085-0f2b-4cc4-8877-b30f15542629"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("43eb646f-29f1-41e5-b223-c2045e4bed76"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("4e3e5532-403c-4996-b89f-d37a2b766b02"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("59194a9f-6a89-4b5c-b1b1-f0b12ae2b31e"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("5cb35bc0-b526-4625-bb01-ed8b2d8ae0d7"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("60ae0ce9-de73-4dc0-9008-d372a0330139"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("7067dc14-eaf3-4d6d-8dab-66f7cd93a5c5"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("73c85bb6-e3d5-401b-a60a-ffd0c557b604"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("7ad91845-612f-4819-8503-8efddc864ac3"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("81d239f3-6d98-410f-9e67-3f820976bb5e"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("909c9d63-176e-4717-9453-078949c62bbe"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("911781bf-4eb7-4d7f-8adc-fb462f9c581c"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("a3e4142c-f1ec-4e32-ba2a-9b3cdf00417e"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("cbe26205-f167-4c42-810f-0986d9fc9f75"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("d2eccd7a-fe7c-4241-95d3-7f58fc2cd11b"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("e3546cde-96bc-493a-8ed4-82099b044601"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("e8840d1e-d001-4cdd-8fb0-04191c7bc9bb"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("17a599ea-fa83-4d41-9899-20f206138d1b"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("3b0fa5b0-b6f2-40e4-8732-760588ac4c6c"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("464cff32-8f36-4c34-92b6-23d6e3f5b672"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("b9766d89-8cd4-4d2a-a759-ff0edd924001"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("ed7f8d96-14d8-49c3-b1cc-a1249ca9432e"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("23ab81aa-79e4-4a1f-ba9c-a4466e826621"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("436931a7-5ce9-4dbd-9281-fc7edeef36b4"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("68001311-c576-43c3-9a1f-e56df3fe0296"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("84cfb2af-d3ea-451d-a874-6e8c3908702d"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("8f3be2f9-e25b-45ec-8908-988f05509d3d"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("9d1d880d-1988-4613-b861-bdcca72ff838"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("c2c62613-e6e6-44bc-acc8-4814f4dd7c43"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("d3377ad7-28f9-4c0d-ad45-a8398a29f38e"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("e1a56522-6775-4eaa-a302-9328e9c20fd3"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("e7c1c33a-d691-4419-9653-fb3f7ba359a9"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("02f713a4-d399-40b2-bdce-7198c23b6eac"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("052b4552-1996-485f-b934-1a5831948a3b"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("12ce8ea8-aaff-4642-b998-a54cd940f8ee"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("14751302-8225-4df0-a724-a825cdb2fcd1"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("3f2a4b27-5f15-495e-b88c-e7f92c30b163"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("3f6a4383-8b79-43b2-8429-5cae20c52bbf"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("4824f1d7-a462-4649-b66c-08a3aec113d9"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("8a3559fb-eeaa-4a6e-a6b5-45d0fc65b76e"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("8aa40bb4-c47d-4716-b0a1-b12b822a7b01"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("953e8791-6b9e-474a-b3f4-9422c431e576"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("c92d238b-45e5-4aaf-848a-d34999c3e339"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("ee42102f-a2ea-4060-9c0c-5a73a1ec4ca7"));

            migrationBuilder.DropColumn(
                name: "Description",
                table: "OrderContent");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddb34bfe-616a-46a0-af02-b7f29ee25daa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "21d3203d-49e7-4395-a93c-256a6c10a906", "AQAAAAIAAYagAAAAEFWydDcdJntXv8CzPbfk5vjBXgdBqNNZq0wTb2rdPcvKKqFcu257wxHxu+Z0+QliIA==", "3f4b06d9-1d76-40d7-b60f-50b1364cd6e5" });

            migrationBuilder.InsertData(
                table: "DropdownOption",
                columns: new[] { "Id", "IncrementValue", "LowerInterval", "UpperInterval" },
                values: new object[,]
                {
                    { new Guid("992f2b25-54e9-4503-aafd-96a8ff4a37d9"), 1, 1, 10 },
                    { new Guid("a76dcca8-db70-4044-91db-ef0777e8dbe6"), 1, 1, 50 }
                });

            migrationBuilder.InsertData(
                table: "Feature",
                columns: new[] { "Id", "DropdownOptionId", "InputType", "Name" },
                values: new object[,]
                {
                    { new Guid("461e5df7-135c-47f3-8108-981f8644ae9d"), null, 2, "Package description" },
                    { new Guid("4cf6d76f-ec78-4720-b0c8-6de3bd860c13"), new Guid("8a4b9c88-1f53-4ab9-9052-f8594d732430"), 1, "Plugins/extensions " },
                    { new Guid("4e23d358-b0f8-4dab-b08c-48336c059aef"), null, 2, "Package name" },
                    { new Guid("568ed8e6-d835-43dd-8ac2-e8a8b18d1592"), null, 0, "Social media" },
                    { new Guid("6b5a6030-6d5c-4e42-b122-1dfa9860f5f5"), new Guid("8a4b9c88-1f53-4ab9-9052-f8594d732430"), 1, "Number of pages" },
                    { new Guid("869100f6-1068-4c6c-8279-59b3eea19dfd"), null, 0, "Functional website" },
                    { new Guid("886abafb-1f31-45ed-94a3-c2559f886a3a"), null, 0, "Responsive design" },
                    { new Guid("89536c07-aea9-429b-8b89-37343bbd8ea8"), null, 0, "Hosting setup" },
                    { new Guid("8ec3a007-d3aa-4add-8ddd-c1036a55fbb1"), null, 0, "Content upload" },
                    { new Guid("93b42924-b626-48e4-94a1-ec2b1aeae689"), null, 0, "Payment processing" },
                    { new Guid("9d1d88cd-129e-4f40-96df-810f23f199f5"), null, 0, "Opt-in form" },
                    { new Guid("a4e03f04-ec7a-499e-842f-d45aa7443f08"), null, 0, "Autoresponder" },
                    { new Guid("ade0f4ff-d964-4d7b-b630-d732f100fe96"), new Guid("e0046a44-904f-4124-8728-298394557fb6"), 1, "Number of products" },
                    { new Guid("c1b4b179-822a-49cf-b581-a0fc9f4de232"), null, 1, "Revisions" },
                    { new Guid("cf2ed7e0-255f-40c8-b20d-af312829b3b6"), null, 2, "Price" },
                    { new Guid("d6b594de-4d9d-4a5c-8113-1334e6797c6c"), null, 0, "E-commerce functionality" },
                    { new Guid("db25089f-a2ac-4ef7-802e-b5ae443945d5"), null, 0, "Speed optimization" },
                    { new Guid("f292f4eb-0804-4a04-827a-d1724710b772"), new Guid("e0046a44-904f-4124-8728-298394557fb6"), 1, "Delivery time" }
                });

            migrationBuilder.InsertData(
                table: "Skill",
                columns: new[] { "Id", "Description", "Name", "SkillSubcategoryId" },
                values: new object[,]
                {
                    { new Guid("04fdc96f-d11b-4b07-847c-d008c0de1778"), "Focuses on creating websites optimized for dropshipping business models.", "Dropshipping Websites", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("39e00de6-fbe5-4740-b328-eac73777b7e6"), "Skills related to designing and developing websites for business purposes.", "Business Websites", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("46a77947-842f-4b87-bc44-043cad058e20"), "Involves creating online stores and platforms for e-commerce activities.", "E-Commerce Development", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("ce016be8-2757-42cf-9ea9-3c40aa4b035b"), "Skills in designing and building effective landing pages for websites.", "Landing Pages", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("f30cf60a-2725-4359-9b93-07ee0cfbdb5f"), "Encompasses skills required to build fully functional and feature-rich websites.", "Build a Complete Website", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") }
                });

            migrationBuilder.InsertData(
                table: "SkillCategory",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("0d2e719d-6477-4de8-8f10-f5575462da70"), "This category covers skills in video creation, editing, and animation production.", "Video & Animation" },
                    { new Guid("35637b56-659b-4ef5-a41c-9e1d85e48292"), "Skills in capturing and editing visual images through photography.", "Photography" },
                    { new Guid("47b48bb5-6748-4e27-9169-8a6e9ff94741"), "Skills related to data analysis, management, and interpretation.", "Data" },
                    { new Guid("516f94f9-a31f-4217-b800-c04d67911b70"), "Encompasses skills related to business strategy, management, and entrepreneurial activities.", "Business" },
                    { new Guid("51793274-564f-4e27-bbe1-89f296e629a9"), "Skills in music composition, audio production, and sound engineering.", "Music & Audio" },
                    { new Guid("77685226-d857-487b-bd4b-e10a9d17028e"), "Skills related to online marketing, advertising, and promotion in the digital realm.", "Digital Marketing" },
                    { new Guid("8a2d2dc3-eeea-4840-977a-5a8a0cbaf2cb"), "Skills in programming, software development, and technology solutions fall under this category.", "Programming & Tech" },
                    { new Guid("92305417-89f8-4a3c-a323-15bbc93e6ab1"), "Skills related to content creation, writing, and translation services.", "Writing & Translation" },
                    { new Guid("93171946-cbb5-47e1-a5b5-66051028c592"), "This category involves skills related to artificial intelligence, machine learning, and AI-based services.", "AI Services" },
                    { new Guid("a9a48139-8db5-4ee8-8792-55f632d6be0e"), "This category encompasses skills related to visual design, graphic arts, and creative visual communication.", "Graphics & Design" }
                });

            migrationBuilder.InsertData(
                table: "SkillSubcategory",
                columns: new[] { "Id", "Description", "Name", "SkillCategoryId" },
                values: new object[,]
                {
                    { new Guid("1e41973a-9516-41b3-89b6-ecde3009cfc9"), "Involves the development and implementation of conversational agents for automated interactions.", "Chatbots", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("220c769a-b332-4c7e-a3f6-adef7f483754"), "Involves creating and maintaining websites, focusing on design, functionality, and user experience.", "Website Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("300b4e13-699b-4874-a49a-24e357671d5c"), "Involves the creation and implementation of artificial intelligence algorithms and systems.", "AI Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("47416329-d453-45a3-a6d0-47408f38293c"), "Focuses on creating interactive and engaging video games for various platforms.", "Game Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("56c544de-148f-4b4e-8f94-d699c96e30f1"), "Involves providing support services and addressing cybersecurity concerns for software and systems.", "Support & Cybersecurity", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("8411eb73-79a6-4528-ac9a-7ec0275b55e7"), "Focuses on designing and building applications specifically for mobile devices.", "Mobile App Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("8429ca23-fb97-4444-83a6-5b2975718ac9"), "Professionals specializing in software development, coding, and programming.", "Software Developers", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("881bd687-252f-427b-9084-7b58b8d2e411"), "Encompasses quality assurance, testing, and review processes to ensure software reliability.", "QA & Review", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("967777df-5016-404c-b379-f42ab2a4a447"), "Encompasses the creation and maintenance of software applications for various platforms.", "Software Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("a063dbcf-29d3-4e1e-9f11-acbf24cdd75f"), "Deals with understanding and utilizing various website development platforms and frameworks.", "Website Platforms", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("be2591d3-29af-4d40-8340-97c292858360"), "Includes miscellaneous skills or services related to the broader category of programming and technology.", "Miscellaneous", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("eb4a6ad9-62ea-41d8-97f5-05da7682173f"), "Concerned with the ongoing support, updates, and troubleshooting of existing websites.", "Website Maintenance", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") }
                });
        }
    }
}
