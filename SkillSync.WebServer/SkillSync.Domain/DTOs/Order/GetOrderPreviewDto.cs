using SkillSync.Domain.Enums;

namespace SkillSync.Domain.DTOs.Order
{
    public class GetOrderPreviewDto
    {
        public Guid Id { get; set; }

        public Guid ProjectId { get; set; }

        public string ProjectTitle { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public OrderStatus Status { get; set; }

        public int Price { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UntilTo { get; set; }

        public DateTime? CompletedAt { get; set; }
    }
}