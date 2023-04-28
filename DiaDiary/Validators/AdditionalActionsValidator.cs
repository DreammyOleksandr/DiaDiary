using DataAccess;
using DiaDiary;
using View;

namespace Controllers.Validators;

public class AdditionalActionsValidator
{
    
    public static void Validate()
    {
        MenuElements menuElements = new MenuElements();
        menuElements.options = new[] { "Glycated Hemoglobin" };
        menuElements.title = null;
        
        ScrollableMenu scrollableMenu = new ScrollableMenu(menuElements);
        
        int userAdditionalChoice = ScrollableMenu.Run();
        switch ((AdditionalMenuEnum)userAdditionalChoice)
        {
            case AdditionalMenuEnum.GlycatedHemoglobin:
                AdditionalActions.GlycatedHemoglobin();
                break;
        }
    }
}