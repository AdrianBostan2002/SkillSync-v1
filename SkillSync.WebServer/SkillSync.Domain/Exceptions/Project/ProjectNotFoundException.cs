using System.Net;

namespace SkillSync.Domain.Exceptions.Project
{
    public class ProjectNotFoundException : ExceptionBase
    {
        public ProjectNotFoundException() :
            base(HttpStatusCode.NotFound, "Project not found")
        { }
    }
}