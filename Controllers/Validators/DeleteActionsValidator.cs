using DataAccess;
using Models;
using View.ActionMenus;

namespace Controllers.Validators;

public class DeleteActionsValidator : IValidator
{
    public static void Validate()
    {
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
    }
}