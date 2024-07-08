using SkillSync.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace SkillSync.Domain.Dtos.Login
{
    public class SocialProviderLoginRequest
    {
        [Required]
        public string AuthorizationCode { get; set; }

        [Required]
        public SocialProvider SocialProvider { get; set; }
    }
}