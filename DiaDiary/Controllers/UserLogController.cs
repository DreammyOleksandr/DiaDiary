using static System.Console;
using DataAccess;
using DataAccess.Models;
using View.Views;

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
    

    public void GetAll()
    {
        List<UserLog> UserLogs = MongoRepository.GetAll().ToList();
        UserLogView.ShowAll(UserLogs);
    }

    public void Update()
    {
    }

    public async Task DeleteAll()
    {
        await MongoRepository.DeleteAll();
    }
}