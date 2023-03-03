using DataAccess;
using Models;

namespace DiaDiary;

class Program
{
    static void Main(string[] args)
    {
        MongoDbManager.Create(new LogEntry()
        {
            GlucoseLevel = 8,
            ShortTermInsulin = 6,
            LongTermInsulin = 6,
            CarbohydratesInBreadUnits = 6,
        });
        
        
        
        MongoDbManager.GetAll();
    }
}