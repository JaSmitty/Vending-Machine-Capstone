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
        

        static void Main(string[] args)
        {
            VendingMachine vending = new VendingMachine();
            vending.Run();
        }
    }
}
