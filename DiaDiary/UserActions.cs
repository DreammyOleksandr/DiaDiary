using DataAccess;
using Models;
using View;

namespace DiaDiary;

public class UserActions
{
    public static void ChooseAction()
    { 
        Menu.Run();
        int userChoice = Menu.Run();
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
                MongoCrud.Delete();
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
            Console.WriteLine("Do you want to continue?y/n");
            char userRepeat = Char.Parse(Console.ReadLine().ToLower());
            if (userRepeat == 'y')
            {
                Console.Clear();
                UserActions.ChooseAction();
            }
            
            if (userRepeat == 'n')
            {
                break;
            }
        }
    }
}