using System.Net;

namespace SkillSync.Domain.Exceptions.Register
{
    public class ConfirmEmailFailedException : ExceptionBase
    {
        public ConfirmEmailFailedException() :
             base(HttpStatusCode.BadRequest, "Email confirmation failed")
        { }
    }
}