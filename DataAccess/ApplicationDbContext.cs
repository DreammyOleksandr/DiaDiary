using MongoDB.Driver;

namespace DataAccess;

public class ApplicationDbContext
{
    private const string DbName = "diabeticslogs";
    protected const string collectionName = "LogEntries";
    
    private static readonly MongoClient _client = new MongoClient();
    protected static IMongoDatabase _db = _client.GetDatabase(DbName);
}