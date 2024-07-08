namespace SkillSync.Domain.Models
{
    public class ProjectFrequentlyAskedQuestion : FrequentlyAskedQuestionBase
    {
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
    }
}