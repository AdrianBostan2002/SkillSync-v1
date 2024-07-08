using AutoMapper;
using Microsoft.AspNetCore.SignalR;
using SkillSync.Domain.DTOs.Models;
using SkillSync.Domain.DTOs.Notifications;
using SkillSync.Domain.Enums;
using SkillSync.Domain.Interfaces.Services;
using SkillSync.Domain.Models;
using System.Data;

namespace SkillSync.Notifications.Services
{
    public class PushNotificationService : IPushNotificationService
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        private readonly IUserService _userService;
        private readonly IUserNotificationService _userNotificationService;
        private readonly INotificationService _notificationService;
        private readonly ICacheService _cacheService;

        private readonly IMapper _mapper;

        public PushNotificationService
        (
            IHubContext<NotificationHub> hubContext,
            IUserService userService,
            IUserNotificationService userNotificationService,
            INotificationService notificationService,
            ICacheService cacheService,
            IMapper mapper
        )
        {
            _hubContext = hubContext ?? throw new ArgumentNullException(nameof(hubContext));
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _userNotificationService = userNotificationService ?? throw new ArgumentNullException(nameof(userNotificationService));
            _notificationService = notificationService ?? throw new ArgumentNullException(nameof(notificationService));
            _cacheService = cacheService ?? throw new ArgumentNullException(nameof(cacheService));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task SendWelcomeNotificationAsync(User receiver, RoleType role)
        {
            Notification notification = null;
            switch (role)
            {
                case RoleType.Freelancer:
                    notification = CreateFreelancerWelcomeNotification();
                    break;
                case RoleType.SkillScout:
                    notification = CreateSkillScouterWelcomeNotification();
                    break;
            }

            if (notification == null)
            {
                return;
            }

            User admin = await GetAdmin();

            var userNotification = await _userNotificationService.AddUserNotificationAsync(admin.Id, receiver.Id, notification);

            var notificationAdded = userNotification.Notifications.FirstOrDefault(n => n.SentAt == notification.SentAt);
            notification.Id = notificationAdded!.Id;

            var notificationDto = await MapNotification(admin, notification);

            await SendNotificationAsync(receiver.Email, notificationDto);
        }

        private async Task<User> GetAdmin()
        {
            var admin = await _userService.GetAdminAsync();
            admin.ProfilePicture = await _userService.GetProfilePictureAsync(admin);
            return admin;
        }

        private Notification CreateFreelancerWelcomeNotification()
        {
            return new Notification
            {
                Content = "Welcome to SkillSync! Dive into a world of endless opportunities to grow and collaborate. Let's build something amazing together!",
                IsRead = false,
                SentAt = DateTime.Now,
                Type = NotificationType.Welcome,
            };
        }

        private Notification CreateSkillScouterWelcomeNotification()
        {
            return new Notification
            {
                Content = "Welcome to SkillSync! Discover top-notch freelancers and unlock limitless potential for your projects. Let's find the perfect match together!",
                IsRead = false,
                SentAt = DateTime.Now,
                Type = NotificationType.Welcome,
            };
        }

        public async Task SendNewMessageNotificationAsync(User sender, User receiver)
        {
            var notification = await _userNotificationService.GetUserChatNotification(sender.Id, receiver.Id);

            if (!(notification == null || notification.IsRead))
            {
                return;
            }

            if (notification == null || !notification.IsRead)
            {
                notification = new Notification
                {
                    Content = $"You've received a new message from {sender.FirstName}!",
                    IsRead = false,
                    SentAt = DateTime.Now,
                    Type = NotificationType.NewMessage,
                };
            }
            else
            {
                notification.IsRead = false;
                notification.SentAt = DateTime.Now;
            }

            var userNotification = await _userNotificationService.AddUserNotificationAsync(sender.Id, receiver.Id, notification);

            var notificationAdded = userNotification.Notifications.FirstOrDefault(n => n.SentAt == notification.SentAt);
            notification.Id = notificationAdded!.Id;

            NotificationDto notificationDto = await MapNotification(sender, notification);
            await SendNotificationAsync(receiver.Email, notificationDto);
        }

        public async Task SendFreelancerNewOrderReceivedNotification(Order order, User freelancer)
        {
            Notification notification = CreateFreelancerNewOrderReceivedNotification(order);

            var sender = order.Customer;

            var userNotification = await _userNotificationService.AddUserNotificationAsync(sender.Id, freelancer.Id, notification);

            var notificationAdded = userNotification.Notifications.FirstOrDefault(n => n.SentAt == notification.SentAt);
            notification.Id = notificationAdded!.Id;

            var notificationDto = await MapNotification(sender, notification);
            await SendNotificationAsync(freelancer.Email, notificationDto);
        }

        public async Task SendSkillScoutOrderPlacedSuccessfullyNotification(Order order)
        {
            Notification notification = CreateSkillScoutNewOrderPlacedSuccessfullyNotification(order);

            var sender = await GetAdmin();

            var userNotification = await _userNotificationService.AddUserNotificationAsync(sender.Id, order.Customer.Id, notification);

            var notificationAdded = userNotification.Notifications.FirstOrDefault(n => n.SentAt == notification.SentAt);
            notification.Id = notificationAdded!.Id;

            var notificationDto = await MapNotification(sender, notification);
            await SendNotificationAsync(order.Customer.Email, notificationDto);
        }

        public async Task SendSkillScoutOrderStatusChangedNotification(Order order, User freelancer)
        {
            Notification notification = CreateOrderStatusChangedNotification(order);

            var sender = freelancer;

            var userNotification = await _userNotificationService.AddUserNotificationAsync(sender.Id, order.Customer.Id, notification);

            var notificationAdded = userNotification.Notifications.FirstOrDefault(n => n.SentAt == notification.SentAt);
            notification.Id = notificationAdded!.Id;

            var notificationDto = await MapNotification(sender, notification);
            await SendNotificationAsync(order.Customer.Email, notificationDto);
        }

        public async Task SendPreviewContentModifiedNotification(Order order, User freelancer)
        {
            var notification = await _userNotificationService.GetNewUploadedPreviewContentNotification(freelancer.Id, order.Customer.Id, order.Id.ToString());

            if (!(notification == null || notification.IsRead))
            {
                return;
            }

            if (notification == null || !notification.IsRead)
            {
                notification = CreatePreviewContentModifiedNotification(order);
            }
            else
            {
                notification.IsRead = false;
                notification.SentAt = DateTime.Now;
            }

            var sender = freelancer;

            var userNotification = await _userNotificationService.AddUserNotificationAsync(sender.Id, order.Customer.Id, notification);

            var notificationAdded = userNotification.Notifications.FirstOrDefault(n => n.SentAt == notification.SentAt);
            notification.Id = notificationAdded!.Id;

            var notificationDto = await MapNotification(sender, notification);
            await SendNotificationAsync(order.Customer.Email, notificationDto);
        }

        public async Task SendOrderCompletedNotification(Order order, User freelancer)
        {
            Notification notification = CreateOrderCompletedNotification(order);

            var sender = order.Customer;
            var receiver = freelancer;

            var userNotification = await _userNotificationService.AddUserNotificationAsync(sender.Id, receiver.Id, notification);

            var notificationAdded = userNotification.Notifications.FirstOrDefault(n => n.SentAt == notification.SentAt);
            notification.Id = notificationAdded!.Id;

            var notificationDto = await MapNotification(sender, notification);
            await SendNotificationAsync(receiver.Email, notificationDto);
        }

        private Notification CreateSkillScoutNewOrderPlacedSuccessfullyNotification(Order order)
        {
            return new Notification
            {
                Content = $"Good news! Your order for '{order.Project.Title}' has been placed successfully!",
                IsRead = false,
                SentAt = DateTime.Now,
                Type = NotificationType.PlacedOrder,
                AdditionalData = order.Id.ToString()
            };
        }

        private Notification CreateFreelancerNewOrderReceivedNotification(Order order)
        {
            return new Notification
            {
                Content = $"Good news! New order for '{order.Project.Title}' has been placed.",
                IsRead = false,
                SentAt = DateTime.Now,
                Type = NotificationType.PlacedOrder,
                AdditionalData = order.Id.ToString()
            };
        }

        private Notification CreateOrderStatusChangedNotification(Order order)
        {
            return new Notification
            {
                Content = $"Hey! Your order {order.Project.Title} status changed into {order.Status}",
                IsRead = false,
                SentAt = DateTime.Now,
                Type = NotificationType.OrderStatusChanged,
                AdditionalData = order.Id.ToString()
            };
        }

        private Notification CreatePreviewContentModifiedNotification(Order order)
        {
            return new Notification
            {
                Content = $"New preview content uploaded for order {order.Project.Title}. Check it out!",
                IsRead = false,
                SentAt = DateTime.Now,
                Type = NotificationType.PreviewContentModified,
                AdditionalData = order.Id.ToString()
            };
        }

        private Notification CreateOrderCompletedNotification(Order order)
        {
            return new Notification
            {
                Content = $"Hey! Good News! Your order {order.Project.Title} from {GetFullName(order.Customer)} is completed!",
                IsRead = false,
                SentAt = DateTime.Now,
                Type = NotificationType.PreviewContentModified,
                AdditionalData = order.Id.ToString()
            };
        }

        public async Task<List<PushNotificationDto>> GetUserNotifications(string email)
        {
            var user = await _userService.GetUserByEmailAsync(email);

            var userNotifications = await _userNotificationService.GetUserNotifications(user.Id);

            List<PushNotificationDto> pushNotifications = await MapPushNotifications(userNotifications);

            return pushNotifications;
        }

        private async Task<List<PushNotificationDto>> MapPushNotifications(List<UserNotification> userNotifications)
        {
            var pushNotifications = new List<PushNotificationDto>();

            foreach (var userNotification in userNotifications)
            {
                var activityNotifications = new List<NotificationDto>();
                var inboxNotifications = new List<NotificationDto>();

                foreach (var notification in userNotification.Notifications)
                {
                    if (notification.Type == NotificationType.NewMessage)
                    {
                        var notificationDto = _mapper.Map<NotificationDto>(notification);
                        inboxNotifications.Add(notificationDto);
                    }
                    else
                    {
                        var notificationDto = _mapper.Map<NotificationDto>(notification);
                        activityNotifications.Add(notificationDto);
                    }
                }

                if (inboxNotifications.Count != 0 || activityNotifications.Count != 0)
                {
                    var user = await _userService.GetUserByIdAsync(userNotification.SenderId);
                    var pushNotification = new PushNotificationDto
                    {
                        Name = GetFullName(user),
                        Email = user.Email,
                        ProfilePicture = await _userService.GetProfilePictureAsync(user),
                        ActivityNotifications = new List<NotificationDto>(),
                        InboxNotifications = new List<NotificationDto>(),
                    };

                    pushNotification.InboxNotifications.AddRange(inboxNotifications);
                    pushNotification.ActivityNotifications.AddRange(activityNotifications);

                    pushNotifications.Add(pushNotification);
                }
            }

            return pushNotifications;
        }

        private async Task<NotificationDto> MapNotification(User sender, Notification? notification)
        {
            var notificationDto = _mapper.Map<NotificationDto>(notification);

            notificationDto.Name = GetFullName(sender);
            notificationDto.Email = sender.Email;
            notificationDto.ProfilePicture = await _userService.GetProfilePictureAsync(sender);
            return notificationDto;
        }

        public async Task SetNotificationAsRead(Guid notificationId)
        {
            await _notificationService.SetNotificationStatusAsync(notificationId, true);
        }

        private static string GetFullName(User sender)
        {
            return $"{sender.FirstName} {sender.LastName}";
        }

        private async Task SendNotificationAsync(string receiverEmail, NotificationDto notification)
        {
            var connectionId = _cacheService.GetUserNotificationConnectionId(receiverEmail);

            if (connectionId != null)
            {
                await _hubContext.Clients.Client(connectionId).SendAsync("ReceiveNotification", notification);
            }
        }
    }
}