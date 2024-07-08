using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillSync.Domain.Interfaces.Services;

namespace SkillSync.WebServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillSubcategoryController : ControllerBase
    {
        private readonly ISkillSubcategoryService _skillSubcategoryService;

        public SkillSubcategoryController(ISkillSubcategoryService skillSubcategoryService)
        {
            _skillSubcategoryService = skillSubcategoryService ?? throw new ArgumentNullException(nameof(skillSubcategoryService));
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("feature-options/{id}")]
        public async Task<IActionResult> GetSkillFeatureOptions([FromRoute] Guid id)
        {
            var result = await _skillSubcategoryService.GetSkillFeatureOptions(id);

            return Ok(result);
        }
    }
}