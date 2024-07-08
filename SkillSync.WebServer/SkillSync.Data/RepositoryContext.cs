using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SkillSync.DataAccess.Configurations;
using SkillSync.Domain.Models;

namespace SkillSync.DataAccess
{
    public class RepositoryContext : IdentityDbContext<User>
    {
        public RepositoryContext(DbContextOptions options) :
            base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new UserRoleConfiguration());
            modelBuilder.ApplyConfiguration(new SkillCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new SkillSubcategoryConfiguration());
            modelBuilder.ApplyConfiguration(new SkillConfiguration());
            modelBuilder.ApplyConfiguration(new DropdownOptionConfiguration());
            modelBuilder.ApplyConfiguration(new FeatureConfiguration());
            modelBuilder.ApplyConfiguration(new SkillSubcategoryFeatureOptionConfiguration());

            ConfigureFreelancer(modelBuilder);
            ConfigureFreelancersSkills(modelBuilder);
            ConfigureSkillScout(modelBuilder);
            ConfigureProject(modelBuilder);
            ConfigureSkillScoutFavoriteSkills(modelBuilder);
            ConfigureProjectFeature(modelBuilder);
            ConfigureSkillSubcategoryFeatureOptions(modelBuilder);
            ConfigureUserFavoriteProjects(modelBuilder);
            ConfigureUserChat(modelBuilder);
            ConfigureChatMessages(modelBuilder);
            ConfigureUserNotification(modelBuilder);
            ConfigureNotification(modelBuilder);
            ConfigureOrder(modelBuilder);
            ConfigureOrderContent(modelBuilder);
            ConfigureProjectReview(modelBuilder);
        }

        private void ConfigureFreelancersSkills(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FreelancerSkills>()
                .HasKey(fp => new { fp.FreelancerId, fp.SkillId });

            modelBuilder.Entity<FreelancerSkills>()
                .HasOne(fp => fp.Freelancer)
                .WithMany(f => f.FreelancerSkills)
                .HasForeignKey(fp => fp.FreelancerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<FreelancerSkills>()
                .HasOne(fp => fp.Skill)
                .WithMany(s => s.Freelancers)
                .HasForeignKey(fp => fp.SkillId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        private void ConfigureFreelancer(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Freelancer>().HasKey(x => x.Id);

            modelBuilder.Entity<SkillScout>()
            .HasOne(f => f.User)
            .WithMany()
            .HasForeignKey(f => f.UserId)
            .IsRequired();
        }

        private void ConfigureSkillScout(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SkillScout>().HasKey(x => x.Id);

            modelBuilder.Entity<SkillScout>()
            .HasOne(ss => ss.User)
            .WithMany()
            .HasForeignKey(ss => ss.UserId)
            .IsRequired();
        }

        private void ConfigureProject(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>().HasKey(x => x.Id);

            modelBuilder.Entity<Project>().Property(x => x.Title).IsRequired().HasMaxLength(100);

            modelBuilder.Entity<Project>()
               .Property(e => e.CreatedAt)
               .HasConversion(
                   v => v.ToString("yyyy-MM-dd"),
                   v => DateTime.ParseExact(v, "yyyy-MM-dd", null)
               );

            modelBuilder.Entity<Project>()
                .HasOne(x => x.Skill)
                .WithMany()
                .HasForeignKey(x => x.SkillId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Project>()
                .HasOne(x => x.Freelancer)
                .WithMany()
                .HasForeignKey(x => x.FreelancerId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Project>()
                .HasMany(x => x.FrequentlyAskedQuestions)
                .WithOne(f => f.Project)
                .HasForeignKey(x => x.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Project>()
                .HasMany(x => x.Pictures)
                .WithOne(f => f.Project)
                .HasForeignKey(x => x.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Project>()
                .HasMany(x => x.Documents)
                .WithOne(f => f.Project)
                .HasForeignKey(x => x.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Project>()
                .HasOne(x => x.Video)
                .WithOne(f => f.Project)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Project>()
                .HasMany(x => x.Reviews)
                .WithOne(f => f.Project)
                .OnDelete(DeleteBehavior.Cascade);
        }

        private void ConfigureSkillScoutFavoriteSkills(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SkillScoutFavoriteSkills>()
                .HasKey(fp => new { fp.SkillScoutId, fp.SkillId });

            modelBuilder.Entity<SkillScoutFavoriteSkills>()
                .HasOne(fp => fp.SkillScout)
                .WithMany(f => f.FavoriteSkills)
                .HasForeignKey(fp => fp.SkillScoutId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SkillScoutFavoriteSkills>()
                .HasOne(fp => fp.Skill)
                .WithMany()
                .HasForeignKey(fp => fp.SkillId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        private void ConfigureProjectFeature(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectFeature>()
                .HasKey(pf => new { pf.ProjectId, pf.FeatureId });

            modelBuilder.Entity<ProjectFeature>()
                .HasOne(pf => pf.Project)
                .WithMany(f => f.Features)
                .HasForeignKey(fp => fp.ProjectId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProjectFeature>()
                .HasOne(pf => pf.Feature)
                .WithMany()
                .HasForeignKey(fp => fp.FeatureId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        private void ConfigureSkillSubcategoryFeatureOptions(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SkillSubcategoryFeatureOption>()
                .HasKey(sf => new { sf.SkillSubcategoryId, sf.FeatureId });

            modelBuilder.Entity<SkillSubcategoryFeatureOption>()
                .HasOne(pf => pf.SkillSubcategory)
                .WithMany(f => f.FeatureOptions)
                .HasForeignKey(fp => fp.SkillSubcategoryId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<SkillSubcategoryFeatureOption>()
                .HasOne(pf => pf.Feature)
                .WithMany()
                .HasForeignKey(fp => fp.FeatureId)
                .OnDelete(DeleteBehavior.Cascade);
        }

        private void ConfigureUserFavoriteProjects(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserFavoriteProject>()
                .HasKey(uf => new { uf.UserId, uf.ProjectId });

            modelBuilder.Entity<UserFavoriteProject>()
               .HasOne(uf => uf.Project)
               .WithMany()
               .HasForeignKey(fp => fp.ProjectId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<UserFavoriteProject>()
               .HasOne(uf => uf.User)
               .WithMany()
               .HasForeignKey(fp => fp.UserId)
               .OnDelete(DeleteBehavior.Cascade);
        }

        private void ConfigureUserChat(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserChat>()
                .HasKey(uc => new { uc.FirstUserId, uc.SecondUserId });

            modelBuilder.Entity<UserChat>()
               .HasMany(uf => uf.Messages)
               .WithOne()
               .OnDelete(DeleteBehavior.NoAction);
        }

        private void ConfigureChatMessages(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ChatMessage>().HasKey(x => x.Id);
        }

        private void ConfigureUserNotification(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserNotification>()
                .HasKey(un => new { un.SenderId, un.ReceiverId });

            modelBuilder.Entity<UserNotification>()
               .HasOne(uf => uf.Sender)
               .WithMany()
               .HasForeignKey(fp => fp.SenderId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserNotification>()
               .HasOne(uf => uf.Receiver)
               .WithMany()
               .HasForeignKey(fp => fp.ReceiverId)
               .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<UserNotification>()
               .HasMany(uf => uf.Notifications)
               .WithOne()
               .OnDelete(DeleteBehavior.Cascade);
        }

        private void ConfigureNotification(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Notification>().HasKey(x => x.Id);

            modelBuilder.Entity<Notification>().Property(x => x.AdditionalData).IsRequired(false);

            modelBuilder.Entity<Notification>()
                .Property(e => e.SentAt)
                .HasConversion(
                    v => v.ToString("yyyy-MM-dd HH:mm:ss"),
                    v => DateTime.ParseExact(v, "yyyy-MM-dd HH:mm:ss", null)
                );
        }

        private void ConfigureOrder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Order>().HasKey(x => x.Id);

            modelBuilder.Entity<Order>()
               .HasMany(o => o.Contents)
               .WithOne(oc => oc.Order)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Order>()
                .Property(e => e.CreatedAt)
                .HasConversion(
                    v => v.ToString("yyyy-MM-dd HH:mm:ss"),
                    v => DateTime.ParseExact(v, "yyyy-MM-dd HH:mm:ss", null)
                );

            modelBuilder.Entity<Order>()
                .Property(e => e.UntilTo)
                .HasConversion(
                    v => v.ToString("yyyy-MM-dd HH:mm:ss"),
                    v => DateTime.ParseExact(v, "yyyy-MM-dd HH:mm:ss", null)
                );

            modelBuilder.Entity<Order>()
                .Property(e => e.CompletedAt)
                .HasConversion(
                    v => v.HasValue ? v.Value.ToString("yyyy-MM-dd HH:mm:ss") : null,
                    v => DateTime.ParseExact(v, "yyyy-MM-dd HH:mm:ss", null)
                );
        }

        private void ConfigureOrderContent(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderContent>().HasKey(x => x.Id);

            modelBuilder.Entity<OrderContent>()
               .HasOne(oc => oc.Order)
               .WithMany(o => o.Contents)
               .HasForeignKey(oc => oc.OrderId)
               .OnDelete(DeleteBehavior.Cascade);
        }

        private void ConfigureProjectReview(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectReview>().HasKey(x => new { x.ProjectId, x.ReviewerId });

            modelBuilder.Entity<ProjectReview>()
               .HasOne(pr => pr.Project)
               .WithMany(p => p.Reviews)
               .HasForeignKey(pr => pr.ProjectId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProjectReview>()
              .HasOne(pr => pr.Reviewer)
              .WithMany()
              .HasForeignKey(pr => pr.ReviewerId)
              .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProjectReview>()
                .Property(pr => pr.ReviewAt)
                .HasConversion(
                    v => v.ToString("yyyy-MM-dd HH:mm:ss"),
                    v => DateTime.ParseExact(v, "yyyy-MM-dd HH:mm:ss", null)
                );

            modelBuilder.Entity<ProjectReview>()
                .Property(x => x.Stars)
                .IsRequired()
                .HasDefaultValue(1)
                .HasMaxLength(5);
        }
    }
}