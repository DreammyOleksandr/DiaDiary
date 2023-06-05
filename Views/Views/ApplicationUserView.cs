using DataAccess.Models;
using static System.Console;

namespace Views;

public class ApplicationUserView
{
    public static ApplicationUser SignIn(ApplicationUser applicationUser)
    {
        Clear();
        Write($"Em@il: ");
        applicationUser.Email = ReadLine().ToLower();
        Write($"Password: ");
        applicationUser.Password = ReadLine();
        Write($"Full name: ");
        applicationUser.FullName = ReadLine();
        WriteLine();
        
        return applicationUser;
    }

    public static ApplicationUser Login(ApplicationUser applicationUser)
    {
        Clear();
        Write($"Em@il: ");
        applicationUser.Email = ReadLine().ToLower();
        Write($"Password: ");
        applicationUser.Password = ReadLine();

        return applicationUser;
    }

    public static void GetInfo(ApplicationUser registeredUser)
    {
        Clear();
        Write($"Em@il: {registeredUser.Email}\n");
        Write($"Full Name: {registeredUser.FullName}\n");
        Write("\nPress any key to continue...");
        ReadKey();
    }
}