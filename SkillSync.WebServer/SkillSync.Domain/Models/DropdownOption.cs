namespace SkillSync.Domain.Models
{
    public class DropdownOption
    {
        public Guid Id { get; set; }

        public int LowerInterval { get; set; }

        public int UpperInterval { get; set; }

        public int IncrementValue { get; set; }
    }
}