using static System.Console;
using DataAccess;
using DataAccess.Models;
using Views;

namespace DiaDiary.Controllers;

public class UserLogController
{
    private readonly MongoRepository<UserLog> MongoRepository;

    public UserLogController(string database, string userLogCollection)
    {
        MongoRepository =
            new MongoRepository<UserLog>(databaseName: database, collectionName: userLogCollection);
    }


    public async Task Create()
    {
        UserLog userLog = new UserLog();
        UserLogView.Create(userLog);
        await MongoRepository.Create(userLog);
    }

    public void GetAll()
    {
        List<UserLog> UserLogs = MongoRepository.GetAll().ToList();
        UserLogView.ShowAll(UserLogs);
    }

    public async Task Update()
    {
        Clear();
        WriteLine("Enter Id of log you want to replace");
        string? userLogId = Console.ReadLine();
        UserLog updatedUserLog = UserLogView.Update(userLogId);
        await MongoRepository.Update(x => x.Id == userLogId, updatedUserLog);
    }

    public async Task Delete()
    {
        string IdToDelete = UserLogView.Delete();
        await MongoRepository.Delete(x => x.Id == IdToDelete);
    }

    public async Task DeleteAll()
    {
        await MongoRepository.DeleteAll();
    }
}