namespace SkillSync.Domain.DTOs.SocialProviderUserData
{
    public class SocialProviderUserDto
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string LoginProviderSubject { get; set; }

        public string? CountryCode { get; set; }
    }
}