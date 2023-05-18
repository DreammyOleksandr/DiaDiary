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
        
    }

    public async Task Register()
    {
        ApplicationUser applicationUser = new ApplicationUser();
        ApplicationUserView.Register(applicationUser);

        string hashedPassword = PasswordHash(applicationUser.Password);
        applicationUser.Password = hashedPassword;
        
        await MongoRepository.Create(applicationUser);
    }

    private string PasswordHash(string password)
    {
        SHA256 hash = SHA256.Create();
        var passwordInBytes = Encoding.Default.GetBytes(password);
        var hashedPassword = hash.ComputeHash(passwordInBytes);

        return Convert.ToString(hashedPassword);
    }
}