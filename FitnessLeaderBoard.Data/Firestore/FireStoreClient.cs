using FitnessLeaderboard.Data.Configuration;
using Google.Cloud.Firestore;
using Microsoft.Extensions.Options;

namespace FitnessLeaderboard.Data.Firestore;

public class FireStoreClient(IOptions<GcpConfiguration> gcpConfiguration):IFireStoreClient
{
    public async Task<List<User>>FetchAllUserAsync()
    {
        var dataBase = await new FirestoreDbBuilder
            { ProjectId = gcpConfiguration.Value.ProjectId, DatabaseId = "fitness" }.BuildAsync(); // Ajouter fitness co mme UserDbName
        
        var snapshot = await dataBase.Collection("users").GetSnapshotAsync();

        return snapshot.Documents.Select(document => document.ConvertTo<User>()).ToList();
    }

    public async Task UpsertUserAsync(User user)
    {
        var database = await new FirestoreDbBuilder(){ProjectId = gcpConfiguration.Value.ProjectId, DatabaseId = "fitness"}.BuildAsync();
        
        var collection = database.Collection("Users");
        var docRef = collection.Document((user.AthleteId).ToString());
        await docRef.SetAsync(user);
    }
}