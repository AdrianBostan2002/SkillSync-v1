using SkillSync.Domain.Enums;

namespace SkillSync.Chat.DTOs.Chat
{
    public class ChatMessageDto<T>
    {
        public string Id { get; set; }

        public T Content { get; set; }

        public string Sender { get; set; }

        public DateTime SentAt { get; set; }

        public ChatMessageType Type { get; set; }
    }
}