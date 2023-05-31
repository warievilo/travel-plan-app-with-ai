using Microsoft.AspNetCore.Mvc;
using TravelPlanApp.Interfaces;
using TravelPlanApp.Models;
using TravelPlanApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient();

builder.Services.AddSingleton<IConfiguration>(provider => builder.Configuration);
builder.Services.AddScoped<IOpenAIService, OpenAIService>();
builder.Services.AddScoped<ITravelPlanService, TravelPlanService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapPost("/plan", async ([FromServices]ITravelPlanService travelPlanService, [FromBody]Travel travel) =>
{
    var travelPan = await travelPlanService.Plan(travel);
    return Results.Ok(travelPan);
}).Produces<TravelPlan>();

app.Run();