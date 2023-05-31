using Azure;
using Azure.AI.OpenAI;
using TravelPlanApp.Interfaces;

namespace TravelPlanApp.Services;

public class OpenAIService : IOpenAIService
{
    private readonly IConfiguration _configuration;

    public OpenAIService(IConfiguration configuration) =>
        _configuration = configuration;

    public async Task<string> Call(string prompt)
    {
        var client = new OpenAIClient(this._configuration["OpenAI-Key"], new OpenAIClientOptions());

        var chatCompletionsOptions = new ChatCompletionsOptions()
        {
            Messages = { new ChatMessage(ChatRole.User, prompt) }
        };

        Response<ChatCompletions> response = await client.GetChatCompletionsAsync(
            deploymentOrModelName: "gpt-3.5-turbo",
            chatCompletionsOptions);

        return response.Value.Choices[0].Message.Content;        
    }
}