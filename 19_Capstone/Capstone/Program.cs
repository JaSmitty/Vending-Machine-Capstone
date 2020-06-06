using Capstone.Models;
using CLI;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using Figgle;

namespace Capstone
{
    class Program
    {
        

        static void Main(string[] args)
        {

            FiggleFun figgle = new FiggleFun();
            figgle.VendingDisplay();
            VendingMachine vending = new VendingMachine();
            vending.Run();
        }
    }
}
