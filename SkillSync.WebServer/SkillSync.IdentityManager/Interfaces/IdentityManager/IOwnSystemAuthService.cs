using Microsoft.AspNetCore.Http;
using SkillSync.Domain.DTOs.Login;
using SkillSync.Domain.Models;
using SkillSync.IdentityManager.Dtos;

namespace SkillSync.IdentityManager.Interfaces.IdentityManager
{
    public interface IOwnSystemAuthService
    {
        Task<LoginResponse> LoginAsync(OwnSystemLoginRequest request);
        Task<User> RegisterAsync(OwnSysRegisterRequest register, HttpRequest httpRequest);
    }
}