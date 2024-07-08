namespace SkillSync.Domain.Models
{
    public class FrequentlyAskedQuestionBase
    {
        public Guid Id { get; set; }

        public string Question { get; set; }

        public string Answer { get; set; }
    }
}