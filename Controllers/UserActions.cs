using DataAccess;
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
                MongoCrud.Create();
                break;
            case MainMenuEnum.Read:
                MongoCrud.GetAll();
                break;
            case MainMenuEnum.Update:
                MongoCrud.Update();
                break;
            case MainMenuEnum.Delete:
                int userDeleteChoice = DeleteMenu.RunMenu();
                switch ((DeleteMenuEnum)userDeleteChoice)
                {
                    case DeleteMenuEnum.DeleteOne:
                        MongoCrud.Delete();
                        break;
                    case DeleteMenuEnum.DeleteAll:
                        MongoCrud.DropLogs();
                        break;
                }
                break;
            case MainMenuEnum.Additional:
                int userAdditionalChoice = AdditionalOptionsMenu.RunMenu();
                switch ((AdditionalEnum)userAdditionalChoice)
                {
                    case AdditionalEnum.GlycatedHemoglobin: 
                        AdditionalActions.GlycatedHemoglobin();
                        break;
                }
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