using MongoDB.Driver;

namespace DataAccess;

public class ApplicationDbContext
{
    private const string ConnectionString = "mongodb://127.0.0.1:27017";
    protected const string DbName = "diabeticslogs";
    protected static readonly string collectionName = "LogEntries";
    
    protected static readonly MongoClient _client = new MongoClient(ConnectionString);
}