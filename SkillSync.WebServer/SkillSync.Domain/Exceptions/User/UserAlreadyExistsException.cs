using System.Net;

namespace SkillSync.Domain.Exceptions.User
{
    public class UserAlreadyExistsException : ExceptionBase
    {
        public UserAlreadyExistsException() :
            base(HttpStatusCode.Conflict, "User already exists")
        { }
    }
}