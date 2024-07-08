using Microsoft.Extensions.Configuration;
using SkillSync.AzureOpenAiChatBot.Interfaces;
using System.Text;
using System.Text.Json;

namespace SkillSync.AzureOpenAiChatBot.Services
{
    public class AzureOpenAiChatBotService : IChatBotService
    {
        private string _url;
        private string _apiKey;
        private string _systemMessage;
        private string _gptModel;

        public AzureOpenAiChatBotService(IConfiguration configuration)
        {
            _url = configuration["AzureOpenAiChatBot:Url"];
            _apiKey = configuration["AzureOpenAiChatBot:ApiKey"];
            _systemMessage = configuration["AzureOpenAiChatBot:SystemMessage"];
            _gptModel = configuration["AzureOpenAiChatBot:GptModel"];
        }

        public async Task<string> ExecuteQuery(string userQuery)
        {
            var client = new HttpClient();

            var request = new HttpRequestMessage(HttpMethod.Post, _url);

            request.Headers.Add("api-key", _apiKey);

            var requestBody = new
            {
                model = _gptModel,
                messages = new[]
            {
                    new { role = "system", content = _systemMessage },
                    new { role = "user", content = userQuery }
                }
            };

            string jsonString = JsonSerializer.Serialize(requestBody);
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            request.Content = content;

            string queryResponse = "Error";

            HttpResponseMessage response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            var responseString = await new StreamReader(responseStream).ReadToEndAsync();

            var jsonResponse = JsonDocument.Parse(responseString);
            var rootElement = jsonResponse.RootElement;

            if (rootElement.TryGetProperty("choices", out JsonElement choicesElement))
            {
                var choicesArray = choicesElement.EnumerateArray();

                foreach (var choice in choicesArray)
                {
                    if (choice.TryGetProperty("message", out JsonElement messageElement))
                    {
                        if (messageElement.TryGetProperty("content", out JsonElement contentElement))
                        {
                            return contentElement.GetString();
                        }
                    }
                }
            }

            return queryResponse;
        }
    }
}