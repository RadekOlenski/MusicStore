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
    public class DataRepository
    {
        #region Constructor
        public DataRepository()
        {
            //Initialization of collections
            Clients = new List<Client>();
            Products = new Dictionary<int, Product>();
            Transactions = new ObservableCollection<Transaction>();
            //ClientsIDCounter = 0;
            //ProductsIDCounter = 0;
        }

        #endregion

        #region Properties

        //public static int ClientsIDCounter { get; set; }
        //public static int ProductsIDCounter { get; set; }

        //Property used to implement Dependency Injection
        public IFillRepository FillRepository { get; set; }
        #endregion

        #region Data Collections
        List<Client> Clients;
        Dictionary<int, Product> Products;
        ObservableCollection<Transaction> Transactions;
        #endregion

        #region Fill Interface Methods
        public void FillClients()
        {
            FillRepository.CreateClients(Clients);
        }
        public void FillProducts()
        {
            FillRepository.CreateProducts(Products);
        }
        public void FillTransactions()
        {
            FillRepository.CreateTransactions(Transactions);
        }
        #endregion

        #region Data Creation Methods
        public void CreateProduct(ProductType Type, string Name, double Price)
        {
            //Function adds new product to the Products Dictionary, according to the Type of product passed from database
            switch (Type)
            {
                case ProductType.Guitar:
                    Products.Add(Product.GenerateProductID(), new Guitar(Name, Price));
                    break;
                case ProductType.Keyboard:
                    Products.Add(Product.GenerateProductID(), new Keyboard(Name, Price));
                    break;
                case ProductType.Longplay:
                    Products.Add(Product.GenerateProductID(), new LongPlay(Name, Price));
                    break;
                case ProductType.LiveAlbum:
                    Products.Add(Product.GenerateProductID(), new LiveAlbum(Name, Price));
                    break;
            }
        }

        public void CreateClient(string Name, string Surname, string Street, string City, int BirthYear)
        {
            //This method add new Client object to the Clients List, with all object properties passed from database 
            Clients.Add(new Client(Name, Surname, Street, City, BirthYear));
        }

        public void CreateTransaction(int ClientID, int ProductID, string Date)
        {
            Transactions.Add(new Transaction(ClientID, ProductID, Date));
        }
        #endregion

        #region Data Read Methods
        public string ReadAllProducts()
        {
            //This method prints out every product from collection, with all of its properties and Object Type
            string result = "";
            for (int i = 0; i < Products.Count; i++)
            {
                //Console.WriteLine("Product Type: {0}, Name: {1}, Price: {2}",
                //    Products.ElementAt(i).Value, Products[i].Name, Products[i].Price);
                result += "Product Type: " + Products.ElementAt(i).Value + ", Name: " + Products[i].Name
                    + ", Price: " + Products[i].Price + "\n";
            }
            return result;
        }

        public string ReadAllClients()
        {
            //This method prints out every client that exists in collecion, with all of its properties
            string result = "";
            foreach (Client client in Clients)
            {
                //Console.WriteLine("Client Name: {0} {1}, Street: {2}, City: {3}, Year of birth: {4}",
                //    client.Name, client.Surname, client.Street, client.City, client.BirthYear);
                result += "Client Name: " + client.Name  + " " + client.Surname + ", Street: " + client.Street
                    + ", City: " + client.City + ", Year of birth: " + client.BirthYear + "\n";
            }
            return result;
        }

        public string ReadAllTransactions()
        {
            string result = "";
            foreach (Transaction transaction in Transactions)
            {
                //Console.WriteLine("Client Name: {0} {1}, Product Name: {2}, Price: {3}, Date: {4}",
                //    Clients[transaction.ClientID].Name, Clients[transaction.ClientID].Surname,
                //    Products[transaction.ProductID].Name, Products[transaction.ProductID].Price, transaction.Date);
                result += "Client Name: " + Clients[transaction.ClientID].Name + " "
                    + Clients[transaction.ClientID].Surname + ", Product Name: " + Products[transaction.ProductID].Name
                    + ", Price: " + Products[transaction.ProductID].Price + ", Date: " + transaction.Date + "\n";
            }
            return result;
        }

        public string GetSpecificProduct(int ID)
        {
            string result = "";
            result += "Product Type: " + Products.ElementAt(ID).Value + ", Name: " + Products[ID].Name
                    + ", Price: " + Products[ID].Price + "\n";
            //Console.WriteLine("Product Type: {0}, Name: {1}, Price: {2}",
            //         Products.ElementAt(ID).Value, Products[ID].Name, Products[ID].Price);
            return result;
        }

        public string GetSpecificClient(int ID)
        {
            string result = "";
            result += "Client Name: " + Clients[ID].Name + " " + Clients[ID].Surname + ", Street: " + Clients[ID].Street + ", City: " + Clients[ID].City + ", Year of birth: " + Clients[ID].BirthYear + "\n";
            //Console.WriteLine("Client Name: {0} {1}, Street: {2}, City: {3}, Year of birth: {4}",
            //        Clients[ID].Name, Clients[ID].Surname, Clients[ID].Street, Clients[ID].City, Clients[ID].BirthYear);
            return result;
        }

        public string GetSpecificTransaction(int ID)
        {
            string result = "";
            result += "Client Name: " + Clients[Transactions[ID].ClientID].Name + " "
                    + Clients[Transactions[ID].ClientID].Surname + ", Product Name: " + Products[Transactions[ID].ProductID].Name + ", Price: " + Products[Transactions[ID].ProductID].Price + ", Date: " + Transactions[ID].Date + "\n";
            return result;
            //Console.WriteLine("Client Name: {0} {1}, Product Name: {2}, Price: {3}, Date: {4}",
            //       Clients[Transactions[ID].ClientID].Name, Clients[Transactions[ID].ClientID].Surname,
            //       Products[Transactions[ID].ProductID].Name, Products[Transactions[ID].ProductID].Price, Transactions[ID].Date);
        }

        #endregion

        #region Data Update Client Collection

        public void UpdateClientName(int ClientID, string NewValue)
        {
            Clients[ClientID].Name = NewValue;
        }

        public void UpdateClientSurname(int ClientID, string NewValue)
        {
            Clients[ClientID].Surname = NewValue;
        }

        public void UpdateClientStreet(int ClientID, string NewValue)
        {
            Clients[ClientID].Street = NewValue;
        }

        public void UpdateClientCity(int ClientID, string NewValue)
        {
            Clients[ClientID].City = NewValue;
        }

        public void UpdateClientBirthYear(int ClientID, int NewValue)
        {
            Clients[ClientID].BirthYear = NewValue;
        }

        #endregion

        #region Data Update Product Collection

        public void UpdateProductName(int ProductID, string NewValue)
        {
            Products[ProductID].Name = NewValue;
        }

        public void UpdateProductPrice(int ProductID, double NewValue)
        {
            Products[ProductID].Price = NewValue;
        }

        #endregion

        #region Object Delete Methods

        public void DeleteClient(int ID)
        {
            Clients.Remove(Clients.ElementAt(ID));
        }

        public void DeleteProduct(int ID)
        {
            Products.Remove(ID);
        }

        public void DeleteTransaction(int ID)
        {
            Transactions.RemoveAt(ID);
        }

        #endregion

        #region Data Filters

        public void FilterByClientAge(int RequiredAge)
        {
            foreach (Client client in Clients)
            {
                if (DateTime.Now.Year - client.BirthYear >= RequiredAge)
                {
                    GetSpecificClient(client.GetClientID());
                }
            }
        }

        public void FilterByGreaterProductPrice(double RequiredPrice)
        {
            foreach (KeyValuePair<int, Product> product in Products)
            {
                if (product.Value.Price > RequiredPrice)
                {
                    GetSpecificProduct(product.Key);
                }
            }
        }

        #endregion
    }
}
