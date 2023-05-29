using DataAccess;
using DataAccess.Models;
using DiaDiary;
using DiaDiary.Controllers;
using View;


MongoRepository<ApplicationUser> mongoRepositoryForAppUser =
    new MongoRepository<ApplicationUser>(DbStrings.DbName, DbStrings.ApplicationUsersCollection);

ApplicationUser applicationUser = new();
ApplicationUserController applicationUserController = new ApplicationUserController(mongoRepositoryForAppUser);

MenuElements menuElements = new MenuElements()
{
    options = new string[]
    {
        "LogIn", "SignIn", "Exit"
    }
};


while (applicationUser.Email == null)
{
    ScrollableMenu scrollableMenu = new ScrollableMenu(menuElements);
    int chosenAction = scrollableMenu.Run();

    dynamic GetPosition(int chosenAction) => chosenAction switch
    {
        0 => applicationUserController.Login(applicationUser),
        1 => applicationUserController.SignIn(applicationUser),
        2 => ContextActions.Exit(),
    };

    dynamic execution = GetPosition(chosenAction);
}

MongoRepository<UserLog> mongoRepository = new MongoRepository<UserLog>(DbStrings.DbName, DbStrings.UserLogsCollection);

UserLogController userLogController = new(mongoRepository, applicationUser);

while (true)
{
    menuElements = new MenuElements()
    {
        options = new string[]
        {
            "Create", "Read", "Update", "Delete", "Delete All", "About", "Exit"
        }
    };
    ScrollableMenu scrollableMenu = new ScrollableMenu(menuElements);
    int chosenAction = scrollableMenu.Run();


    dynamic execution = userLogController.UserAction(chosenAction);
}