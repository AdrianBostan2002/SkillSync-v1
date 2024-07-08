using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillSync.Domain.Interfaces.Services;

namespace SkillSync.WebServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillCategoryController : ControllerBase
    {
        private readonly ISkillCategoryService _skillCategoryService;

        public SkillCategoryController(ISkillCategoryService skillCategoryService)
        {
            _skillCategoryService = skillCategoryService ?? throw new ArgumentNullException(nameof(skillCategoryService));
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWithDependenciesAsync()
        {
            return Ok(await _skillCategoryService.GetWithAllDependenciesAsync());
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("frequently-asked-questions/{id}")]
        public async Task<IActionResult> GetFrequentlyAskedQuestionsAsync([FromRoute] Guid id)
        {
            var result = await _skillCategoryService.GetSkillCategoryFrequentlyAskedQuestionsAsync(id);

            return Ok(result);
        }
    }
}