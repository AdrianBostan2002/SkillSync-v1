using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SkillSync.Domain.Dtos.Login;
using SkillSync.Domain.DTOs.Login;
using SkillSync.IdentityManager.Dtos;
using SkillSync.IdentityManager.Services.Auth;

namespace SkillSync.WebServer.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;

        public IdentityController(IAuthService authService, IConfiguration configuration)
        {
            _authService = authService ?? throw new ArgumentNullException(nameof(authService));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("/login")]
        public async Task<IActionResult> LoginAsync([FromBody] OwnSystemLoginRequest request)
        {
            var result = await _authService.OwnSystemLoginAsync(request);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("/social-login")]
        public async Task<IActionResult> SocialProviderLoginIn(SocialProviderLoginRequest request)
        {
            var result = await _authService.LoginWithSocialProviderAsync(request);
            return Ok(result);
        }

        [Route("/own-system-register")]
        [HttpPost]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> OwnSystemRegisterAsync([FromForm] OwnSysRegisterRequest request)
        {
            await _authService.OwnSystemRegisterAsync(request, Request);

            return Ok(new { message = "A confirmation email has been sent! Please check your email to confirm your registration!" });
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("/social-provider-register")]
        public async Task<IActionResult> Register(SocialProviderRegisterRequest request)
        {
            var result = await _authService.SocialProviderRegisterAsync(request);
            return Ok(result);
        }

        [AllowAnonymous]
        [Route("ConfirmEmail")]
        [HttpGet]
        public async Task<IActionResult> ConfirmEmail([FromQuery] string id, [FromQuery] string confirmationToken)
        {
            await _authService.ConfirmEmailAsync(id, confirmationToken);

            var frontendAppUrl = _configuration.GetSection("FrontendApp:Url");

            return Redirect($"{frontendAppUrl.Value}/email-confirmation");
        }
    }
}