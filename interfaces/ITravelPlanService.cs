using TravelPlanApp.Models;

namespace TravelPlanApp.Interfaces;

public interface ITravelPlanService
{
    Task<TravelPlan> Plan(Travel travel);
}