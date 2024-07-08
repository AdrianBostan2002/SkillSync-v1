using SkillSync.Domain.DTOs.Notifications;
using SkillSync.Domain.Enums;
using SkillSync.Domain.Models;

namespace SkillSync.Domain.Interfaces.Services
{
    public interface IPushNotificationService
    {
        Task<List<PushNotificationDto>> GetUserNotifications(string email);
        Task SendFreelancerNewOrderReceivedNotification(Order order, User freelancer);
        Task SendNewMessageNotificationAsync(User sender, User receiver);
        Task SendOrderCompletedNotification(Order order, User freelancer);
        Task SendPreviewContentModifiedNotification(Order order, User freelancer);
        Task SendSkillScoutOrderPlacedSuccessfullyNotification(Order order);
        Task SendSkillScoutOrderStatusChangedNotification(Order order, User freelancer);
        Task SendWelcomeNotificationAsync(User receiver, RoleType role);
        Task SetNotificationAsRead(Guid notificationId);
    }
}