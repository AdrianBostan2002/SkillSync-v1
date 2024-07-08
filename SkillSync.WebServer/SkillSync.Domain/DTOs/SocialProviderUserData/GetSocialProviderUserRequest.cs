using SkillSync.Domain.Enums;

namespace SkillSync.Domain.DTOs.SocialProviderUserData
{
    public class GetSocialProviderUserRequest
    {
        public SocialProvider SocialProvider { get; set; }

        public string AccessToken { get; set; }
    }
}