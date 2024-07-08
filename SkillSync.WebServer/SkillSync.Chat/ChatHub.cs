using Microsoft.AspNetCore.SignalR;
using SkillSync.Chat.DTOs.Chat;
using SkillSync.Chat.Services;
using SkillSync.Domain.Interfaces.Services;

namespace SkillSync.Chat
{
    public class ChatHub : Hub
    {
        private readonly IChatService _chatService;
        private readonly IPushNotificationService _pushNotificationService;

        public ChatHub(IChatService chatService, IPushNotificationService pushNotificationService)
        {
            _chatService = chatService ?? throw new ArgumentNullException(nameof(chatService));
            _pushNotificationService = pushNotificationService ?? throw new ArgumentNullException(nameof(pushNotificationService));
        }

        public override Task OnConnectedAsync()
        {
            var email = GetUserEmailFromQueryParam();

            _chatService.ConnectUser(email, Context.ConnectionId);

            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            var email = GetUserEmailFromQueryParam();

            _chatService.DisconnectUser(email);

            return base.OnDisconnectedAsync(exception);
        }

        public async Task GetChatRoom(string senderEmail, string receiverEmail)
        {
            var chatRoom = await _chatService.UpsertRoomAsync(senderEmail, Context.ConnectionId, receiverEmail);

            await Clients.Caller.SendAsync("ChatRoomCreated", chatRoom);
        }

        public async Task SendTextMessage(string chatRoomId, ChatMessageDto<string> message)
        {
            var receiverConnectionId = _chatService.GetReceiverConnectionId(chatRoomId, message.Sender);

            if (receiverConnectionId != null)
            {
                var newInitiatedChatRoom = await _chatService.ShouldReceiverGetNewInitiatedChatRoomAsync(chatRoomId, message.Sender);
                if (newInitiatedChatRoom != null)
                {
                    await Clients.Client(receiverConnectionId).SendAsync("NewChatRoomInitiated", newInitiatedChatRoom);
                }
                await Clients.Client(receiverConnectionId).SendAsync("ReceiveMessage", message);
                await SendNotification(chatRoomId, message);
            }

            await _chatService.SaveMessageAsync(chatRoomId, message);
            await Clients.Caller.SendAsync("MessageSentSuccessfully", message.Id);

            await SendNotification(chatRoomId, message);
        }

        private async Task SendNotification(string chatRoomId, ChatMessageDto<string> message)
        {
            var chatRoom = _chatService.GetChatRoomFromCache(chatRoomId);

            var receiver = _chatService.GetOtherParticipant(message.Sender, chatRoom);
            if (receiver == null)
            {
                return;
            }

            var sender = _chatService.GetOtherParticipant(receiver.Email, chatRoom);
            if (sender == null)
            {
                return;
            }

            await _pushNotificationService.SendNewMessageNotificationAsync(sender, receiver);
        }

        public async Task GetUserChats(string email)
        {
            var chats = await _chatService.GetAllUserChats(email, Context.ConnectionId);

            await Clients.Caller.SendAsync("ReceiveAllUserChats", chats);
        }

        private string GetUserEmailFromQueryParam()
        {
            var httpContext = Context.GetHttpContext();
            var userId = httpContext.Request.Query["user"];

            return userId.ToString();
        }
    }
}