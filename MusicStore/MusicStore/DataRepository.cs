#region includes
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

//Class responsible for storing all data in project
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
        //Property used to gain access to FillRepository Interface implementation, realized with Dependency Injection.
        public IFillRepository FillRepository { get; set; }
        #endregion

        #region Data Collections
        //Declarations of objects collections.
        List<Client> Clients;
        Dictionary<int, Product> Products;
        ObservableCollection<Transaction> Transactions;
        #endregion

        #region Fill Repository Methods
        //This is usage of methods provided from FillRepository Interface implementation applied with Dependency Injection to FillRepository property
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
        //Methods that can be used to create new object of any type: product, client, transaction
        public void CreateProduct(ProductType Type, string Name, double Price)
        {
            //Function adds new Product to the Products Dictionary, according to the Type of product selected by user 
            //Selected type is checking with ProductType enumerable type
            //int ID = Product.GeneralProductID;
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
            //ID++;
            //if(!Products.ContainsKey(ID))
            //{
            //    throw new NullReferenceException("Product was not created!");
            //}
        }

        public void CreateClient(string Name, string Surname, string Street, string City, int BirthYear)
        {
            //This method add new Client to the Clients List, with all object properties given by user
            //int ID = Clients.Count;
            Clients.Add(new Client(Name, Surname, Street, City, BirthYear));
            //    ID++;
            //if (Clients.ElementAt(ID) == null)
            //{
            //    throw new NullReferenceException("Client was not created!");
            //}
        }

        public void CreateTransaction(int ClientID, int ProductID, string Date)
        {
            //This method add new Transaction to the Transactions Observable Collection, with all object properties given by user
            //int ID = Transactions.Count;
            Transactions.Add(new Transaction(ClientID, ProductID, Date));
            //ID++;
            //if (Transactions.ElementAt(ID) == null)
            //{
            //    throw new NullReferenceException("Transaction was not created!");
            //}
        }
        #endregion

        #region Data Read Methods
        //Methods used to pull out informations about every object in repository, together or individually
        public string ReadAllProducts()
        {
            //This method returns string with info about every product from collection
            if (Products.ContainsKey(0))
            {
                string result = "";
                for (int i = 0; i < Products.Count; i++)
                {
                    result += Products.ElementAt(i).ToString() + "\n";
                }
                return result;
            }
            else
            {
                throw new System.InvalidOperationException("There is no products in repository!");
            }
        }

        public string ReadAllClients()
        {
            //This method returns string with info about every client that exists in collecion
            if (Clients.ElementAt(0) != null)
            {
                string result = "";
                foreach (Client client in Clients)
                {
                    result += client.ToString() + "\n";
                }
                return result;
            }
            else
            {
                throw new System.ArgumentOutOfRangeException("There is no clients in repository!");
            }
        }

        public string ReadAllTransactions()
        {
            //This method returns string with info about every transaction that exists in collecion
            if (Transactions.ElementAt(0) != null)
            {
                string result = "";
                foreach (Transaction transaction in Transactions)
                {
                    result += Clients[transaction.ClientID].ToString() + "\n"
                       + Products[transaction.ProductID].ToString() + "\n"
                       + transaction.ToString() + "\n";
                }
                return result;
            }
            else
            {
                throw new System.ArgumentOutOfRangeException("There is no transactions in repository!");
            }
        }

        public string GetSpecificProduct(int ID)
        {
            //This method returns string with info about single product. User must enter ID of product.
            //In the case that user selected ID that not exists, method is throwing out a new InvalidOperationException 
            if (Products.ContainsKey(ID))
            {
                return Products.ElementAt(ID).ToString();
            }
            else
            {
                throw new System.InvalidOperationException("That product does not exists!");
            }
        }

        public string GetSpecificClient(int ID)
        {
            //This method returns string with info about single client. User must enter ID of client.
            //In the case that user selected ID that not exists, method is throwing out a new ArgumentOutOfRangeException
            if (Clients.ElementAt(ID) != null)
            {
                return Clients.ElementAt(ID).ToString();
            }
            else
            {
                throw new System.ArgumentOutOfRangeException("That client does not exists!");
            }
        }

        public string GetSpecificTransaction(int ID)
        {
            //This method returns string with info about single transaction. User must enter ID of transaction.
            //In the case that user selected ID that not exists, method is throwing out a new ArgumentOutOfRangeException
            if (Transactions.ElementAt(ID) != null)
            {
                return Clients[Transactions[ID].ClientID].ToString() + "\n"
                       + Products[Transactions[ID].ProductID].ToString() + "\n" 
                       + Transactions.ElementAt(ID).ToString() + "\n";
            }
            else
            {
                throw new System.ArgumentOutOfRangeException("That transaction does not exists!");
            }
        }

        #endregion

        #region Data Update Client Collection
        //Methods used to update informations about client selected by user 
        //In case that user selected client that not exists, method is throwing out ArgumentOutOfRangeException
        public void UpdateClientName(int ClientID, string NewValue)
        {
            if (Clients.ElementAt(ClientID) != null)
            {
                Clients[ClientID].Name = NewValue;
            }
            else
            {
                throw new ArgumentOutOfRangeException("That client does not exists!");
            }
        }

        public void UpdateClientSurname(int ClientID, string NewValue)
        {
            if (Clients.ElementAt(ClientID) != null)
            {
                Clients[ClientID].Surname = NewValue;
            }
            else
            {
                throw new ArgumentOutOfRangeException("That client does not exists!");
            }
        }

        public void UpdateClientStreet(int ClientID, string NewValue)
        {
            if (Clients.ElementAt(ClientID) != null)
            {
                Clients[ClientID].Street = NewValue;
            }
            else
            {
                throw new ArgumentOutOfRangeException("That client does not exists!");
            }
        }

        public void UpdateClientCity(int ClientID, string NewValue)
        {
            if (Clients.ElementAt(ClientID) != null)
            {
                Clients[ClientID].City = NewValue;
            }
            else
            {
                throw new ArgumentOutOfRangeException("That client does not exists!");
            }
        }

        public void UpdateClientBirthYear(int ClientID, int NewValue)
        {
            if (Clients.ElementAt(ClientID) != null)
            {
                Clients[ClientID].BirthYear = NewValue;
            }
            else
            {
                throw new ArgumentOutOfRangeException("That client does not exists!");
            }
        }

        #endregion

        #region Data Update Product Collection
        //Methods used to update informations about product selected by user 
        //In case that user selected product that not exists, method is throwing out InvalidOperationException
        public void UpdateProductName(int ProductID, string NewValue)
        {
            if (Products.ContainsKey(ProductID))
            {
                Products[ProductID].Name = NewValue;
            }
            else
            {
                throw new System.InvalidOperationException("That product does not exists!");
            }
        }

        public void UpdateProductPrice(int ProductID, double NewValue)
        {
            if (Products.ContainsKey(ProductID))
            {
                Products[ProductID].Price = NewValue;
            }
            else
            {
                throw new System.InvalidOperationException("That product does not exists!");
            }
        }
        #endregion

        #region Object Delete Methods
        //Methods used to delete specific object from collections
        public void DeleteClient(int ID)
        {
            if (Clients.ElementAt(ID) != null)
            {
                Clients.Remove(Clients.ElementAt(ID));
            }
            else
            {
                throw new System.InvalidOperationException("That product does not exists!");
            }
        }

        public void DeleteProduct(int ID)
        {
            if (Products.ContainsKey(ID))
            {
                Products.Remove(ID);
                Product.DeleteProductID();
            }
            else
            {
                throw new System.InvalidOperationException("That product does not exists!");
            }
        }

        public void DeleteTransaction(int ID)
        {
            if (Transactions.ElementAt(ID) != null)
            {
                Transactions.RemoveAt(ID);
            }
            else
            {
                throw new System.InvalidOperationException("That transaction does not exists!");
            }
        }
        #endregion

        #region Data Filters
        //Methods used to filter objects in collections by some properties
        //Every method returns string with objects info with applied filter
        public string FilterByClientAge(int RequiredAge)
        {
            if (Clients.ElementAt(0) != null)
            {
                string result = "";
                for (int i = 0; i < Clients.Count; i++)
                {
                    if (DateTime.Now.Year - Clients.ElementAt(i).BirthYear >= RequiredAge)
                    {
                        result += GetSpecificClient(i);
                    }
                }
                return result;
            }
            else
            {
                throw new System.InvalidOperationException("There is no clients in repository!");
            }
        }

        public string FilterByGreaterProductPrice(double RequiredPrice)
        {
            if (Products.ContainsKey(0))
            {
                string result = "";
                foreach (KeyValuePair<int, Product> product in Products)
                {
                    if (product.Value.Price > RequiredPrice)
                    {
                        result += GetSpecificProduct(product.Key);
                    }
                }
                return result;
            }
            else
            {
                throw new System.InvalidOperationException("That product does not exists!");
            }
        }
        #endregion
    }
}
