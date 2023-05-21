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

        if (userToFind != null && PasswordHash(applicationUser.Password) == userToFind.Password)
        {
            Console.Clear();
            Messages.SuccessfulLogin();
        }
        else
        {
            Console.WriteLine("No");
        }
    }

    public async Task Register()
    {
        ApplicationUser registeredUser = new ApplicationUser();
        ApplicationUserView.Register(registeredUser);

        string hashedPassword = PasswordHash(registeredUser.Password);
        registeredUser.Password = hashedPassword;
        
        await MongoRepository.Create(registeredUser);
    }

    private string PasswordHash(string password)
    {
        SHA256 hash = SHA256.Create();
        var passwordInBytes = Encoding.Default.GetBytes(password);
        var hashedPassword = hash.ComputeHash(passwordInBytes);

        return Convert.ToHexString(hashedPassword);
    }
}