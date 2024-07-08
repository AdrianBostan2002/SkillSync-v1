using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkillSync.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedPackeTypeInsideOrderEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CompletedAt",
                table: "Order",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "PackageType",
                table: "Order",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "DropdownOption",
                keyColumn: "Id",
                keyValue: new Guid("992f2b25-54e9-4503-aafd-96a8ff4a37d9"));

            migrationBuilder.DeleteData(
                table: "DropdownOption",
                keyColumn: "Id",
                keyValue: new Guid("a76dcca8-db70-4044-91db-ef0777e8dbe6"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("461e5df7-135c-47f3-8108-981f8644ae9d"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("4cf6d76f-ec78-4720-b0c8-6de3bd860c13"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("4e23d358-b0f8-4dab-b08c-48336c059aef"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("568ed8e6-d835-43dd-8ac2-e8a8b18d1592"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("6b5a6030-6d5c-4e42-b122-1dfa9860f5f5"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("869100f6-1068-4c6c-8279-59b3eea19dfd"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("886abafb-1f31-45ed-94a3-c2559f886a3a"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("89536c07-aea9-429b-8b89-37343bbd8ea8"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("8ec3a007-d3aa-4add-8ddd-c1036a55fbb1"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("93b42924-b626-48e4-94a1-ec2b1aeae689"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("9d1d88cd-129e-4f40-96df-810f23f199f5"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("a4e03f04-ec7a-499e-842f-d45aa7443f08"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("ade0f4ff-d964-4d7b-b630-d732f100fe96"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("c1b4b179-822a-49cf-b581-a0fc9f4de232"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("cf2ed7e0-255f-40c8-b20d-af312829b3b6"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("d6b594de-4d9d-4a5c-8113-1334e6797c6c"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("db25089f-a2ac-4ef7-802e-b5ae443945d5"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("f292f4eb-0804-4a04-827a-d1724710b772"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("04fdc96f-d11b-4b07-847c-d008c0de1778"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("39e00de6-fbe5-4740-b328-eac73777b7e6"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("46a77947-842f-4b87-bc44-043cad058e20"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("ce016be8-2757-42cf-9ea9-3c40aa4b035b"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("f30cf60a-2725-4359-9b93-07ee0cfbdb5f"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("0d2e719d-6477-4de8-8f10-f5575462da70"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("35637b56-659b-4ef5-a41c-9e1d85e48292"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("47b48bb5-6748-4e27-9169-8a6e9ff94741"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("516f94f9-a31f-4217-b800-c04d67911b70"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("51793274-564f-4e27-bbe1-89f296e629a9"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("77685226-d857-487b-bd4b-e10a9d17028e"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("8a2d2dc3-eeea-4840-977a-5a8a0cbaf2cb"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("92305417-89f8-4a3c-a323-15bbc93e6ab1"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("93171946-cbb5-47e1-a5b5-66051028c592"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("a9a48139-8db5-4ee8-8792-55f632d6be0e"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("1e41973a-9516-41b3-89b6-ecde3009cfc9"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("220c769a-b332-4c7e-a3f6-adef7f483754"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("300b4e13-699b-4874-a49a-24e357671d5c"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("47416329-d453-45a3-a6d0-47408f38293c"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("56c544de-148f-4b4e-8f94-d699c96e30f1"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("8411eb73-79a6-4528-ac9a-7ec0275b55e7"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("8429ca23-fb97-4444-83a6-5b2975718ac9"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("881bd687-252f-427b-9084-7b58b8d2e411"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("967777df-5016-404c-b379-f42ab2a4a447"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("a063dbcf-29d3-4e1e-9f11-acbf24cdd75f"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("be2591d3-29af-4d40-8340-97c292858360"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("eb4a6ad9-62ea-41d8-97f5-05da7682173f"));

            migrationBuilder.DropColumn(
                name: "PackageType",
                table: "Order");

            migrationBuilder.AlterColumn<string>(
                name: "CompletedAt",
                table: "Order",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddb34bfe-616a-46a0-af02-b7f29ee25daa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "dcd1f49f-f2d4-4571-8c1b-45cca3f29eda", "AQAAAAIAAYagAAAAEGaw2zApKYiBX7nxLwNjiQFBAgf8TcxW8YPR98m4P9eRroKlCkIxQFjX6+6m8EQzeg==", "c958d692-c58b-4d2c-8a6f-ecd77700d7b1" });

            migrationBuilder.InsertData(
                table: "DropdownOption",
                columns: new[] { "Id", "IncrementValue", "LowerInterval", "UpperInterval" },
                values: new object[,]
                {
                    { new Guid("2eab09aa-d20e-4488-814b-7aef7b5e060d"), 1, 1, 10 },
                    { new Guid("cef1346d-e4e9-4c00-8df2-da0fdea77738"), 1, 1, 50 }
                });

            migrationBuilder.InsertData(
                table: "Feature",
                columns: new[] { "Id", "DropdownOptionId", "InputType", "Name" },
                values: new object[,]
                {
                    { new Guid("008fde91-47f2-4646-be00-9737e21b9200"), null, 2, "Package name" },
                    { new Guid("042197e1-497f-4c8d-8205-89d96d7b9625"), new Guid("e0046a44-904f-4124-8728-298394557fb6"), 1, "Number of products" },
                    { new Guid("0f8a8362-a095-4b30-bfbd-0d5f99afeddd"), null, 1, "Revisions" },
                    { new Guid("133e56ad-270b-4979-948d-7f908519c2e5"), null, 2, "Package description" },
                    { new Guid("154ed73b-990a-4243-badd-6ef7345df485"), null, 0, "Hosting setup" },
                    { new Guid("19779139-3811-41ee-9f6e-d586f854d83b"), null, 0, "Responsive design" },
                    { new Guid("360e8150-eee1-40d2-abf2-a66e82dee391"), new Guid("8a4b9c88-1f53-4ab9-9052-f8594d732430"), 1, "Number of pages" },
                    { new Guid("3d3e2ada-6551-463b-b8f1-96c208833b66"), null, 0, "Content upload" },
                    { new Guid("585b3ff6-7e9b-40c5-939b-2b280f635d26"), null, 0, "Opt-in form" },
                    { new Guid("59b54baa-ef2d-4752-a10c-0396d89a6f3b"), null, 2, "Price" },
                    { new Guid("88648780-448c-4db5-8296-dcd759a5ae32"), null, 0, "Social media" },
                    { new Guid("918f2360-6613-43b2-9f42-7cc182c49862"), new Guid("8a4b9c88-1f53-4ab9-9052-f8594d732430"), 1, "Plugins/extensions " },
                    { new Guid("abfadeb7-232b-4528-99fd-f1e30daf7c6d"), null, 0, "Functional website" },
                    { new Guid("b5ca34e3-7fc2-4598-b585-59b21829f022"), null, 0, "E-commerce functionality" },
                    { new Guid("b67353ea-a325-4417-a5fe-c67a8ccab714"), null, 0, "Autoresponder" },
                    { new Guid("d31fb5cc-4dd2-4e97-9ead-c1eed76c122a"), new Guid("e0046a44-904f-4124-8728-298394557fb6"), 1, "Delivery time" },
                    { new Guid("e202ebed-7c3c-4639-8691-e1eabe714f17"), null, 0, "Speed optimization" },
                    { new Guid("e532a1ef-5c9b-42e7-97d4-b04ec1c84861"), null, 0, "Payment processing" }
                });

            migrationBuilder.InsertData(
                table: "Skill",
                columns: new[] { "Id", "Description", "Name", "SkillSubcategoryId" },
                values: new object[,]
                {
                    { new Guid("028c59b5-bc28-452e-beb5-c4d15bafd873"), "Encompasses skills required to build fully functional and feature-rich websites.", "Build a Complete Website", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("0409eb99-0b12-4243-9f84-dfc69798d755"), "Skills related to designing and developing websites for business purposes.", "Business Websites", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("816c8d4d-b6c7-4a0a-8d76-3dff6e395b26"), "Involves creating online stores and platforms for e-commerce activities.", "E-Commerce Development", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("cfb80acc-03ce-4d3c-a1a4-427abbb9f93a"), "Focuses on creating websites optimized for dropshipping business models.", "Dropshipping Websites", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("d5c22c51-4de6-4877-92f6-502ed76269b8"), "Skills in designing and building effective landing pages for websites.", "Landing Pages", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") }
                });

            migrationBuilder.InsertData(
                table: "SkillCategory",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("07d3d424-55a3-41df-a2f0-f15354294cfd"), "Skills in music composition, audio production, and sound engineering.", "Music & Audio" },
                    { new Guid("4a596ad2-e3d1-4ee3-9e30-a0538c914df9"), "This category covers skills in video creation, editing, and animation production.", "Video & Animation" },
                    { new Guid("554f07e0-94da-4744-8827-6f39ea22a75d"), "This category involves skills related to artificial intelligence, machine learning, and AI-based services.", "AI Services" },
                    { new Guid("6c29a308-7b5b-4e84-afd8-4ecd8e3924b3"), "Skills related to content creation, writing, and translation services.", "Writing & Translation" },
                    { new Guid("753d0c92-fb7b-4295-9c17-6061550ed54e"), "Skills related to online marketing, advertising, and promotion in the digital realm.", "Digital Marketing" },
                    { new Guid("851f5c9f-37f4-4a59-8ab0-a479aa7de028"), "Encompasses skills related to business strategy, management, and entrepreneurial activities.", "Business" },
                    { new Guid("87eac28b-463f-4971-b89a-d768bb17a3b9"), "Skills related to data analysis, management, and interpretation.", "Data" },
                    { new Guid("e5c39090-d287-46d6-ac54-3f8a9f5eeb0d"), "Skills in capturing and editing visual images through photography.", "Photography" },
                    { new Guid("ea142354-6ae9-4b09-9eeb-de08b785af51"), "This category encompasses skills related to visual design, graphic arts, and creative visual communication.", "Graphics & Design" },
                    { new Guid("feb75e26-3be2-49ee-a325-c00dd99f96ea"), "Skills in programming, software development, and technology solutions fall under this category.", "Programming & Tech" }
                });

            migrationBuilder.InsertData(
                table: "SkillSubcategory",
                columns: new[] { "Id", "Description", "Name", "SkillCategoryId" },
                values: new object[,]
                {
                    { new Guid("0188a931-b93b-4c23-b5ea-bef96e94d551"), "Deals with understanding and utilizing various website development platforms and frameworks.", "Website Platforms", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("0a1945f3-b824-44cb-b304-900f5dbc1900"), "Professionals specializing in software development, coding, and programming.", "Software Developers", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("4aa1ba5a-bb9e-4d01-93b4-bece642c4f50"), "Involves creating and maintaining websites, focusing on design, functionality, and user experience.", "Website Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("6ac4d5b2-8a63-4c29-89c9-2fd0605e2b6d"), "Involves providing support services and addressing cybersecurity concerns for software and systems.", "Support & Cybersecurity", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("74b4dd68-0c1f-4a44-80a2-4719f4d1bff6"), "Focuses on designing and building applications specifically for mobile devices.", "Mobile App Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("988ae729-4c9f-4fb1-9fc5-d62605950e77"), "Focuses on creating interactive and engaging video games for various platforms.", "Game Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("9a3be120-b408-49da-a403-6936e186b2cc"), "Involves the development and implementation of conversational agents for automated interactions.", "Chatbots", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("b341b805-9455-45bf-975e-6611fc2e6b39"), "Encompasses the creation and maintenance of software applications for various platforms.", "Software Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("b8f78954-ef50-4709-8693-0282f2219f3a"), "Involves the creation and implementation of artificial intelligence algorithms and systems.", "AI Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("d19915de-40da-4c01-88f3-4bd2d136e96c"), "Encompasses quality assurance, testing, and review processes to ensure software reliability.", "QA & Review", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("e3dd1b8f-58dd-4df2-be29-a7113904cb03"), "Includes miscellaneous skills or services related to the broader category of programming and technology.", "Miscellaneous", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("fcf284b4-afcf-4718-9a55-6537924a886d"), "Concerned with the ongoing support, updates, and troubleshooting of existing websites.", "Website Maintenance", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") }
                });
        }
    }
}
