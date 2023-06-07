using static System.Console;

namespace View;

public struct ScrollableMenu
{
    private static int _selectedIndex = 0;
    private static string? _prefsufix;
    private static string[] _options;

    public ScrollableMenu(MenuElements elements)
    {
        _title = elements.title;
        _options = elements.options;
    }

    private static string? _title;

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

    public int Run()
    {
        ConsoleKey keyPressed;

        do
        {
            Clear();
            DisplayOptions(_options);

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