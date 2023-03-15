using Models;
using MongoDB.Driver;

namespace DataAccess;

public class MongoCRUD : ApplicationDbContext
{
    //Create
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
            Console.WriteLine($"Time: {entry.Time:t}\n\n"+
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
    public static async Task Delete()
    {
        Console.WriteLine("Choose note which you want to delete by glucose level");
        string GlucoseEntrieToDelete = Console.ReadLine();
        try
        {
            await collection.DeleteOneAsync(p => p.GlucoseLevel.ToString() == GlucoseEntrieToDelete);
            collection.FindAsync(p => p.GlucoseLevel.ToString() == GlucoseEntrieToDelete);
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}