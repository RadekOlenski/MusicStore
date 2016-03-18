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
        List<Clients> Clients;
        Dictionary<string, Product> Products;
        ObservableCollection<Transactions> Transactions;
        #endregion

        #region Data Methods

        #endregion

    }
}
