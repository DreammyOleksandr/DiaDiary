
using Models;
using MongoDB.Driver;

namespace DataAccess;

public class ApplicationDbContext
{
    private const string DbName = "diabeticslogs";
    private const string CollectionName = "LogEntries";
    
    private static readonly MongoClient Client = new MongoClient();
    private static IMongoDatabase Db = Client.GetDatabase(DbName);
    protected static readonly IMongoCollection<LogEntry> collection = Db.GetCollection<LogEntry>(CollectionName);

}