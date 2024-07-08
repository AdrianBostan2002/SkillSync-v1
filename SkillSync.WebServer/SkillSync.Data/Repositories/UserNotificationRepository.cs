using Microsoft.EntityFrameworkCore;
using SkillSync.Domain.Enums;
using SkillSync.Domain.Interfaces.Repositories;
using SkillSync.Domain.Models;

namespace SkillSync.DataAccess.Repositories
{
    public class UserNotificationRepository : RepositoryBase<UserNotification>, IUserNotificationRepository
    {
        private readonly RepositoryContext _repositoryContext;

        public UserNotificationRepository(RepositoryContext repositoryContext) :
            base(repositoryContext)
        {
            _repositoryContext = repositoryContext ?? throw new ArgumentNullException(nameof(repositoryContext));
        }

        public async Task<UserNotification> GetUserNotificationIncludeMessages(string senderId, string receivedId)
        {
            return await _repositoryContext.Set<UserNotification>().Include(x => x.Notifications).FirstOrDefaultAsync(x => x.SenderId == senderId && x.ReceiverId == receivedId);
        }

        public async Task<List<UserNotification>> GetUserNotificationsAsync(string receiverId)
        {
            return await _repositoryContext.Set<UserNotification>()
                .Where(x => x.ReceiverId == receiverId)
                .Include(x => x.Notifications)
                .ToListAsync();
        }

        public async Task<Notification> GetUserChatNotification(string senderId, string receiverId)
        {
            var query = await _repositoryContext.Set<UserNotification>().Include(x => x.Notifications).FirstOrDefaultAsync(x => x.SenderId == senderId && x.ReceiverId == receiverId);

            if (query == null)
            {
                return null;
            }

            return query.Notifications.FirstOrDefault(x => x.Type == NotificationType.NewMessage);
        }

        public async Task<Notification> GetNewPreviewContentUploadedNotification(string senderId, string receiverId, string additionalData)
        {
            var query = await _repositoryContext.Set<UserNotification>().Include(x => x.Notifications).FirstOrDefaultAsync(x => x.SenderId == senderId && x.ReceiverId == receiverId);

            if (query == null)
            {
                return null;
            }

            return query.Notifications.FirstOrDefault(x => x.Type == NotificationType.PreviewContentModified && x.AdditionalData == additionalData);
        }
    }
}