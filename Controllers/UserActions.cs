using DataAccess;
using DataAccess.IDataAccess;
using Models;
using View;
using View.ActionMenus;

namespace DiaDiary;

public class UserActions
{

    public void ChooseAction(IMongoRepository<LogEntry> mongoRepository)
    {

        int userChoice = MainMenu.Run();
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
                int userAdditionalChoice = AdditionalOptionsMenu.RunMenu();
                switch ((AdditionalMenuEnum)userAdditionalChoice)
                {
                    case AdditionalMenuEnum.GlycatedHemoglobin: 
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
            float pf = 2;
            Console.WriteLine("Press enter to go back to main menu");
            ConsoleKey keyPressed = Console.ReadKey().Key;
            if (keyPressed == ConsoleKey.Enter)
            {
                ChooseAction(mongoRepository);
            }
        }
    }
}