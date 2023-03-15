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
                MongoCRUD.Create(new LogEntry()
                {
                    GlucoseLevel = Convert.ToDouble(Console.ReadLine()),
                    ShortTermInsulin = Convert.ToByte(Console.ReadLine()),
                    LongTermInsulin = Convert.ToByte(Console.ReadLine()),
                    CarbsInBreadUnits = Convert.ToDouble(Console.ReadLine()),
                    Notes = Console.ReadLine(),
                });
                break;
            case 's':
                DefaultMessages.ViewLogs();
                MongoCRUD.GetAll();
                break;
            case 'u':
                break;
            case 'd':
                DefaultMessages.Deleteion();
                MongoCRUD.Delete();
                break;
        }
    }
}