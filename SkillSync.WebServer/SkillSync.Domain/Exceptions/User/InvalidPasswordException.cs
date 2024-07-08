using System.Net;

namespace SkillSync.Domain.Exceptions.User
{
    public class InvalidPasswordException : ExceptionBase
    {
        public InvalidPasswordException() :
            base(HttpStatusCode.BadRequest, "Wrong password")
        { }
    }
}