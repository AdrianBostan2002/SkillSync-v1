namespace SkillSync.AzureOpenAiChatBot.Interfaces
{
    public interface IChatBotService
    {
        Task<string> ExecuteQuery(string userQuery);
    }
}