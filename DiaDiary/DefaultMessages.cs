namespace DiaDiary;

public class DefaultMessages
{
    public static void Creation()
    {
        Console.WriteLine("To create your log fill next fields:\n"
                          +"Glucose level\n"
                          +"Short term insulin dose\n"
                          +"Long term insulin dose\n"
                          +"Carbs eaten (bread units)\n"
                          +"Notes(optional)\n");
    }
    public static void SuccessfulCreation()
    {
        Console.WriteLine("Your log has been created successfully!");
    }
    public static void Deletion()
    {
        Console.WriteLine("Choose log you want to delete by typing glucose level of log(experimental)");
    }
    public static void SuccessfulDeletion()
    {
        Console.WriteLine("Your log has been deleted successfully!");
    }
    public static void ViewLogs()
    {
        Console.WriteLine("Here are your previous logs:");
    }
    public static void Error()
    {
        Console.WriteLine("Ooops... Something went wrong :(");
    }
}