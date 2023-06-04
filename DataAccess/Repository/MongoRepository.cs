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

    public async Task Create(T entity) =>
        await _collection.InsertOneAsync(entity);

    public async Task<List<T>> GetRange(Expression<Func<T, bool>> filter) =>
        await _collection.Find(filter).ToListAsync();  

    public async Task<T> GetOne(Expression<Func<T, bool>> filter) =>
        await _collection.Find(filter).FirstOrDefaultAsync();

    public async Task Update(Expression<Func<T, bool>> filter, T entity) =>
        await _collection.ReplaceOneAsync(filter, entity);

    public async Task Delete(Expression<Func<T, bool>> filter) =>
        await _collection.DeleteOneAsync(filter);

    public async Task DeleteRange(Expression<Func<T, bool>> filter) =>
        await _collection.DeleteManyAsync(filter);
}