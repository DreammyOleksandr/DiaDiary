using Controllers.Validators;
using DataAccess;
using DataAccess.IDataAccess;
using Models;
using View;

namespace DiaDiary;

public class UserActions
{

    public void ChooseAction(IMongoRepository<LogEntry> mongoRepository)
    {
        MenuElements menuElements = new MenuElements();
        menuElements.options = new[] { "Create", "Read", "Update", "Delete", "Additional", "About", "Exit" };
        ScrollableMenu scrollableMenu = new ScrollableMenu(menuElements);
        int userChoice = ScrollableMenu.Run();
        Console.Clear();

        switch ((MainMenuEnum)userChoice)
        {
            case MainMenuEnum.Create:
                mongoRepository.Create();
                break;
            case MainMenuEnum.Read:
                mongoRepository.GetAll();
                break;
            case MainMenuEnum.Update:
                mongoRepository.Update();
                break;
            case MainMenuEnum.Delete:
                DeleteActionsValidator.Validate();
                break;
            case MainMenuEnum.Additional:
                AdditionalActionsValidator.Validate();
                break;
            case MainMenuEnum.About:
                ContextActions.About();
                break;
            case MainMenuEnum.Exit:
                ContextActions.Exit();
                break;
        }
        while (true)
        {
            Console.WriteLine("Press enter to go back to main menu");
            ConsoleKey keyPressed = Console.ReadKey().Key;
            if (keyPressed == ConsoleKey.Enter)
            {
                ChooseAction(mongoRepository);
            }
        }
        
    }
}