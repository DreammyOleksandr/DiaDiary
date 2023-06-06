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
    
    public static void AccountDeletion()
    {
        Clear();
        WriteLine("This action will delete every log you ever made! Are you sure you want to continue?\n" +
                  "Enter - Yes\n" +
                  "Backspace - No\n");
    }
    
    public static void AccountUpdate(ApplicationUser applicationUser)
    {
        Clear();
        Write("Enter new, or same em@il: ");
        applicationUser.Email = ReadLine();
        Write("Enter new, or same password: ");
        applicationUser.Password = ReadLine();
        Write("Enter new, or same full name: ");
        applicationUser.FullName = ReadLine();
    }
}