using DataAccess;
using Models;

namespace DiaDiary;

class Program
{
    static void Main(string[] args)
    {
        MongoDbManager.Create(new LogEntry()
        {
            GlucoseLevel = 3,
            ShortTermInsulin = 0,
            LongTermInsulin = 0,
            CarbsInBreadUnits = 2,
        });
        Console.ReadKey();
        MongoDbManager.GetAll();
    }
}