using DataAccess;
using Models;
using MongoDB.Driver;
using View;
using View.ActionMenus;

namespace DiaDiary;

public class UserActions
{
    private const string DbName = "diabeticslogs";
    private const string CollectionName = "LogEntries";
    
    private static readonly MongoClient Client = new MongoClient();
    protected static IMongoDatabase Db = Client.GetDatabase(DbName);
    protected static readonly IMongoCollection<LogEntry> collection = Db.GetCollection<LogEntry>(CollectionName);
    
    public static void ChooseAction()
    {


        LogEntry logEntry = new LogEntry();
        MongoRepository<LogEntry> Pon = new MongoRepository<LogEntry>(Db); 
        
        
        int userChoice = MainMenu.Run();
        Console.Clear();

        switch ((MainMenuEnum)userChoice)
        {
            case MainMenuEnum.Create:
                MongoRepository<LogEntry>.Create(logEntry);
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
            float pf = 2;
            Console.WriteLine("Press enter to go back to main menu");
            ConsoleKey keyPressed = Console.ReadKey().Key;
            if (keyPressed == ConsoleKey.Enter)
            {
                UserActions.ChooseAction();
            }
        }
    }
}