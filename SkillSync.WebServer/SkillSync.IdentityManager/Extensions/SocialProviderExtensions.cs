using SkillSync.Domain.Enums;
using SkillSync.Domain.Exceptions.LoginProvider;

namespace SkillSync.IdentityManager.Extensions
{
    public static class SocialProviderExtensions
    {
        public static string ToString(this SocialProvider provider)
        {
            switch (provider)
            {
                case SocialProvider.Google:
                    return "Google";
                case SocialProvider.LinkedIn:
                    return "LinkedIn";
                default:
                    throw new InvalidSocialProviderException();
            }
        }
    }
}