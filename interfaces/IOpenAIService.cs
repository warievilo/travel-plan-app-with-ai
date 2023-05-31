namespace TravelPlanApp.Interfaces;

public interface IOpenAIService
{
    Task<string> Call(string prompt);
}