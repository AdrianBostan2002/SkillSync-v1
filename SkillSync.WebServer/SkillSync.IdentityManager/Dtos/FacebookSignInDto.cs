using System.ComponentModel.DataAnnotations;

namespace SkillSync.IdentityManager.Dtos
{
    public class FacebookSignInDto
    {
        [Required]
        public string AccessToken { get; set; }
    }
}