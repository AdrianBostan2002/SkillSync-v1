using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillSync.Domain.Models;

namespace SkillSync.DataAccess.Configurations
{
    public class SkillConfiguration : IEntityTypeConfiguration<Skill>
    {
        public void Configure(EntityTypeBuilder<Skill> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Description).IsRequired();

            builder.HasData(
                new Skill
                {
                    Id = Guid.NewGuid(),
                    SkillSubcategoryId = Guid.Parse("241bbcfd-c981-4a19-803b-1753ce92643b"),
                    Name = "Business Websites",
                    Description = "Skills related to designing and developing websites for business purposes.",
                },
                new Skill
                {
                    Id = Guid.NewGuid(),
                    SkillSubcategoryId = Guid.Parse("241bbcfd-c981-4a19-803b-1753ce92643b"),
                    Name = "E-Commerce Development",
                    Description = "Involves creating online stores and platforms for e-commerce activities.",
                },
                new Skill
                {
                    Id = Guid.NewGuid(),
                    SkillSubcategoryId = Guid.Parse("241bbcfd-c981-4a19-803b-1753ce92643b"),
                    Name = "Landing Pages",
                    Description = "Skills in designing and building effective landing pages for websites.",
                },
                new Skill
                {
                    Id = Guid.NewGuid(),
                    SkillSubcategoryId = Guid.Parse("241bbcfd-c981-4a19-803b-1753ce92643b"),
                    Name = "Dropshipping Websites",
                    Description = "Focuses on creating websites optimized for dropshipping business models.",
                },
                new Skill
                {
                    Id = Guid.NewGuid(),
                    SkillSubcategoryId = Guid.Parse("241bbcfd-c981-4a19-803b-1753ce92643b"),
                    Name = "Build a Complete Website",
                    Description = "Encompasses skills required to build fully functional and feature-rich websites.",
                },

                //software development
                new Skill
                {
                    Id = Guid.NewGuid(),
                    SkillSubcategoryId = Guid.Parse("30a6b7a6-cc7f-4224-9b78-08c238d25271"),
                    Name = "Desktop Applications",
                    Description = "Developing software applications for desktop operating systems.",
                },
                new Skill
                {
                    Id = Guid.NewGuid(),
                    SkillSubcategoryId = Guid.Parse("30a6b7a6-cc7f-4224-9b78-08c238d25271"),
                    Name = "SaaS Development",
                    Description = "Creating software as a service applications hosted in the cloud.",
                },
                new Skill
                {
                    Id = Guid.NewGuid(),
                    SkillSubcategoryId = Guid.Parse("30a6b7a6-cc7f-4224-9b78-08c238d25271"),
                    Name = "API Development",
                    Description = "Building and integrating APIs for software applications.",
                },
                new Skill
                {
                    Id = Guid.NewGuid(),
                    SkillSubcategoryId = Guid.Parse("30a6b7a6-cc7f-4224-9b78-08c238d25271"),
                    Name = "Custom Software Development",
                    Description = "Developing bespoke software solutions tailored to specific business needs.",
                },
                new Skill
                {
                    Id = Guid.NewGuid(),
                    SkillSubcategoryId = Guid.Parse("30a6b7a6-cc7f-4224-9b78-08c238d25271"),
                    Name = "Database Development",
                    Description = "Designing and implementing databases to support software applications.",
                },

                //mobile app development
                new Skill
                {
                    Id = Guid.NewGuid(),
                    SkillSubcategoryId = Guid.Parse("4cf2f802-220b-46cc-8032-e3e1ebd4a312"),
                    Name = "iOS Development",
                    Description = "Creating applications specifically for Apple's iOS platform.",
                },
                new Skill
                {
                    Id = Guid.NewGuid(),
                    SkillSubcategoryId = Guid.Parse("4cf2f802-220b-46cc-8032-e3e1ebd4a312"),
                    Name = "Android Development",
                    Description = "Developing applications for Android devices.",
                },
                new Skill
                {
                    Id = Guid.NewGuid(),
                    SkillSubcategoryId = Guid.Parse("4cf2f802-220b-46cc-8032-e3e1ebd4a312"),
                    Name = "Cross-Platform Development",
                    Description = "Building mobile applications that run on multiple platforms (e.g., React Native, Flutter).",
                },
                new Skill
                {
                    Id = Guid.NewGuid(),
                    SkillSubcategoryId = Guid.Parse("4cf2f802-220b-46cc-8032-e3e1ebd4a312"),
                    Name = "App Design",
                    Description = "Designing user interfaces and experiences for mobile applications.",
                },
                new Skill
                {
                    Id = Guid.NewGuid(),
                    SkillSubcategoryId = Guid.Parse("4cf2f802-220b-46cc-8032-e3e1ebd4a312"),
                    Name = "App Store Optimization",
                    Description = "Optimizing mobile apps to rank higher in app store search results.",
                },

                //AI development
                new Skill
                {
                    Id = Guid.NewGuid(),
                    SkillSubcategoryId = Guid.Parse("526672e5-87f2-400a-90fe-1b2251a77943"),
                    Name = "Machine Learning",
                    Description = "Developing algorithms that enable machines to learn from data.",
                },
                new Skill
                {
                    Id = Guid.NewGuid(),
                    SkillSubcategoryId = Guid.Parse("526672e5-87f2-400a-90fe-1b2251a77943"),
                    Name = "Natural Language Processing",
                    Description = "Creating systems that understand and respond to human language.",
                },
                new Skill
                {
                    Id = Guid.NewGuid(),
                    SkillSubcategoryId = Guid.Parse("526672e5-87f2-400a-90fe-1b2251a77943"),
                    Name = "Computer Vision",
                    Description = "Developing systems that interpret and process visual data from the world.",
                },
                new Skill
                {
                    Id = Guid.NewGuid(),
                    SkillSubcategoryId = Guid.Parse("526672e5-87f2-400a-90fe-1b2251a77943"),
                    Name = "AI Model Training",
                    Description = "Training AI models using large datasets to perform specific tasks.",
                },
                new Skill
                {
                    Id = Guid.NewGuid(),
                    SkillSubcategoryId = Guid.Parse("526672e5-87f2-400a-90fe-1b2251a77943"),
                    Name = "Robotics",
                    Description = "Creating intelligent robots that can perform automated tasks.",
                },

                //game development
                new Skill
                {
                    Id = Guid.NewGuid(),
                    SkillSubcategoryId = Guid.Parse("d79dd736-6a61-4ecc-bc45-61dddd67cf88"),
                    Name = "Unity Development",
                    Description = "Creating games using the Unity game engine.",
                },
                new Skill
                {
                    Id = Guid.NewGuid(),
                    SkillSubcategoryId = Guid.Parse("d79dd736-6a61-4ecc-bc45-61dddd67cf88"),
                    Name = "Unreal Engine Development",
                    Description = "Developing games using the Unreal Engine.",
                },
                new Skill
                {
                    Id = Guid.NewGuid(),
                    SkillSubcategoryId = Guid.Parse("d79dd736-6a61-4ecc-bc45-61dddd67cf88"),
                    Name = "2D Game Development",
                    Description = "Creating 2D games and experiences.",
                },
                new Skill
                {
                    Id = Guid.NewGuid(),
                    SkillSubcategoryId = Guid.Parse("d79dd736-6a61-4ecc-bc45-61dddd67cf88"),
                    Name = "3D Game Development",
                    Description = "Creating 3D games and experiences.",
                },
                new Skill
                {
                    Id = Guid.NewGuid(),
                    SkillSubcategoryId = Guid.Parse("d79dd736-6a61-4ecc-bc45-61dddd67cf88"),
                    Name = "VR/AR Development",
                    Description = "Developing virtual reality and augmented reality games.",
                },

                //chatbots
                new Skill
                {
                    Id = Guid.NewGuid(),
                    SkillSubcategoryId = Guid.Parse("fb996aff-82f7-4b6c-a673-4befddfcf693"), // Use the correct Guid for "Chatbots"
                    Name = "Bot Development",
                    Description = "Creating and programming chatbots for various platforms.",
                },
                new Skill
                {
                    Id = Guid.NewGuid(),
                    SkillSubcategoryId = Guid.Parse("fb996aff-82f7-4b6c-a673-4befddfcf693"),
                    Name = "NLP Integration",
                    Description = "Integrating natural language processing capabilities into chatbots.",
                },
                new Skill
                {
                    Id = Guid.NewGuid(),
                    SkillSubcategoryId = Guid.Parse("fb996aff-82f7-4b6c-a673-4befddfcf693"),
                    Name = "Customer Support Bots",
                    Description = "Developing chatbots for customer support and service.",
                },
                new Skill
                {
                    Id = Guid.NewGuid(),
                    SkillSubcategoryId = Guid.Parse("fb996aff-82f7-4b6c-a673-4befddfcf693"),
                    Name = "E-Commerce Bots",
                    Description = "Creating chatbots for e-commerce platforms to assist with sales and support.",
                },
                new Skill
                {
                    Id = Guid.NewGuid(),
                    SkillSubcategoryId = Guid.Parse("fb996aff-82f7-4b6c-a673-4befddfcf693"),
                    Name = "Chatbot Analytics",
                    Description = "Implementing analytics to track and improve chatbot performance.",
                },

                //website maintenance
                new Skill
                {
                    Id = Guid.NewGuid(),
                    SkillSubcategoryId = Guid.Parse("43d0dc1e-3da6-4407-b984-d6bc91873fdf"),
                    Name = "Regular Updates",
                    Description = "Performing regular updates to ensure websites remain functional and secure.",
                },
                new Skill
                {
                    Id = Guid.NewGuid(),
                    SkillSubcategoryId = Guid.Parse("43d0dc1e-3da6-4407-b984-d6bc91873fdf"),
                    Name = "Security Monitoring",
                    Description = "Monitoring websites for security vulnerabilities and threats.",
                },
                new Skill
                {
                    Id = Guid.NewGuid(),
                    SkillSubcategoryId = Guid.Parse("43d0dc1e-3da6-4407-b984-d6bc91873fdf"),
                    Name = "Backup Management",
                    Description = "Managing website backups to prevent data loss.",
                },
                new Skill
                {
                    Id = Guid.NewGuid(),
                    SkillSubcategoryId = Guid.Parse("43d0dc1e-3da6-4407-b984-d6bc91873fdf"),
                    Name = "Performance Optimization",
                    Description = "Optimizing website performance for faster load times and better user experience.",
                },
                new Skill
                {
                    Id = Guid.NewGuid(),
                    SkillSubcategoryId = Guid.Parse("43d0dc1e-3da6-4407-b984-d6bc91873fdf"),
                    Name = "Troubleshooting",
                    Description = "Diagnosing and fixing website issues and errors.",
                },

                //QA & Review
                new Skill
                {
                    Id = Guid.NewGuid(),
                    SkillSubcategoryId = Guid.Parse("914a86c0-ee84-4a3a-9313-e48d61f0e38e"),
                    Name = "Manual Testing",
                    Description = "Performing manual testing to identify bugs and issues.",
                },
                new Skill
                {
                    Id = Guid.NewGuid(),
                    SkillSubcategoryId = Guid.Parse("914a86c0-ee84-4a3a-9313-e48d61f0e38e"),
                    Name = "Automated Testing",
                    Description = "Creating automated tests to ensure software quality and performance.",
                },
                new Skill
                {
                    Id = Guid.NewGuid(),
                    SkillSubcategoryId = Guid.Parse("914a86c0-ee84-4a3a-9313-e48d61f0e38e"),
                    Name = "Usability Testing",
                    Description = "Testing the usability and user experience of software applications.",
                },
                new Skill
                {
                    Id = Guid.NewGuid(),
                    SkillSubcategoryId = Guid.Parse("914a86c0-ee84-4a3a-9313-e48d61f0e38e"),
                    Name = "Performance Testing",
                    Description = "Assessing software performance under various conditions and loads.",
                },
                new Skill
                {
                    Id = Guid.NewGuid(),
                    SkillSubcategoryId = Guid.Parse("914a86c0-ee84-4a3a-9313-e48d61f0e38e"),
                    Name = "Bug Tracking",
                    Description = "Identifying, tracking, and managing software bugs and issues.",
                },

                //Support & Cybersecurity
                new Skill
                {
                    Id = Guid.NewGuid(),
                    SkillSubcategoryId = Guid.Parse("9447d817-d8e3-455b-9303-8ae66a15d6bc"),
                    Name = "Technical Support",
                    Description = "Providing technical support to resolve software and hardware issues.",
                },
                new Skill
                {
                    Id = Guid.NewGuid(),
                    SkillSubcategoryId = Guid.Parse("9447d817-d8e3-455b-9303-8ae66a15d6bc"),
                    Name = "Network Security",
                    Description = "Implementing security measures to protect networks and systems.",
                },
                new Skill
                {
                    Id = Guid.NewGuid(),
                    SkillSubcategoryId = Guid.Parse("9447d817-d8e3-455b-9303-8ae66a15d6bc"),
                    Name = "Penetration Testing",
                    Description = "Conducting penetration tests to identify and address security vulnerabilities.",
                },
                new Skill
                {
                    Id = Guid.NewGuid(),
                    SkillSubcategoryId = Guid.Parse("9447d817-d8e3-455b-9303-8ae66a15d6bc"),
                    Name = "Incident Response",
                    Description = "Managing and responding to security incidents and breaches.",
                },
                new Skill
                {
                    Id = Guid.NewGuid(),
                    SkillSubcategoryId = Guid.Parse("9447d817-d8e3-455b-9303-8ae66a15d6bc"),
                    Name = "Data Encryption",
                    Description = "Implementing data encryption to protect sensitive information.",
                }
              );
        }
    }
}