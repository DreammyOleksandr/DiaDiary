using Models;

namespace DataAccess;

public interface IMongoCollectionReceiver
{
    LogEntry logEntry { get; set; }
}