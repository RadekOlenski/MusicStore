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
        //Do dictionary ??
        //public class item
        //{
        //    [XmlAttribute]
        //    public int id;
        //    [XmlAttribute]
        //    public Product product;
        //}

        public Product readProduct(string path)
        {
            //TODO: jak rozwiązać różne typy produktów ???
            //XmlSerializer ser = new XmlSerializer(typeof(Keyboard));
            //using (FileStream fs = File.OpenRead(path))
            //{
            //    object obj = ser.Deserialize(fs);
            //    return (Keyboard)obj;
            //}
            return null;
        }

        public void writeCollection(Dictionary<int, Product> collection, string path)
        {
            //TODO: Serializacja Dictionary!
            //XmlSerializer ser = new XmlSerializer(typeof(item[]), new XmlRootAttribute() { ElementName = "items" });
            //using (FileStream fs = File.Create(path))
            //{
            //    ser.Serialize(fs, collection.Select(n => new item() { id = n.Key, product = n.Value }).ToArray());
            //}
        }

        public void writeCollection(ObservableCollection<Transaction> collection, string path)
        {
            XmlSerializer ser = new XmlSerializer(collection.GetType());
            using (FileStream fs = File.Create(path))
            {
                ser.Serialize(fs, collection);
            }
        }

        public void writeCollection(List<Client> collection, string path)
        {
            XmlSerializer ser = new XmlSerializer(collection.GetType());
            using (FileStream fs = File.Create(path))
            {
                ser.Serialize(fs, collection);
            }
        }

        public void writeObject(object obj, string path)
        {
            XmlSerializer ser = new XmlSerializer(obj.GetType());
            using (FileStream fs = File.Create(path))
            {
                ser.Serialize(fs, obj);
            }
        }

        public Transaction readTransaction(string path)
        {
            XmlSerializer ser = new XmlSerializer(typeof(Transaction));
            using (FileStream fs = File.OpenRead(path))
            {
                return (Transaction)ser.Deserialize(fs);
            }
        }

        public Client readClient(string path)
        {
            XmlSerializer ser = new XmlSerializer(typeof(Client));
            using (FileStream fs = File.OpenRead(path))
            {
                return (Client)ser.Deserialize(fs);
            }
        }

        public List<object> readList(string path)
        {
            //XmlSerializer ser = new XmlSerializer(typeof(object));
            //using (FileStream fs = File.OpenRead(path))
            //{
            //    return ser.Deserialize(fs);
            //}
            return null;
        }

        public ObservableCollection<object> readObservableCollection(string path)
        {
            throw new NotImplementedException();
        }

        public Dictionary<int, object> readDictionary(string path)
        {
            throw new NotImplementedException();
        }
    }
    }
