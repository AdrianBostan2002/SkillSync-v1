using System.Net;

namespace SkillSync.Domain.Exceptions.Order
{
    public class OrderNotFoundException : ExceptionBase
    {
        public OrderNotFoundException() :
           base(HttpStatusCode.NotFound, "Order not found")
        { }
    }
}