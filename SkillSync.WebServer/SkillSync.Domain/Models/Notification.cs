using SkillSync.Domain.Enums;

namespace SkillSync.Domain.Models
{
    public class Notification
    {
        public Guid Id { get; set; }

        public string Content { get; set; }

        public DateTime SentAt { get; set; }

        public bool IsRead { get; set; }

        public NotificationType Type { get; set; }

        public string? AdditionalData { get; set; }
    }
}