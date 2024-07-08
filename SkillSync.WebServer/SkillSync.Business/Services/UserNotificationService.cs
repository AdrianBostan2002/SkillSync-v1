using SkillSync.Domain.Interfaces.Repositories;
using SkillSync.Domain.Interfaces.Services;
using SkillSync.Domain.Models;

namespace SkillSync.Business.Services
{
    public class UserNotificationService : IUserNotificationService
    {
        private readonly IUserNotificationRepository _userNotificationRepository;

        public UserNotificationService(IUserNotificationRepository userNotificationRepository)
        {
            _userNotificationRepository = userNotificationRepository ?? throw new ArgumentNullException(nameof(userNotificationRepository));
        }

        public async Task<UserNotification> AddUserNotificationAsync(string senderId, string receivedId, Notification notification)
        {
            var userNotification = await EnsureUserNotificationExists(senderId, receivedId);

            userNotification.Notifications.Add(notification);

            return await _userNotificationRepository.UpdateAsync(userNotification);
        }

        public async Task<List<UserNotification>> GetUserNotifications(string receiverId)
        {
            return await _userNotificationRepository.GetUserNotificationsAsync(receiverId);
        }

        public async Task<Notification> GetUserChatNotification(string senderId, string receiverId)
        {
            return await _userNotificationRepository.GetUserChatNotification(senderId, receiverId);
        }

        public async Task<Notification> GetNewUploadedPreviewContentNotification(string senderId, string receiverId, string additionalData)
        {
            return await _userNotificationRepository.GetNewPreviewContentUploadedNotification(senderId, receiverId, additionalData);
        }

        public async Task<UserNotification> EnsureUserNotificationExists(string senderId, string receiverId)
        {
            var userNotification = await _userNotificationRepository.GetUserNotificationIncludeMessages(senderId, receiverId);

            if (userNotification != null)
            {
                return userNotification;
            }

            userNotification = new UserNotification
            {
                SenderId = senderId,
                ReceiverId = receiverId,
                Notifications = new List<Notification>()
            };

            await _userNotificationRepository.AddAsync(userNotification);

            return userNotification;
        }
    }
}