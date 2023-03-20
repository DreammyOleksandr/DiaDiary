using Models;
using MongoDB.Driver;

namespace DataAccess;

public class MongoCRUD : ApplicationDbContext
{
    //Create
    public static async Task Create()
    {
        LogEntry logEntry = new LogEntry();
        
        Console.Write("Glucose level:");
        logEntry.GlucoseLevel = double.Parse(Console.ReadLine());
        Console.Write("Short term insulin injected:");
        logEntry.ShortTermInsulin = byte.Parse(Console.ReadLine());
        Console.Write("Long term insulin injected:");
        logEntry.LongTermInsulin = byte.Parse(Console.ReadLine());
        Console.Write("Carbs eaten:");
        logEntry.CarbsInBreadUnits = double.Parse(Console.ReadLine());
        Console.WriteLine("Notes:");
        logEntry.Notes = Console.ReadLine();

        await collection.InsertOneAsync(logEntry);
    }
    //Read
    public static void GetAll()
    {
        var entries = collection.Find(_ => true);

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