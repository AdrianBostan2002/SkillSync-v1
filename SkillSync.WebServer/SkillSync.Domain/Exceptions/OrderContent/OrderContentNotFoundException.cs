using System.Net;

namespace SkillSync.Domain.Exceptions.OrderContent
{
    public class OrderContentNotFoundException : ExceptionBase
    {
        public OrderContentNotFoundException() :
            base(HttpStatusCode.NotFound, "Order Content not found")
        { }
    }
}