using System.Security.Cryptography;
using System.Text;
using DataAccess;
using DataAccess.Models;
using View;
using Views;

namespace DiaDiary.Controllers;

public class ApplicationUserController
{
    public readonly MenuElements menuElements = new MenuElements()
    {
        options = new string[]
        {
            "LogIn", "SignIn", "Exit"
        }
    };

    private readonly MongoRepository<ApplicationUser> _mongoRepository;
    private readonly ApplicationUser _applicationUser;

    public ApplicationUserController(MongoRepository<ApplicationUser> mongoRepository, ApplicationUser applicationUser)
    {
        _mongoRepository = mongoRepository;
        _applicationUser = applicationUser;
    }

    public dynamic ActionsRouting(int chosenAction) => chosenAction switch
    {
        0 => LogIn(_applicationUser),
        1 => SignIn(_applicationUser),
        2 => ContextActions.Exit(),
    };

    private ApplicationUser LogIn(ApplicationUser applicationUserToLogin)
    {
        ApplicationUserView.Login(applicationUserToLogin);

        var foundUser = _mongoRepository.GetOne(_ => _.Email == applicationUserToLogin.Email).Result;

        if (foundUser == null)
        {
            Console.Clear();
            Messages.EmailError();
            applicationUserToLogin.Email = null;
            return applicationUserToLogin;
        }

        if (foundUser.Email != null && PasswordHash(applicationUserToLogin.Password) == foundUser.Password)
        {
            Console.Clear();
            Messages.SuccessfulLogin();
            return applicationUserToLogin;
        }
        else
        {
            Console.Clear();
            Messages.PasswordError();
            applicationUserToLogin.Email = null;
            return applicationUserToLogin;
        }
    }

    private async Task<ApplicationUser> SignIn(ApplicationUser registeredUser)
    {
        ApplicationUserView.SignIn(registeredUser);

        string hashedPassword = PasswordHash(registeredUser.Password);
        registeredUser.Password = hashedPassword;

        bool uniqueEmail = CheckEmailOnUniqueness(registeredUser.Email);
        if (uniqueEmail)
        {
            Messages.SuccessfulSignin();
            await _mongoRepository.Create(registeredUser);
            return registeredUser;
        }
        else
        {
            Messages.NotUniqueEmail();
            registeredUser.Email = null;
            return registeredUser;
        }
    }

    public async Task AccountActions(ApplicationUser registeredUser)
    {
    }

    private async Task AccountInfo(ApplicationUser applicationUser)
    {
        ApplicationUser user = await _mongoRepository.GetOne(_ => _.Email == applicationUser.Email);
        ApplicationUserView.GetInfo(user);
    }

    private async Task DeleteAccount(ApplicationUser applicationUser)
    {
        ApplicationUserView.AccountDeletion();
        ConsoleKey keyPressed = Console.ReadKey().Key;
        if (keyPressed == ConsoleKey.Enter)
        {
            await _mongoRepository.Delete(_ => _.Id == applicationUser.Id);
        }
    }

    public async Task UpdateAccount(ApplicationUser applicationUser)
    {
        var applicationUserFromDb = _mongoRepository.GetOne(x=>x.Email == applicationUser.Email).Result;
        var applicationUserId = applicationUserFromDb.Id;
        Console.Clear();
        Console.WriteLine("Enter password for further changes");
        string enteredPassword = Console.ReadLine();

        if (enteredPassword == applicationUser.Password)
        {
            Console.Clear();
            Messages.PasswordEnteredSuccessfully();
            ApplicationUserView.AccountUpdate(applicationUser);
            applicationUser.Id = applicationUserId;
            string hashedPassword = PasswordHash(applicationUser.Password);
            applicationUser.Password = hashedPassword;

            await _mongoRepository.Update(_=>_.Id == applicationUserId, applicationUser);
        }
        else
        {
            Console.Clear();
            Messages.PasswordError();
        }
    }


    private string PasswordHash(string password)
    {
        SHA256 hash = SHA256.Create();
        var passwordInBytes = Encoding.Default.GetBytes(password);
        var hashedPassword = hash.ComputeHash(passwordInBytes);

        return Convert.ToHexString(hashedPassword);
    }

    private bool CheckEmailOnUniqueness(string createdEmail)
    {
        var dataBaseEmail = _mongoRepository.GetOne(_ => _.Email == createdEmail).Result;
        return dataBaseEmail == null ? true : false;
    }
}