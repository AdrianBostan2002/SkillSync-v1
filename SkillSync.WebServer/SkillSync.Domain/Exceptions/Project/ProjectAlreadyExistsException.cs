using System.Net;

namespace SkillSync.Domain.Exceptions.Project
{
    public class ProjectAlreadyExistsException : ExceptionBase
    {
        public ProjectAlreadyExistsException() :
            base(HttpStatusCode.BadRequest, "Project already exists")
        { }
    }
}