using Newtonsoft.Json;

namespace SkillSync.IdentityManager.Dtos
{
    public class LinkedInUserDto
    {
        [JsonProperty("given_name")]
        public string FirstName { get; set; }

        [JsonProperty("family_name")]
        public string LastName { get; set; }

        [JsonProperty("email")]
        public string Email { get; set; }

        [JsonProperty("locale")]
        public Locale Locale { get; set; }

        [JsonProperty("email_verified")]
        public bool EmailVerified { get; set; }

        [JsonProperty("sub")]
        public string Subject { get; set; }

        [JsonProperty("picture")]
        public string ProfilePicture { get; set; }
    }

    public class Locale
    {
        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("language")]
        public string Language { get; set; }
    }
}