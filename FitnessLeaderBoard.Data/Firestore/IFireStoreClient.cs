namespace FitnessLeaderboard.Data.Firestore;

public interface IFireStoreClient
{
    public Task<List<User>> FetchAllUserAsync();
    public Task UpsertUserAsync(User user);
}