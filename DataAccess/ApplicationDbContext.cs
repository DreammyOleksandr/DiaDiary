using Models;
using MongoDB.Driver;

namespace DataAccess;

public class ApplicationDbContext
{
    private const string ConnectionString = "mongodb://127.0.0.1:27017";
    private const string DbName = "diabeticslogs";
    private static readonly MongoClient _client = new MongoClient(ConnectionString);

    public static async Task Insert(LogEntry logEntry)
    {
        var _db = _client.GetDatabase(DbName);
        var collection = _db.GetCollection<LogEntry>("LogEntries");
        await collection.InsertOneAsync(logEntry);
    }
    public static void Update()
    {
        var _db = _client.GetDatabase(DbName);
        var collection = _db.GetCollection<LogEntry>("LogEntries");
    }
}