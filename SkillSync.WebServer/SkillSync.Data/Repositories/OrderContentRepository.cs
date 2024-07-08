using SkillSync.Domain.Interfaces.Repositories;
using SkillSync.Domain.Models;

namespace SkillSync.DataAccess.Repositories
{
    public class OrderContentRepository : RepositoryBase<OrderContent>, IOrderContentRepository
    {
        private readonly RepositoryContext _repositoryContext;

        public OrderContentRepository(RepositoryContext repositoryContext) :
            base(repositoryContext)
        {
            _repositoryContext = repositoryContext ?? throw new ArgumentNullException(nameof(repositoryContext));
        }
    }
}