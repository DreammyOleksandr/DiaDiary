using Models;
using MongoDB.Driver;
using DataAccess.IDataAccess;
using MongoDB.Bson;


namespace DataAccess;

public class MongoRepository<T> : IMongoRepository<T> where T : class
{
    private static IMongoCollection<T> _collection;
    
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
        var filter = _collection.CountDocuments("Glucose level");
       

        Console.WriteLine(filter.CompareTo(1));
    }
    //Update
    public async Task Update()
    {
        Console.WriteLine("Enter Glucose level of log you want to Update");
        double glucoseToFind = double.Parse(Console.ReadLine());
        var filter = new BsonDocument("GlucoseLevel", glucoseToFind);
        
        Console.WriteLine("Enter new Glucose level");
        double updatedValue = double.Parse(Console.ReadLine());
        var updated = new BsonDocument("$set", new BsonDocument("GlucoseLevel", updatedValue));

        var result = await _collection.UpdateOneAsync(filter, updated);
    }
    //Delete
    public static async Task Delete()
    {
        Console.WriteLine("Choose note which you want to delete by glucose level");
        string GlucoseEntrieToDelete = Console.ReadLine();
        
        var filter = Builders<T>.Filter.Eq("GlucoseLevel", GlucoseEntrieToDelete);
        await _collection.DeleteOneAsync(filter);
    }

    public static async Task DeleteAll()
    {
        
        Console.WriteLine("This option will delete all your entries\n" +
                          "Hit enter to continue/backspace to discard changes");
        
        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
        ConsoleKey keyPressed = keyInfo.Key;

        if (keyPressed == ConsoleKey.Enter)
        {
            await _collection.DeleteManyAsync(_ => true);
        }

        if (keyPressed == ConsoleKey.Backspace)
        {
            
        }
    }
}