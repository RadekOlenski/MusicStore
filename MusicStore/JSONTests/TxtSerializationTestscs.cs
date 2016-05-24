using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicStore;
using MusicStoreConsoleApplication;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace TXTTests
{
    [TestClass]
    public class TxtSerializationTestscs
    {
        [TestMethod]
        public void CountArgumentsTest()
        {
            Product prod = new Product("Ibanez", 200.0);
            Assert.AreEqual(5, prod.CountArguments());
        }

        [TestMethod]
        public void ClientSerializationTXTTest()
        {
            Client client = new Client("Tadeusz", "Nowak", "Random Street 23", "Lodz", 2005);
            TxtPROConverter txtcon = new TxtPROConverter();
            txtcon.writeObject(client, "client.txt");
            Client secondClient = txtcon.readClient("client.txt");
            Assert.AreEqual(client.ToString(), secondClient.ToString());
        }

        [TestMethod]
        public void ProductSerializationTXTTest()
        {
            Product product = new Product("Ibanez 200", 349.55);
            TxtPROConverter txtcon = new TxtPROConverter();
            txtcon.writeObject(product, "product.txt");
            Product secondClient = txtcon.readProduct("product.txt");
            Assert.AreEqual(product.ToString(), secondClient.ToString());
        }

        [TestMethod]
        public void TransactionSerializationTXTTest()
        {
            Transaction transaction = new Transaction(3, 3, "5 maja");
            TxtPROConverter txtcon = new TxtPROConverter();
            txtcon.writeObject(transaction, "transaction.txt");
            Transaction secondClient = txtcon.readTransaction("transaction.txt");
            Assert.AreEqual(transaction.ToString(), secondClient.ToString());
        }

        [TestMethod]
        public void ClientListSerializationTXTTest()
        {
            List<Client> clients = new List<Client>
            {
                new Client("Tadeusz", "Nowak", " Red Street 453", "Lodz", 2005),
                new Client("Adrain", "Kowalski", "Random Street 23", "Breslau", 1964),
                new Client("Konrad", "Starski", "Sweet Street 567", "Hong Kong", 1874),
                new Client("Stefan", "Jura", "Honey Street 31", "Radom", 2100)
            };

            TxtPROConverter txtcon = new TxtPROConverter();
            txtcon.writeClientsList(clients, "clients.txt");
            List<Client> deClients = txtcon.readClientsList("clients.txt");
            for (int i = 0; i < clients.Count; i++)
            {
                Assert.AreEqual(clients[i].ToString(), deClients[i].ToString());
            }
        }

        [TestMethod]
        public void ClientListSerializationCountTXTTest()
        {
            List<Client> clients = new List<Client>
            {
                new Client("Tadeusz", "Nowak", " Red Street 453", "Lodz", 2005),
                new Client("Adrain", "Kowalski", "Random Street 23", "Breslau", 1964),
                new Client("Konrad", "Starski", "Sweet Street 567", "Hong Kong", 1874),
                new Client("Stefan", "Jura", "Honey Street 31", "Radom", 2100)
            };

            TxtPROConverter txtcon = new TxtPROConverter();
            txtcon.writeClientsList(clients, "clients.txt");
            List<Client> deClients = txtcon.readClientsList("clients.txt");

            Assert.AreEqual(clients.Count, deClients.Count);
        }

        [TestMethod]
        public void TransactionObservableCollectionSerializationTXTTest()
        {
            ObservableCollection<Transaction> transactions = new ObservableCollection<Transaction>
            {
                new Transaction(1,13, "5 wrzesnia"),
                new Transaction(45,3, "8 wrzesnia"),
                new Transaction(4,4, "30 wrzesnia"),
                new Transaction(7,4, "45 wrzesnia"),
            };

            TxtPROConverter txtcon = new TxtPROConverter();
            txtcon.writeTransactionsObservableCollection(transactions, "transactions.txt");
            ObservableCollection<Transaction> deTransactions = txtcon.readTransactionsObservableCollection("transactions.txt");
            for (int i = 0; i < transactions.Count; i++)
            {
                Assert.AreEqual(transactions[i].ToString(), deTransactions[i].ToString());
            }
        }

        [TestMethod]
        public void TransactionObservableCollectionSerializationCountTXTTest()
        {
            ObservableCollection<Transaction> transactions = new ObservableCollection<Transaction>
            {
                new Transaction(1,13, "5 wrzesnia"),
                new Transaction(45,3, "8 wrzesnia"),
                new Transaction(4,4, "30 wrzesnia"),
                new Transaction(7,4, "45 wrzesnia"),
            };

            TxtPROConverter txtcon = new TxtPROConverter();
            txtcon.writeTransactionsObservableCollection(transactions, "transactions.txt");
            ObservableCollection<Transaction> deTransactions = txtcon.readTransactionsObservableCollection("transactions.txt");
            Assert.AreEqual(transactions.Count, deTransactions.Count);
        }

        [TestMethod]
        public void ProductDictionarySerializationCountTXTTest()
        {
            Dictionary<int, Product> products = new Dictionary<int, Product>
            {
                { 1, new Product { Name = "Yamaha 2", Price = 400.99}},
                { 2, new Product { Name = "Ibanez 2111", Price = 402130.99}},
                { 3, new Product { Name = "Cort 242", Price = 4111100.99}},
                { 4, new Product { Name = "Yamaha -4", Price = 4500.99}},
            };

            TxtPROConverter txtcon = new TxtPROConverter();
            txtcon.writeProductsDictionary(products, "products.txt");
            Dictionary<int, Product> deProducts = txtcon.readProductsDictionary("products.txt");
            Assert.AreEqual(products.Count, deProducts.Count);
        }

        [TestMethod]
        public void ProductDictionarySerializationTXTTest()
        {
            Dictionary<int, Product> products = new Dictionary<int, Product>
            {
                { 0, new Product { Name = "Yamaha 2.0", Price = 3200.99}},
                { 1, new Product { Name = "Yamaha 2", Price = 400.99}},
                { 2, new Product { Name = "Ibanez 2111", Price = 402130.99}},
                { 3, new Product { Name = "Cort 242", Price = 4111100.99}},
                { 4, new Product { Name = "Yamaha -4", Price = 4500.99}},
            };

            TxtPROConverter txtcon = new TxtPROConverter();
            txtcon.writeProductsDictionary(products, "products.txt");
            Dictionary<int, Product> deProducts = txtcon.readProductsDictionary("products.txt");
            for (int i = 0; i < products.Count; i++)
            {
                Assert.AreEqual(products[i].ToString(), deProducts[i].ToString());
            }
        }
    }
}
