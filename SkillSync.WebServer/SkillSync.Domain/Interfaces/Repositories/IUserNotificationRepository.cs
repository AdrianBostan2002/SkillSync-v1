using SkillSync.Domain.Models;

namespace SkillSync.Domain.Interfaces.Repositories
{
    public interface IUserNotificationRepository : IRepository<UserNotification>
    {
        Task<Notification> GetNewPreviewContentUploadedNotification(string senderId, string receiverId, string additionalData);
        Task<Notification> GetUserChatNotification(string senderId, string receiverId);
        Task<UserNotification> GetUserNotificationIncludeMessages(string senderId, string receivedId);
        Task<List<UserNotification>> GetUserNotificationsAsync(string receiverId);
    }
}