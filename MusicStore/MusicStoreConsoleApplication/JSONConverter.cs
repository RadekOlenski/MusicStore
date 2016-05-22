using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MusicStore;
using Newtonsoft.Json;
using System.IO;

namespace MusicStoreConsoleApplication
{
    public class JSONConverter : IConverter
    {
        public Client readClient(string path)
        {
            return readObject<Client>(path);
        }

        public Dictionary<int, Product> readProductsDictionary(string path)
        {
            return readObject<Dictionary<int, Product>>(path);
        }

        public List<Client> readClientsList(string path)
        {
            return readObject<List<Client>>(path);
        }

        public ObservableCollection<Transaction> readTransactionsObservableCollection(string path)
        {
            return readObject<ObservableCollection<Transaction>>(path);
        }    

        public Product readProduct(string path)
        {
            return readObject<Product>(path);
        }

        public Transaction readTransaction(string path)
        {
            return readObject<Transaction>(path);
        }

        public void writeTransactionsObservableCollection(ObservableCollection<Transaction> collection, string path)
        {
            writeObject(collection, path);
        }

        public void writeProductsDictionary(Dictionary<int, Product> collection, string path)
        {
            writeObject(collection, path);
        }

        public void writeClientsList(List<Client> collection, string path)
        {
            writeObject(collection, path);
        }

        public void writeObject(object obj, string path)
        {
            JsonSerializer serializer = new JsonSerializer();
            using (StreamWriter sw = new StreamWriter(path))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, obj);
            }
        }

        private T readObject<T>(string path)
        {
            JsonSerializer deserializer = new JsonSerializer();
            using (StreamReader sw = new StreamReader(path))
            using (JsonReader reader = new JsonTextReader(sw))
            {
                return deserializer.Deserialize<T>(reader);
            }
        }
    }
}
