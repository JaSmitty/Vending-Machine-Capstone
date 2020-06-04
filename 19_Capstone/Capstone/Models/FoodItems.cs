using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class FoodItems
    {
        public FoodItems(string productName, decimal price, string type)
        { 
            this.ProductName = productName;
            this.Price = price;
            this.Type = type;
            this.Inventory = 5;
        }


        public string ProductName { get; private set; }
        public decimal Price { get; private set; }
        public string Type { get; private set; }
        public int Inventory { get; private set; }
    }
}
