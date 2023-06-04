using static System.Console;
using DataAccess;
using DataAccess.Models;
using View;
using Views;

namespace DiaDiary.Controllers;

public class UserLogController
{
    public readonly MenuElements menuElements = new MenuElements()
    {
        options = new string[]
        {
            "Create", "Read", "Update", "Delete", "Delete All", "About", "Exit"
        }
    };

    private readonly MongoRepository<UserLog> _mongoRepository;
    private readonly ApplicationUser _applicationUser;

    public UserLogController(MongoRepository<UserLog> mongoRepository, ApplicationUser applicationUser)
    {
        _mongoRepository = mongoRepository;
        _applicationUser = applicationUser;
    }

    public dynamic ActionsRouting(int chosenAction) => chosenAction switch
    {
        0 => Create(_applicationUser),
        1 => GetAll(_applicationUser),
        2 => Update(_applicationUser),
        3 => Delete(_applicationUser),
        4 => DeleteAll(_applicationUser),
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
        string? idToUpdate = Console.ReadLine();
        var userLogToDelete = _mongoRepository.GetOne(x => x.Id == idToUpdate).Result;
        if (userLogToDelete.AssignedTo.Id == applicationUser.Id)
        {
            UserLog updatedUserLog = UserLogView.Update(idToUpdate);
            updatedUserLog.AssignedTo = applicationUser;
            
            await _mongoRepository.Update(x => x.Id == idToUpdate, updatedUserLog);
        }
        else
        {
            Messages.LogNotFound();
        }
    }

    private async Task Delete(ApplicationUser applicationUser)
    {
        string IdToDelete = UserLogView.Delete();
        var userLogToDelete = _mongoRepository.GetOne(x => x.Id == IdToDelete).Result;

        if (userLogToDelete.AssignedTo.Id == applicationUser.Id)
        {
            Clear();
            Messages.SuccessfulDeletion();
            await _mongoRepository.Delete(x => x.Id == IdToDelete);
        }
        else
        {
            Clear();
            Messages.LogNotFound();
        }
    }

    private async Task DeleteAll(ApplicationUser applicationUser)
    {
        await _mongoRepository.DeleteRange(_ => _.AssignedTo == applicationUser);
    }
}