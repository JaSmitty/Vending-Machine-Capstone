using Capstone.Models;
using System;

namespace Capstone
{
    class Program
    {
        static void Main(string[] args)
        {
            VendingMachine vending = new VendingMachine();
            vending.Run();



            SalesReport sale = new SalesReport();
            sale.RecordMoney(5.00M, 0.00M);
        }


    }
}
