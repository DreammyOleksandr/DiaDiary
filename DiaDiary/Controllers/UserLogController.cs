using static System.Console;
using DataAccess;
using DataAccess.Models;
using MongoDB.Driver;

namespace DiaDiary.Controllers;

public class UserLogController
{
    private readonly MongoRepository<UserLog> MongoRepository;

    public UserLogController(string databaseName, string userLogCollectionName)
    {
        MongoRepository = new MongoRepository<UserLog>(databaseName: databaseName, collectionName: userLogCollectionName);
    }


    public async Task Create()
    {
        UserLog userLog = new UserLog();

        Write($"Glucose level: ");
        userLog.GlucoseLevel = double.Parse(ReadLine());
        Write($"S-term insulin: ");
        userLog.ShortTermInsulin = byte.Parse(ReadLine());
        Write($"L-term insulin: ");
        userLog.LongTermInsulin = byte.Parse(ReadLine());
        Write($"Carbs eaten: ");
        userLog.CarbsInBreadUnits = double.Parse(ReadLine());
        Write($"Notes: ");
        userLog.Notes = ReadLine();


        await MongoRepository.Create(userLog);
    }

    public void GetOne()
    {
    }

    public void GetAll()
    {
        List<UserLog> UserLogs = MongoRepository.GetAll().ToList();
        foreach (var userLog in UserLogs)
        {
            WriteLine($"Glucose level: {userLog.GlucoseLevel}\n" +
                      $"Short term insulin injected: {userLog.ShortTermInsulin}\n" +
                      $"Long term insulin injected: {userLog.LongTermInsulin}\n" +
                      $"Carbs eaten: {userLog.CarbsInBreadUnits}\n" +
                      $"Notes: {userLog.Notes}\n");
        }
    }

    public void Update()
    {
    }

    public void Delete()
    {
    }
}