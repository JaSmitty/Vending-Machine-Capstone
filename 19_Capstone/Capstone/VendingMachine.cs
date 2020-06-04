using Capstone.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone
{
    public class VendingMachine
    {
        public void Run()
        {
            string directory = @"..\..\..\..";
            string fileName = "vendingmachine.csv";
            string fullPath = Path.Combine(directory, fileName);
            Dictionary<string, FoodItems> vendingItems = new Dictionary<string, FoodItems>();
            using (StreamReader rdr = new StreamReader(fullPath))
            {
                while (!rdr.EndOfStream)
                {
                    string line = rdr.ReadLine();
                    string[] itemsInfo = line.Split("|");
                    FoodItems item = new FoodItems(itemsInfo[1], decimal.Parse(itemsInfo[2]), itemsInfo[3]);
                    vendingItems.Add(itemsInfo[0], item);
                }
            }
            foreach (KeyValuePair<string, FoodItems> item in vendingItems)
            {
                Console.Write($"{item.Key}  ");
                Console.Write($"{item.Value.ProductName}  ");
                Console.Write($"{item.Value.Price}  ");
                Console.Write(item.Value.Type);
                Console.WriteLine();
            }
        }
    }
}
