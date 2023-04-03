using Models;
using MongoDB.Driver;
using DataAccess.IDataAccess;
using MongoDB.Bson;


namespace DataAccess;

public class MongoRepository<T> : ApplicationDbContext, IMongoRepository<T> where T : class
{
    private static IMongoCollection<T> _collection = Db.GetCollection<T>("LogEntries");
    
    public MongoRepository(IMongoDatabase database)
    {
        _collection = database.GetCollection<T>("LogEntries");
    }
    
    //Create
    public async Task Create(T item)
    {
        await _collection.InsertOneAsync(item);
    }
    //Read
    public static void GetAll()
    {
        var entries = _collection.Find(_ => true);

        foreach (var entry in entries.ToList())
        {
            Console.WriteLine(entry.ToBson());

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
        
        await collection.DeleteOneAsync(p => p.GlucoseLevel.ToString() == GlucoseEntrieToDelete);
    }

    public static async Task DeleteAll()
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