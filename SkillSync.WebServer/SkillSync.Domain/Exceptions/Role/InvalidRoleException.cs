namespace SkillSync.Domain.Exceptions.Role
{
    public class InvalidRoleException : ExceptionBase
    {
        public InvalidRoleException() :
            base(System.Net.HttpStatusCode.BadRequest, "Invalid role")
        { }
    }
}