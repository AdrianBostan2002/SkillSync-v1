using Microsoft.EntityFrameworkCore;
using SkillSync.Domain.Enums;
using SkillSync.Domain.Interfaces.Repositories;
using SkillSync.Domain.Models;

namespace SkillSync.DataAccess.Repositories
{
    public class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        private readonly RepositoryContext _repositoryContext;

        public OrderRepository(RepositoryContext repositoryContext) :
            base(repositoryContext)
        {
            _repositoryContext = repositoryContext ?? throw new ArgumentNullException(nameof(repositoryContext));
        }

        public async Task<Order> GetByIdIncludeContents(Guid id)
        {
            var query = await _repositoryContext.Set<Order>()
                .Where(o => o.Id == id)
                .Include(o => o.Contents)
                .Include(o => o.Customer)
                .Include(o => o.Project)
                .ThenInclude(p => p.Features.Where(f => f.Feature.Name == "Price"))
                .FirstOrDefaultAsync();

            return query;
        }

        public async Task<Order> GetByIdIncludeAllDependencies(Guid id)
        {
            var query = await _repositoryContext.Set<Order>()
                .Where(o => o.Id == id)
                .Include(o => o.Contents)
                .Include(o => o.Customer)
                .Include(o => o.Project)
                .ThenInclude(p => p.Freelancer)
                .ThenInclude(f => f.User)
                .Include(p => p.Project.Features.Where(f => f.Feature.Name == "Price"))
                .FirstOrDefaultAsync();

            return query;
        }

        public async Task<List<Order>> GetFreelancerOrdersByStatusAsync(Guid freelancerId, OrderStatus status)
        {
            return await _repositoryContext.Set<Order>()
                .Where(o => o.Project.FreelancerId == freelancerId && o.Status == status)
                .Include(o => o.Customer)
                .Include(o => o.Project)
                .ThenInclude(p => p.Features.Where(f => f.Feature.Name == "Price"))
                .ToListAsync();
        }

        public async Task<List<Order>> GetSkillScoutOrdersByStatusAsync(string customerId, OrderStatus status)
        {
            return await _repositoryContext.Set<Order>()
                .Where(o => o.CustomerId == customerId && o.Status == status)
                .Include(o => o.Project)
                .ThenInclude(p => p.Features.Where(f => f.Feature.Name == "Price"))
                .Include(o => o.Project.Freelancer)
                .ThenInclude(f => f.User)
                .ToListAsync();
        }
    }
}