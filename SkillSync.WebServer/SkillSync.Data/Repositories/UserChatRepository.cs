using Microsoft.EntityFrameworkCore;
using SkillSync.Domain.Interfaces.Repositories;
using SkillSync.Domain.Models;

namespace SkillSync.DataAccess.Repositories
{
    public class UserChatRepository : RepositoryBase<UserChat>, IUserChatRepository
    {
        private readonly RepositoryContext _repositoryContext;

        public UserChatRepository(RepositoryContext repositoryContext) :
            base(repositoryContext)
        {
            _repositoryContext = repositoryContext ?? throw new ArgumentNullException(nameof(repositoryContext));
        }

        public async Task<UserChat> GetUserChat(string firstUserEmail, string secondUserEmail)
        {
            var query = await _repositoryContext.Set<UserChat>()
                .Where(uc =>
                (uc.FirstUser.Email == firstUserEmail && uc.SecondUser.Email == secondUserEmail) ||
                (uc.FirstUser.Email == secondUserEmail && uc.SecondUser.Email == firstUserEmail))
                .Include(uc => uc.FirstUser)
                .Include(uc => uc.SecondUser)
                .Include(uc => uc.Messages)
                .FirstOrDefaultAsync();

            return query;
        }

        public async Task<List<UserChat>> GetUserChats(string userEmail)
        {
            var query = await _repositoryContext.Set<UserChat>()
                .Where(uc => (uc.FirstUser.Email == userEmail || uc.SecondUser.Email == userEmail))
                .Include(uc => uc.FirstUser)
                .Include(uc => uc.SecondUser)
                .Include(uc => uc.Messages)
                .ToListAsync();

            return query;
        }
    }
}