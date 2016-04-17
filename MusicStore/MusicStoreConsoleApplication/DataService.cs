using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.ConsoleApplication
{
    public class DataService
    {
        #region Constructors
        public DataService(DataRepository DataRepository)
        {
            this.DataRepository = DataRepository;
            DataRepository.GetAllTransactions().CollectionChanged += DataService_CollectionChanged;
        }
        public DataService()
        {

        }
        #endregion

        #region Properties
        public DataRepository DataRepository { get; set; }

        #endregion

        #region Transactions Actions Handling
        private void DataService_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            Console.WriteLine("Action: {0}", e.Action);
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                Console.WriteLine("Message: New transaction has been added.\nDetails:");
                foreach (Transaction trans in e.NewItems)
                {
                    Console.WriteLine(trans.ToString());
                }
                Console.WriteLine();
            }
            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                Console.WriteLine("Message: New transaction has been removed.\nDetails:");
                foreach (Transaction trans in e.OldItems)
                {
                    Console.WriteLine(trans.ToString());
                }
                Console.WriteLine();
            }
        } 
        #endregion

        #region Read Methods

        public string ReadAllClients()
        {
            return DataRepository.ReadAllClients();
        }

        public string ReadAllProducts()
        {
            return DataRepository.ReadAllProducts();
        }

        public string ReadAllTransactions()
        {
            return DataRepository.ReadAllTransactions();
        }

        public string GetSpecificClient(int ID)
        {
            return DataRepository.GetSpecificClient(ID);
        }

        #endregion

        #region Client Edition Methods

        public void UpdateClientName(int ClientID, string NewValue)
        {
            DataRepository.UpdateClientName(ClientID, NewValue);
        }

        public void UpdateClientSurname(int ClientID, string NewValue)
        {
            DataRepository.UpdateClientSurname(ClientID, NewValue);
        }

        public void UpdateClientStreet(int ClientID, string NewValue)
        {
            DataRepository.UpdateClientStreet(ClientID, NewValue);
        }

        public void UpdateClientCity(int ClientID, string NewValue)
        {
            DataRepository.UpdateClientCity(ClientID, NewValue);
        }

        public void UpdateClientBirthYear(int ClientID, int NewValue)
        {
            DataRepository.UpdateClientBirthYear(ClientID, NewValue);
        }

        #endregion

        #region Product Edition Methods

        public void UpdateProductName(int ProductID, string NewValue)
        {
            DataRepository.UpdateClientName(ProductID, NewValue);
        }

        public void UpdateProductPrice(int ProductID, double NewValue)
        {
            DataRepository.UpdateProductPrice(ProductID, NewValue);
        }

        #endregion

        #region Delete Methods

        public void DeleteClient(int ID)
        {
            DataRepository.DeleteClient(ID);
        }

        public void DeleteProduct(int ID)
        {
            DataRepository.DeleteProduct(ID);
        }

        public void DeleteTransaction(int ID)
        {
            DataRepository.DeleteTransaction(ID);
        }

        #endregion

        #region Filter Methods

        public void FilterByClientAge(int RequiredAge)
        {
            DataRepository.FilterByClientAge(RequiredAge);
        }

        public void FilterByGreaterProductPrice(double RequiredPrice)
        {
            DataRepository.FilterByGreaterProductPrice(RequiredPrice);
        }

        #endregion

        #region Count Objects
        public int CountClients()
        {
           return DataRepository.CountClients();
        }

        public int CountProducts()
        {
           return DataRepository.CountProducts();
        }

        public int CountTransactions()
        {
           return DataRepository.CountTransactions();
        }
        #endregion
    }
}
