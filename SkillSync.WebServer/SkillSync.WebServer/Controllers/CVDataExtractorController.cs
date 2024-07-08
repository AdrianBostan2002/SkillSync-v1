using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillSync.CVDataExtractor.Interfaces;

namespace SkillSync.WebServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CVDataExtractorController : ControllerBase
    {
        private readonly ICVDataExtractorService _cvDataExtractorService;

        public CVDataExtractorController(ICVDataExtractorService cvDataExtractorService)
        {
            _cvDataExtractorService = cvDataExtractorService ?? throw new ArgumentNullException(nameof(cvDataExtractorService));
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> ExtractCVData([FromForm] IFormFile resume)
        {
            var result = await _cvDataExtractorService.ExtractResumeDataAsync(resume);

            return Ok(result);
        }
    }
}