using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SkillSync.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddedOneToManyRelationshipFromReviewer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProjectReview_ReviewerId",
                table: "ProjectReview");

            migrationBuilder.CreateIndex(
                name: "IX_ProjectReview_ReviewerId",
                table: "ProjectReview",
                column: "ReviewerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_ProjectReview_ReviewerId",
                table: "ProjectReview");

            migrationBuilder.DeleteData(
                table: "DropdownOption",
                keyColumn: "Id",
                keyValue: new Guid("0c20d8f7-8047-4a77-a703-c6b1ecba09de"));

            migrationBuilder.DeleteData(
                table: "DropdownOption",
                keyColumn: "Id",
                keyValue: new Guid("6a28470f-2961-4e7f-955c-dc2791726fa4"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("0e738dc1-9dc1-4a58-8bf8-831ef98e733e"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("1f590421-f067-430c-9a8b-154c104aa2aa"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("3f33658e-640d-4c53-9890-d2ca5ffbf400"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("5a783c8e-1554-4221-833c-1daa4d13b38d"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("6708c4e0-2b4b-4a4d-b2f2-6018c08f4d29"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("71c981b3-5b97-4dae-981f-b4a0814ef5bc"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("71f8f4ae-645f-481d-8c5f-2f072d5d4b40"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("8895fcce-de66-4f80-bd64-ff1d1991f578"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("925ec3ea-fe21-4ff5-9cf9-c1ca047c2c0b"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("ae389447-83c8-4892-9eeb-65785787309f"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("b580c9d7-8077-42d3-9d26-d31425ccd595"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("b8f77e4f-a6f3-478d-80cc-75f830dbde54"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("c19ff12a-06ce-4ba8-89b3-bc4a7fcf065b"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("c24ae5c4-fdf5-48db-9f86-32577d0fa593"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("c8e3c029-ab3d-48cc-ae85-42a4810ff83b"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("d5e8c03f-5e20-49af-b691-9954d9361678"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("ea4fe4d4-c4cd-4cf0-b010-1628ae64e127"));

            migrationBuilder.DeleteData(
                table: "Feature",
                keyColumn: "Id",
                keyValue: new Guid("edebacfa-72d5-4db0-b6ae-19a3e3759cfe"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("12c3549a-7ce2-4597-867c-f504f1c18491"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("5270b6e2-d10c-4688-b06a-b67e2c2f451a"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("612baaf0-eaa6-4acd-9953-4574c826e61a"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("9e1e8e0c-77a3-470a-a2fa-f505e658bdcf"));

            migrationBuilder.DeleteData(
                table: "Skill",
                keyColumn: "Id",
                keyValue: new Guid("e09094e2-e776-407f-9044-4c7a02163216"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("3c4e2c00-b75d-43a9-940a-6882f8862e46"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("454c5c13-ed83-46b6-ad34-1f3ed21826f0"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("4dc58574-9fb1-45bb-88ae-7ec2cd4a4acb"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("5fa768c1-3299-4d5d-9158-86a9d5123d0e"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("9811aba0-bcbe-4f34-a918-de9814a37834"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("a1c9585a-a4d6-40b5-ade9-87a907eb93af"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("af6b52a3-0ff0-4bd1-9654-9998cfa57328"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("d0e966cb-1e8b-43d5-bb75-d72451c8a83f"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("df3f1c55-5af6-4196-baa7-19e4b4f3e515"));

            migrationBuilder.DeleteData(
                table: "SkillCategory",
                keyColumn: "Id",
                keyValue: new Guid("fe1d9ba4-2f0d-4c62-9b6e-9593941fed87"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("092378e8-566d-48fc-ab6d-76221ebcfc5b"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("1bc2e934-40e5-469e-8395-869e208b1213"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("1cabd95c-14da-4311-aad7-46b9ba02d478"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("1eb8fc12-c2a0-42db-b1d3-14ce9a4a7264"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("31729be6-53bf-47a2-80c4-ff13624e0456"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("363e6ba1-4216-4e77-b11f-754146318757"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("395f84ab-dd46-4247-a5c0-c31d048466f5"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("53acd660-fa33-4008-b2ce-51872908fd4f"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("7890f4e1-ab3e-4220-be8d-f964a5ac7e9f"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("82931d61-56a6-436a-b2fa-e05a9e7655ce"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("8b7ede62-9a42-4c2d-ae8e-aca5594b8674"));

            migrationBuilder.DeleteData(
                table: "SkillSubcategory",
                keyColumn: "Id",
                keyValue: new Guid("b1e26967-dd9e-4dc6-aca5-16e687cc71b4"));

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ddb34bfe-616a-46a0-af02-b7f29ee25daa",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "6d74b28a-014b-4dab-847b-aabb19150705", "AQAAAAIAAYagAAAAEKkrtIjsaGEGUe1pm4eKvvppKHRd6M0lt4fbC6HRBFNhGnrZCxpmj0s2oBwdcT//LQ==", "1094fe72-7158-4ee6-b299-ae12e5607076" });

            migrationBuilder.InsertData(
                table: "DropdownOption",
                columns: new[] { "Id", "IncrementValue", "LowerInterval", "UpperInterval" },
                values: new object[,]
                {
                    { new Guid("5b887f9d-c137-4641-be1c-7e7c2322b35a"), 1, 1, 10 },
                    { new Guid("8f6797bf-82fa-4a96-be35-47e8991f24f4"), 1, 1, 50 }
                });

            migrationBuilder.InsertData(
                table: "Feature",
                columns: new[] { "Id", "DropdownOptionId", "InputType", "Name" },
                values: new object[,]
                {
                    { new Guid("0f30a18d-4074-4ac3-bf35-29e30afd5e89"), null, 0, "Functional website" },
                    { new Guid("45059886-4bb6-4120-a94b-78cd546bf6ed"), null, 0, "Speed optimization" },
                    { new Guid("4b21d6b2-88f0-46ab-8b70-40ee158c90fd"), null, 0, "Autoresponder" },
                    { new Guid("4c92e135-1aa9-42c8-84ba-0cb24e55395f"), null, 0, "Opt-in form" },
                    { new Guid("5a024545-a427-48e8-9c19-b873fe1df5e8"), new Guid("8a4b9c88-1f53-4ab9-9052-f8594d732430"), 1, "Number of pages" },
                    { new Guid("6b343d1c-5068-4d2e-90ce-3ded58ded1b1"), null, 0, "E-commerce functionality" },
                    { new Guid("6b664ebd-63c2-4539-9c5c-effba7467edb"), new Guid("8a4b9c88-1f53-4ab9-9052-f8594d732430"), 1, "Plugins/extensions " },
                    { new Guid("6dab43b7-763f-41f4-ac95-db042b2a799b"), new Guid("e0046a44-904f-4124-8728-298394557fb6"), 1, "Delivery time" },
                    { new Guid("83d5d0f1-ffe2-40a2-91e7-1573d87704c2"), null, 0, "Responsive design" },
                    { new Guid("96f29025-77c3-480b-ba24-d4954cd68934"), null, 2, "Package name" },
                    { new Guid("97f74157-7d71-40ec-a994-47cb7889577c"), null, 0, "Content upload" },
                    { new Guid("97f76982-c91b-4e83-8a50-b7b79a81b82c"), null, 0, "Payment processing" },
                    { new Guid("baf0e89d-c7f4-4067-97d0-0fb00aff46d4"), null, 2, "Price" },
                    { new Guid("c2e28394-74f1-4198-b5a3-51835691ca66"), null, 0, "Social media" },
                    { new Guid("d385ed59-ab8b-4963-9833-7e5fcb675526"), null, 0, "Hosting setup" },
                    { new Guid("df6456f7-9b2b-4589-ba78-762170c9c93f"), null, 1, "Revisions" },
                    { new Guid("e52a3674-04e1-42fe-b739-7245cc7df283"), null, 2, "Package description" },
                    { new Guid("f0166c25-dec1-4086-aebe-9e65d4314dae"), new Guid("e0046a44-904f-4124-8728-298394557fb6"), 1, "Number of products" }
                });

            migrationBuilder.InsertData(
                table: "Skill",
                columns: new[] { "Id", "Description", "Name", "SkillSubcategoryId" },
                values: new object[,]
                {
                    { new Guid("038a5ed4-a9f6-4949-a3da-35062507afcf"), "Skills in designing and building effective landing pages for websites.", "Landing Pages", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("12caca20-5884-4dff-9a65-77c3ae91ea55"), "Involves creating online stores and platforms for e-commerce activities.", "E-Commerce Development", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("a10e77c6-2c1a-4f2f-a5a3-214e255252c2"), "Skills related to designing and developing websites for business purposes.", "Business Websites", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("ad639acf-d732-4c61-b8c6-ce028d5905c4"), "Focuses on creating websites optimized for dropshipping business models.", "Dropshipping Websites", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") },
                    { new Guid("d66a01af-ce65-40f5-bf91-62c3334475a1"), "Encompasses skills required to build fully functional and feature-rich websites.", "Build a Complete Website", new Guid("241bbcfd-c981-4a19-803b-1753ce92643b") }
                });

            migrationBuilder.InsertData(
                table: "SkillCategory",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { new Guid("074a84b2-1d42-4e50-be47-91905d26d98a"), "Skills in programming, software development, and technology solutions fall under this category.", "Programming & Tech" },
                    { new Guid("141b929c-1b2b-4d9f-8e13-fcd99c6d4c82"), "Skills related to data analysis, management, and interpretation.", "Data" },
                    { new Guid("2ad9ae0a-8ca6-44c0-a26f-41db79da03aa"), "Skills related to content creation, writing, and translation services.", "Writing & Translation" },
                    { new Guid("4a967498-f59a-483b-8a07-92f7b2a68cca"), "Skills related to online marketing, advertising, and promotion in the digital realm.", "Digital Marketing" },
                    { new Guid("583bc43c-52f4-44f6-9df4-b7d790e8cdb5"), "This category covers skills in video creation, editing, and animation production.", "Video & Animation" },
                    { new Guid("695ebde4-d416-4a87-982c-a198eb0883d0"), "This category involves skills related to artificial intelligence, machine learning, and AI-based services.", "AI Services" },
                    { new Guid("811c8d4e-e42a-4e54-9178-0c2c3c3f6035"), "Encompasses skills related to business strategy, management, and entrepreneurial activities.", "Business" },
                    { new Guid("9c81cc22-1c24-430d-9099-ffdfc4ff43d3"), "Skills in capturing and editing visual images through photography.", "Photography" },
                    { new Guid("b9386c93-d434-45b6-9275-a2765ea3ef0f"), "Skills in music composition, audio production, and sound engineering.", "Music & Audio" },
                    { new Guid("bd84a2e3-875c-4676-9600-7b7b84a33fbf"), "This category encompasses skills related to visual design, graphic arts, and creative visual communication.", "Graphics & Design" }
                });

            migrationBuilder.InsertData(
                table: "SkillSubcategory",
                columns: new[] { "Id", "Description", "Name", "SkillCategoryId" },
                values: new object[,]
                {
                    { new Guid("06074e9a-6f33-4f87-8161-6466bd62ae69"), "Includes miscellaneous skills or services related to the broader category of programming and technology.", "Miscellaneous", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("08b14cc0-a04a-43a1-a0cc-2ee5e96374f0"), "Involves the development and implementation of conversational agents for automated interactions.", "Chatbots", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("157bacc2-77a0-4be4-830f-e0c07ece9da8"), "Encompasses quality assurance, testing, and review processes to ensure software reliability.", "QA & Review", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("29060a86-1892-4d84-8a3b-95db4cf4ea65"), "Encompasses the creation and maintenance of software applications for various platforms.", "Software Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("35f4113c-9705-4baf-a3dd-2c4559a280b0"), "Focuses on designing and building applications specifically for mobile devices.", "Mobile App Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("48fdac65-6259-46a5-9677-50a1d6e4ba43"), "Focuses on creating interactive and engaging video games for various platforms.", "Game Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("6242985a-5a71-46ea-be22-847ca89cbc81"), "Deals with understanding and utilizing various website development platforms and frameworks.", "Website Platforms", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("81c75518-dd4d-4d28-be03-b4e04828faa6"), "Involves providing support services and addressing cybersecurity concerns for software and systems.", "Support & Cybersecurity", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("c65e790e-a81c-43ad-bf0d-2396f0b8e1c6"), "Involves the creation and implementation of artificial intelligence algorithms and systems.", "AI Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("dbd8ba95-3105-4198-8f04-0120b0c46014"), "Involves creating and maintaining websites, focusing on design, functionality, and user experience.", "Website Development", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("eb7cc34f-c366-4757-ad7d-dca7bdca3c01"), "Professionals specializing in software development, coding, and programming.", "Software Developers", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") },
                    { new Guid("f9d32425-9b60-4a42-928d-3d2b92657808"), "Concerned with the ongoing support, updates, and troubleshooting of existing websites.", "Website Maintenance", new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e") }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProjectReview_ReviewerId",
                table: "ProjectReview",
                column: "ReviewerId",
                unique: true);
        }
    }
}
