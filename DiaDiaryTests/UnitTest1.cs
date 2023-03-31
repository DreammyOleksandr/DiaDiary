using DataAccess;
using Models;

namespace DiaDiaryTests;

public class Tests
{

    [Test]
    public void CreateMethodCheck()
    {
        LogEntry createdlogEntry = new LogEntry()
        {
            GlucoseLevel = 100,
            ShortTermInsulin = 100,
            LongTermInsulin = 100,
            CarbsInBreadUnits = 100,
            Notes = "Unit test note",
        };

        LogEntry expectedLogEntry = MongoCrud.ReadLast();
    }
}