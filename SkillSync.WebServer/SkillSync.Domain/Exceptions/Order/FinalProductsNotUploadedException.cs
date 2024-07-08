using System.Net;

namespace SkillSync.Domain.Exceptions.Order
{
    public class FinalProductsNotUploadedException : ExceptionBase
    {
        public FinalProductsNotUploadedException() :
            base(HttpStatusCode.NotAcceptable, "Final Products are not uploaded")
        { }
    }
}