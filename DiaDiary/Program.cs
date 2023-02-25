using DataAccess;
using Models;

namespace DiaDiary;

class Program
{
    static void Main(string[] args)
    {
        LogEntry userEntry = new LogEntry()
        {
            CarbohydratesInBreadUnits = 5,
            GlucoseLevel = 7,
            ShortTermInsulin = 5,
            LongTermInsulin = 0
        };
        
        ApplicationDbContext.Insert(userEntry);
    }
}