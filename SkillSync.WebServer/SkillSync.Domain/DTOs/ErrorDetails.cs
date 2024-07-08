using System.Net;
using System.Text.Json;

namespace SkillSync.Domain.DTOs
{
    public class ErrorDetails
    {
        public HttpStatusCode HttpCodeStatus { get; set; }
        public string Message { get; set; }
        public bool IsCustom { get; set; }
        public override string ToString() => JsonSerializer.Serialize(this);
    }
}
