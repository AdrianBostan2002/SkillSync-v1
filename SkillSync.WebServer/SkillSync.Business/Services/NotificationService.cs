using SkillSync.Domain.Interfaces.Repositories;
using SkillSync.Domain.Interfaces.Services;

namespace SkillSync.Business.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository _notificationRepository;

        public NotificationService(INotificationRepository notificationRepository)
        {
            _notificationRepository = notificationRepository ?? throw new ArgumentNullException(nameof(notificationRepository));
        }

        public async Task SetNotificationStatusAsync(Guid notificationId, bool status)
        {
            var notification = await _notificationRepository.SingleByCondition(x => x.Id == notificationId);

            if (status == notification.IsRead)
            {
                return;
            }

            notification.IsRead = status;
            await _notificationRepository.UpdateAsync(notification);
        }
    }
}
