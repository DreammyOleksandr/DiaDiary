using System.Linq.Expressions;
using MongoDB.Driver;
using DataAccess.IDataAccess;
using DiaDiary;


namespace DataAccess;

public class MongoRepository<T> : IMongoRepository<T> where T : class
{
    private readonly string _collectionName = "LogEntries";
    private static IMongoCollection<T> _collection;

    public MongoRepository(IMongoDatabase database)
    {
        _collection = database.GetCollection<T>(_collectionName);
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
        DefaultMessages.Warning();
        
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