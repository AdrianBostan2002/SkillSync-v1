namespace SkillSync.Domain.Models
{
    public class UserChat
    {
        public string FirstUserId { get; set; }
        public User FirstUser { get; set; }

        public string SecondUserId { get; set; }
        public User SecondUser { get; set; }

        public List<ChatMessage> Messages { get; set; }
    }
}