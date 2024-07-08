using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SkillSync.Domain.Models;

namespace SkillSync.DataAccess.Configurations
{
    public class DropdownOptionConfiguration : IEntityTypeConfiguration<DropdownOption>
    {
        public void Configure(EntityTypeBuilder<DropdownOption> builder)
        {
            builder.HasData(
                new DropdownOption { Id = Guid.NewGuid(), LowerInterval = 1, UpperInterval = 10, IncrementValue = 1 },
                new DropdownOption { Id = Guid.NewGuid(), LowerInterval = 1, UpperInterval = 50, IncrementValue = 1 }
            );
        }
    }
}