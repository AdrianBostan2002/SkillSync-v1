using SkillSync.Domain.Enums;

namespace SkillSync.Domain.DTOs.Models
{
    public class NotificationDto
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Email { get; set; }

        public string? ProfilePicture { get; set; }

        public string Content { get; set; }

        public DateTime SentAt { get; set; }

        public bool IsRead { get; set; }

        public NotificationType Type { get; set; }

        public string? AdditionalData { get; set; }
    }
}