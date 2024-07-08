namespace SkillSync.Domain.Models
{
    public class SkillScoutFavoriteSkills
    {
        public Guid SkillScoutId { get; set; }
        public SkillScout SkillScout { get; set; }

        public Guid SkillId { get; set; }
        public Skill Skill { get; set; }
    }
}