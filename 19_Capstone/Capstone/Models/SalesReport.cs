using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Capstone.Models
{
    public class SalesReport
    {
        public void RecordMoney(decimal moneyInsert, decimal currentMoney)
        {
            string directory = @"..\..\..\..";
            string fileName = "Log.txt";
            string fullPath = Path.Combine(directory, fileName);
            using (StreamWriter sw = new StreamWriter(fullPath, true))
            {
                sw.WriteLine($"{DateTime.UtcNow} | FEED MONEY | ${moneyInsert} | ${currentMoney}");
            }
        }

        public void RecordPurchase(decimal moneyAfter, decimal currentMoney, string productName, string productKey)
        {
            string directory = @"..\..\..\..";
            string fileName = "Log.txt";
            string fullPath = Path.Combine(directory, fileName);
            using (StreamWriter sw = new StreamWriter(fullPath, true))
            {
                sw.WriteLine($"{DateTime.UtcNow} | {productName}  {productKey} | ${currentMoney} | ${moneyAfter}");
            }
        }

        public void RecordChange(decimal currentMoney)
        {
            string directory = @"..\..\..\..";
            string fileName = "Log.txt";
            string fullPath = Path.Combine(directory, fileName);
            using (StreamWriter sw = new StreamWriter(fullPath, true))
            {
                sw.WriteLine($"{DateTime.UtcNow} | FEED MONEY | ${currentMoney} | $0.00");
            }
        }
    }
}
