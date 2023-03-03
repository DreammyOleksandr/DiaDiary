using DataAccess;
using Models;

namespace DiaDiary;

class Program
{
    static void Main(string[] args)
    {
        LogEntry userEntry = new LogEntry()
        {
            CarbohydratesInBreadUnits = 2,
            GlucoseLevel = 0,
            ShortTermInsulin = 1,
            LongTermInsulin = 3,
        };
        
        MongoDbManager.Create(userEntry);
    }
}