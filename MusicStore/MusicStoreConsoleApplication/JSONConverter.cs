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
            JsonSerializer deserializer = new JsonSerializer();
            using (StreamReader sw = new StreamReader(path))
            using (JsonReader reader = new JsonTextReader(sw))
            {
                return deserializer.Deserialize<Client>(reader);
            }
        }

        public Dictionary<int, Product> readDictionary(string path)
        {
            JsonSerializer deserializer = new JsonSerializer();
            using (StreamReader sw = new StreamReader(path))
            using (JsonReader reader = new JsonTextReader(sw))
            {
                return deserializer.Deserialize<Dictionary<int, Product>>(reader);
            }
        }

        public List<Client> readList(string path)
        {
            JsonSerializer deserializer = new JsonSerializer();
            using (StreamReader sw = new StreamReader(path))
            using (JsonReader reader = new JsonTextReader(sw))
            {
                return deserializer.Deserialize<List<Client>>(reader);
            }
        }

        public ObservableCollection<Transaction> readObservableCollection(string path)
        {
            JsonSerializer deserializer = new JsonSerializer();
            using (StreamReader sw = new StreamReader(path))
            using (JsonReader reader = new JsonTextReader(sw))
            {
                return deserializer.Deserialize<ObservableCollection<Transaction>>(reader);
            }
        }

        public Product readProduct(string path)
        {
            JsonSerializer deserializer = new JsonSerializer();
            using (StreamReader sw = new StreamReader(path))
            using (JsonReader reader = new JsonTextReader(sw))
            {
                return deserializer.Deserialize<Product>(reader);
            }
        }

        public Transaction readTransaction(string path)
        {
            JsonSerializer deserializer = new JsonSerializer();
            using (StreamReader sw = new StreamReader(path))
            using (JsonReader reader = new JsonTextReader(sw))
            {
                return deserializer.Deserialize<Transaction>(reader);
            }
        }

        public void writeCollection(ObservableCollection<Transaction> collection, string path)
        {
            JsonSerializer serializer = new JsonSerializer();

            using (StreamWriter sw = new StreamWriter(path))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, collection);
            }
        }

        public void writeCollection(Dictionary<int, Product> collection, string path)
        {
            JsonSerializer serializer = new JsonSerializer();

            using (StreamWriter sw = new StreamWriter(path))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, collection);
            }
        }

        public void writeCollection(List<Client> collection, string path)
        {
            JsonSerializer serializer = new JsonSerializer();

            using (StreamWriter sw = new StreamWriter(path))
            using (JsonWriter writer = new JsonTextWriter(sw))
            {
                serializer.Serialize(writer, collection);
            }
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
    }
}
