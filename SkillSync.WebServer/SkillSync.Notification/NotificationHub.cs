using Microsoft.AspNetCore.SignalR;
using SkillSync.Domain.Interfaces.Services;
using SkillSync.Notifications.Services;

namespace SkillSync.Notifications
{
    public class NotificationHub : Hub
    {
        private readonly ICacheService _cacheService;
        private readonly IPushNotificationService _pushNotificationService;

        public NotificationHub(ICacheService cacheService, IPushNotificationService notificationService)
        {
            _cacheService = cacheService ?? throw new ArgumentNullException(nameof(cacheService));
            _pushNotificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));
        }

        public override Task OnConnectedAsync()
        {
            var email = GetUserEmailFromQueryParam();

            _cacheService.AddUserNotificationConnectionId(email, Context.ConnectionId);

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            var email = GetUserEmailFromQueryParam();

            _cacheService.RemoveUserNotificationConnectionId(email);

            return base.OnDisconnectedAsync(exception);
        }

        public async Task GetUserPushNotifications(string email)
        {
            var userNotifications = await _pushNotificationService.GetUserNotifications(email);

            await Clients.Caller.SendAsync("ReceiveAllNotifications", userNotifications);
        }

        public async Task SetNotificationAsRead(Guid notificationId)
        {
            await _pushNotificationService.SetNotificationAsRead(notificationId);
        }

        private string GetUserEmailFromQueryParam()
        {
            var httpContext = Context.GetHttpContext();
            var userId = httpContext.Request.Query["user"];

            return userId.ToString();
        }
    }
}