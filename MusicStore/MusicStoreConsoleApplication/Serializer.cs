using MusicStore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStoreConsoleApplication
{
    public class Serializer
    {
        public readonly bool mode;
        private string filePath;
        public object SerializedObject { get; set; }

        public Serializer()
        {
            Console.WriteLine("Ścieżka do pliku: ");
            filePath = Console.ReadLine();
            mode = chooseSerializationMode();
        }

        public void startSerializer()
        {
            if (SerializedObject != null)
            {
                string format = chooseSerializationFormat();
                string data = chooseDataToSerialization();
                beginSerialization(format + data); 
            }
        }

        public void startDeserializer()
        {
            string format = chooseSerializationFormat();
            string data = chooseDataToSerialization();
            SerializedObject = beginDeserialization(format + data);
        }

        public bool chooseSerializationMode()
        {
            Console.WriteLine("Co chcesz zrobić?\n1.Serializacja\n2.Deserializacja");
            if (Console.ReadLine().Contains("1")) return true;
            else return false;
        }

        private string chooseSerializationFormat()
        {
            Console.WriteLine("Jaki format chcesz wykorzystać?\n1.XML\n2.JSON\n3.Binary");
            string answer = Console.ReadLine();
            if (answer.Contains("1")) return "xml";
            else if (answer.Contains("2")) return "json";
            else return "bin";
        }

        private string chooseDataToSerialization()
        {
            Console.WriteLine("Jakie dane wykorzystać?\n1.Pojedynczego klienta\n2.Pojedynczy produkt\n3.Pojedynczą transakcję\n4.Listę klientów\n5.Obserwowaną kolekcję transakcji\n6.Słownik produktów");
            string answer = Console.ReadLine();
            if (answer.Contains("1")) return "c";
            else if (answer.Contains("2")) return "p";
            else if (answer.Contains("3")) return "t";
            else if (answer.Contains("4")) return "lc";
            else if (answer.Contains("5")) return "oct";
            else return "dp";
        }

        private void beginSerialization(string answer)
        {
            XMLConverter xc = new XMLConverter();
            JSONConverter jc = new JSONConverter();
            BinaryConverter bc = new BinaryConverter();
            switch(answer)
            {
                case "xmlc":
                case "xmlp":
                case "xmlt":
                    xc.writeObject(SerializedObject, filePath);
                    break;
                case "xmllc":
                    xc.writeClientsList((List<Client>)SerializedObject, filePath);
                    break;
                case "xmloct":
                    xc.writeTransactionsObservableCollection((ObservableCollection<Transaction>)SerializedObject, filePath);
                    break;
                case "xmldp":
                    xc.writeProductsDictionary((Dictionary<int, Product>)SerializedObject, filePath);
                    break;
                case "jsonc":
                case "jsonp":
                case "jsont":
                    jc.writeObject(SerializedObject, filePath);
                    break;
                case "jsonlc":
                    jc.writeClientsList((List<Client>)SerializedObject, filePath);
                    break;
                case "jsonoct":
                    jc.writeTransactionsObservableCollection((ObservableCollection<Transaction>)SerializedObject, filePath);
                    break;
                case "jsondp":
                    jc.writeProductsDictionary((Dictionary<int, Product>)SerializedObject, filePath);
                    break;
                case "binc":
                case "binp":
                case "bint":
                    bc.writeObject(SerializedObject, filePath);
                    break;
                case "binlc":
                    bc.writeClientsList((List<Client>)SerializedObject, filePath);
                    break;
                case "binoct":
                    bc.writeTransactionsObservableCollection((ObservableCollection<Transaction>)SerializedObject, filePath);
                    break;
                case "bindp":
                    bc.writeProductsDictionary((Dictionary<int, Product>)SerializedObject, filePath);
                    break;
                default:
                    break;

            };
        }

        private object beginDeserialization(string answer)
        {
            XMLConverter xc = new XMLConverter();
            JSONConverter jc = new JSONConverter();
            BinaryConverter bc = new BinaryConverter();
            switch (answer)
            {
                case "xmlc":
                    return xc.readClient(filePath);
                case "xmlp":
                    return xc.readProduct(filePath);
                case "xmlt":
                    return xc.readTransaction(filePath);
                case "xmllc":
                    return xc.readClientsList(filePath);
                case "xmloct":
                    return xc.readTransactionsObservableCollection(filePath);
                case "xmldp":
                    return xc.readProductsDictionary(filePath);
                case "jsonc":
                    return jc.readClient(filePath);
                case "jsonp":
                    return jc.readProduct(filePath);
                case "jsont":
                    return jc.readTransaction(filePath);
                case "jsonlc":
                    return jc.readClientsList(filePath);
                case "jsonoct":
                    return jc.readTransactionsObservableCollection(filePath);
                case "jsondp":
                    return jc.readProductsDictionary(filePath);
                case "binc":
                    return bc.readClient(filePath);
                case "binp":
                    return bc.readProduct(filePath);
                case "bint":
                    return bc.readTransaction(filePath);
                case "binlc":
                    return bc.readClientsList(filePath);
                case "binoct":
                    return bc.readTransactionsObservableCollection(filePath);
                case "bindp":
                    return bc.readProductsDictionary(filePath);
                default:
                    return null;

            };
        }
    }
}
