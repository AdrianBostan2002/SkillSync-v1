using System.Net;

namespace SkillSync.Domain.Exceptions.Freelancer
{
    public class FreelancerNotFoundException : ExceptionBase
    {
        public FreelancerNotFoundException() :
           base(HttpStatusCode.NotFound, "Freelancer not found")
        { }
    }
}