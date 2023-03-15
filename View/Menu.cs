using System;
using static System.Console;

namespace View;

public class Menu
{
    private int SelectedIndex = 0;
    private string[] Options = new[] { "create", "show", "update", "delete", "additional"};
    private string Prompt;

    public Menu(string prompt, string[] options)
    {
        Prompt = prompt;
        Options = options;
    }
}