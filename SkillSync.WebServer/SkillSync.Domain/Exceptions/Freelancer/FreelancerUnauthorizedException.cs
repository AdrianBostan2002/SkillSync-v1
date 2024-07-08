using System.Net;

namespace SkillSync.Domain.Exceptions.Freelancer
{
    public class FreelancerUnauthorizedException : ExceptionBase
    {
        public FreelancerUnauthorizedException() :
           base(HttpStatusCode.Unauthorized, "Freelancer not authorized")
        { }

        public FreelancerUnauthorizedException(string message) :
           base(HttpStatusCode.Unauthorized, message)
        { }
    }
}