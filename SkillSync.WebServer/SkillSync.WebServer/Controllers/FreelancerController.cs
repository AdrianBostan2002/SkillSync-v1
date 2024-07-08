using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillSync.Domain.DTOs.Register;
using SkillSync.Domain.Interfaces.Services;
using SkillSync.WebServer.Extensions;

namespace SkillSync.WebServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FreelancerController : ControllerBase
    {
        private readonly IFreelancerService _freelancerService;

        public FreelancerController(IFreelancerService freelancerService)
        {
            _freelancerService = freelancerService ?? throw new ArgumentNullException(nameof(freelancerService));
        }

        [Authorize(Roles = "Admin,Freelancer,SkillScout")]
        [HttpGet]
        [Route("own-profile")]
        public async Task<IActionResult> GetFreelancerProfile()
        {
            var email = HttpContext.GetUserEmailWithCheck();

            var freelancer = await _freelancerService.GetFreelancerAsync(email);

            var result = await _freelancerService.GetFreelancerDtoById(freelancer.Id);

            return Ok(result);
        }

        [HttpGet]
        [Route("by-id/{id}")]
        public async Task<IActionResult> GetFreelancerById(Guid id)
        {
            var result = await _freelancerService.GetFreelancerDtoById(id);

            return Ok(result);
        }

        [Authorize(Roles = "Admin,Freelancer")]
        [HttpGet]
        [Route("project-by-publish-status/{isPublished}")]
        public async Task<IActionResult> GetFreelancerProjectByPublishStatus([FromRoute] bool isPublished)
        {
            var email = HttpContext.GetUserEmailWithCheck();

            var result = await _freelancerService.GetFreelancerProjectsByPublishStatusAsync(email, isPublished);

            return Ok(result);
        }

        [Authorize(Roles = "Admin,Freelancer")]
        [HttpGet]
        [Route("has-completed-experience-info")]
        public async Task<IActionResult> HasCompletedExperienceInformations()
        {
            var email = HttpContext.GetUserEmailWithCheck();

            var result = await _freelancerService.HasCompletedExperienceInformationsAsync(email);

            return Ok(result);
        }

        [Authorize(Roles = "Admin,Freelancer")]
        [HttpPatch]
        [Route("set-complete-experience-info")]
        public async Task<IActionResult> SetCompleteExperienceInformations([FromBody] bool freelancerHasCompletedExperienceInformations)
        {
            var email = HttpContext.GetUserEmailWithCheck();

            await _freelancerService.SetCompleteExperienceInformationsAsync(email, freelancerHasCompletedExperienceInformations);

            return Ok();
        }

        [Authorize(Roles = "Admin,Freelancer")]
        [HttpPatch]
        [Route("complete-experience-info")]
        public async Task<IActionResult> AddCompleteExperienceInformations([FromBody] CompleteFreelancerExperienceInfoRequest request)
        {
            var email = HttpContext.GetUserEmailWithCheck();

            await _freelancerService.CompleteExperienceInformationsAsync(email, request);

            return Ok();
        }
    }
}