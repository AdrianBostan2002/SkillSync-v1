using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillSync.AzureBlobStorage.Interfaces;
using SkillSync.Domain.DTOs.File;
using SkillSync.Domain.Interfaces.Services;
using SkillSync.WebServer.Extensions;

namespace SkillSync.WebServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IFileService _fileService;

        public UserController(IUserService userService, IFileService fileService)
        {
            _userService = userService ?? throw new ArgumentNullException(nameof(userService));
            _fileService = fileService ?? throw new ArgumentNullException(nameof(fileService));
        }

        [Authorize(Roles = "Admin,Freelancer,SkillScout")]
        [HttpGet]
        [Route("role")]
        public async Task<IActionResult> GetUserRoleAsync()
        {
            var email = HttpContext.GetUserEmailWithCheck();

            var result = await _userService.GetUserRoleAsync(email);

            return Ok(result);
        }

        [HttpPost]
        [Route("profile-picture")]
        public async Task<IActionResult> UploadProfilePicture([FromForm] UploadFileDto request)
        {
            await _fileService.UploadProfilePictureAsync(request);

            return Ok();
        }

        [Authorize(Roles = "Admin,Freelancer,SkillScout")]
        [HttpGet]
        [Route("profile-picture/")]
        public async Task<IActionResult> GetProfilePicture()
        {
            var email = HttpContext.GetUserEmailWithCheck();

            var result = await _userService.GetProfilePictureAsync(email);

            return Ok(new { ProfilePictureUrl = result });
        }
    }
}