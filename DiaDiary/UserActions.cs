using DataAccess;
using Models;
using View;
using View.ActionMenus;

namespace DiaDiary;

public class UserActions
{
    public static void ChooseAction()
    { 
        MainMenu.Run();
        int userChoice = MainMenu.Run();
        Console.Clear();

        switch ((OptionsEnum)userChoice)
        {
            case OptionsEnum.Create:
                 MongoCrud.Create();
                break;
            case OptionsEnum.Read:
                MongoCrud.GetAll();
                break;
            case OptionsEnum.Update:
                MongoCrud.Update();
                break;
            case OptionsEnum.Delete:
                DeleteMenu.RunMenu();
                int userDeleteChoice = DeleteMenu.RunMenu();
                break;
            case OptionsEnum.Additional:
                AdditionalActions.GlycatedHemoglobin();
                break;
            case OptionsEnum.About:
                ContextActions.About();
                break;
            case OptionsEnum.Exit:
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