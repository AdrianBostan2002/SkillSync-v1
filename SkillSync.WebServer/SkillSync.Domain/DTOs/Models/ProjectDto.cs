using SkillSync.Domain.DTOs.Project;
using SkillSync.Domain.DTOs.Review;

namespace SkillSync.Domain.DTOs.Models
{
    public class ProjectDto
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public bool HasPackages { get; set; }

        public bool? IsUserWhoMadeRequestFavorite { get; set; }

        public List<GetProjectFeatureDto> Features { get; set; }

        public List<FrequentlyAskedQuestionDto> FrequentlyAskedQuestions { get; set; }

        public List<string> Pictures { get; set; }

        public string Video { get; set; }

        public List<string> Documents { get; set; }

        public FreelancerDto Freelancer { get; set; }

        public List<GetProjectReviewDto> Reviews { get; set; }
    }
}