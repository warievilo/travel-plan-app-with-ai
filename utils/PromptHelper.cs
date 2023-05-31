namespace TravelPlanApp.Utils;

public static class PromptHelper
{
    public static string GetItineraryPromptText(string destination, DateTime startDate, DateTime endDate) =>
      $"Estou viajando para {destination} nos dias {startDate} até {endDate} por favor me sugira um roteiro de viagem para cada dia.";

    public static string GetWeatherPromptText(string destination, DateTime startDate) =>
      $"Estou viajando para {destination} nos dia {startDate} baseado em dados históricos como é o clima nesse mês?";

    public static string GetViolencePromptText(string destination) =>
      $"Estou viajando para {destination}, como é a segurança desta cidade, devo me preocupar?";

    public static string GetBestWayPromptText(string origin, string destination) =>
      $"Eu moro em {origin} qual a forma mais eficiente de chegar em {destination}?";
}