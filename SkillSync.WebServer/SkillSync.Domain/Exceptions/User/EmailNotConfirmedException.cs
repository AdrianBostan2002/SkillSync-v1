using System.Net;

namespace SkillSync.Domain.Exceptions.User
{
    public class EmailNotConfirmedException : ExceptionBase
    {
        public EmailNotConfirmedException() :
            base(HttpStatusCode.Forbidden, "Email is not confirmed")
        { }
    }
}