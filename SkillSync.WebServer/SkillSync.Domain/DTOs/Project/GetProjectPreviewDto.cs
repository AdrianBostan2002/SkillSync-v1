using SkillSync.Domain.DTOs.Review;

namespace SkillSync.Domain.DTOs.Project
{
    public class GetProjectPreviewDto
    {
        public Guid Id { get; set; }

        public Guid FreelancerId { get; set; }
        public string FreelancerProfilePicture { get; set; }
        public string FreelancerName { get; set; }

        public bool? IsUserWhoMadeRequestFavorite { get; set; }

        public string Title { get; set; }

        public int Price { get; set; }

        public List<string> Pictures { get; set; }

        public string Video { get; set; }

        public ReviewStatisticsDto? ReviewStatistics { get; set; }
    }
}