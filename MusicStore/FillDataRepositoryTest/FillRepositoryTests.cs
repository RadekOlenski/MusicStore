using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicStore.ConsoleApplication;
using System.Collections.Generic;
using MusicStore;
using System.Collections.ObjectModel;

namespace FillDataRepositoryTest
{
    [TestClass]
    public class FillRepositoryTests
    {
        private FillRepository sut;

        [TestInitialize]
        public void init()
        {
            sut = new FillRepository();
        }

        [TestMethod]
        public void FillWithClients()
        {
            List<Client> clients = new List<Client>();
            sut.CreateClients(clients);
            Assert.AreEqual(5, clients.Count);
        }

        [TestMethod]
        public void FillWithProducts()
        {
            Dictionary<int, Product> products = new Dictionary<int, Product>();
            sut.CreateProducts(products);
            Assert.AreEqual(4, products.Count);
        }

        [TestMethod]
        public void FillWithTransactions()
        {
            ObservableCollection<Transaction> transactions = new ObservableCollection<Transaction>();
            sut.CreateTransactions(transactions);
            Assert.AreEqual(1, transactions.Count);
        }
    }
}
