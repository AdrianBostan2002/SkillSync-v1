﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SkillSync.DataAccess;

#nullable disable

namespace SkillSync.DataAccess.Migrations
{
    [DbContext(typeof(RepositoryContext))]
    [Migration("20240218215526_AddedProjectFeatureAndFeatureTables")]
    partial class AddedProjectFeatureAndFeatureTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "1",
                            Name = "Admin",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "2",
                            Name = "Freelancer",
                            NormalizedName = "FREELANCER"
                        },
                        new
                        {
                            Id = "3",
                            Name = "SkillScout",
                            NormalizedName = "SKILLSCOUT"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);

                    b.HasData(
                        new
                        {
                            UserId = "ddb34bfe-616a-46a0-af02-b7f29ee25daa",
                            RoleId = "1"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("SkillSync.Domain.Models.Feature", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("InputType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Feature");
                });

            modelBuilder.Entity("SkillSync.Domain.Models.Freelancer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("HasCompletedExperienceInformations")
                        .HasColumnType("bit");

                    b.Property<string>("ScopeDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Freelancer");
                });

            modelBuilder.Entity("SkillSync.Domain.Models.FreelancerSkills", b =>
                {
                    b.Property<Guid>("FreelancerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SkillId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Experience")
                        .HasColumnType("int");

                    b.HasKey("FreelancerId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("FreelancerSkills");
                });

            modelBuilder.Entity("SkillSync.Domain.Models.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("EstimatedDays")
                        .HasColumnType("bigint");

                    b.Property<Guid>("FreelancerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<Guid>("SkillId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("FreelancerId");

                    b.HasIndex("SkillId");

                    b.ToTable("Project");
                });

            modelBuilder.Entity("SkillSync.Domain.Models.ProjectFeature", b =>
                {
                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("FeatureId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PackageType")
                        .HasColumnType("int");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProjectId", "FeatureId");

                    b.HasIndex("FeatureId");

                    b.ToTable("ProjectFeature");
                });

            modelBuilder.Entity("SkillSync.Domain.Models.Skill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("SkillSubcategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SkillSubcategoryId");

                    b.ToTable("Skill");

                    b.HasData(
                        new
                        {
                            Id = new Guid("99a449ed-bc43-47e0-b6a9-09483d16c432"),
                            Description = "Skills related to designing and developing websites for business purposes.",
                            Name = "Business Websites",
                            SkillSubcategoryId = new Guid("241bbcfd-c981-4a19-803b-1753ce92643b")
                        },
                        new
                        {
                            Id = new Guid("68323a81-34c5-4668-936a-c6ff47d3d73c"),
                            Description = "Involves creating online stores and platforms for e-commerce activities.",
                            Name = "E-Commerce Development",
                            SkillSubcategoryId = new Guid("241bbcfd-c981-4a19-803b-1753ce92643b")
                        },
                        new
                        {
                            Id = new Guid("f5692b89-1719-47a8-92e5-3f6e48ea0d77"),
                            Description = "Skills in designing and building effective landing pages for websites.",
                            Name = "Landing Pages",
                            SkillSubcategoryId = new Guid("241bbcfd-c981-4a19-803b-1753ce92643b")
                        },
                        new
                        {
                            Id = new Guid("bd90bcc6-9d94-4170-b709-8166c5363393"),
                            Description = "Focuses on creating websites optimized for dropshipping business models.",
                            Name = "Dropshipping Websites",
                            SkillSubcategoryId = new Guid("241bbcfd-c981-4a19-803b-1753ce92643b")
                        },
                        new
                        {
                            Id = new Guid("a1dc20d6-59d0-4b42-94e5-790ac3a01154"),
                            Description = "Encompasses skills required to build fully functional and feature-rich websites.",
                            Name = "Build a Complete Website",
                            SkillSubcategoryId = new Guid("241bbcfd-c981-4a19-803b-1753ce92643b")
                        });
                });

            modelBuilder.Entity("SkillSync.Domain.Models.SkillCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("SkillCategory");

                    b.HasData(
                        new
                        {
                            Id = new Guid("b5928161-d751-4563-8ffa-04c7f62f1c59"),
                            Description = "This category encompasses skills related to visual design, graphic arts, and creative visual communication.",
                            Name = "Graphics & Design"
                        },
                        new
                        {
                            Id = new Guid("ebcf02d0-c013-4801-ad74-939e9fea21e7"),
                            Description = "Skills in programming, software development, and technology solutions fall under this category.",
                            Name = "Programming & Tech"
                        },
                        new
                        {
                            Id = new Guid("b2019ee9-fe05-4291-a55f-c1771fb04f88"),
                            Description = "Skills related to online marketing, advertising, and promotion in the digital realm.",
                            Name = "Digital Marketing"
                        },
                        new
                        {
                            Id = new Guid("e06ca9f9-9724-475d-a894-969645112df4"),
                            Description = "This category covers skills in video creation, editing, and animation production.",
                            Name = "Video & Animation"
                        },
                        new
                        {
                            Id = new Guid("5d51fdb4-9069-4633-a0bb-724bcb7701f4"),
                            Description = "Skills related to content creation, writing, and translation services.",
                            Name = "Writing & Translation"
                        },
                        new
                        {
                            Id = new Guid("e9c6bc91-234b-42a2-b7c5-231aa2bfca27"),
                            Description = "Skills in music composition, audio production, and sound engineering.",
                            Name = "Music & Audio"
                        },
                        new
                        {
                            Id = new Guid("5037c6de-bc04-4c1a-bf57-c37aa480df22"),
                            Description = "Encompasses skills related to business strategy, management, and entrepreneurial activities.",
                            Name = "Business"
                        },
                        new
                        {
                            Id = new Guid("2afac680-ec50-4d8e-9b67-24f5b99e7eff"),
                            Description = "Skills related to data analysis, management, and interpretation.",
                            Name = "Data"
                        },
                        new
                        {
                            Id = new Guid("ba922266-9790-4c8c-9a8e-e3325a2edb93"),
                            Description = "Skills in capturing and editing visual images through photography.",
                            Name = "Photography"
                        },
                        new
                        {
                            Id = new Guid("269f0dbc-fca4-4248-bac9-00d5ecc83ef6"),
                            Description = "This category involves skills related to artificial intelligence, machine learning, and AI-based services.",
                            Name = "AI Services"
                        });
                });

            modelBuilder.Entity("SkillSync.Domain.Models.SkillScout", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("SkillScout");
                });

            modelBuilder.Entity("SkillSync.Domain.Models.SkillScoutFavoriteSkills", b =>
                {
                    b.Property<Guid>("SkillScoutId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SkillId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("SkillScoutId", "SkillId");

                    b.HasIndex("SkillId");

                    b.ToTable("SkillScoutFavoriteSkills");
                });

            modelBuilder.Entity("SkillSync.Domain.Models.SkillSubcategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<Guid>("SkillCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("SkillCategoryId");

                    b.ToTable("SkillSubcategory");

                    b.HasData(
                        new
                        {
                            Id = new Guid("2db1f812-bfae-433d-aea7-b72053ca672b"),
                            Description = "Involves creating and maintaining websites, focusing on design, functionality, and user experience.",
                            Name = "Website Development",
                            SkillCategoryId = new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e")
                        },
                        new
                        {
                            Id = new Guid("7b8e7ee9-0f26-43fb-9bdc-0250675f1df7"),
                            Description = "Encompasses the creation and maintenance of software applications for various platforms.",
                            Name = "Software Development",
                            SkillCategoryId = new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e")
                        },
                        new
                        {
                            Id = new Guid("66a8cac4-4733-4772-a762-dcc9524d452c"),
                            Description = "Focuses on designing and building applications specifically for mobile devices.",
                            Name = "Mobile App Development",
                            SkillCategoryId = new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e")
                        },
                        new
                        {
                            Id = new Guid("a1eaa387-d663-4dd0-9883-12a7e4e1c804"),
                            Description = "Involves the creation and implementation of artificial intelligence algorithms and systems.",
                            Name = "AI Development",
                            SkillCategoryId = new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e")
                        },
                        new
                        {
                            Id = new Guid("647a331c-9e09-4849-bcf6-b41ad5ae7fe0"),
                            Description = "Deals with understanding and utilizing various website development platforms and frameworks.",
                            Name = "Website Platforms",
                            SkillCategoryId = new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e")
                        },
                        new
                        {
                            Id = new Guid("431b5b53-39c4-4f46-ab2d-b21405e0298a"),
                            Description = "Professionals specializing in software development, coding, and programming.",
                            Name = "Software Developers",
                            SkillCategoryId = new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e")
                        },
                        new
                        {
                            Id = new Guid("0246daa6-29d5-4332-a318-be802f1896ef"),
                            Description = "Focuses on creating interactive and engaging video games for various platforms.",
                            Name = "Game Development",
                            SkillCategoryId = new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e")
                        },
                        new
                        {
                            Id = new Guid("b10357d0-8b3e-4689-a9e6-dafad35a4660"),
                            Description = "Involves the development and implementation of conversational agents for automated interactions.",
                            Name = "Chatbots",
                            SkillCategoryId = new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e")
                        },
                        new
                        {
                            Id = new Guid("62611690-def9-4ffc-b30b-919edcc98499"),
                            Description = "Concerned with the ongoing support, updates, and troubleshooting of existing websites.",
                            Name = "Website Maintenance",
                            SkillCategoryId = new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e")
                        },
                        new
                        {
                            Id = new Guid("6d47bbd3-6ea3-4a78-9699-aadc00fab349"),
                            Description = "Encompasses quality assurance, testing, and review processes to ensure software reliability.",
                            Name = "QA & Review",
                            SkillCategoryId = new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e")
                        },
                        new
                        {
                            Id = new Guid("cf03e1b2-d149-41fe-9a28-755f6fd53cd7"),
                            Description = "Involves providing support services and addressing cybersecurity concerns for software and systems.",
                            Name = "Support & Cybersecurity",
                            SkillCategoryId = new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e")
                        },
                        new
                        {
                            Id = new Guid("4840d905-040d-439a-870a-d0ae6cadbcd2"),
                            Description = "Includes miscellaneous skills or services related to the broader category of programming and technology.",
                            Name = "Miscellaneous",
                            SkillCategoryId = new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e")
                        });
                });

            modelBuilder.Entity("SkillSync.Domain.Models.User", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CountryCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("ProfilePicture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "ddb34bfe-616a-46a0-af02-b7f29ee25daa",
                            AccessFailedCount = 0,
                            ConcurrencyStamp = "a40d70a9-51af-409b-b8a3-b89ffeeb28b0",
                            CountryCode = "RO",
                            Email = "bostan.adrian@gmail.com",
                            EmailConfirmed = true,
                            FirstName = "Adrian",
                            LastName = "Bostan",
                            LockoutEnabled = false,
                            NormalizedEmail = "BOSTAN.ADRIAN@GMAIL.COM",
                            NormalizedUserName = "BOSTAN.ADRIAN@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEMoU2cMHokI6ZfQUF5TtsTkoOXaGrVrJh2dl0KdpZh6wZW4mABTDFHqAhZAc9E7j/Q==",
                            PhoneNumberConfirmed = false,
                            ProfilePicture = "admin-pf",
                            SecurityStamp = "c05a6fb2-96d8-4e03-9ad9-61245894b457",
                            TwoFactorEnabled = false,
                            UserName = "bostan.adrian@gmail.com"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("SkillSync.Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("SkillSync.Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SkillSync.Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("SkillSync.Domain.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SkillSync.Domain.Models.Freelancer", b =>
                {
                    b.HasOne("SkillSync.Domain.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SkillSync.Domain.Models.FreelancerSkills", b =>
                {
                    b.HasOne("SkillSync.Domain.Models.Freelancer", "Freelancer")
                        .WithMany("FreelancerSkills")
                        .HasForeignKey("FreelancerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SkillSync.Domain.Models.Skill", "Skill")
                        .WithMany("Freelancers")
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Freelancer");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("SkillSync.Domain.Models.Project", b =>
                {
                    b.HasOne("SkillSync.Domain.Models.Freelancer", "Freelancer")
                        .WithMany()
                        .HasForeignKey("FreelancerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("SkillSync.Domain.Models.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Freelancer");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("SkillSync.Domain.Models.ProjectFeature", b =>
                {
                    b.HasOne("SkillSync.Domain.Models.Feature", "Feature")
                        .WithMany()
                        .HasForeignKey("FeatureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SkillSync.Domain.Models.Project", "Project")
                        .WithMany("Features")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Feature");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("SkillSync.Domain.Models.Skill", b =>
                {
                    b.HasOne("SkillSync.Domain.Models.SkillSubcategory", null)
                        .WithMany("Skills")
                        .HasForeignKey("SkillSubcategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SkillSync.Domain.Models.SkillScout", b =>
                {
                    b.HasOne("SkillSync.Domain.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SkillSync.Domain.Models.SkillScoutFavoriteSkills", b =>
                {
                    b.HasOne("SkillSync.Domain.Models.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SkillSync.Domain.Models.SkillScout", "SkillScout")
                        .WithMany("FavoriteSkills")
                        .HasForeignKey("SkillScoutId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Skill");

                    b.Navigation("SkillScout");
                });

            modelBuilder.Entity("SkillSync.Domain.Models.SkillSubcategory", b =>
                {
                    b.HasOne("SkillSync.Domain.Models.SkillCategory", "SkillCategory")
                        .WithMany("SkillSubcategories")
                        .HasForeignKey("SkillCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("SkillCategory");
                });

            modelBuilder.Entity("SkillSync.Domain.Models.Freelancer", b =>
                {
                    b.Navigation("FreelancerSkills");
                });

            modelBuilder.Entity("SkillSync.Domain.Models.Project", b =>
                {
                    b.Navigation("Features");
                });

            modelBuilder.Entity("SkillSync.Domain.Models.Skill", b =>
                {
                    b.Navigation("Freelancers");
                });

            modelBuilder.Entity("SkillSync.Domain.Models.SkillCategory", b =>
                {
                    b.Navigation("SkillSubcategories");
                });

            modelBuilder.Entity("SkillSync.Domain.Models.SkillScout", b =>
                {
                    b.Navigation("FavoriteSkills");
                });

            modelBuilder.Entity("SkillSync.Domain.Models.SkillSubcategory", b =>
                {
                    b.Navigation("Skills");
                });
#pragma warning restore 612, 618
        }
    }
}