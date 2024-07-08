namespace SkillSync.Domain.Exceptions.Role
{
    public class UserDontHaveRoleException : ExceptionBase
    {
        public UserDontHaveRoleException() :
            base(System.Net.HttpStatusCode.NotFound, "User don't have any role assigned")
        { }
    }
}