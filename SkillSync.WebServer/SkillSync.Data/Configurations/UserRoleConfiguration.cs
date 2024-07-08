using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SkillSync.DataAccess.Configurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
    {
        public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
        {
            builder.HasKey(ur => new { ur.UserId, ur.RoleId });

            builder.HasData(
                new IdentityUserRole<string> { RoleId = "1", UserId = "ddb34bfe-616a-46a0-af02-b7f29ee25daa" });
        }
    }
}
