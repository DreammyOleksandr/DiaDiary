using DataAccess;
using Models;

namespace DiaDiary;

public class UserActions
{
    public static void ChooseAction()
    {
        char userChoice = Convert.ToChar(Console.ReadLine().ToLower());

        switch (userChoice)
        {
            case 'c':
                DefaultMessages.Creation();
                MongoDbManager.Create(new LogEntry()
                {
                    GlucoseLevel = Convert.ToDouble(Console.ReadLine()),
                    ShortTermInsulin = Convert.ToInt32(Console.ReadLine()),
                    LongTermInsulin = Convert.ToInt32(Console.ReadLine()),
                    CarbsInBreadUnits = Convert.ToDouble(Console.ReadLine()),
                    Notes = Console.ReadLine(),
                });
                break;
            case 's':
                DefaultMessages.ViewLogs();
                MongoDbManager.GetAll();
                break;
            case 'u':
                break;
            case 'd':
                DefaultMessages.Deleteion();
                MongoDbManager.Delete();
                break;
        }
    }
}