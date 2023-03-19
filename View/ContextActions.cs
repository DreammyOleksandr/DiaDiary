using static System.Console;

namespace View;

public class ContextActions
{
    public static void Exit()
    {
        
    }

    public static void About()
    {
        WriteLine("Uni project. Presented to make diabetics lives easier\n\n"
                  +"DiaDiary is a console project which main purpose is to be a (surprise, surprise) diary for diabetics, where you can "
                  +"Create, Read, Update and Delete your logs. This project has an interactive fancy and understandable interface which is pretty unusual to see in console projects.\n\n"
                  +"MongoDB (noSQL) is the datasaver of this project, also it has additional functions, like showing you glycated hemoglobin (indeed, not precisely)\n\n"
                  +"Still much work to do, so follow the updates, if you're interested :D\n\n"
                  +"email: albom2004q@gmail.com \ninstagram: @dreammy_oleksandr \nyoutube: @bananagiornogiovanna7094\n\n");
    }
}