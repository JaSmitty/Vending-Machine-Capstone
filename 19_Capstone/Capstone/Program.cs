using Capstone.Models;
using CLI;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;

namespace Capstone
{
    class Program
    {
        private static Dictionary<string, FoodItems> vendingItems;

        static void Main(string[] args)
        {
            MainMenu menu = new MainMenu();

            VendingMachine vendingMachine = new VendingMachine();
            vendingMachine.DisplayItems(vendingItems);
            

        }
    }
}
