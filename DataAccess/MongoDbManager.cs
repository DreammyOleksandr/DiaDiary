using Models;
using MongoDB.Driver;

namespace DataAccess;

public class MongoDbManager : ApplicationDbContext
{ 
    static IMongoCollection<LogEntry> collection = _db.GetCollection<LogEntry>(collectionName);
    
    public static async Task Create(LogEntry logEntry)
    {
        await collection.InsertOneAsync(logEntry);
    }
    //Read
    public static async Task GetAll()
    {
        var entries = await collection.FindAsync(_ => true);

        foreach (var entry in entries.ToList())
        {
            Console.WriteLine($"Glucose level = {entry.GlucoseLevel}");
        }
    }
    //Update
    public static async Task Update()
    {

    }
    //Delete
    public static async Task DeleteByGlucoseLevel()
    {
        Console.WriteLine("Choose note which you want to delete by glucose level");
        string GlucoseEntrieToDelete = Console.ReadLine();
        
        collection.DeleteOneAsync(p => p.GlucoseLevel.ToString() == GlucoseEntrieToDelete);
    }
}