using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicStore.ConsoleApplication;
using System.Collections.Generic;
using MusicStore;
using System.Collections.ObjectModel;

namespace FillDataRepositoryTest
{
    [TestClass]
    public class FillFromFileTests
    {
        private FillRepositoryFromFile sut;

        [TestInitialize]
        public void init()
        {
            sut = new FillRepositoryFromFile();
        }
        
        [TestMethod]
        public void ReadClientsFile()
        {
            List<string> expectedList = new List<string>();
            expectedList.Add("Edward;Smith;Long Street;Longtown;1960");
            expectedList.Add("Roger;Smaul;Small Street;Smalltown;2010");
            expectedList.Add("Adam;Framework;Frame Street;Frametown;1984");
            expectedList.Add("Andrew;Bracket;Bracket Street;Bracketown;1200");

            List<string> actualList = sut.FileToString("clients.txt");
            Assert.AreEqual(expectedList[0], actualList[0]);
            Assert.AreEqual(expectedList[1], actualList[1]);
            Assert.AreEqual(expectedList[2], actualList[2]);
        }

        [TestMethod]
        public void ReadProductsFile()
        {
            List<string> expectedList = new List<string>();
            expectedList.Add("produkt1;100");
            expectedList.Add("produkt2;500");
            expectedList.Add("produkt3;1000");
            expectedList.Add("produkt4;10230,23");
            expectedList.Add("produkt5;100,24");

            List<string> actualList = sut.FileToString("products.txt");
            Assert.AreEqual(expectedList[0], actualList[0]);
            Assert.AreEqual(expectedList[1], actualList[1]);
            Assert.AreEqual(expectedList[2], actualList[2]);
            Assert.AreEqual(expectedList[3], actualList[3]);
            Assert.AreEqual(expectedList[4], actualList[4]);
        }

        [TestMethod]
        public void ReadTransactionsFile()
        {
            List<string> expectedList = new List<string>();
            expectedList.Add("1;2;20.12.2005");
            expectedList.Add("0;0;01.02.921");

            List<string> actualList = sut.FileToString("transactions.txt");
            Assert.AreEqual(expectedList[0], actualList[0]);
            Assert.AreEqual(expectedList[1], actualList[1]);
        }

        [TestMethod]
        public void CreateClientsFromFile()
        {
            List<Client> clients = new List<Client>();
            sut.CreateClients(clients);
            Assert.IsTrue(clients.Count > 0);
        }

        [TestMethod]
        public void CreateProductsFromFile()
        {
            Dictionary<int, Product> products = new Dictionary<int, Product>();
            sut.CreateProducts(products);
            Assert.IsTrue(products.Count > 0);
        }

        [TestMethod]
        public void CreateTransactionsFromFile()
        {
            ObservableCollection<Transaction> transactions = new ObservableCollection<Transaction>();
            sut.CreateTransactions(transactions);
            Assert.IsTrue(transactions.Count > 0);
        }
    }
}
