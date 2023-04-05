using System;
using static System.Console;

namespace View;

public class MainMenu : ScrollableMenu
{
    private static string[] MenuOptions = {"create", "show", "update", "delete", "additional", "about", "exit"};

    public static int RunMenu()
    {
        return Run(MenuOptions);
    }
}