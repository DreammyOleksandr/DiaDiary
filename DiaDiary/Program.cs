using DataAccess;
using Models;
using MongoDB.Driver;

namespace DiaDiary;

class Program
{
    
    const string DbName = "diabeticslogs";
    
    static readonly MongoClient Client = new MongoClient();
    static IMongoDatabase _db = Client.GetDatabase(DbName);

    static void Main()
    {
        
        MongoRepository<LogEntry> pon = new MongoRepository<LogEntry>(_db); 
        
        UserActions action = new UserActions();
        action.ChooseAction(pon);
    }
}