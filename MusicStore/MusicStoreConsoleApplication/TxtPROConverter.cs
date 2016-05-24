using MusicStore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreConsoleApplication
{
    public class TxtPROConverter : IConverter
    {
        public Client readClient(string path)
        {
            string[] parts = FileToString(path)[0].Split(';');
            try
            {
                if (parts.Length < 5)
                {
                    throw new Exception("Niewłaściwa liczba argumentów");
                }
                return new Client(parts[0], parts[1], parts[2], parts[3], Int32.Parse(parts[4]));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public List<Client> readClientsList(string path)
        {
            List<Client> clients = new List<Client>();
            foreach (string line in FileToString(path))
            {
                string[] parts = line.Split(';');
                if (parts.Length >= 5)
                {
                    clients.Add(new Client(parts[0], parts[1], parts[2], parts[3], Int32.Parse(parts[4])));
                }
            }
            return clients;
        }

        public Product readProduct(string path)
        {
            string[] parts = FileToString(path)[0].Split(';');
            try
            {
                if (parts.Length < 2)
                {
                    throw new Exception("Niewłaściwa liczba argumentów");
                }
                return new Product(parts[0], Double.Parse(parts[1]));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public Dictionary<int, Product> readProductsDictionary(string path)
        {
            Dictionary<int, Product> products = new Dictionary<int, Product>();
            foreach (string line in FileToString("products.txt"))
            {
                string[] parts = line.Split(';');
                if (parts.Length >= 3)
                {
                    products.Add(Int32.Parse(parts[0]), new Product(parts[1], Double.Parse(parts[2])));
                }
            }
            return products;
        }

        public Transaction readTransaction(string path)
        {
            string[] parts = FileToString(path)[0].Split(';');
            try
            {
                if (parts.Length < 3)
                {
                    throw new Exception("Niewłaściwa liczba argumentów");
                }
                return new Transaction(Int32.Parse(parts[0]), Int32.Parse(parts[1]), parts[2]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public ObservableCollection<Transaction> readTransactionsObservableCollection(string path)
        {
            ObservableCollection<Transaction> transactions = new ObservableCollection<Transaction>();
            foreach (string line in FileToString("transactions.txt"))
            {
                string[] parts = line.Split(';');
                if (parts.Length >= 3)
                {
                    transactions.Add(new Transaction(Int32.Parse(parts[0]), Int32.Parse(parts[1]), parts[2]));
                }
            }
            return transactions;
        }

        public void writeClientsList(List<Client> collection, string path)
        {
            StringBuilder serializedData = new StringBuilder();
            foreach (Client cl in collection)
            {
                serializedData.Append(cl.ToSerialize());
                serializedData.AppendLine();
            }
            File.WriteAllText(path, serializedData.ToString());
        }

        public void writeProductsDictionary(Dictionary<int, Product> collection, string path)
        {
            StringBuilder serializedData = new StringBuilder();
            foreach (var pair in collection)
            {
                serializedData.Append(String.Format("{0};{1}", pair.Key, pair.Value.ToSerialize()));
                serializedData.AppendLine();
            }
            File.WriteAllText(path, serializedData.ToString());
        }

        public void writeTransactionsObservableCollection(ObservableCollection<Transaction> collection, string path)
        {
            StringBuilder serializedData = new StringBuilder();
            foreach (Transaction tr in collection)
            {
                serializedData.Append(tr.ToSerialize());
                serializedData.AppendLine();
            }
            File.WriteAllText(path, serializedData.ToString());
        }

        public void writeObject(object obj, string path)
        {
            try
            {
                if (obj as ITXTSerializable == null)
                {
                    throw new Exception("Serializacja nieobsługiwanego typu.");
                }
                string serData = ((ITXTSerializable)obj).ToSerialize();
                File.WriteAllText(path, serData);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        private List<string> FileToString(string FilePath)
        {
            return File.ReadLines(FilePath).ToList();
        }
    }
}
