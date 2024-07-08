using SkillSync.Domain.Interfaces.Repositories;
using SkillSync.Domain.Models;

namespace SkillSync.DataAccess.Repositories
{
    public class NotificationRepository : RepositoryBase<Notification>, INotificationRepository
    {
        private readonly RepositoryContext _repositoryContext;

        public NotificationRepository(RepositoryContext repositoryContext) :
            base(repositoryContext)
        {
            _repositoryContext = repositoryContext ?? throw new ArgumentNullException(nameof(repositoryContext));
        }
    }
}