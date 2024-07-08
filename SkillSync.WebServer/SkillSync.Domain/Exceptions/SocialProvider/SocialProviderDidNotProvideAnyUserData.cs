namespace SkillSync.Domain.Exceptions.SocialProvider
{
    public class SocialProviderDidNotProvideAnyUserData : ExceptionBase
    {
        public SocialProviderDidNotProvideAnyUserData() :
            base(System.Net.HttpStatusCode.BadRequest, "Social provider didn't provide any user data")
        { }
    }
}