namespace TravelPlanApp.Models;

public class TravelPlan
{
    public string Itinerary { get; private set; }
    public string Weather { get; private set; }
    public string ViolenceInfo { get; private set; }
    public string BestWayToTravel { get; private set; }

    public TravelPlan(string itinerary, string weather, string violenceInfo, string bestWayToTravel)
    {
        this.Itinerary = itinerary;
        this.Weather = weather;
        this.ViolenceInfo = violenceInfo;
        this.BestWayToTravel = bestWayToTravel;
    }
}