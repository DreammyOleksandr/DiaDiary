using static System.Console;

namespace DiaDiary;

public class Messages
{
    private static void AnyKeyToContinue()
    {
        WriteLine("Press any key to continue...");
        ReadKey();
    }
    private static void AnyKeyToReturn()
    {
        WriteLine("Press any key to return...");
        ReadKey();
    }
    
    public static void SuccessfulLogin()
    {
        WriteLine("Login was successful!");
        AnyKeyToContinue();
    }
    public static void SuccessfulSignin()
    {
        WriteLine("SignIn was successful!");
        AnyKeyToContinue();
    }

    public static void EmailError()
    {
        WriteLine("User with such em@il was not found");
        AnyKeyToReturn();
    }

    public static void PasswordError()
    {
        WriteLine("Wrong password D: ");
        AnyKeyToReturn();
    }

    public static void NotUniqueEmail()
    {
        WriteLine("User with this email already exists");
        AnyKeyToReturn();
    }
}