using Models;
using MongoDB.Driver;

namespace DataAccess;

public class MongoDbManager : ApplicationDbContext
{ 
    static readonly IMongoCollection<LogEntry> collection = _db.GetCollection<LogEntry>(collectionName);
    
    public static async Task Create(LogEntry logEntry)
    {
        LogEntry.LogNumber++;
        await collection.InsertOneAsync(logEntry);
    }
    //Read
    public static async Task GetAll()
    {
        var entries = await collection.FindAsync(_ => true);

        foreach (var entry in entries.ToList())
        {
            Console.WriteLine($"{LogEntry.LogNumber}) Time: {entry.Time:t}\n\n"+
                              $"Glucose level: {entry.GlucoseLevel}\n" +
                              $"Short term insulin: {entry.ShortTermInsulin}\n" +
                              $"Long term insulin: {entry.LongTermInsulin}\n" +
                              $"Carbs (Bread units): {entry.CarbsInBreadUnits}\n");
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
        await collection.FindAsync(p => p.GlucoseLevel.ToString() == GlucoseEntrieToDelete);
    }
}