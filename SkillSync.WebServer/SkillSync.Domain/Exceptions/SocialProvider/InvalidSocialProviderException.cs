namespace SkillSync.Domain.Exceptions.LoginProvider
{
    public class InvalidSocialProviderException : ExceptionBase
    {
        public InvalidSocialProviderException() :
            base(System.Net.HttpStatusCode.BadRequest, "Login Provider is not valid")
        { }
    }
}