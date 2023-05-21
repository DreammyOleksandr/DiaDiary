using System.Security.Cryptography;
using System.Text;
using DataAccess;
using DataAccess.Models;
using MongoDB.Bson;
using MongoDB.Driver;
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
            Messages.
        }

        await MongoRepository.Create(registeredUser);
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
        List<ApplicationUser> applicationUsers = MongoRepository.GetAll().ToList();

        foreach (var applicationUser in applicationUsers)
        {
            if (createdEmail == applicationUser.Email)
            {
                return false;
            }
        }

        return true;
    }
}