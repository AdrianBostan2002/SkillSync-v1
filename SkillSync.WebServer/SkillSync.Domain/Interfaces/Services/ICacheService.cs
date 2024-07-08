using SkillSync.Domain.DTOs.Models;

namespace SkillSync.Domain.Interfaces.Services
{
    public interface ICacheService
    {
        void AddChatRoom(ChatRoom chatRoom);
        void AddSkillCategories(List<SkillCategoryDto> skillCategories);
        void AddUserConnectionId(string email, string connectionId);
        void AddUserNotificationConnectionId(string email, string connectionId);
        void DeleteChatRoom(string key);
        void DisconnectUser(string email);
        List<SkillCategoryDto> GetAllSkillCategories();
        ChatRoom GetChatRoom(string key);
        string GetConnectionId(string email);
        string GetUserNotificationConnectionId(string email);
        void RemoveUserNotificationConnectionId(string email);
    }
}