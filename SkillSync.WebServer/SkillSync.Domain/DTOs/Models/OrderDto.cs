using SkillSync.Domain.Enums;

namespace SkillSync.Domain.DTOs.Models
{
    public class OrderDto
    {
        public Guid Id { get; set; }

        public Guid ProjectId { get; set; }

        public string ProjectTitle { get; set; }

        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }

        public string FreelancerName { get; set; }
        public string FreelancerId { get; set; }

        public int Price { get; set; }

        public PackageType PackageType { get; set; }

        public OrderStatus Status { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UntilTo { get; set; }

        public DateTime? CompletedAt { get; set; }

        public List<OrderContentDto> PreviewContents { get; set; }

        public List<OrderContentDto> FinalProductContents { get; set; }
    }
}