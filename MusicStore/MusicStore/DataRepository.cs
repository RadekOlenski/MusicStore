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
    class DataRepository
    {
        #region Data Collections
        List<Client> Clients;
        Dictionary<string, Product> Products;
        ObservableCollection<Transaction> Transactions;
        #endregion

        #region Data Creation Methods
        void CreateProduct()
        {

        }

        void CreateClient()
        {

        }

        void CreateTransaction()
        {

        }

        #endregion

        #region Data Read Methods

        void ReadAllProducts()
        {
            
        }

        void ReadAllClients()
        {

        }

        void ReadAlltransactions()
        {

        }

        void GetSpecificProduct()
        {

        }

        void GetSpecificClient()
        {

        }

        void GetSpecificTransaction()
        {

        }

        #endregion

    }
}
