using SkillSync.Domain.Enums;

namespace SkillSync.Domain.DTOs.Models
{
    public class OrderContentDto
    {
        public Guid Id { get; set; }

        public Guid OrderId { get; set; }

        public string Content { get; set; }

        public string BlobName { get; set; }    

        public string? Description { get; set; }

        public OrderContentType Type { get; set; }
    }
}