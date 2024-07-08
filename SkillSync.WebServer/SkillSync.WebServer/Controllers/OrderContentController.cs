using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillSync.Domain.Interfaces.Services;

namespace SkillSync.WebServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderContentController : ControllerBase
    {
        private readonly IOrderContentService _orderContentService;

        public OrderContentController(IOrderContentService orderContentService)
        {
            _orderContentService = orderContentService ?? throw new ArgumentNullException(nameof(orderContentService));
        }

        [Authorize(Roles = "Admin,Freelancer,SkillScout")]
        [HttpGet]
        [Route("get-content-file/{id}")]
        public async Task<IActionResult> DownloadContent([FromRoute] Guid id)
        {
            (Stream file, string extension) = await _orderContentService.DownloadOrderContent(id);

            return File(file, extension);
        }
    }
}