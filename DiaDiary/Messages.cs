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

    public static void LogNotFound()
    {
        WriteLine("There is no such log");
        AnyKeyToReturn();
    }

    public static void SuccessfulDeletion()
    {
        WriteLine("Log has been deleted successfully");
        AnyKeyToReturn();
    }

    public static void WarningToDeleteAll()
    {
        WriteLine("This action will delete every log you ever made! Are you sure you want to continue?\n" +
                  "Enter - Yes\n" +
                  "Any other key - No\n");
    }

    public static void PasswordEnteredSuccessfully()
    {
        WriteLine("Password was entered successfully");
        AnyKeyToContinue();
    }

    public static void AuthenticateToNewAccount()
    {
        WriteLine("To authenticate to new account you have to restart the application");
    }

    public static void EnterPasswordForFurtherChanges()
    {
        WriteLine("Enter password for further changes");
    }
    public static void IdOfLogToReplace()
    {
        WriteLine("Enter Id of log you want to replace");
    }
}