using SkillSync.Domain.Enums;
using SkillSync.Domain.Models;

namespace SkillSync.Domain.Interfaces.Repositories
{
    public interface IOrderRepository : IRepository<Order>
    {
        Task<Order> GetByIdIncludeAllDependencies(Guid id);
        Task<Order> GetByIdIncludeContents(Guid id);
        Task<List<Order>> GetFreelancerOrdersByStatusAsync(Guid freelancerId, OrderStatus status);
        Task<List<Order>> GetSkillScoutOrdersByStatusAsync(string customerId, OrderStatus status);
    }
}