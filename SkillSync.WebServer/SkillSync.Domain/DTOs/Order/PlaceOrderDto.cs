using SkillSync.Domain.Enums;

namespace SkillSync.Domain.DTOs.Order
{
    public class PlaceOrderDto
    {
        public Guid ProjectId { get; set; }

        public string? CustomerEmail { get; set; }

        public PackageType PackageType { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UntilTo { get; set; }
    }
}