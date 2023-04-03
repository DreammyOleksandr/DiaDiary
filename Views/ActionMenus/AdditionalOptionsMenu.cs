namespace View.ActionMenus;


public class AdditionalOptionsMenu : ScrollableMenu
{
    private static string[] AdditionalOptions = {"glycated hemoglobin",};
   
    public static int RunMenu()
    {
        return Run(AdditionalOptions);
    }
}