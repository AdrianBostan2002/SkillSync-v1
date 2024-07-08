using System.Net;

namespace SkillSync.Domain.Exceptions.Claims
{
    public class UserEmailClaimNotFoundException : ExceptionBase
    {
        public UserEmailClaimNotFoundException() :
           base(HttpStatusCode.NotFound, "User email claim not found")
        { }
    }
}