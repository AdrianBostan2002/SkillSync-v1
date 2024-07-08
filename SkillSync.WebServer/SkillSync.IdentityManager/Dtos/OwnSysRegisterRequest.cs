using Microsoft.AspNetCore.Http;
using SkillSync.Domain.Enums;

namespace SkillSync.IdentityManager.Dtos
{
    public class OwnSysRegisterRequest
    {
        public string Email { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CountryCode { get; set; }

        public IFormFile ProfilePicture { get; set; }

        public RoleType Role { get; set; }
    }
}