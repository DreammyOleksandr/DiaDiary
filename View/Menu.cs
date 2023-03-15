using System;
using System.Runtime.Intrinsics.Arm;
using static System.Console;

namespace View;

public class Menu
{
    
    private static string Title = @"  ____  _       ____  _                  
 |  _ \(_) __ _|  _ \(_) __ _ _ __ _   _ 
 | | | | |/ _` | | | | |/ _` | '__| | | |
 | |_| | | (_| | |_| | | (_| | |  | |_| |
 |____/|_|\__,_|____/|_|\__,_|_|   \__, |
                                   |___/    
                                by @dreammyoleksandr";
    
    
    private static int SelectedIndex = 0;
    private static string[] Options = new[] { "create", "show", "update", "delete", "additional"};

    private static string prefsufix;

    private static void DisplayOptions()
    {
        Console.WriteLine(Title);
        for (int i = 0; i < Options.Length; i++)
        {
            string currentOption = Options[i];

            if (i == SelectedIndex)
            {
                prefsufix = "--";
                ForegroundColor = ConsoleColor.White;
                BackgroundColor = ConsoleColor.Black;
            }
            else
            {
                prefsufix = "  ";
                ForegroundColor = ConsoleColor.Black;
                BackgroundColor = ConsoleColor.Gray;
            }
            
            WriteLine($"{prefsufix}<< {currentOption} >>{prefsufix}");
        }
    }

    public static int MenuRun()
    {
        ConsoleKey keyPressed;

        do
        {
            Clear();
            DisplayOptions();

            ConsoleKeyInfo keyInfo = ReadKey(true);
            keyPressed = keyInfo.Key;

            if (keyPressed == ConsoleKey.UpArrow)
            {
                SelectedIndex--;
                if (SelectedIndex < 0)
                {
                    SelectedIndex = Options.Length - 1;
                }
            }
            if (keyPressed == ConsoleKey.DownArrow)
            {
                SelectedIndex++;
                if (SelectedIndex > Options.Length - 1)
                {
                    SelectedIndex = 0;
                }
            }
        } while (keyPressed != ConsoleKey.Enter );

        return SelectedIndex;
    }
}