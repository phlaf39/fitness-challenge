using System.Net.Http.Headers;
using System.Net.Http.Json;
using FitnessLeaderboard.Data.Configuration;
using Microsoft.Extensions.Options;

namespace FitnessLeaderboard.Data.Strava;

public class StravaClient: IStravaClient
{
    private readonly HttpClient _httpClient;
    private readonly IOptions<StravaConfiguration> _stravaConfiguration;

    public StravaClient(HttpClient httpClient, IOptions<StravaConfiguration> stravaConfiguration)
    {
        _httpClient = httpClient;
        _httpClient.BaseAddress = new Uri("https://www.strava.com/");
        _stravaConfiguration = stravaConfiguration;
    }
    
    public async Task<StravaUserResponse?> GetUserAsync(string code)
    {
        var formData = new FormUrlEncodedContent([
                new KeyValuePair<string, string>("client_id", _stravaConfiguration.Value.ClientId),
                new KeyValuePair<string, string>("client_secret", _stravaConfiguration.Value.ClientSecret),
                new KeyValuePair<string, string>("code", code),
                new KeyValuePair<string, string>("grant_type", "authorization_code")
            ]
        );
         var response = await _httpClient.PostAsync($"oauth/token", formData);
         return await response.Content.ReadFromJsonAsync<StravaUserResponse>();
    }

    public async Task<StravaAthleteResponse?> GetAthleteAsync(User user)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", user.RefreshToken);
        var response = await _httpClient.GetAsync($"https://www.strava.com/api/v3/athletes/{user.AthleteId}/stats");
        return await response.Content.ReadFromJsonAsync<StravaAthleteResponse>();
    }

}