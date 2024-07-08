using System.Net;

namespace SkillSync.Domain.Exceptions.Skill
{
    public class SkillNotFoundException : ExceptionBase
    {
        public SkillNotFoundException() :
            base(HttpStatusCode.NotFound, "Skill not found")
        { }
    }
}