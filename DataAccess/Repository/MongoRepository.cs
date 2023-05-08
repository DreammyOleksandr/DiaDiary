using System.Linq.Expressions;
using MongoDB.Driver;
using DataAccess.IDataAccess;


namespace DataAccess;

public class MongoRepository<T> : IMongoRepository<T> where T : class
{
    private static MongoClient _mongoClient = new MongoClient();
    private static IMongoDatabase _db;
    private static IMongoCollection<T> _collection;

    public MongoRepository(string databaseName, string collectionName)
    {
        _db = _mongoClient.GetDatabase(databaseName);
        _collection = _db.GetCollection<T>(collectionName);
    }

    public async Task Create(T entity)
    {
        await _collection.InsertOneAsync(entity);
    }

    public IEnumerable<T> GetAll()
    {
        return _collection.Find(_ => true).ToList();
    }

    public async Task FirstOrDefault(Expression<Func<T, bool>> filter, T entity)
    {
        await _collection.ReplaceOneAsync(filter, entity);
    }

    public async Task Delete(Expression<Func<T, bool>> filter)
    {
        await _collection.DeleteOneAsync(filter);
    }

    public async Task DeleteAll()
    {
        
        ConsoleKeyInfo keyInfo = Console.ReadKey(true);
        ConsoleKey keyPressed = keyInfo.Key;

        if (keyPressed == ConsoleKey.Enter)
        {
            await _collection.DeleteManyAsync(_ => true);
        }

        if (keyPressed == ConsoleKey.Backspace)
        {
            return;
        }
    }
}