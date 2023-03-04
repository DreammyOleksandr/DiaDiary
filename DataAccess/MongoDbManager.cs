using Models;
using MongoDB.Driver;

namespace DataAccess;

public class MongoDbManager
{
    private const string ConnectionString = "mongodb://127.0.0.1:27017";
    private const string DbName = "diabeticslogs";
    private static readonly string collectionName = "LogEntries";
    
    private static readonly MongoClient _client = new MongoClient(ConnectionString);

    //Create
    public static async Task Create(LogEntry logEntry)
    {
        var _db = _client.GetDatabase(DbName);
        var collection = _db.GetCollection<LogEntry>(collectionName);
        await collection.InsertOneAsync(logEntry);
    }
    //Read
    public static void GetAll()
    {
        var _db = _client.GetDatabase(DbName);
        var collection = _db.GetCollection<LogEntry>(collectionName);
        var entries = collection.Find(_ => true);

        foreach (var entry in entries.ToList())
        {
            Console.WriteLine($"Glucose level = {entry.GlucoseLevel}");
        }
    }
    //Update
    public static void Update()
    {
        var _db = _client.GetDatabase(DbName);
        var collection = _db.GetCollection<LogEntry>(collectionName);
    }
    //Delete
    public static void DeleteByGlucoseLevel()
    {
        Console.WriteLine("Choose note which you want to delete by glucose level");
        string GlucoseEntrieToDelete = Console.ReadLine();
        var _db = _client.GetDatabase(DbName);
        var collection = _db.GetCollection<LogEntry>(collectionName);
        collection.DeleteOne(p => p.GlucoseLevel.ToString() == GlucoseEntrieToDelete);
    }
}