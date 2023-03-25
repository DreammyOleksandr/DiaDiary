using System;
using static System.Console;

namespace View;

public class Menu
{
    
    private static string _title = @"  ____  _       ____  _                  
 |  _ \(_) __ _|  _ \(_) __ _ _ __ _   _ 
 | | | | |/ _` | | | | |/ _` | '__| | | |
 | |_| | | (_| | |_| | | (_| | |  | |_| |
 |____/|_|\__,_|____/|_|\__,_|_|   \__, |
                                   |___/    
                                by @DreammyOleksandr";
    
    
    private static int _selectedIndex = 0;
    private static string[] _options = new[] { "create", "show", "update", "delete", "additional", "about", "exit"};

    private static string? _prefsufix;

    private static void DisplayOptions()
    {
        WriteLine(_title);
        for (int i = 0; i < _options.Length; i++)
        {
            string currentOption = _options[i];

            if (i == _selectedIndex)
            {
                _prefsufix = "--";
                ForegroundColor = ConsoleColor.Green;
            }
            else
            {
                _prefsufix = "  ";
            }
            
            WriteLine($"{_prefsufix}<< {currentOption} >>{_prefsufix}");
        }
    }

    public static int Run()
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
                _selectedIndex--;
                if (_selectedIndex < 0)
                {
                    _selectedIndex = _options.Length - 1;
                }
            }
            if (keyPressed == ConsoleKey.DownArrow)
            {
                _selectedIndex++;
                if (_selectedIndex > _options.Length - 1)
                {
                    _selectedIndex = 0;
                }
            }
        } while (keyPressed != ConsoleKey.Enter );

        return _selectedIndex;
    }
}