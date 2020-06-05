using Capstone.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

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
            //while (true)
            //{
            //    Console.Clear();
                
            //}
        }
        public void DisplayItems(Dictionary<string, FoodItems> vendingItems)
        {
                foreach (KeyValuePair<string, FoodItems> Item in vendingItems)
                {
                    Console.WriteLine($"{Item.Key} - {Item.Value} {Item.Value.Price} {Item.Value.Inventory} {Item.Value.Type}");
                    
                }
            }
       

    }
}
