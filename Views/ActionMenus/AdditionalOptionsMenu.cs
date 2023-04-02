namespace View.ActionMenus;

public class AdditionalOptionsMenu : Menu
{
    private static string[] AdditionalOptions = {"glycated hemoglobin",};
   
    public static int RunMenu()
    {
        return Run(AdditionalOptions);
    }
}