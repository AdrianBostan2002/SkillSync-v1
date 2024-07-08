using Microsoft.AspNetCore.SignalR;
using SkillSync.Notifications.Services;

namespace SkillSync.Notifications
{
    public class NotificationHub : Hub
    {
        private readonly INotificationService _notificationService;

        public NotificationHub(INotificationService notificationService)
        {
            _notificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));
        }

        public override Task OnConnectedAsync()
        {
            var email = GetUserEmailFromQueryParam();

            _notificationService.ConnectUser(email, Context.ConnectionId);

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            var email = GetUserEmailFromQueryParam();

            _notificationService.DisconnectUser(email);

            return base.OnDisconnectedAsync(exception);
        }

        private string GetUserEmailFromQueryParam()
        {
            var httpContext = Context.GetHttpContext();
            var userId = httpContext.Request.Query["user"];

            return userId.ToString();
        }
    }
}