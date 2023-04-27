using DataAccess;
using Models;
using View;

// using View.ActionMenus;

namespace Controllers.Validators;

public class DeleteActionsValidator : IValidator
{
    public static void Validate()
    {
        MenuElements menuElements = new MenuElements();
        menuElements.options = new[] { "Delete One", "Delete All" };
        menuElements.title = null;
        
        ScrollableMenu scrollableMenu = new ScrollableMenu(menuElements);
        
        int userDeleteChoice = ScrollableMenu.Run();
        switch ((DeleteMenuEnum)userDeleteChoice)
        {
            case DeleteMenuEnum.DeleteOne:
                MongoRepository<LogEntry>.Delete(_=>_.Id!=null);
                break;
            case DeleteMenuEnum.DeleteAll:
                MongoRepository<LogEntry>.DeleteAll();
                break;
        }
    }
}