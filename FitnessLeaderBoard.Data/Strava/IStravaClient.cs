namespace FitnessLeaderboard.Data.Strava;

public interface IStravaClient
{
    public Task<StravaUserResponse?> GetUserAsync(string code);
    public Task<StravaAthleteResponse?> GetAthleteAsync(User user);
}