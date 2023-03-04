using Models;
using MongoDB.Driver;

namespace DataAccess;

public class MongoDbManager : ApplicationDbContext
{

    public static async Task Create(LogEntry logEntry)
    {
        var _db = _client.GetDatabase(DbName);
        var collection = _db.GetCollection<LogEntry>(collectionName);
        await collection.InsertOneAsync(logEntry);
    }
    //Read
    public static async Task GetAll()
    {
        var _db = _client.GetDatabase(DbName);
        var collection = _db.GetCollection<LogEntry>(collectionName);
        var entries = await collection.FindAsync(_ => true);

        foreach (var entry in entries.ToList())
        {
            Console.WriteLine($"Glucose level = {entry.GlucoseLevel}");
        }
    }
    //Update
    public static async Task Update()
    {
        var _db = _client.GetDatabase(DbName);
        var collection = _db.GetCollection<LogEntry>(collectionName);
    }
    //Delete
    public static async Task DeleteByGlucoseLevel()
    {
        Console.WriteLine("Choose note which you want to delete by glucose level");
        string GlucoseEntrieToDelete = Console.ReadLine();
        var _db = _client.GetDatabase(DbName);
        var collection = _db.GetCollection<LogEntry>(collectionName);
        collection.DeleteOneAsync(p => p.GlucoseLevel.ToString() == GlucoseEntrieToDelete);
    }
}