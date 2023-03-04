namespace DiaDiary;

public class DefaultMessages
{
    public static void WelcomeMessage()
    {
        Console.WriteLine("Hello user!\n\nType\n"
                          + "c to create new log\n"
                          + "d to delete chosen log\n"
                          + "u to update chosen log\n"
                          + "s to show all logs\n\n"
                          +"*Case doesn't matter*");
    }
}