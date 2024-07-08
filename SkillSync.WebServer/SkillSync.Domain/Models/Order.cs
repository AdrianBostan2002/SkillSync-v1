using SkillSync.Domain.Enums;

namespace SkillSync.Domain.Models
{
    public class Order
    {
        public Guid Id { get; set; }

        public Guid ProjectId { get; set; }
        public Project Project { get; set; }

        public string CustomerId { get; set; }
        public User Customer { get; set; }

        public PackageType PackageType { get; set; }

        public OrderStatus Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UntilTo { get; set; }

        public DateTime? CompletedAt { get; set; }

        public List<OrderContent> Contents { get; set; }
    }
}