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
    [Migration("20240211173910_SeededSkills")]
    partial class SeededSkills
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

            modelBuilder.Entity("SkillSync.Domain.Models.Freelancer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

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
                            Id = new Guid("51731ffa-f8d4-4959-b9f3-109f9d9de6be"),
                            Description = "Skills related to designing and developing websites for business purposes.",
                            Name = "Business Websites",
                            SkillSubcategoryId = new Guid("241bbcfd-c981-4a19-803b-1753ce92643b")
                        },
                        new
                        {
                            Id = new Guid("76129785-91f1-4ab5-b2e4-983d01e74fba"),
                            Description = "Involves creating online stores and platforms for e-commerce activities.",
                            Name = "E-Commerce Development",
                            SkillSubcategoryId = new Guid("241bbcfd-c981-4a19-803b-1753ce92643b")
                        },
                        new
                        {
                            Id = new Guid("c0eabaee-44ef-4456-aede-08775c74dbde"),
                            Description = "Skills in designing and building effective landing pages for websites.",
                            Name = "Landing Pages",
                            SkillSubcategoryId = new Guid("241bbcfd-c981-4a19-803b-1753ce92643b")
                        },
                        new
                        {
                            Id = new Guid("8f8f2d8e-8554-4d48-a1b4-518ddb494fae"),
                            Description = "Focuses on creating websites optimized for dropshipping business models.",
                            Name = "Dropshipping Websites",
                            SkillSubcategoryId = new Guid("241bbcfd-c981-4a19-803b-1753ce92643b")
                        },
                        new
                        {
                            Id = new Guid("4c6e20ea-36cb-4562-938a-ec154f72962e"),
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
                            Id = new Guid("98ec0423-ee89-4080-a235-7e584b36d515"),
                            Description = "This category encompasses skills related to visual design, graphic arts, and creative visual communication.",
                            Name = "Graphics & Design"
                        },
                        new
                        {
                            Id = new Guid("941f4362-b90b-4fb0-95dc-bb5c479075c0"),
                            Description = "Skills in programming, software development, and technology solutions fall under this category.",
                            Name = "Programming & Tech"
                        },
                        new
                        {
                            Id = new Guid("77c605c7-fe8c-4e08-8924-62b8d75d7e2e"),
                            Description = "Skills related to online marketing, advertising, and promotion in the digital realm.",
                            Name = "Digital Marketing"
                        },
                        new
                        {
                            Id = new Guid("05e32d9c-da27-454e-8cec-a6fc19337a0f"),
                            Description = "This category covers skills in video creation, editing, and animation production.",
                            Name = "Video & Animation"
                        },
                        new
                        {
                            Id = new Guid("577135f8-baee-4aae-b383-559f22d765d6"),
                            Description = "Skills related to content creation, writing, and translation services.",
                            Name = "Writing & Translation"
                        },
                        new
                        {
                            Id = new Guid("15dd8634-e83c-40a1-a010-a22c37742279"),
                            Description = "Skills in music composition, audio production, and sound engineering.",
                            Name = "Music & Audio"
                        },
                        new
                        {
                            Id = new Guid("9bef0605-b311-4e80-b6e4-ad01f5ae967d"),
                            Description = "Encompasses skills related to business strategy, management, and entrepreneurial activities.",
                            Name = "Business"
                        },
                        new
                        {
                            Id = new Guid("6a32a035-a9fd-48ba-950d-54d1fc5766a4"),
                            Description = "Skills related to data analysis, management, and interpretation.",
                            Name = "Data"
                        },
                        new
                        {
                            Id = new Guid("879021d5-d241-4b98-b287-610daff4a922"),
                            Description = "Skills in capturing and editing visual images through photography.",
                            Name = "Photography"
                        },
                        new
                        {
                            Id = new Guid("ea065843-56d6-4fe5-9b20-cb0ec07d94be"),
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
                            Id = new Guid("d9929376-0e97-4a3d-9a6d-eb10a5bae1bd"),
                            Description = "Involves creating and maintaining websites, focusing on design, functionality, and user experience.",
                            Name = "Website Development",
                            SkillCategoryId = new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e")
                        },
                        new
                        {
                            Id = new Guid("433b318d-0d0a-46ff-8456-0e5e94ee06d1"),
                            Description = "Encompasses the creation and maintenance of software applications for various platforms.",
                            Name = "Software Development",
                            SkillCategoryId = new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e")
                        },
                        new
                        {
                            Id = new Guid("66d07342-5750-413d-9563-9a4350d3f175"),
                            Description = "Focuses on designing and building applications specifically for mobile devices.",
                            Name = "Mobile App Development",
                            SkillCategoryId = new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e")
                        },
                        new
                        {
                            Id = new Guid("6b0a960c-fcf9-4d1f-b3c1-eb28b24e4bcb"),
                            Description = "Involves the creation and implementation of artificial intelligence algorithms and systems.",
                            Name = "AI Development",
                            SkillCategoryId = new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e")
                        },
                        new
                        {
                            Id = new Guid("af6ac843-1139-4dcc-bcb0-56be93f4127b"),
                            Description = "Deals with understanding and utilizing various website development platforms and frameworks.",
                            Name = "Website Platforms",
                            SkillCategoryId = new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e")
                        },
                        new
                        {
                            Id = new Guid("663d78dc-e632-4f1c-ba6d-ad3bd752b0dd"),
                            Description = "Professionals specializing in software development, coding, and programming.",
                            Name = "Software Developers",
                            SkillCategoryId = new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e")
                        },
                        new
                        {
                            Id = new Guid("cf187e2b-f62b-4f06-9869-5168e01b4497"),
                            Description = "Focuses on creating interactive and engaging video games for various platforms.",
                            Name = "Game Development",
                            SkillCategoryId = new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e")
                        },
                        new
                        {
                            Id = new Guid("c43436d7-a1cf-45b7-a4b7-31962a4842d6"),
                            Description = "Involves the development and implementation of conversational agents for automated interactions.",
                            Name = "Chatbots",
                            SkillCategoryId = new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e")
                        },
                        new
                        {
                            Id = new Guid("38243d46-ad9a-4b64-a136-34891399ab1e"),
                            Description = "Concerned with the ongoing support, updates, and troubleshooting of existing websites.",
                            Name = "Website Maintenance",
                            SkillCategoryId = new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e")
                        },
                        new
                        {
                            Id = new Guid("867f32ee-8ecd-4248-a995-d8a60117fb1a"),
                            Description = "Encompasses quality assurance, testing, and review processes to ensure software reliability.",
                            Name = "QA & Review",
                            SkillCategoryId = new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e")
                        },
                        new
                        {
                            Id = new Guid("4091911a-5bac-469a-8cf6-ed7d41704449"),
                            Description = "Involves providing support services and addressing cybersecurity concerns for software and systems.",
                            Name = "Support & Cybersecurity",
                            SkillCategoryId = new Guid("8a3ea6d0-ef9f-4aa4-b779-e3af636ed75e")
                        },
                        new
                        {
                            Id = new Guid("00077880-2b41-4bb3-918a-a4b7ee51d5d0"),
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
                            ConcurrencyStamp = "788363c7-6927-42ca-9985-c0c52797f48d",
                            CountryCode = "RO",
                            Email = "bostan.adrian@gmail.com",
                            EmailConfirmed = true,
                            FirstName = "Adrian",
                            LastName = "Bostan",
                            LockoutEnabled = false,
                            NormalizedEmail = "BOSTAN.ADRIAN@GMAIL.COM",
                            NormalizedUserName = "BOSTAN.ADRIAN@GMAIL.COM",
                            PasswordHash = "AQAAAAIAAYagAAAAEI3Rdg6jke6pv6IBxcmQfdWP/3vemZjPRDF/Q2+ERyelisJUzArJK8aWCeS/n7qfGg==",
                            PhoneNumberConfirmed = false,
                            SecurityStamp = "b86f30b8-3938-4a73-8598-f4c77ca40540",
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