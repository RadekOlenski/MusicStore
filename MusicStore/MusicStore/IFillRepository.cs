using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore
{
    public interface IFillRepository
    {
        void CreateClients(List<Client> Clients);
        void CreateProducts(Dictionary<int, Product> Products);
        void CreateTransactions(ObservableCollection<Transaction> Transactions);
    }
}
