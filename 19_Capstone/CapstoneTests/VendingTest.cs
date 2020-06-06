using Capstone;
using Capstone.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CapstoneTests
{
    [TestClass]
    public class VendingTest
    {
        [TestMethod]
        public void FoodItemsConstructorMethod()
        {
            FoodItems testItem = new FoodItems("Potatoes", 53.24M, "Chip");
            Assert.AreEqual("Chip", testItem.Type);
            Assert.AreEqual("Potatoes", testItem.ProductName);
            Assert.AreEqual(53.24M, testItem.Price);

        }

        [TestMethod]
        public void TransactionMethod()
        {
            Transactions testTransactions = new Transactions();
            Assert.AreEqual(0M, testTransactions.MoneyHeld);
            testTransactions.FeedMoney(10M);
            Assert.AreEqual(10M, testTransactions.MoneyHeld);
            testTransactions.PurchaseItem(3M);
            Assert.AreEqual(7M, testTransactions.MoneyHeld);
            Assert.AreEqual("Your change is 28 Quarters, 0 Dimes, 0 Nickles.", testTransactions.GiveChange());
        }

        [TestMethod]
        public void VendingMethod()
        {
            VendingMachine vending = new VendingMachine();

        }
    }
}
