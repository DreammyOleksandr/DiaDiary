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

    public ApplicationUser Login(ApplicationUser applicationUserToLogin)
    {
        ApplicationUserView.Login(applicationUserToLogin);

        var userToFind = MongoRepository.GetOne(_ => _.Email == applicationUserToLogin.Email).Result;

        if (userToFind == null)
        {
            Console.Clear();
            Messages.EmailError();
            applicationUserToLogin.Email = null;
            return applicationUserToLogin;
        }

        if (userToFind.Email != null && PasswordHash(applicationUserToLogin.Password) == userToFind.Password)
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

    public async Task<ApplicationUser> SignIn(ApplicationUser registeredUser)
    {
        ApplicationUserView.SignIn(registeredUser);

        string hashedPassword = PasswordHash(registeredUser.Password);
        registeredUser.Password = hashedPassword;

        bool uniqueEmail = CheckEmailOnUniqueness(registeredUser.Email);
        if (uniqueEmail)
        {
            Messages.SuccessfulSignin();
            await MongoRepository.Create(registeredUser);
            return registeredUser;
        }
        else{
            Messages.NotUniqueEmail();
            registeredUser.Email = null;
            return registeredUser;
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
        var dataBaseEmail = MongoRepository.GetOne(_ => _.Email == createdEmail).Result;
        return dataBaseEmail == null ? true : false;
    }
}