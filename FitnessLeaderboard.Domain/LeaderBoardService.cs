using FitnessLeaderboard.Data.Firestore;
using FitnessLeaderboard.Data.Strava;

namespace FitnessLeaderboard.Domain;

public class LeaderBoardService(IFireStoreClient fireStoreClient, IStravaClient stravaClient)
{
    public async Task PostLeaderBoardAsync()
    {
        var users = await fireStoreClient.FetchAllUserAsync();
        var athletes = new List<Athlete>();
        foreach (var user in users)
        {
            var stravaAthlete = await stravaClient.GetAthleteAsync(user);
            var userScore = stravaAthlete.YtdRideTotals.Distance + stravaAthlete.YtdRunTotals.Distance * 3 +
                            stravaAthlete.YtdSwimTotals.ElapsedTime; 
            // athletes.Add(new Athlete
            // {
            //     FullName = user.FullName,
            //     
            // });
        }
    } 
} 