using System.Net;

namespace SkillSync.Domain.Exceptions.Chat
{
    public class ChatNotFoundException : ExceptionBase
    {
        public ChatNotFoundException() :
           base(HttpStatusCode.NotFound, "Chat not found")
        { }
    }
}