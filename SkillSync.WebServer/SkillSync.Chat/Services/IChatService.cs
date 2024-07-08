using SkillSync.Chat.DTOs.Chat;
using SkillSync.Domain.DTOs.Models;
using SkillSync.Domain.Enums;
using SkillSync.Domain.Models;

namespace SkillSync.Chat.Services
{
    public interface IChatService
    {
        void ConnectUser(string email, string connectionId);
        Task<ChatRoom> CreateChatRoomAsync(string firstUserEmail, string secondUserEmail);
        void DeleteRoomAsync(string roomName);
        void DisconnectUser(string email);
        Task<List<ChatRoomDto>> GetAllUserChats(string email, string connectionId);
        ChatRoom GetChatRoomFromCache(string chatRoomName);
        string GetConnectionId(string email);
        string GetMediaFromStorage(string fileName, ChatMessageType type);
        User GetOtherParticipant(string currentParticipant, ChatRoom chatRoom);
        string GetReceiverConnectionId(string chatRoomId, string sender);
        Task<string> SaveMessageAsync<T>(string chatRoomId, ChatMessageDto<T> message);
        Task<ChatRoomDto> ShouldReceiverGetNewInitiatedChatRoomAsync(string chatRoomId, string sender);
        Task<ChatRoomDto> UpsertRoomAsync(string firstUserEmail, string firstUserConnectionId, string secondUserEmail);
    }
}