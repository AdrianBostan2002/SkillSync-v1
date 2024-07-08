namespace SkillSync.Domain.DTOs.Review
{
    public class FreelancerReviewsDto
    {
        public Dictionary<string, string> UsersProfilePicture { get; set; }

        public Dictionary<Guid, ProjectReviewDataDto> Projects { get; set; }

        public List<GetFreelancerReviewDto> Reviews { get; set; }

        public ReviewStatisticsDto ReviewStatistics { get; set; }
    }

    public class ProjectReviewDataDto
    {
        public string Name { get; set; }

        public string Picture { get; set; }
    }
}