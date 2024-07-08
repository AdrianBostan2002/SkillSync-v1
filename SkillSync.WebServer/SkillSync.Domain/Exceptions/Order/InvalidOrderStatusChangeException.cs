using System.Net;

namespace SkillSync.Domain.Exceptions.Order
{
    public class InvalidOrderStatusChangeException : ExceptionBase
    {
        public InvalidOrderStatusChangeException() :
            base(HttpStatusCode.BadRequest, "Already processed order status cannot be changed into pending!")
        { }
    }
}