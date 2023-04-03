using System.Security.Cryptography;
using DataAccess;
using Models;
using MongoDB.Driver;
using View;

namespace DiaDiary;

class Program
{
    
    private const string DbName = "diabeticslogs";
    private const string CollectionName = "LogEntries";
    
    private static readonly MongoClient Client = new MongoClient();
    protected static IMongoDatabase Db = Client.GetDatabase(DbName);

    static void Main()
    {
                
        MongoRepository<LogEntry> pon = new MongoRepository<LogEntry>(Db); 
        
        UserActions action = new UserActions();
        action.ChooseAction(pon);
    }
}