using SkillSync.Domain.DTOs.Models;
using SkillSync.Domain.DTOs.Order;
using SkillSync.Domain.Enums;
using SkillSync.Domain.Models;

namespace SkillSync.Domain.Interfaces.Services
{
    public interface IOrderService
    {
        Task<Guid> AddOrderAsync(PlaceOrderDto request);
        Task<OrderDto> GetOrderById(Guid id);
        Task<List<Order>> GetOrdersByProjectId(Guid projectId);
        Task<List<GetOrderPreviewDto>> GetOrdersPreviewByStatus(string email, OrderStatus status, RoleType role);
        Task UpdateOrderStatus(Guid orderId, OrderStatus newOrderStatus);
        Task UpsertOrderContetMediaAsync(UpsertOrderContentDto request, Guid orderId, OrderContentPurpose purpose);
    }
}