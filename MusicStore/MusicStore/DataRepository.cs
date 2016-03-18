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
        #region Data Collections
        static List<Client> Clients;
        static Dictionary<int, Product> Products;
        static ObservableCollection<Transaction> Transactions;
        #endregion

        static DataRepository()
        {
            Clients = new List<Client>();
            Products = new Dictionary<int, Product>();
            Transactions = new ObservableCollection<Transaction>();
        }

        #region Data Creation Methods
        public static void CreateProduct(int Type, string Name, double Price)
        {
            switch(Type)
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
            Clients.Add(new Client(Name, Surname, Street, City, BirthYear));
        }

        public static void CreateTransaction()
        {

        }
        #endregion

        #region Data Read Methods

        static void ReadAllProducts()
        {
            
        }

        static void ReadAllClients()
        {

        }

        static void ReadAlltransactions()
        {

        }

        static void GetSpecificProduct()
        {

        }

        static void GetSpecificClient()
        {

        }

        static void GetSpecificTransaction()
        {

        }

        #endregion

    }
}
