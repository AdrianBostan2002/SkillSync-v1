namespace SkillSync.Domain.Exceptions.Register
{
    public class FreelancerWasNotCreatedException : ExceptionBase
    {
        public FreelancerWasNotCreatedException() :
           base(System.Net.HttpStatusCode.ExpectationFailed, "Freelancer Was Not Created Exception")
        { }
    }
}