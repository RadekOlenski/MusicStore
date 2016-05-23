using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using MusicStore;

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

        public void writeProductsDictionary(Dictionary<int, Product> collection, string path)
        {
            writeObject(collection, path);
        }

        public void writeTransactionsObservableCollection(ObservableCollection<Transaction> collection, string path)
        {
            writeObject(collection, path);
        }

        public void writeObject(object obj, string path)
        {
            XmlSerializer ser = new XmlSerializer(obj.GetType());
            using (FileStream fs = File.Create(path))
            {
                ser.Serialize(fs, obj);
            }
        } 

        private T readObject<T>(string path)
        {
            XmlSerializer ser = new XmlSerializer(typeof(T));
            using (FileStream fs = File.OpenRead(path))
            {
                return (T)ser.Deserialize(fs);
            }
        }
    }
   }
