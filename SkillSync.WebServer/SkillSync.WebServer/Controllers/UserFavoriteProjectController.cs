using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillSync.Domain.Interfaces.Services;
using SkillSync.WebServer.Extensions;

namespace SkillSync.WebServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserFavoriteProjectController : ControllerBase
    {
        private readonly IUserFavoriteProjectService _userFavoriteProjectService;

        public UserFavoriteProjectController(IUserFavoriteProjectService userFavoriteProjectService)
        {
            _userFavoriteProjectService = userFavoriteProjectService ?? throw new ArgumentNullException(nameof(userFavoriteProjectService));
        }

        [Authorize(Roles = "Admin,Freelancer,SkillScout")]
        [HttpPost]
        [Route("change-favorite-status/{projectId}")]
        public async Task<IActionResult> ChangeProjectFavoriteStatusAsync([FromRoute] Guid projectId, [FromBody] bool newStatus)
        {
            var email = HttpContext.GetUserEmailWithCheck();

            await _userFavoriteProjectService.ChangeProjectFavoriteStatusAsync(projectId, newStatus, email);

            return Created("", newStatus);
        }
    }
}