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
            Assert.IsTrue(clients.Count == 5);
        }

        [TestMethod]
        public void FillWithProducts()
        {
            Dictionary<int, Product> products = new Dictionary<int, Product>();
            sut.CreateProducts(products);
            Assert.IsTrue(products.Count == 4);
        }

        [TestMethod]
        public void FillWithTransactions()
        {
            ObservableCollection<Transaction> transactions = new ObservableCollection<Transaction>();
            sut.CreateTransactions(transactions);
            Assert.IsTrue(transactions.Count == 1);
        }
    }
}
