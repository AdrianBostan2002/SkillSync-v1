using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillSync.Domain.DTOs.Register;
using SkillSync.Domain.Interfaces.Services;
using SkillSync.WebServer.Extensions;

namespace SkillSync.WebServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillController : Controller
    {
        private readonly ISkillService _skillService;

        public SkillController(ISkillService skillService)
        {
            _skillService = skillService ?? throw new ArgumentNullException(nameof(skillService));
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("by-id/{id}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] Guid id)
        {
            var result = await _skillService.GetById(id);

            return Ok(result);
        }

        [Authorize(Roles = "Admin,Freelancer")]
        [HttpPost]
        [Route("register-freelancer-skills")]
        public async Task<IActionResult> RegisterFreelancerSkillsAsync([FromBody] RegisterFreelancerSkillsRequest request)
        {
            var email = HttpContext.GetUserEmailWithCheck();

            await _skillService.AddFreelancerSkills(email, request);

            return Ok();
        }
    }
}