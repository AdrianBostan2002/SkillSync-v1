using System.Net;

namespace SkillSync.Domain.Exceptions.User
{
    public class UserNotFoundException : ExceptionBase
    {
        public UserNotFoundException() :
            base(HttpStatusCode.NotFound, "User not found")
        { }
    }
}