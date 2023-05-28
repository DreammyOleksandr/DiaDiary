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


    public async Task Create(ApplicationUser applicationUser)
    {
        UserLog userLog = new UserLog();
        UserLogView.Create(userLog);
        userLog.AssignedTo = applicationUser;
        await MongoRepository.Create(userLog);
    }

    public async Task GetAll()
    {
        List<UserLog> UserLogs = await MongoRepository.GetAll();
        UserLogView.ShowAll(UserLogs);
    }

    public async Task Update(ApplicationUser applicationUser)
    {
        Clear();
        WriteLine("Enter Id of log you want to replace");
        string? userLogId = Console.ReadLine();
        UserLog updatedUserLog = UserLogView.Update(userLogId);
        updatedUserLog.AssignedTo = applicationUser;

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