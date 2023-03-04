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
            ShortTermInsulin = 5,
            LongTermInsulin = 6,
            CarbsInBreadUnits = 5,
        });
        Console.ReadKey();
    }
}