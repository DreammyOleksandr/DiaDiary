using Models;
using MongoDB.Driver;
using DataAccess.IDataAccess;
using MongoDB.Bson;


namespace DataAccess;

public class MongoCrud : ApplicationDbContext, IMongoCrud
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
        logEntry.Notes = Console.ReadLine() ?? "*There was no notes written*";

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
                              $"Carbs (Bread units): {entry.CarbsInBreadUnits}\n" +
                              $"{entry.Notes}\n\n");
            
        }
    }
    //Update
    public static async Task Update()
    {
        Console.WriteLine("Enter Glucose level to Update");
        double glucoseToFind = double.Parse(Console.ReadLine());
        var filter = new BsonDocument("GlucoseLevel", glucoseToFind);
        
        Console.WriteLine("Enter Glucose level to Update");
        double updatedValue = double.Parse(Console.ReadLine());
        var updated = new BsonDocument("$set", new BsonDocument("GlucoseLevel", updatedValue));

        var result = await collection.UpdateOneAsync(filter, updated);
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
        catch (MongoException ex)
        {
            throw ex;
        }
    }

    public static async Task DropLogs()
    {
        
        Console.WriteLine("This option will delete all your entries\n" +
                          "Hit enter to continue/backspace to discard changes");
        
        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
        ConsoleKey keyPressed = keyInfo.Key;

        if (keyPressed == ConsoleKey.Enter)
        {
            await collection.DeleteManyAsync(_ => true);
        }

        if (keyPressed == ConsoleKey.Backspace)
        {
            
        }
    }
}