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
            //This method prints out every product from collection, with all of its properties and Object Type
            for (int i = 0; i < Products.Count; i++)
            {
                Console.WriteLine("Product Type: {0}, Name: {1}, Price: {2}",
                    Products.ElementAt(i).Value, Products[i].Name, Products[i].Price);
            }
        }

        public static void ReadAllClients()
        {
            //This method prints out every client that exists in collecion, with all of its properties
            foreach (Client client in Clients)
            {
                Console.WriteLine("Client Name: {0} {1}, Street: {2}, City: {3}, Year of birth: {4}",
                    client.Name, client.Surname, client.Street, client.City, client.BirthYear);
            }
        }

        public static void ReadAllTransactions()
        {
            foreach (Transaction transaction in Transactions)
            {
                Console.WriteLine("Client Name: {0} {1}, Product Name: {2}, Price: {3}, Date: {4}",
                    Clients[transaction.ClientID].Name, Clients[transaction.ClientID].Surname,
                    Products[transaction.ProductID].Name, Products[transaction.ProductID].Price, transaction.Date);
            }
        }

        public static void GetSpecificProduct(int ID)
        {
            Console.WriteLine("Product Type: {0}, Name: {1}, Price: {2}",
                     Products.ElementAt(ID).Value, Products[ID].Name, Products[ID].Price);
        }

        public static void GetSpecificClient(int ID)
        {
            Console.WriteLine("Client Name: {0} {1}, Street: {2}, City: {3}, Year of birth: {4}",
                    Clients[ID].Name, Clients[ID].Surname, Clients[ID].Street, Clients[ID].City, Clients[ID].BirthYear);
        }

        public static void GetSpecificTransaction(int ID)
        {
            Console.WriteLine("Client Name: {0} {1}, Product Name: {2}, Price: {3}, Date: {4}",
                   Clients[Transactions[ID].ClientID].Name, Clients[Transactions[ID].ClientID].Surname,
                   Products[Transactions[ID].ProductID].Name, Products[Transactions[ID].ProductID].Price, Transactions[ID].Date);
        }

        #endregion

        #region Data Update Client Collection

        public static void UpdateClientName(int ClientID, string NewValue)
        {
            Clients[ClientID].Name = NewValue;
        }

        public static void UpdateClientSurname(int ClientID, string NewValue)
        {
            Clients[ClientID].Surname = NewValue;
        }

        public static void UpdateClientStreet(int ClientID, string NewValue)
        {
            Clients[ClientID].Street = NewValue;
        }

        public static void UpdateClientCity(int ClientID, string NewValue)
        {
            Clients[ClientID].City = NewValue;
        }

        public static void UpdateClientBirthYear(int ClientID, int NewValue)
        {
            Clients[ClientID].BirthYear = NewValue;
        }

        #endregion

        #region Data Update Product Collection

        public static void UpdateProductName (int ProductID, string NewValue)
        {
            Products[ProductID].Name = NewValue;
        }

        public static void UpdateProductPrice(int ProductID, double NewValue)
        {
            Products[ProductID].Price = NewValue;
        }

        #endregion

        #region Object Delete Methods

        public static void DeleteClient(int ID)
        {
           Clients.Remove(Clients.ElementAt(ID));
        }

        public static void DeleteProduct(int ID)
        {
            Products.Remove(ID);
        }

        public static void DeleteTransaction(int ID)
        {
            Transactions.RemoveAt(ID);
        }

        #endregion

        #region Data Filters

        public static void FilterByClientAge (int RequiredAge)
        {
            foreach (Client client in Clients)
            {
                if (DateTime.Now.Year - client.BirthYear >= RequiredAge)
                {
                    GetSpecificClient(client.GetClientID());
                }
            }
        }

        #endregion
    }
}
