using MusicStore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreConsoleApplication
{
    interface IConverter
    {
        void writeObject(object obj, string path);

        void writeClientsList(List<Client> collection, string path);
        void writeTransactionsObservableCollection(ObservableCollection<Transaction> collection, string path);
        void writeProductsDictionary(Dictionary<int, Product> collection, string path);

        Product readProduct(string path);
        Transaction readTransaction(string path);
        Client readClient(string path);
        List<Client> readClientsList(string path);
        ObservableCollection<Transaction> readTransactionsObservableCollection(string path);
        Dictionary<int, Product> readProductsDictionary(string path);

    }
}
