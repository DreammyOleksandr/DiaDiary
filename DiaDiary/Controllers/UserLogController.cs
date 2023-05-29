using static System.Console;
using DataAccess;
using DataAccess.Models;
using View;
using Views;

namespace DiaDiary.Controllers;

public class UserLogController
{
    private readonly MongoRepository<UserLog> _mongoRepository;
    private readonly ApplicationUser _applicationUser;

    public UserLogController(MongoRepository<UserLog> mongoRepository, ApplicationUser applicationUser)
    {
        _mongoRepository = mongoRepository;
        _applicationUser = applicationUser;
    }


    public dynamic UserAction(int chosenAction) => chosenAction switch
    {
        0 => Create(_applicationUser),
        1 => GetAll(_applicationUser),
        2 => Update(_applicationUser),
        3 => Delete(),
        4 => DeleteAll(),
        5 => ContextActions.About(),
        6 => ContextActions.Exit(),
    };

    private async Task Create(ApplicationUser applicationUser)
    {
        UserLog userLog = new UserLog();
        UserLogView.Create(userLog);
        userLog.AssignedTo = applicationUser;
        await _mongoRepository.Create(userLog);
    }

    private async Task GetAll(ApplicationUser applicationUser)
    {
        List<UserLog> userLogs = await _mongoRepository.GetRange(_ => _.AssignedTo == applicationUser);
        UserLogView.ShowAll(userLogs);
    }

    private async Task Update(ApplicationUser applicationUser)
    {
        Clear();
        WriteLine("Enter Id of log you want to replace");
        string? userLogId = Console.ReadLine();
        UserLog updatedUserLog = UserLogView.Update(userLogId);
        updatedUserLog.AssignedTo = applicationUser;

        await _mongoRepository.Update(x => x.Id == userLogId, updatedUserLog);
    }

    private async Task Delete()
    {
        string IdToDelete = UserLogView.Delete();
        await _mongoRepository.Delete(x => x.Id == IdToDelete);
    }

    private async Task DeleteAll()
    {
        await _mongoRepository.DeleteAll();
    }
}