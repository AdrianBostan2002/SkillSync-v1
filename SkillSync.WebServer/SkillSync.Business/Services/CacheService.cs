using Microsoft.Extensions.Caching.Memory;
using SkillSync.Domain.DTOs.Models;
using SkillSync.Domain.Interfaces.Services;

namespace SkillSync.Business.Services
{
    public class CacheService : ICacheService
    {
        private readonly IMemoryCache _memoryCache;

        private string GetNotificationKey(string email) => $"notification-{email}";
        private string GetAllSkillCategoriesKey() => "all-skill-categories";


        public CacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache ?? throw new ArgumentNullException(nameof(memoryCache));
        }

        public void AddChatRoom(ChatRoom chatRoom)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromMinutes(60)
            };

            _memoryCache.Set(chatRoom.Id, chatRoom, cacheEntryOptions);
        }

        public ChatRoom GetChatRoom(string key)
        {
            ChatRoom chatRoom;
            if (_memoryCache.TryGetValue(key, out chatRoom))
            {
                return chatRoom;
            }

            return null;
        }

        public void DeleteChatRoom(string key)
        {
            _memoryCache.Remove(key);
        }

        public void AddUserConnectionId(string email, string connectionId)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromMinutes(60)
            };

            _memoryCache.Set(email, connectionId, cacheEntryOptions);
        }

        public void DisconnectUser(string email)
        {
            _memoryCache.Remove(email);
        }

        public string GetConnectionId(string email)
        {
            string connectionId;
            if (_memoryCache.TryGetValue(email, out connectionId))
            {
                return connectionId;
            }

            return null;
        }

        public void AddUserNotificationConnectionId(string email, string connectionId)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromMinutes(60)
            };

            var key = GetNotificationKey(email);

            _memoryCache.Set(key, connectionId, cacheEntryOptions);
        }

        public string GetUserNotificationConnectionId(string email)
        {
            var key = GetNotificationKey(email);

            string connectionId;
            if (_memoryCache.TryGetValue(key, out connectionId))
            {
                return connectionId;
            }

            return null;
        }

        public void RemoveUserNotificationConnectionId(string email)
        {
            var key = GetNotificationKey(email);

            _memoryCache.Remove(key);
        }

        public void AddSkillCategories(List<SkillCategoryDto> skillCategories)
        {
            var cacheEntryOptions = new MemoryCacheEntryOptions
            {
                SlidingExpiration = TimeSpan.FromMinutes(60)
            };

            _memoryCache.Set(GetAllSkillCategoriesKey(), skillCategories, cacheEntryOptions);
        }

        public List<SkillCategoryDto> GetAllSkillCategories()
        {
            List<SkillCategoryDto> skillCategories;
            if (_memoryCache.TryGetValue(GetAllSkillCategoriesKey(), out skillCategories))
            {
                return skillCategories;
            }

            return null;
        }
    }
}