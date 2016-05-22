using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicStore;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace MusicStoreConsoleApplication
{
    public class BinaryConverter : IConverter
    {
        public Client readClient(string path)
        {
            return readObject<Client>(path);
        }

        public List<Client> readClientsList(string path)
        {
            return readObject<List<Client>>(path);
        }

        public Product readProduct(string path)
        {
            return readObject<Product>(path);
        }

        public Dictionary<int, Product> readProductsDictionary(string path)
        {
            return readObject<Dictionary<int, Product>>(path);
        }

        public Transaction readTransaction(string path)
        {
            return readObject<Transaction>(path);
        }

        public ObservableCollection<Transaction> readTransactionsObservableCollection(string path)
        {
            return readObject<ObservableCollection<Transaction>>(path);
        }

        public void writeClientsList(List<Client> collection, string path)
        {
            writeObject(collection, path);
        }

        public void writeObject(object obj, string path)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.Create))
            {
                formatter.Serialize(fs, obj);
            }
        }

        public void writeProductsDictionary(Dictionary<int, Product> collection, string path)
        {
            writeObject(collection, path);
        }

        public void writeTransactionsObservableCollection(ObservableCollection<Transaction> collection, string path)
        {
            writeObject(collection, path);
        }

        private T readObject<T>(string path)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream(path, FileMode.Open))
            {
                return (T)formatter.Deserialize(fs);
            }
        }
    }
}
