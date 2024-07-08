namespace SkillSync.Notifications.Services
{
    public interface INotificationService
    {
        void ConnectUser(string email, string connectionId);
        void DisconnectUser(string email);
    }
}