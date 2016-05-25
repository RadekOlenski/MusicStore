using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using MusicStore;
using System.Runtime.Serialization;
using System.Xml;

namespace MusicStoreConsoleApplication
{
    public class XMLConverter : IConverter
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
            string s = File.ReadAllText(path);
            using (StreamReader sr = new StreamReader(path))
            {
                List<Type> knownTypes = new List<Type> { typeof(Keyboard), typeof(Guitar), typeof(LiveAlbum), typeof(LongPlay) };
                DataContractSerializer ser = new DataContractSerializer(typeof(Dictionary<int, Product>), knownTypes);
                return ser.ReadObject(sr.BaseStream) as Dictionary<int, Product>;
            }
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

        public void writeProductsDictionary(Dictionary<int, Product> collection, string path)
        {
            using (StringWriter sw = new StringWriter())
            using (XmlTextWriter writer = new XmlTextWriter(sw))
            {
                writer.Formatting = Formatting.Indented;
                List<Type> knownTypes = new List<Type> { typeof(Keyboard), typeof(Guitar), typeof(LiveAlbum), typeof(LongPlay) };
                DataContractSerializer ser = new DataContractSerializer(typeof(Dictionary<int, Product>), knownTypes);
                ser.WriteObject(writer, collection);
                File.WriteAllText(path, sw.ToString());
            }
        }

        public void writeTransactionsObservableCollection(ObservableCollection<Transaction> collection, string path)
        {
            writeObject(collection, path);
        }

        public void writeObject(object obj, string path)
        {
            using (FileStream fs = File.Create(path))
            {
                XmlSerializer ser = new XmlSerializer(obj.GetType());
                ser.Serialize(fs, obj);
            }
        }

        private T readObject<T>(string path)
        {
            using (FileStream fs = File.OpenRead(path))
            {
                XmlSerializer ser = new XmlSerializer(typeof(T));
                return (T)ser.Deserialize(fs);
            }
        }
    }
}
