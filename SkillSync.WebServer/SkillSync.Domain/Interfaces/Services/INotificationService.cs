
namespace SkillSync.Domain.Interfaces.Services
{
    public interface INotificationService
    {
        Task SetNotificationStatusAsync(Guid notificationId, bool status);
    }
}
