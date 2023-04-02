using DataAccess;
using Models;
using View;
using View.ActionMenus;

namespace DiaDiary;

public class UserActions
{
    public static void ChooseAction()
    { 
        int userChoice = MainMenu.Run();
        Console.Clear();

        switch ((MainMenuEnum)userChoice)
        {
            case MainMenuEnum.Create:
                MongoRepository<LogEntry>.Create();
                break;
            case MainMenuEnum.Read:
                MongoRepository<LogEntry>.GetAll();
                break;
            case MainMenuEnum.Update:
                MongoRepository<LogEntry>.Update();
                break;
            case MainMenuEnum.Delete:
                int userDeleteChoice = DeleteMenu.RunMenu();
                switch ((DeleteMenuEnum)userDeleteChoice)
                {
                    case DeleteMenuEnum.DeleteOne:
                        MongoRepository<LogEntry>.Delete();
                        break;
                    case DeleteMenuEnum.DeleteAll:
                        MongoRepository<LogEntry>.DeleteAll();
                        break;
                }
                break;
            case MainMenuEnum.Additional:
                AdditionalActions.GlycatedHemoglobin();
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
                UserActions.ChooseAction();
            }
        }
    }
}