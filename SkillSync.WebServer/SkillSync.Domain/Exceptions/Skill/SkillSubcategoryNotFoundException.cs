using System.Net;

namespace SkillSync.Domain.Exceptions.Skill
{
    public class SkillSubcategoryNotFoundException : ExceptionBase
    {
        public SkillSubcategoryNotFoundException() :
            base(HttpStatusCode.NotFound, "SkillSubcategory not found")
        { }
    }
}