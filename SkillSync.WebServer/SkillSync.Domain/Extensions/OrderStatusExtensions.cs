using SkillSync.Domain.Enums;

namespace SkillSync.Domain.Extensions
{
    public static class OrderStatusExtensions
    {
        public static string ToString(this OrderStatus status)
        {
            return status switch
            {
                OrderStatus.Pending => "Pending",
                OrderStatus.Active => "Active",
                OrderStatus.Delivered => "Delivered",
                OrderStatus.Completed => "Completed",
                OrderStatus.Cancelled => "Cancelled",
                _ => "Unknown"
            };
        }
    }
}