using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SkillSync.Chat;
using SkillSync.Chat.DTOs.Chat;
using SkillSync.Chat.Services;
using SkillSync.Domain.Enums;

namespace SkillSync.WebServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly IChatService _chatService;

        public ChatController(IHubContext<ChatHub> hubContext, IChatService chatService)
        {
            _hubContext = hubContext ?? throw new ArgumentNullException(nameof(hubContext));
            _chatService = chatService ?? throw new ArgumentNullException(nameof(chatService));
        }

        [Authorize(Roles = "Admin,Freelancer,SkillScout")]
        [HttpPost("send/{chatRoomId}")]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> AddMediaMessage([FromRoute] string chatRoomId, [FromForm] ChatMessageDto<IFormFile> message)
        {
            var mediaUrl = await _chatService.SaveMessageAsync(chatRoomId, message);

            var receiverConnectionId = _chatService.GetReceiverConnectionId(chatRoomId, message.Sender);
            if (receiverConnectionId != null)
            {
                await _hubContext.Clients.Client(receiverConnectionId).SendAsync("ReceiveMessage", new ChatMessageDto<string>
                {
                    Id = message.Id,
                    Sender = message.Sender,
                    SentAt = message.SentAt,
                    Content = mediaUrl,
                    Type = message.Type
                });
            }

            var senderConnectionId = _chatService.GetConnectionId(message.Sender);
            await _hubContext.Clients.Client(senderConnectionId).SendAsync("MessageSentSuccessfully", message.Id);

            return Ok();
        }

        [Authorize(Roles = "Admin,Freelancer,SkillScout")]
        [HttpGet("media/{fileName}/{type}")]
        public IActionResult GetMediaMessage([FromRoute] string fileName, [FromRoute] ChatMessageType type)
        {
            var result = _chatService.GetMediaFromStorage(fileName, type);

            return Ok(new { result });
        }
    }
}