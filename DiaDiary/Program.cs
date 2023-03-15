using System.Security.Cryptography;
using DataAccess;
using Models;

namespace DiaDiary;

class Program
{
    static void Main(string[] args)
    {
        DefaultMessages.Welcome();
        UserActions.ChooseAction();
        
        while (true)
        {
            Console.WriteLine("Do you want to continue?y/n");
            char userRepeat = Char.Parse(Console.ReadLine().ToLower());
            if (userRepeat == 'y')
            {
                Console.Clear();
                UserActions.ChooseAction();
            }
        
            if (userRepeat == 'n')
            {
                break;
            }
        }
    }
}