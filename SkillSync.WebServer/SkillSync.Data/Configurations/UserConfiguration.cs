using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillSync.Domain.Models;

namespace SkillSync.DataAccess.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var pssHasher = new PasswordHasher<User>();

            builder.HasKey(x => x.Id);
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);

            builder.HasData(
                new User
                {
                    Id = "ddb34bfe-616a-46a0-af02-b7f29ee25daa",
                    FirstName = "Adrian",
                    LastName = "Bostan",
                    CountryCode = "RO",
                    Email = "bostan.adrian@gmail.com",
                    NormalizedEmail = "BOSTAN.ADRIAN@GMAIL.COM",
                    UserName = "bostan.adrian@gmail.com",
                    NormalizedUserName = "BOSTAN.ADRIAN@GMAIL.COM",
                    EmailConfirmed = true,
                    PasswordHash = pssHasher.HashPassword(null, "Adrian1234!"),
                    ProfilePicture = "admin-pf"
                }
                );
        }
    }
}