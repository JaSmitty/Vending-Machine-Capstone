using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Models
{
    public class Transactions
    {
        public Transactions()
        {
            this.MoneyHeld = 0;
        }

        public decimal MoneyHeld { get; private set; }

        public decimal FeedMoney(decimal money)
        {
            this.MoneyHeld += money;
            return MoneyHeld;
        }

        public decimal PurchaseItem(decimal cost)
        {
            this.MoneyHeld -= cost;
            return MoneyHeld;
        }

        public string GiveChange()
        {
            int quarters = 0;
            int dimes = 0;
            int nickles = 0;
            if(MoneyHeld >= .25M)
            {
                quarters = (int)(MoneyHeld / .25M);
                MoneyHeld %= .25M;
            }
            if (MoneyHeld >= .1M)
            {
                dimes = (int)(MoneyHeld / .1M);
                MoneyHeld %= .1M;
            }
            if (MoneyHeld >= .05M)
            {
                nickles = (int)(MoneyHeld / .05M);
                MoneyHeld %= .05M;
            }
            return $"Your change is {quarters} Quarters, {dimes} Dimes, {nickles} Nickles.";
        }
    }
}
