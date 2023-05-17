using DiaDiary.Controllers;
using MongoDB.Driver;
using View;

string dbName = "DiaDiary";
string userLogsCollection = "UserLogs";
MongoClient client = new MongoClient();
IMongoDatabase db = client.GetDatabase(dbName);

UserLogController logEntryController = new UserLogController(dbName, userLogsCollection);

MenuElements menuElements = new MenuElements()
{
    options = new string[]
    {
        "Create", "Read", "Update", "Delete", "Delete All"
    }
};


while (true)
{
    ScrollableMenu scrollableMenu = new ScrollableMenu(menuElements);
    int chosenAction = scrollableMenu.Run();
    if (chosenAction == 0)
    {
        await logEntryController.Create();
    }

    if (chosenAction == 1)
    {
        logEntryController.GetAll();
        Console.ReadKey();
    }

    if (chosenAction == 2)
    {
        await logEntryController.Update();
    }

    if (chosenAction == 3)
    {
        await logEntryController.Delete();
    }

    if (chosenAction == 4)
    {
        await logEntryController.DeleteAll();
    }
}