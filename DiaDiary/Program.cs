using DiaDiary.Controllers;
using MongoDB.Driver;
using View;
using View.Enums;

string dbName = "DiaDiary";
string userLogsCollection = "UserLogs";
MongoClient client = new MongoClient();





UserLogController logEntryController = new UserLogController(dbName, userLogsCollection);

MenuElements menuElements = new MenuElements()
{
    options = new string[]
    {
        "Create", "Read", "Update", "Delete", "About", "Exit",
    }
};


while (true)
{
    ScrollableMenu scrollableMenu = new ScrollableMenu(menuElements);
    int chosenAction = scrollableMenu.Run();

    switch ((MainMenuElement)chosenAction)
    {
        case MainMenuElement.Create:
            await logEntryController.Create();
            break;
        case MainMenuElement.Read:
            logEntryController.GetAll();
            break;
        case MainMenuElement.Update:
            await logEntryController.Update();
            break;
        case MainMenuElement.Delete:
            await logEntryController.Delete();
            break;
        case MainMenuElement.About:
            Console.Clear();
            ContextActions.About();
            break;
        case MainMenuElement.Exit:
            ContextActions.Exit();
            break;
    }
}