using FitnessLeaderboard.Api.Strava;
using FitnessLeaderboard.Data;
using FitnessLeaderboard.Data.Configuration;
using FitnessLeaderboard.Data.Firestore;
using FitnessLeaderboard.Data.Strava;
using FitnessLeaderboard.Domain.Strava;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<StravaAuthService>();
builder.Services.AddScoped<IFireStoreClient, FireStoreClient>();
builder.Services.AddHttpClient();//Is this still necessary with typed clients?
builder.Services.Configure<GcpConfiguration>(builder.Configuration.GetSection("Gcp"));
builder.Services.Configure<StravaConfiguration>(builder.Configuration.GetSection("Strava"));

builder.Services.AddHttpClient<IStravaClient, StravaClient>();

var app = builder.Build();

app.MapGet("/hello", () => "Sup World");
app.MapGet("/auth-strava", async (StravaAuthService stravaAuthService, string? code) => await stravaAuthService.HandleAsync(code));
app.MapGet("/auth-strava", async (StravaAuthService stravaAuthService, string? code) => await stravaAuthService.HandleAsync(code));
app.MapPost("/publish/{request}", async (Webhook webhookService, string request) => await webhookService.NewAthleteActivity(request));

app.Run(); 