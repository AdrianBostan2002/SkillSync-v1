namespace SkillSync.Domain.Exceptions.Register
{
    public class UserWasNotCreatedException : ExceptionBase
    {
        public UserWasNotCreatedException() :
           base(System.Net.HttpStatusCode.ExpectationFailed, "User was not created")
        { }
    }
}