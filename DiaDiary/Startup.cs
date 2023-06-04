using DataAccess;
using DataAccess.Models;
using DiaDiary;
using DiaDiary.Controllers;
using View;

MongoRepository<ApplicationUser> mongoRepositoryForAppUser =
    new MongoRepository<ApplicationUser>(DbStrings.DbName, DbStrings.ApplicationUsersCollection);
ApplicationUser applicationUser = new();

ApplicationUserController applicationUserController = new ApplicationUserController(mongoRepositoryForAppUser, applicationUser);

while (applicationUser.Email == null)
{
    ScrollableMenu scrollableMenu = new ScrollableMenu(applicationUserController.menuElements);
    int chosenAction = scrollableMenu.Run();
    dynamic execution = applicationUserController.ActionsRouting(chosenAction);
}

MongoRepository<UserLog> mongoRepository = new MongoRepository<UserLog>(DbStrings.DbName, DbStrings.UserLogsCollection);
UserLogController userLogController = new(mongoRepository, applicationUser);

while (true)
{
    ScrollableMenu scrollableMenu = new ScrollableMenu(userLogController.menuElements);
    int chosenAction = scrollableMenu.Run();
    dynamic execution = userLogController.ActionsRouting(chosenAction);
}