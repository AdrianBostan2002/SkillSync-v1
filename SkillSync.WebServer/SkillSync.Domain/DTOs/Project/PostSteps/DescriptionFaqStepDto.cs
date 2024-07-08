namespace SkillSync.Domain.DTOs.Project.PostSteps
{
    public class DescriptionFaqStepDto
    {
        public string Description { get; set; }

        public ICollection<FrequentlyAskedQuestionDto>? FrequentlyAskedQuestions { get; set; }

        public bool WasAnyQuestionModified { get; set; }
    }
}