﻿using DataAccess;
using Models;

namespace DiaDiary;

class Program
{
    static void Main(string[] args)
    {
        DefaultMessages.WelcomeMessage();
        MongoDbManager.DeleteByDate();
        Console.ReadKey();
    }
}