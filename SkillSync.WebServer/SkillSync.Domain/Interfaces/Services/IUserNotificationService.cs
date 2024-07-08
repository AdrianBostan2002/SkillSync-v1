using SkillSync.Domain.Models;

namespace SkillSync.Domain.Interfaces.Services
{
    public interface IUserNotificationService
    {
        Task<UserNotification> AddUserNotificationAsync(string senderId, string receivedId, Notification notification);
        Task<UserNotification> EnsureUserNotificationExists(string senderId, string receiverId);
        Task<Notification> GetNewUploadedPreviewContentNotification(string senderId, string receiverId, string additionalData);
        Task<Notification> GetUserChatNotification(string senderId, string receiverId);
        Task<List<UserNotification>> GetUserNotifications(string receiverId);
    }
}