using Microsoft.AspNetCore.Identity;

namespace SkillSync.Domain.Models
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string CountryCode { get; set; }

        public string ProfilePicture { get; set; }
    }
}