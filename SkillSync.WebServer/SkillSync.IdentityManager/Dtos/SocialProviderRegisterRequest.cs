using SkillSync.Domain.Enums;

namespace SkillSync.IdentityManager.Dtos
{
    public class SocialProviderRegisterRequest
    {
        public SocialProvider SocialProvider { get; set; }

        public string AccessToken { get; set; }

        public RoleType Role { get; set; }
    }
}