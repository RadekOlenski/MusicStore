#region includes
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion
//Class responsible for managing all data in project

namespace MusicStore
{
    public static class DataRepository
    {
        #region Constructor
        static DataRepository()
        {
            //Initialization of collections
            Clients = new List<Client>();
            Products = new Dictionary<int, Product>();
            Transactions = new ObservableCollection<Transaction>();
        }
        #endregion

        #region Data Collections
        // ?? Assuming there will be only one instance of every collection, these collections may be static ??
        static List<Client> Clients;
        static Dictionary<int, Product> Products;
        static ObservableCollection<Transaction> Transactions;
        #endregion

        #region Data Creation Methods
        public static void CreateProduct(int Type, string Name, double Price)
        {
            //Function adds new product to the Products Dictionary, according to the Type of product passed from database
            switch (Type)
            {
                case ProductType.GUITAR:
                    Products.Add(Product.GenerateProductID(), new Guitar(Name, Price));
                    break;
                case ProductType.KEYBOARD:
                    Products.Add(Product.GenerateProductID(), new Keyboard(Name, Price));
                    break;
                case ProductType.LONGPLAY:
                    Products.Add(Product.GenerateProductID(), new LongPlay(Name, Price));
                    break;
                case ProductType.LIVEALBUM:
                    Products.Add(Product.GenerateProductID(), new LiveAlbum(Name, Price));
                    break;
            }
        }

        public static void CreateClient(string Name, string Surname, string Street, string City, int BirthYear)
        {
            //This method add new Client object to the Clients List, with all object properties passed from database 
            Clients.Add(new Client(Name, Surname, Street, City, BirthYear));
        }

        public static void CreateTransaction(int ClientID, int ProductID, string Date)
        {
            Transactions.Add(new Transaction(ClientID, ProductID, Date));
        }
        #endregion

        #region Data Read Methods
        public static void ReadAllProducts()
        {
            //This method prints out every product from collection, with all of its properties
            for (int i = 1; i <= Products.Count; i++)
            {
                Console.WriteLine("Product Type: {2}, Name: {0}, Price: {1}",
                    Products[i].Name, Products[i].Price, Products.ElementAt(i - 1).Value);
            }
        }

        public static void ReadAllClients()
        {
            //This method prints out every client that exists in collecion, with all of its properties
            foreach (var client in Clients)
            {
                Console.WriteLine("Client Name: {0} {1}, Street: {2}, City: {3}, Year of birth: {4}",
                    client.Name, client.Surname, client.Street, client.City, client.BirthYear);
            }
        }

        static void ReadAlltransactions()
        {
            //TODO
        }

        static void GetSpecificProduct()
        {
            //TODO
        }

        static void GetSpecificClient()
        {
            //TODO
        }

        static void GetSpecificTransaction()
        {
            //TODO
        }

        #endregion

    }
}
