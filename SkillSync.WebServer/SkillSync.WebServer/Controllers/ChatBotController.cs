using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillSync.AzureOpenAiChatBot.Interfaces;

namespace SkillSync.WebServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatBotController : ControllerBase
    {
        private readonly IChatBotService _chatBotService;

        public ChatBotController(IChatBotService chatBotService)
        {
            _chatBotService = chatBotService ?? throw new ArgumentNullException(nameof(chatBotService));
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("{query}")]
        public async Task<IActionResult> ExecuteQuery([FromRoute] string query)
        {
            var result = await _chatBotService.ExecuteQuery(query);

            return Ok(new { result });
        }
    }
}