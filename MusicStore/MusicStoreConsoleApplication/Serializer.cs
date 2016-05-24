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
        private readonly DataRepository dataRepo;
        private readonly bool mode;
        private readonly string filePath;

        public object DeserializedObject { get; set; }

        public Serializer(DataRepository dataRepo)
        {
            this.dataRepo = dataRepo;
            Console.WriteLine("Ścieżka do pliku: ");
            filePath = Console.ReadLine();
            Console.WriteLine();
            mode = chooseSerializationMode();
        }

        public void start()
        {
            if (mode)
            {
                startSerializer();
            }
            else
            {
                DeserializedObject = startDeserializer();
            }
        }

        public void startSerializer()
        {
            string format = chooseSerializationFormat();
            string data = chooseDataToSerialization();
            beginSerialization(format + data);
        }

        public object startDeserializer()
        {
            string format = chooseSerializationFormat();
            string data = chooseDataToSerialization();
            return beginDeserialization(format + data);
        }

        public bool chooseSerializationMode()
        {
            Console.WriteLine("Co chcesz zrobić?\n1.Serializacja\n2.Deserializacja\n");
            if (Console.ReadLine().Contains("1")) return true;
            else return false;
        }

        private string chooseSerializationFormat()
        {
            Console.WriteLine("Jaki format chcesz wykorzystać?\n1.XML\n2.JSON\n3.Binary\n");
            string answer = Console.ReadLine();
            Console.WriteLine();
            if (answer.Contains("1")) return "xml";
            else if (answer.Contains("2")) return "json";
            else return "bin";
        }

        private string chooseDataToSerialization()
        {
            Console.WriteLine("Jakie dane wykorzystać?\n1.Pojedynczego klienta\n2.Pojedynczy produkt\n3.Pojedynczą transakcję\n4.Listę klientów\n5.Obserwowaną kolekcję transakcji\n6.Słownik produktów\n");
            string answer = Console.ReadLine();
            Console.WriteLine();
            if (answer.Contains("1")) return "c";
            else if (answer.Contains("2")) return "p";
            else if (answer.Contains("3")) return "t";
            else if (answer.Contains("4")) return "lc";
            else if (answer.Contains("5")) return "oct";
            else return "dp";
        }

        private int chooseIndex()
        {
            Console.WriteLine("Pod którym indexem? ");
            return Int32.Parse(Console.ReadLine().Substring(0, 1));
        }

        private void beginSerialization(string answer)
        {
            XMLConverter xc = new XMLConverter();
            JSONConverter jc = new JSONConverter();
            BinaryConverter bc = new BinaryConverter();
            switch (answer)
            {
                case "xmlc":
                    xc.writeObject(dataRepo.GetSpecificClient(chooseIndex()), filePath);
                    break;
                case "xmlp":
                    xc.writeObject(dataRepo.GetSpecificProduct(chooseIndex()), filePath);
                    break;
                case "xmlt":
                    xc.writeObject(dataRepo.GetSpecificTransaction(chooseIndex()), filePath);
                    break;
                case "xmllc":
                    xc.writeClientsList(dataRepo.GetAllClients(), filePath);
                    break;
                case "xmloct":
                    xc.writeTransactionsObservableCollection(dataRepo.GetAllTransactions(), filePath);
                    break;
                case "xmldp":
                    xc.writeProductsDictionary(dataRepo.GetAllProducts(), filePath);
                    break;
                case "jsonc":
                    jc.writeObject(dataRepo.GetSpecificClient(chooseIndex()), filePath);
                    break;
                case "jsonp":
                    xc.writeObject(dataRepo.GetSpecificProduct(chooseIndex()), filePath);
                    break;
                case "jsont":
                    xc.writeObject(dataRepo.GetSpecificTransaction(chooseIndex()), filePath);
                    break;
                case "jsonlc":
                    jc.writeClientsList(dataRepo.GetAllClients(), filePath);
                    break;
                case "jsonoct":
                    jc.writeTransactionsObservableCollection(dataRepo.GetAllTransactions(), filePath);
                    break;
                case "jsondp":
                    jc.writeProductsDictionary(dataRepo.GetAllProducts(), filePath);
                    break;
                case "binc":
                    bc.writeObject(dataRepo.GetSpecificClient(chooseIndex()), filePath);
                    break;
                case "binp":
                    jc.writeObject(dataRepo.GetSpecificProduct(chooseIndex()), filePath);
                    break;
                case "bint":
                    jc.writeObject(dataRepo.GetSpecificTransaction(chooseIndex()), filePath);
                    break;
                case "binlc":
                    bc.writeClientsList(dataRepo.GetAllClients(), filePath);
                    break;
                case "binoct":
                    bc.writeTransactionsObservableCollection(dataRepo.GetAllTransactions(), filePath);
                    break;
                case "bindp":
                    bc.writeProductsDictionary(dataRepo.GetAllProducts(), filePath);
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
