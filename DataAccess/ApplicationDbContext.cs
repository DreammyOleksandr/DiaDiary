using MongoDB.Driver;

namespace DataAccess;

public class ApplicationDbContext
{
    private const string ConnectionString = "mongodb://127.0.0.1:27017";
    private const string DbName = "diabeticslogs";
    protected const string collectionName = "LogEntries";
    
    private static readonly MongoClient _client = new MongoClient(ConnectionString);
    protected static IMongoDatabase _db = _client.GetDatabase(DbName);
}