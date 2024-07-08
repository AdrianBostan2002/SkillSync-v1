namespace SkillSync.Domain.Exceptions.Role
{
    public class UserHasMultipleRolesException : ExceptionBase
    {
        public UserHasMultipleRolesException() :
            base(System.Net.HttpStatusCode.Conflict, "User has multiple roles assigned")
        { }
    }
}