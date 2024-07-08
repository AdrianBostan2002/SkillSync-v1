namespace SkillSync.Domain.Exceptions.SocialProvider
{
    public class LinkedInObtainedTokenIsNullException : ExceptionBase
    {
        public LinkedInObtainedTokenIsNullException() :
            base(System.Net.HttpStatusCode.BadRequest, "LinkedIn obtained token is null")
        { }
    }
}