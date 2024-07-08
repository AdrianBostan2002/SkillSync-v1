using SkillSync.Domain.Enums;
using SkillSync.Domain.Interfaces.Repositories;
using SkillSync.Domain.Interfaces.Services;
using SkillSync.Domain.Models;

namespace SkillSync.Notifications.Services
{
    public class NotificationService : INotificationService
    {
        private readonly ICacheService _cacheService;

        private readonly INotificationRepository _notificationRepository;
        private readonly IUserNotificationRepository _userNotificationRepository;

        public NotificationService(ICacheService cacheService, INotificationRepository notificationRepository, IUserNotificationRepository userNotificationRepository)
        {
            _cacheService = cacheService ?? throw new ArgumentNullException(nameof(cacheService));
            _notificationRepository = notificationRepository ?? throw new ArgumentNullException(nameof(notificationRepository));
            _userNotificationRepository = userNotificationRepository ?? throw new ArgumentNullException(nameof(userNotificationRepository));
        }

        public void ConnectUser(string email, string connectionId)
        {
            _cacheService.AddUserNotificationConnectionId(email, connectionId);
        }

        public void DisconnectUser(string email)
        {
            _cacheService.RemoveUserNotificationConnectionId(email);
        }

        public void SendWelcomeNotification()
        {
            var notification = new Notification
            {
                Content = "We're excited to welcome you to SkillSync, your go-to platform for connecting with talented professionals, sharing knowledge, and collaborating on projects. Get ready to explore a world of endless opportunities and take your skills to new heights!",
                IsRead = false,
                SenderId = "1b1394ef-a197-443f-b6b0-19abbb38446f",
                SentAt = DateTime.Now,
                Type = NotificationType.Welcome,
            };
        }
    }
}