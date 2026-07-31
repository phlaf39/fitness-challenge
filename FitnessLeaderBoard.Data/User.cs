using Google.Cloud.Firestore;

namespace FitnessLeaderboard.Data;

[FirestoreData]
public class User
{
    [FirestoreProperty("athlete_id")]
    public int AthleteId { get; set; }
    [FirestoreProperty("FullName")]
    public string FullName  { get; set; }
    [FirestoreProperty("refresh_token")]
    public string RefreshToken {get; set;}
    
}
