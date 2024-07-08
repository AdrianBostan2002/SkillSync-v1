using SkillSync.Domain.Models;

namespace SkillSync.Domain.Interfaces.Repositories
{
    public interface IUserChatRepository : IRepository<UserChat>
    {
        Task<UserChat> GetUserChat(string firstUserEmail, string secondUserEmail);
        Task<List<UserChat>> GetUserChats(string userEmail);
    }
}