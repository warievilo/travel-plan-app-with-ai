using TravelPlanApp.Interfaces;
using TravelPlanApp.Models;
using TravelPlanApp.Utils;

namespace TravelPlanApp.Services;

public class TravelPlanService : ITravelPlanService
{
    private readonly IOpenAIService _openAIService;
    
    public TravelPlanService(IOpenAIService openAIService) =>
        _openAIService = openAIService;

    public async Task<TravelPlan> Plan(Travel travel)
    {
        var travelItinerary = await this.GetTravelItinerary(travel.Destination, travel.StartDate, travel.EndDate);
        var travelWeather = await this.GetTravelWeather(travel.Destination, travel.StartDate);
        var travelViolenceInfo = await this.GetTravelViolenceInfo(travel.Destination);
        var travelBestWay = await this.GetBestWay(travel.Origin, travel.Destination);

        return new TravelPlan(travelItinerary, travelWeather, travelViolenceInfo, travelBestWay);
    }

    private async Task<string> GetTravelItinerary(string destination, DateTime startDate, DateTime endDate)
    {
        var prompt = PromptHelper.GetItineraryPromptText(destination, startDate, endDate);

        return await _openAIService.Call(prompt);
    }

    private async Task<string> GetTravelWeather(string destination, DateTime startDate)
    {
        var prompt = PromptHelper.GetWeatherPromptText(destination, startDate);
        
        return await _openAIService.Call(prompt);
    }

    private async Task<string> GetTravelViolenceInfo(string destination)
    {
        var prompt = PromptHelper.GetViolencePromptText(destination);
        
        return await _openAIService.Call(prompt);
    }

    private async Task<string> GetBestWay(string origin, string destination)
    {
        var prompt = PromptHelper.GetBestWayPromptText(origin, destination);
        
        return await _openAIService.Call(prompt);
    }
}