namespace SkillSync.Domain.Models
{
    public class UserFavoriteProject
    {
        public string UserId { get; set; }
        public User User { get; set; }

        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
    }
}