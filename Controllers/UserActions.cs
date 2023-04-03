using DataAccess;
using DataAccess.IDataAccess;
using Models;
using MongoDB.Driver;
using View;
using View.ActionMenus;

namespace DiaDiary;

public class UserActions
{

    public void ChooseAction(IMongoRepository<LogEntry> mongoRepository)
    {


        LogEntry logEntry = new LogEntry()
        {
            GlucoseLevel = 191,
            ShortTermInsulin = 121,
            LongTermInsulin = 132,
            CarbsInBreadUnits = 12,
            Notes = "dasfax"
        };

        
        
        int userChoice = MainMenu.Run();
        Console.Clear();

        switch ((MainMenuEnum)userChoice)
        {
            case MainMenuEnum.Create:
                mongoRepository.Create(logEntry);
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