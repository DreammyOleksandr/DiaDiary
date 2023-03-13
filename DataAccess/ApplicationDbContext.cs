using Models;
using MongoDB.Driver;

namespace DataAccess;

public class ApplicationDbContext
{
    private const string DbName = "diabeticslogs";
    protected const string collectionName = "LogEntries";
    
    private static readonly MongoClient _client = new MongoClient();
    protected static IMongoDatabase _db = _client.GetDatabase(DbName);
    protected static readonly IMongoCollection<LogEntry> collection = _db.GetCollection<LogEntry>(collectionName);

}