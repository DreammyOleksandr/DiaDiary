using static  System.Console;

namespace View.ActionMenus;

public class DeleteMenu : ScrollableMenu
{
   private static string[] DeleteOptions = {"delete chosen log", "delete all logs"};
   
   public static int RunMenu()
   {
      return Run(DeleteOptions);
   }
}