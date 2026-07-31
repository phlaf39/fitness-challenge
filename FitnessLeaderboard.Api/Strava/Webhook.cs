
namespace FitnessLeaderboard.Api.Strava;
public class Webhook
{
    public async Task NewAthleteActivity(string activity)
    {
        // Handle the new activity here
        Console.WriteLine("new activity: " + activity);
    }
}