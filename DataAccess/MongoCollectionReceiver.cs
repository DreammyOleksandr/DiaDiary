using Models;

namespace DataAccess;

public class MongoCollectionReceiver : IMongoCollectionReceiver
{
    public LogEntry logEntry { get; set; }
}