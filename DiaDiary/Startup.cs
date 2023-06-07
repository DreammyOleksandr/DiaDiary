using DataAccess;
using DataAccess.Models;
using DiaDiary;
using DiaDiary.Controllers;

MongoRepository<ApplicationUser> mongoRepositoryForAppUser =
    new MongoRepository<ApplicationUser>(DbStrings.DbName, DbStrings.ApplicationUsersCollection);
ApplicationUser applicationUser = new();

ApplicationUserController applicationUserController =
    new ApplicationUserController(mongoRepositoryForAppUser, applicationUser);

MongoRepository<UserLog> mongoRepositoryForUserLogs =
    new MongoRepository<UserLog>(DbStrings.DbName, DbStrings.UserLogsCollection);

UserLogController userLogController =
    new(mongoRepositoryForUserLogs, mongoRepositoryForAppUser, applicationUser);

applicationUserController.AuthenticationActions(applicationUser);
userLogController.UserActions();