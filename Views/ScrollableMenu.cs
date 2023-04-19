using static System.Console;

namespace View;

public abstract class ScrollableMenu
{
    public ScrollableMenu(string[] options, string title)
    {
        _options = options;
        _title = title;
    }

    private static int _selectedIndex = 0;
    private static string? _prefsufix;
    private static string[] _options;

    private static string _title = @"  ____  _       ____  _                  
 |  _ \(_) __ _|  _ \(_) __ _ _ __ _   _ 
 | | | | |/ _` | | | | |/ _` | '__| | | |
 | |_| | | (_| | |_| | | (_| | |  | |_| |
 |____/|_|\__,_|____/|_|\__,_|_|   \__, |
                                   |___/    
                                by @DreammyOleksandr";

    private static void DisplayOptions(string[] options)
    {
        ForegroundColor = ConsoleColor.Green;
        WriteLine(_title);
        _options = options;

        for (int i = 0; i < _options.Length; i++)
        {
            string currentOption = _options[i];

            if (i == _selectedIndex)
            {
                _prefsufix = "--";
            }
            else
            {
                _prefsufix = "  ";
            }

            WriteLine($"{_prefsufix}<< {currentOption} >>{_prefsufix}");
        }
    }

    protected static int Run(string[] options)
    {
        ConsoleKey keyPressed;

        do
        {
            Clear();
            DisplayOptions(options);

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
        } while (keyPressed != ConsoleKey.Enter);

        return _selectedIndex;
    }
}