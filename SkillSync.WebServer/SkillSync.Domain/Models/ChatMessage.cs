using SkillSync.Domain.Enums;

namespace SkillSync.Domain.Models
{
    public class ChatMessage
    {
        public Guid Id { get; set; }

        public string Content { get; set; }

        public string SenderId { get; set; }
        public User Sender { get; set; }

        public DateTime SentAt { get; set; }

        public ChatMessageType Type { get; set; }
    }
}