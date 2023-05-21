using System.Security.Cryptography;
using System.Text;
using DataAccess;
using DataAccess.Models;
using Views;

namespace DiaDiary.Controllers;

public class ApplicationUserController
{
    private readonly MongoRepository<ApplicationUser> MongoRepository;

    public ApplicationUserController(string database, string applicationUserCollection)
    {
        MongoRepository =
            new MongoRepository<ApplicationUser>(databaseName: database, collectionName: applicationUserCollection);
    }

    public async Task Login()
    {
        ApplicationUser applicationUser = new ApplicationUser();
        ApplicationUserView.Login(applicationUser);

        var userToFind = MongoRepository.GetOne(_ => _.Email == applicationUser.Email).Result;

        if (userToFind == null)
        {
            Console.Clear();
            Messages.EmailError();
            return;
        }

        if (userToFind.Email != null && PasswordHash(applicationUser.Password) == userToFind.Password)
        {
            Console.Clear();
            Messages.SuccessfulLogin();
            
        }
        else
        {
            Console.Clear();
            Messages.PasswordError();
        }
    }

    public async Task SignIn()
    {
        ApplicationUser registeredUser = new ApplicationUser();
        ApplicationUserView.SignIn(registeredUser);

        string hashedPassword = PasswordHash(registeredUser.Password);
        registeredUser.Password = hashedPassword;

        bool uniqueEmail = CheckEmailOnUniqueness(registeredUser.Email);
        if (uniqueEmail)
        {
            Messages.SuccessfulSignin();
            await MongoRepository.Create(registeredUser);
        }
        else
            Messages.NotUniqueEmail();
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
        var dataBaseEmail = MongoRepository.GetOne(_ => _.Email == createdEmail).Result;

        if (dataBaseEmail == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}