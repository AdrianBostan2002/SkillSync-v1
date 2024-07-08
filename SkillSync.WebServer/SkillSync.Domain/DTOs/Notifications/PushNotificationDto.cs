using SkillSync.Domain.DTOs.Models;

namespace SkillSync.Domain.DTOs.Notifications
{
    public class PushNotificationDto
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string ProfilePicture { get; set; }

        public List<NotificationDto> ActivityNotifications { get; set; }

        public List<NotificationDto> InboxNotifications { get; set; }
    }
}