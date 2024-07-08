using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillSync.Domain.DTOs.Project;
using SkillSync.Domain.DTOs.Project.PostSteps;
using SkillSync.Domain.DTOs.Review;
using SkillSync.Domain.Interfaces.Services;
using SkillSync.Domain.QueryParams;
using SkillSync.WebServer.Extensions;

namespace SkillSync.WebServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService ?? throw new ArgumentNullException(nameof(projectService));
        }

        [Authorize(Roles = "Admin,Freelancer")]
        [HttpPost]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> AddProject([FromForm] PostProjectRequest request)
        {
            var email = HttpContext.GetUserEmailWithCheck();

            await _projectService.AddProjectAsync(request, email);

            return Ok();
        }

        [Authorize(Roles = "Admin,Freelancer")]
        [HttpPost]
        [Route("overview")]
        public async Task<IActionResult> AddProjectOverview([FromBody] OverviewStepDto request)
        {
            var email = HttpContext.GetUserEmailWithCheck();

            var projectId = await _projectService.AddProjectOverviewAsync(request, email);

            return Created(string.Empty, new { projectId });
        }

        [Authorize(Roles = "Admin,Freelancer")]
        [HttpPut]
        [Route("overview/{projectId}")]
        public async Task<IActionResult> UpdateProjectOverview([FromBody] OverviewStepDto request, [FromRoute] Guid projectId)
        {
            var email = HttpContext.GetUserEmailWithCheck();

            await _projectService.UpdateProjectOverviewAsync(request, projectId, email);

            return NoContent();
        }

        [Authorize(Roles = "Admin,Freelancer")]
        [HttpGet]
        [Route("overview/{projectId}")]
        public async Task<IActionResult> GetProjectOverview([FromRoute] Guid projectId)
        {
            var result = await _projectService.GetProjectOverviewStepAsync(projectId);

            return Ok(result);
        }

        [Authorize(Roles = "Admin,Freelancer")]
        [HttpPut]
        [Route("pricing/{projectId}")]
        public async Task<IActionResult> UpsertProjectPricing([FromBody] UpsertPricingStepDto request, [FromRoute] Guid projectId)
        {
            var email = HttpContext.GetUserEmailWithCheck();

            await _projectService.UpsertPricingStepAsync(request, projectId, email);

            return NoContent();
        }

        [Authorize(Roles = "Admin,Freelancer")]
        [HttpGet]
        [Route("pricing/{projectId}")]
        public async Task<IActionResult> GetProjectPricing([FromRoute] Guid projectId)
        {
            var result = await _projectService.GetPricingStepAsync(projectId);

            return Ok(result);
        }

        [Authorize(Roles = "Admin,Freelancer")]
        [HttpPut]
        [Route("description-faq/{projectId}")]
        public async Task<IActionResult> UpsertProjectDescriptionFaq([FromBody] DescriptionFaqStepDto request, [FromRoute] Guid projectId)
        {
            var email = HttpContext.GetUserEmailWithCheck();

            await _projectService.UpsertDescriptionAndFaqStepAsync(request, projectId, email);

            return NoContent();
        }

        [Authorize(Roles = "Admin,Freelancer")]
        [HttpGet]
        [Route("description-faq/{projectId}")]
        public async Task<IActionResult> GetProjectDescriptionFaq([FromRoute] Guid projectId)
        {
            var result = await _projectService.GetProjectDescriptionAndFaqStepAsync(projectId);

            return Ok(result);
        }

        [Authorize(Roles = "Admin,Freelancer")]
        [HttpPut]
        [DisableRequestSizeLimit]
        [Route("gallery/{projectId}")]
        public async Task<IActionResult> UpsertProjectGallery([FromForm] UpsertProjectGalleryStepDto request, [FromRoute] Guid projectId)
        {
            var email = HttpContext.GetUserEmailWithCheck();

            await _projectService.UpsertProjectGalleryStepAsync(request, projectId, email);

            return NoContent();
        }

        [Authorize(Roles = "Admin,Freelancer")]
        [HttpGet]
        [Route("gallery/{projectId}")]
        public async Task<IActionResult> GetProjectGallery([FromRoute] Guid projectId)
        {
            var result = await _projectService.GetProjectGalleryStepAsync(projectId);

            return Ok(result);
        }

        [Authorize(Roles = "Admin,Freelancer")]
        [HttpPut]
        [Route("publish-status/{projectId}")]
        public async Task<IActionResult> UpsertProjectDescriptionFaq([FromRoute] Guid projectId, [FromBody] bool newStatus)
        {
            var email = HttpContext.GetUserEmailWithCheck();

            await _projectService.ModifyProjectPublishStatusAsync(projectId, newStatus, email);

            return NoContent();
        }

        [Authorize(Roles = "Admin,Freelancer")]
        [HttpGet]
        [Route("publish-status/{projectId}")]
        public async Task<IActionResult> GetProjectPublishStatus([FromRoute] Guid projectId)
        {
            var result = await _projectService.GetProjectPublishStatusAsync(projectId);

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("by-id/{projectId}")]
        public async Task<IActionResult> GetProject([FromRoute] Guid projectId)
        {
            var result = await _projectService.GetProjectAllDetailsByIdAsync(projectId);

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("all-projects-preview")]
        public async Task<IActionResult> GetAllProjectPreview()
        {
            var result = await _projectService.GetAllProjectsPreviewAsync();

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("by-subcategory-id/{subcategoryId}")]
        public async Task<IActionResult> GetProjectPreviewBySubcategoryId([FromRoute] Guid subcategoryId, [FromQuery] ProjectQueryParams queryParams)
        {
            var email = HttpContext.GetUserEmailWithoutCheck();

            var result = await _projectService.GetProjectsPreviewBySubcategoryId(subcategoryId, email, queryParams);

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("by-skill-id/{skillId}")]
        public async Task<IActionResult> GetProjectPreviewBySkillId([FromRoute] Guid skillId, [FromQuery] ProjectQueryParams queryParams)
        {
            var email = HttpContext.GetUserEmailWithoutCheck();

            var result = await _projectService.GetProjectsPreviewBySkillId(skillId, email, queryParams);

            return Ok(result);
        }

        [Authorize(Roles = "Admin,SkillScout")]
        [HttpPost]
        [Route("review/{projectId}")]
        public async Task<IActionResult> AddProjectReview([FromRoute] Guid projectId, [FromBody] PostReviewDto request)
        {
            var email = HttpContext.GetUserEmailWithCheck();

            await _projectService.AddProjectReview(email, projectId, request);

            return NoContent();
        }

        [Authorize(Roles = "Admin,Freelancer")]
        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteProject([FromRoute] Guid id)
        {
            var email = HttpContext.GetUserEmailWithCheck();

            await _projectService.DeleteProjectAsync(email, id);

            return NoContent();
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("search/{textSearch}")]
        public async Task<IActionResult> SearchProjects([FromRoute] string textSearch)
        {
            var result = await _projectService.SearchAllProjectsByTitle(textSearch);

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("search-by-subcategory-id/{textSearch}/{subCategoryId}")]
        public async Task<IActionResult> SearchProjectsBySkillCategoryId([FromRoute] string textSearch, [FromRoute] Guid subCategoryId)
        {
            var result = await _projectService.SearchProjectsHavingSkillSubcategoryIdByTitle(subCategoryId, textSearch);

            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("search-by-skill-id/{textSearch}/{skillId}")]
        public async Task<IActionResult> SearchProjectsBySkillId([FromRoute] string textSearch, [FromRoute] Guid skillId)
        {
            var result = await _projectService.SearchProjectsHavingSkillIdByTitle(skillId, textSearch);

            return Ok(result);
        }
    }
}