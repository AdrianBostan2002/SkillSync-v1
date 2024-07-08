using System.ComponentModel.DataAnnotations;

namespace SkillSync.IdentityManager.Dtos
{
    public class LinkedInSignInDto
    {
        [Required]
        public string AuthorizationCode { get; set; }
    }
}