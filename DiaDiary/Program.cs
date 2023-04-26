using DataAccess;
using Models;
using MongoDB.Driver;

namespace DiaDiary;

class Program
{
    static void Main()
    {
        string dbName = "diabeticslogs";
        MongoClient client = new MongoClient();
        IMongoDatabase db = client.GetDatabase(dbName);
        
        MongoRepository<LogEntry> mongoRepository = new MongoRepository<LogEntry>(db);
        UserInput userInput = new UserInput();
        userInput.Run(mongoRepository);
    }
}