using System.ComponentModel.DataAnnotations.Schema;

namespace SkillSync.Domain.Models
{
    public class SkillScout
    {
        public Guid Id { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }

        public ICollection<SkillScoutFavoriteSkills> FavoriteSkills { get; set; }
    }
}