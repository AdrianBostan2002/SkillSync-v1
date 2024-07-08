using System.ComponentModel.DataAnnotations;

namespace SkillSync.Domain.DTOs.Login
{
    public class OwnSystemLoginRequest
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}