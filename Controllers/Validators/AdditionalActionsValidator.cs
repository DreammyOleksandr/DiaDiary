using DataAccess;
using DiaDiary;
using View.ActionMenus;

namespace Controllers.Validators;

public class AdditionalActionsValidator : IValidator
{
    public static void Validate()
    {
        int userAdditionalChoice = AdditionalOptionsMenu.RunMenu();
        switch ((AdditionalMenuEnum)userAdditionalChoice)
        {
            case AdditionalMenuEnum.GlycatedHemoglobin:
                AdditionalActions.GlycatedHemoglobin();
                break;
        }
    }
}