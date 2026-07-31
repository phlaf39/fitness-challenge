using FitnessLeaderboard.Data;
using FitnessLeaderboard.Data.Firestore;
using FitnessLeaderboard.Data.Strava;

namespace FitnessLeaderboard.Domain.Strava;
//Would like to use IResult but Failed RIP
public class StravaAuthService( IFireStoreClient fireStoreClient, IStravaClient stravaClient )
{
    public async Task<string> HandleAsync(string? code)
    {
        if (code == null) return "Code is null";
        var stravaUser = await stravaClient.GetUserAsync(code);
        if (stravaUser == null) return "User is null";
  
        var user = new User { FullName = stravaUser.Athlete.Firstname + stravaUser.Athlete.Lastname, RefreshToken = stravaUser.RefreshToken, AthleteId =
            (stravaUser.Athlete.Id)};
        
        await fireStoreClient.UpsertUserAsync(user);

        return "Time To grind " + user.FullName;
    }
}