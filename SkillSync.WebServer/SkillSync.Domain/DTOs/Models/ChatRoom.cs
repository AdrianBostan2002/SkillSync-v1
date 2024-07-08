using SkillSync.Domain.Models;

namespace SkillSync.Domain.DTOs.Models
{
    public class ChatRoom
    {
        public string Id { get; set; }

        public UserChat Chat { get; set; }
    }
}