using Capstone.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;

namespace Capstone
{
    public class VendingMachine
    {

        #region Constructor
        Dictionary<string, FoodItems> vendingItems = new Dictionary<string, FoodItems>();
        Transactions transactions = new Transactions();
        SalesReport salesReport = new SalesReport();
        public VendingMachine()
        {
            string directory = @"..\..\..\..";
            string fileName = "vendingmachine.csv";
            string fullPath = Path.Combine(directory, fileName);
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

           
        }
        #endregion


        #region Run Method
        public void Run()
        {
            while (true)
            {

                Console.Clear();
                SetColor(ConsoleColor.DarkBlue);
                Console.WriteLine("Welcome to a Vending Machine");
                Console.WriteLine("*********************************");
                Console.WriteLine();
                Console.WriteLine("Please choose a command:");
                Console.WriteLine("1.)  Display Vending Machine items");
                Console.WriteLine("2.)  Purchase Item");
                Console.WriteLine("3.)  Exit");
                Console.WriteLine();
                string command = Console.ReadLine();
                if (command == "1")
                {
                    Console.Clear();
                    DisplayItems();
                }
                else if (command == "2")
                {
                    Purchase();
                }
                else if (command == "3")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("                              ___");
                    Console.WriteLine("Please enter a valid command (o_0)");
                    Console.WriteLine(@"                              /|\");
                    Console.WriteLine(@"                             _/ \_");
                    Console.ReadLine();
                }
            }
        }
        #endregion


        #region DiplayItems Method
        public void DisplayItems()
        {
            while (true)
            {
                SetColor(ConsoleColor.White);
                Console.WriteLine("Key | Product Name | Price | Inventory Left");
                Console.WriteLine("******************************************");
                foreach (KeyValuePair<string, FoodItems> item in vendingItems)
                {
                    if (item.Value.Inventory == 0)
                    {
                        Console.WriteLine($"{item.Key} | {item.Value.ProductName} | ${item.Value.Price} | SOLD OUT");
                    }
                    else
                    {
                        Console.WriteLine($"{item.Key} | {item.Value.ProductName} | ${item.Value.Price} | {item.Value.Inventory}");
                    }
                }
                Console.ReadLine();
                break;
            }
        }
        #endregion


        #region Purchase Method
        public void Purchase()
        {
            while (true)
            {
                Console.Clear();
                SetColor(ConsoleColor.Red);
                Console.WriteLine("Purchase Menu");
                Console.WriteLine("****************************");
                Console.WriteLine();
                Console.WriteLine("1.)   Feed Money");
                Console.WriteLine("2.)   Select Product");
                Console.WriteLine("3.)   Finish Transaction");
                Console.WriteLine();
                Console.WriteLine($"Money Inserted:  ${transactions.MoneyHeld}");
                string command = Console.ReadLine();
                if (command == "1")
                {
                    while (true)
                    {
                        Console.Write("Please insert money here: $");
                        string moneyInserted = Console.ReadLine();
                        decimal money = 0;
                        if (moneyInserted == "100" || moneyInserted == "50" || moneyInserted == "20" || moneyInserted == "10" || moneyInserted == "5" || moneyInserted == "2" || moneyInserted == "1")
                        {
                            money = decimal.Parse(moneyInserted);
                            transactions.FeedMoney(money);
                            salesReport.RecordMoney(money, transactions.MoneyHeld);
                        }
                        else
                        {
                            Console.WriteLine($"${moneyInserted} bills dont exist!!");
                            Console.ReadLine();
                        }
                        break;
                    }
                    
                }
                else if (command == "2")
                {
                    while (true)
                    {
                        Console.Clear();
                        Console.WriteLine("Key | Product Name | Price | Inventory Left");
                        Console.WriteLine("*********************************************");

                        foreach (KeyValuePair<string, FoodItems> item in vendingItems)
                        {

                            if (item.Value.Inventory == 0)
                            {
                                Console.WriteLine($"{item.Key} | {item.Value.ProductName} | ${item.Value.Price} | SOLD OUT");
                            }
                            else
                            {
                                Console.WriteLine($"{item.Key} | {item.Value.ProductName} | ${item.Value.Price} | {item.Value.Inventory}");
                            }
                        }
                        Console.WriteLine();
                        Console.WriteLine($"Money Inserted:  ${transactions.MoneyHeld}");
                        Console.WriteLine();
                        Console.WriteLine("To quit menu press (q)");
                        Console.Write("Please enter the code of the item: ");
                        string itemKey = Console.ReadLine();
                        
                        if (itemKey == "q")
                        {
                            break;
                        }
                        decimal moneyBefore = transactions.MoneyHeld;
                        try
                        {
                            if ((vendingItems[itemKey].Inventory > 0) && (transactions.MoneyHeld >= vendingItems[itemKey].Price))
                            {
                                vendingItems[itemKey].Inventory -= 1;
                                transactions.PurchaseItem(vendingItems[itemKey].Price);
                                if (vendingItems[itemKey].Type == "Chip")
                                {
                                    Console.WriteLine("CRUNCH CRUNCH, Yum!");
                                    Console.ReadLine();
                                }
                                else if (vendingItems[itemKey].Type == "Candy")
                                {
                                    Console.WriteLine("MUNCH MUNCH, Yum!");
                                    Console.ReadLine();
                                }
                                else if (vendingItems[itemKey].Type == "Drink")
                                {
                                    Console.WriteLine("GLUG GLUG, Yum!");
                                    Console.ReadLine();
                                }
                                else
                                {
                                    Console.WriteLine("CHEW CHEW, Yum!");
                                    Console.ReadLine();
                                }
                                salesReport.RecordPurchase(transactions.MoneyHeld, moneyBefore, vendingItems[itemKey].ProductName, itemKey);
                            }
                            else if (vendingItems[itemKey].Inventory == 0)
                            {
                                Console.WriteLine("OUT OF STOCK");
                                Console.ReadLine();
                            }
                            else if (transactions.MoneyHeld < vendingItems[itemKey].Price)
                            {
                                Console.WriteLine("FEED ME MORE MONEY");
                                Console.ReadLine();
                            }
                        }
                        catch
                        {
                            Console.WriteLine("KEY NOT FOUND");
                            Console.ReadLine();
                        }
                    }

                }
                else if(command == "3")
                {
                    salesReport.RecordChange(transactions.MoneyHeld);
                    Console.WriteLine(transactions.GiveChange());
                    Console.ReadLine();
                    break;
                }
                else
                {
                    Console.WriteLine("                              ___");
                    Console.WriteLine("Please enter a valid command (o_0)");
                    Console.WriteLine(@"                              /|\");
                    Console.WriteLine(@"                             _/ \_");
                    Console.ReadLine();
                }
            }


        }
        #endregion

        #region Color
        static private ConsoleColor originalForegroundColor = Console.ForegroundColor;
        static private ConsoleColor originalBackgroundColor = Console.BackgroundColor;
        static public void SetColor(ConsoleColor foregroundColor)
        {
            Console.ForegroundColor = foregroundColor;
        }

        static public void SetColor(ConsoleColor foregroundColor, ConsoleColor backgroundColor)
        {
            Console.ForegroundColor = foregroundColor;
            Console.BackgroundColor = backgroundColor;
        }

        static public void ResetColor()
        {
            Console.ForegroundColor = originalForegroundColor;
            Console.BackgroundColor = originalBackgroundColor;
        }
        #endregion
    }
}
