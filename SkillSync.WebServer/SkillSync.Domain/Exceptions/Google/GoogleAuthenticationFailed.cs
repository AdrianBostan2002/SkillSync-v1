namespace SkillSync.Domain.Exceptions.Google
{
    public class GoogleAuthenticationFailed : ExceptionBase
    {
        public GoogleAuthenticationFailed() :
            base(System.Net.HttpStatusCode.NotFound, "Google account was not found")
        { }
    }
}