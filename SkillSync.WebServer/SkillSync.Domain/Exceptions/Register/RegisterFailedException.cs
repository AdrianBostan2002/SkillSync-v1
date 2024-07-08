namespace SkillSync.Domain.Exceptions.Register
{
    public class RegisterFailedException : ExceptionBase
    {
        public RegisterFailedException() :
            base(System.Net.HttpStatusCode.Forbidden, "Register failed")
        { }

        public RegisterFailedException(string errorMessage) :
            base(System.Net.HttpStatusCode.Forbidden, errorMessage)
        { }
    }
}