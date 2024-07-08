namespace SkillSync.Chat.DTOs.Chat
{
    public class ChatRoomDto
    {
        public string? Id { get; set; }

        public List<ChatMessageDto<string>> Messages { get; set; }

        public ChatRoomParticipantDto OtherParticipant { get; set; }
    }
}