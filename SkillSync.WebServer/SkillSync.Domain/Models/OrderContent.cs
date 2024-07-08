using SkillSync.Domain.Enums;

namespace SkillSync.Domain.Models
{
    public class OrderContent
    {
        public Guid Id { get; set; }

        public Guid OrderId { get; set; }
        public Order Order { get; set; }

        public string Content { get; set; }

        public string? Description { get; set; }

        public OrderContentPurpose Purpose { get; set; }

        public OrderContentType Type { get; set; }
    }
}