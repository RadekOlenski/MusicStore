using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicStore;
using MusicStoreConsoleApplication;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace BinaryTests
{
    [TestClass]
    public class BinarySerializationTest
    {
        [TestMethod]
        public void ClientSerializationBinaryTest()
        {
            Client client = new Client("Tadeusz", "Nowak", "Random Street 23", "Lodz", 2005);
            BinaryConverter bc = new BinaryConverter();
            bc.writeObject(client, "client.dat");
            Client secondClient = bc.readClient("client.dat");
            Assert.AreEqual(client.ToString(), secondClient.ToString());
        }

        [TestMethod]
        public void ProductSerializationBinaryTest()
        {
            Product product = new Product("Ibanez 200", 349.55);
            BinaryConverter bc = new BinaryConverter();
            bc.writeObject(product, "product.dat");
            Product secondClient = bc.readProduct("product.dat");
            Assert.AreEqual(product.ToString(), secondClient.ToString());
        }

        [TestMethod]
        public void TransactionSerializationBinaryTest()
        {
            Transaction transaction = new Transaction(3, 3, "5 maja");
            BinaryConverter bc = new BinaryConverter();
            bc.writeObject(transaction, "transaction.dat");
            Transaction secondClient = bc.readTransaction("transaction.dat");
            Assert.AreEqual(transaction.ToString(), secondClient.ToString());
        }

        [TestMethod]
        public void ClientListSerializationBinaryTest()
        {
            List<Client> clients = new List<Client>
            {
                new Client("Tadeusz", "Nowak", " Red Street 453", "Lodz", 2005),
                new Client("Adrain", "Kowalski", "Random Street 23", "Breslau", 1964),
                new Client("Konrad", "Starski", "Sweet Street 567", "Hong Kong", 1874),
                new Client("Stefan", "Jura", "Honey Street 31", "Radom", 2100)
            };

            BinaryConverter bc = new BinaryConverter();
            bc.writeClientsList(clients, "clients.dat");
            List<Client> deClients = bc.readClientsList("clients.dat");
            for (int i = 0; i < clients.Count; i++)
            {
                Assert.AreEqual(clients[i].ToString(), deClients[i].ToString());
            }
        }

        [TestMethod]
        public void ClientListSerializationCountBinaryTest()
        {
            List<Client> clients = new List<Client>
            {
                new Client("Tadeusz", "Nowak", " Red Street 453", "Lodz", 2005),
                new Client("Adrain", "Kowalski", "Random Street 23", "Breslau", 1964),
                new Client("Konrad", "Starski", "Sweet Street 567", "Hong Kong", 1874),
                new Client("Stefan", "Jura", "Honey Street 31", "Radom", 2100)
            };

            BinaryConverter bc = new BinaryConverter();
            bc.writeClientsList(clients, "clients.dat");
            List<Client> deClients = bc.readClientsList("clients.dat");

            Assert.AreEqual(clients.Count, deClients.Count);
        }

        [TestMethod]
        public void TransactionObservableCollectionSerializationBinaryTest()
        {
            ObservableCollection<Transaction> transactions = new ObservableCollection<Transaction>
            {
                new Transaction(1,13, "5 wrzesnia"),
                new Transaction(45,3, "8 wrzesnia"),
                new Transaction(4,4, "30 wrzesnia"),
                new Transaction(7,4, "45 wrzesnia"),
            };

            BinaryConverter bc = new BinaryConverter();
            bc.writeTransactionsObservableCollection(transactions, "transactions.dat");
            ObservableCollection<Transaction> deTransactions = bc.readTransactionsObservableCollection("transactions.dat");
            for (int i = 0; i < transactions.Count; i++)
            {
                Assert.AreEqual(transactions[i].ToString(), deTransactions[i].ToString());
            }
        }

        [TestMethod]
        public void TransactionObservableCollectionSerializationCountBinaryTest()
        {
            ObservableCollection<Transaction> transactions = new ObservableCollection<Transaction>
            {
                new Transaction(1,13, "5 wrzesnia"),
                new Transaction(45,3, "8 wrzesnia"),
                new Transaction(4,4, "30 wrzesnia"),
                new Transaction(7,4, "45 wrzesnia"),
            };

            BinaryConverter bc = new BinaryConverter();
            bc.writeTransactionsObservableCollection(transactions, "transactions.dat");
            ObservableCollection<Transaction> deTransactions = bc.readTransactionsObservableCollection("transactions.dat");
            Assert.AreEqual(transactions.Count, deTransactions.Count);
        }

        [TestMethod]
        public void ProductDictionarySerializationCountBinaryTest()
        {
            Dictionary<int, Product> products = new Dictionary<int, Product>
            {
                { 1, new Product { Name = "Yamaha 2", Price = 400.99}},
                { 2, new Product { Name = "Ibanez 2111", Price = 402130.99}},
                { 3, new Product { Name = "Cort 242", Price = 4111100.99}},
                { 4, new Product { Name = "Yamaha -4", Price = 4500.99}},
            };

            BinaryConverter bc = new BinaryConverter();
            bc.writeProductsDictionary(products, "products.dat");
            Dictionary<int, Product> deProducts = bc.readProductsDictionary("products.dat");
            Assert.AreEqual(products.Count, deProducts.Count);
        }

        [TestMethod]
        public void ProductDictionarySerializationBinaryTest()
        {
            Dictionary<int, Product> products = new Dictionary<int, Product>
            {
                { 0, new Product { Name = "Yamaha 2.0", Price = 3200.99}},
                { 1, new Product { Name = "Yamaha 2", Price = 400.99}},
                { 2, new Product { Name = "Ibanez 2111", Price = 402130.99}},
                { 3, new Product { Name = "Cort 242", Price = 4111100.99}},
                { 4, new Product { Name = "Yamaha -4", Price = 4500.99}},
            };

            BinaryConverter bc = new BinaryConverter();
            bc.writeProductsDictionary(products, "products.dat");
            Dictionary<int, Product> deProducts = bc.readProductsDictionary("products.dat");
            for (int i = 0; i < products.Count; i++)
            {
                Assert.AreEqual(products[i].ToString(), deProducts[i].ToString());
            }
        }
    }
}
