namespace SkillSync.Domain.Exceptions.Register
{
    public class NotAbleToRegisterNewAdministratorException : ExceptionBase
    {
        public NotAbleToRegisterNewAdministratorException() :
            base(System.Net.HttpStatusCode.MethodNotAllowed, "You are not able to register new administrator")
        { }
    }
}