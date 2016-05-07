using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicStore;

namespace LinqQueriesTest
{
    [TestClass]
    public class ExtensionMethodsTest
    {
        [TestMethod]
        public void GetClientsInGroupsOfTenWithReminderTest()
        {
            DataRepository repo = new DataRepository();
            for (int i = 0; i < 41; i++)
            {
            repo.CreateClient();
            }
            Assert.AreEqual(5,(repo.GetClientsInGroupsOfTen()).Length);
        }

        [TestMethod]
        public void GetClientsInGroupsOfTenWholeNumberTest()
        {
            DataRepository repo = new DataRepository();
            for (int i = 0; i < 40; i++)
            {
                repo.CreateClient();
            }
            Assert.AreEqual(4, (repo.GetClientsInGroupsOfTen()).Length);
        }

        [TestMethod]
        public void GetClientsInGroupsOfTenTensTest()
        {
            DataRepository repo = new DataRepository();
            for (int i = 0; i < 100; i++)
            {
                repo.CreateClient(BirthYear: i);
            }
            var subset = repo.GetClientsInGroupsOfTen();
            for (int i = 0; i < subset.Length; i++)
            {
                Console.WriteLine(i);
                Assert.AreEqual(10, subset[i].Count);
            }
        }

        [TestMethod]
        public void GetBestBuyingClientTest()
        {
            DataRepository repo = new DataRepository();
            for (int i = 0; i < 3; i++)
            {
                repo.CreateClient(Name: String.Format("ImieKlienta{0}", i));
            }

            repo.CreateTransaction(0, 0, "1 kwietnia");
            repo.CreateTransaction(1, 1, "14 kwietnia");
            repo.CreateTransaction(1, 5, "12 kwietnia");
            repo.CreateTransaction(1, 23, "6 kwietnia");
            repo.CreateTransaction(2, 21, "16 maja");
            repo.CreateTransaction(2, 21, "2 stycznia");

            Assert.AreEqual(repo.GetSpecificClientToString(1), repo.GetBestBuyingClient().ToString());
        }

        [TestMethod]
        public void GetNotBoughtProductsTest()
        {
            DataRepository repo = new DataRepository();
            repo.CreateProduct(ProductType.Guitar, "Ibanez 30000", 2300);
            repo.CreateProduct(ProductType.Keyboard, "Yamaxa ProPlayer", 39,99);
            repo.CreateProduct(ProductType.Guitar, "Cort BlackMadness", 800);
            repo.CreateProduct(ProductType.Keyboard, "Yamaha B6", 1000);
            repo.CreateProduct(ProductType.Guitar, "Fender Stratocaster", 5300);

            repo.CreateTransaction(1, 0, "14 kwietnia");
            repo.CreateTransaction(15, 0, "14 kwietnia");
            repo.CreateTransaction(11, 2, "14 kwietnia");
            repo.CreateTransaction(2, 3, "14 kwietnia");

            foreach (Product poorProduct in repo.GetNotBoughtProducts())
            {
                Assert.IsTrue(poorProduct.Name.Equals("Yamaxa ProPlayer") || poorProduct.Name.Equals("Fender Stratocaster"));
                Assert.IsFalse(poorProduct.Price == 1000 || poorProduct.Price == 800 || poorProduct.Price == 2300);
            }
        }
    }
}
