using static System.Console;
using DataAccess;
using Models;
using MongoDB.Driver;

namespace DiaDiary.Controllers;

public class LogEntryController
{
    private readonly MongoRepository<LogEntry> MongoRepository;

    public LogEntryController(IMongoDatabase database)
    {
        MongoRepository = new MongoRepository<LogEntry>(database);
    }


    public void Create()
    {
        LogEntry logEntry = new LogEntry();

        Write($"Glucose level: ");
        logEntry.GlucoseLevel = double.Parse(ReadLine());
        Write($"S-term insulin: ");
        logEntry.ShortTermInsulin = byte.Parse(ReadLine());
        Write($"L-term insulin: ");
        logEntry.LongTermInsulin = byte.Parse(ReadLine());
        Write($"Carbs eaten: ");
        logEntry.CarbsInBreadUnits = double.Parse(ReadLine());
        Write($"Notes: ");
        logEntry.Notes = ReadLine();


        MongoRepository.Create(logEntry);
    }

    public void GetOne()
    {
        
    }

    public void GetAll()
    {
    }

    public void Update()
    {
    }

    public void Delete()
    {
    }
}