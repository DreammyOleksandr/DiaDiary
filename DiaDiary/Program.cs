using DiaDiary.Controllers;
using View;
using View.Enums;

string dbName = "DiaDiary";
string userLogsCollection = "ApplicationUsers";


ApplicationUserController applicationUserController = new ApplicationUserController(dbName, userLogsCollection);

MenuElements menuElements = new MenuElements()
{
    options = new string[]
    {
        "Login", "Registration", "Exit"
    }
};

while (true)
{
    ScrollableMenu scrollableMenu = new ScrollableMenu(menuElements);
    int chosenAction = scrollableMenu.Run();

    switch ((AuthorizationEnum)chosenAction)
    {
        case AuthorizationEnum.Login:
            await applicationUserController.Login();
            break;
        case AuthorizationEnum.Registration:
            await applicationUserController.Register();
            break;
        case AuthorizationEnum.Exit:
            ContextActions.Exit();
            break;
    }
}


//
//
// while (true)
// {
//     ScrollableMenu scrollableMenu = new ScrollableMenu(menuElements);
//     int chosenAction = scrollableMenu.Run();
//
//     switch ((MainMenuElement)chosenAction)
//     {
//         case MainMenuElement.Create:
//             await logEntryController.Create();
//             break;
//         case MainMenuElement.Read:
//             logEntryController.GetAll();
//             break;
//         case MainMenuElement.Update:
//             await logEntryController.Update();
//             break;
//         case MainMenuElement.Delete:
//             await logEntryController.Delete();
//             break;
//         case MainMenuElement.About:
//             Console.Clear();
//             ContextActions.About();
//             break;
//         case MainMenuElement.Exit:
//             ContextActions.Exit();
//             break;
//     }
// }