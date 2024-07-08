using System.Net;

namespace SkillSync.Domain.Exceptions.Order
{
    public class DeleteProjectException : ExceptionBase
    {
        public DeleteProjectException() :
            base(HttpStatusCode.NotAcceptable, "You cannot delete this project because it has a processed order. Instead, please set the project to 'not published'.")
        { }
    }
}