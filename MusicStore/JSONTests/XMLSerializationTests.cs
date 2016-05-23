using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicStore;
using MusicStoreConsoleApplication;

namespace XMLTests
{
    [TestClass]
    public class XMLSerializationTests
    {
        [TestMethod]
        public void ClientSerializationXMLTest()
        {
            Client client = new Client("Tadeusz", "Nowak", "Random Street 23", "Lodz", 2005);
            XMLConverter xmlc = new XMLConverter();
            xmlc.writeObject(client, "client.txt");
            Client secondClient = xmlc.readClient("client.txt");
            Assert.AreEqual(client.ToString(), secondClient.ToString());
        }

        [TestMethod]
        public void ProductSerializationXMLTest()
        {
            Product product = new Product("Ibanez 200", 349.55);
            XMLConverter xmlc = new XMLConverter();
            xmlc.writeObject(product, "product.txt");
            Product secondClient = xmlc.readProduct("product.txt");
            Assert.AreEqual(product.ToString(), secondClient.ToString());
        }

        [TestMethod]
        public void TransactionSerializationXMLTest()
        {
            Transaction transaction = new Transaction(3, 3, "5 maja");
            XMLConverter xmlc = new XMLConverter();
            xmlc.writeObject(transaction, "transaction.txt");
            Transaction secondClient = xmlc.readTransaction("transaction.txt");
            Assert.AreEqual(transaction.ToString(), secondClient.ToString());
        }

        [TestMethod]
        public void ClientListSerializationXMLTest()
        {
            List<Client> clients = new List<Client>
            {
                new Client("Tadeusz", "Nowak", " Red Street 453", "Lodz", 2005),
                new Client("Adrain", "Kowalski", "Random Street 23", "Breslau", 1964),
                new Client("Konrad", "Starski", "Sweet Street 567", "Hong Kong", 1874),
                new Client("Stefan", "Jura", "Honey Street 31", "Radom", 2100)
            };

            XMLConverter xmlc = new XMLConverter();
            xmlc.writeClientsList(clients, "clients.txt");
            List<Client> deClients = xmlc.readClientsList("clients.txt");
            for (int i = 0; i < clients.Count; i++)
            {
                Assert.AreEqual(clients[i].ToString(), deClients[i].ToString());
            }
        }

        [TestMethod]
        public void ClientListSerializationCountXMLTest()
        {
            List<Client> clients = new List<Client>
            {
                new Client("Tadeusz", "Nowak", " Red Street 453", "Lodz", 2005),
                new Client("Adrain", "Kowalski", "Random Street 23", "Breslau", 1964),
                new Client("Konrad", "Starski", "Sweet Street 567", "Hong Kong", 1874),
                new Client("Stefan", "Jura", "Honey Street 31", "Radom", 2100)
            };

            XMLConverter xmlc = new XMLConverter();
            xmlc.writeClientsList(clients, "clients.txt");
            List<Client> deClients = xmlc.readClientsList("clients.txt");

            Assert.AreEqual(clients.Count, deClients.Count);
        }

        [TestMethod]
        public void TransactionObservableCollectionSerializationXMLTest()
        {
            ObservableCollection<Transaction> transactions = new ObservableCollection<Transaction>
            {
                new Transaction(1,13, "5 wrzesnia"),
                new Transaction(45,3, "8 wrzesnia"),
                new Transaction(4,4, "30 wrzesnia"),
                new Transaction(7,4, "45 wrzesnia"),
            };

            XMLConverter xmlc = new XMLConverter();
            xmlc.writeTransactionsObservableCollection(transactions, "transactions.txt");
            ObservableCollection<Transaction> deTransactions = xmlc.readTransactionsObservableCollection("transactions.txt");
            for (int i = 0; i < transactions.Count; i++)
            {
                Assert.AreEqual(transactions[i].ToString(), deTransactions[i].ToString());
            }
        }

        [TestMethod]
        public void TransactionObservableCollectionSerializationCountXMLTest()
        {
            ObservableCollection<Transaction> transactions = new ObservableCollection<Transaction>
            {
                new Transaction(1,13, "5 wrzesnia"),
                new Transaction(45,3, "8 wrzesnia"),
                new Transaction(4,4, "30 wrzesnia"),
                new Transaction(7,4, "45 wrzesnia"),
            };

            XMLConverter xmlc = new XMLConverter();
            xmlc.writeTransactionsObservableCollection(transactions, "transactions.txt");
            ObservableCollection<Transaction> deTransactions = xmlc.readTransactionsObservableCollection("transactions.txt");
            Assert.AreEqual(transactions.Count, deTransactions.Count);
        }

        [TestMethod]
        public void ProductDictionarySerializationCountXMLTest()
        {
            Dictionary<int, Product> products = new Dictionary<int, Product>
            {
                { 1, new Product { Name = "Yamaha 2", Price = 400.99}},
                { 2, new Product { Name = "Ibanez 2111", Price = 402130.99}},
                { 3, new Product { Name = "Cort 242", Price = 4111100.99}},
                { 4, new Product { Name = "Yamaha -4", Price = 4500.99}},
            };

            XMLConverter xmlc = new XMLConverter();
            xmlc.writeProductsDictionary(products, "products.txt");
            Dictionary<int, Product> deProducts = xmlc.readProductsDictionary("products.txt");
            Assert.AreEqual(products.Count, deProducts.Count);
        }

        [TestMethod]
        public void ProductDictionarySerializationXMLTest()
        {
            Dictionary<int, Product> products = new Dictionary<int, Product>
            {
                { 0, new Product { Name = "Yamaha 2.0", Price = 3200.99}},
                { 1, new Product { Name = "Yamaha 2", Price = 400.99}},
                { 2, new Product { Name = "Ibanez 2111", Price = 402130.99}},
                { 3, new Product { Name = "Cort 242", Price = 4111100.99}},
                { 4, new Product { Name = "Yamaha -4", Price = 4500.99}},
            };

            XMLConverter xmlc = new XMLConverter();
            xmlc.writeProductsDictionary(products, "products.txt");
            Dictionary<int, Product> deProducts = xmlc.readProductsDictionary("products.txt");
            for (int i = 0; i < products.Count; i++)
            {
                Assert.AreEqual(products[i].ToString(), deProducts[i].ToString());
            }
        }
    }
}
