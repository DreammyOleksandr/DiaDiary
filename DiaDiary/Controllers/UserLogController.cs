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
            "Create", "Read", "Update", "Delete", "Delete All", "Account", "About", "Exit"
        }
    };

    private readonly MongoRepository<UserLog> _mongoRepository;
    private readonly ApplicationUser _applicationUser;
    private readonly ApplicationUserController _applicationUserController;

    public UserLogController(MongoRepository<UserLog> mongoRepository,
        MongoRepository<ApplicationUser> applicationUserMongoRepository, ApplicationUser applicationUser)
    {
        _mongoRepository = mongoRepository;
        _applicationUser = applicationUser;
        _applicationUserController = new ApplicationUserController(applicationUserMongoRepository, _applicationUser);
    }

    public dynamic UserActions()
    {
        MenuElements menuElements =
            new MenuElements()
            {
                options = new string[]
                {
                    "Create", "Read", "Update", "Delete", "Delete All", "Account", "About", "Exit"
                }
            };

        dynamic ActionsRouting(int chosenAction) => chosenAction switch
        {
            0 => Create(_applicationUser),
            1 => GetAll(_applicationUser),
            2 => Update(_applicationUser),
            3 => Delete(_applicationUser),
            4 => DeleteAll(_applicationUser),
            5 => _applicationUserController.AccountActions(_applicationUser),
            6 => ContextActions.About(),
            7 => ContextActions.Exit(),
        };

        while (_applicationUser.Email != null)
        {
            ScrollableMenu scrollableMenu = new ScrollableMenu(menuElements);
            int chosenAction = scrollableMenu.Run();
            dynamic execution = ActionsRouting(chosenAction);
        }

        return _applicationUser;
    }

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
        Messages.IdOfLogToReplace();
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
        Clear();
        Messages.WarningToDeleteAll();
        ConsoleKey keyPressed = ReadKey().Key;
        if (keyPressed == ConsoleKey.Enter)
        {
            Messages.SuccessfulDeletion();
            await _mongoRepository.DeleteRange(_ => _.AssignedTo == applicationUser);
        }

        if (keyPressed == ConsoleKey.Backspace)
        {
            return;
        }
    }
}