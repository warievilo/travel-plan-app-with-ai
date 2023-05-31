namespace TravelPlanApp.Models;

public class Travel 
{
    public DateTime StartDate { get; private set; }
    public DateTime EndDate { get; private set; }
    public string Origin { get; private set; }
    public string Destination { get; private set; }

    public Travel(DateTime startDate, DateTime endDate, string origin, string destination)
    {
        this.StartDate = startDate;
        this.EndDate = endDate;
        this.Origin = origin;
        this.Destination = destination;
    }
}