using MusicStoreConsoleApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.ConsoleApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            DataRepository _DataRepository = new DataRepository();
            _DataRepository.CreateProduct(ProductType.Keyboard, "Keyboard", 100);
            try
            {
                _DataRepository.ReadAllProducts();
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            _DataRepository.FillRepository = new FillRepository();
            _DataRepository.FillClients();
            _DataRepository.FillProducts();
            _DataRepository.FillTransactions();
            Console.WriteLine(_DataRepository.ReadAllClients());
            Console.WriteLine(_DataRepository.ReadAllProducts());
            Console.WriteLine(_DataRepository.ReadAllTransactions());

            DataService _DataService = new DataService(_DataRepository);

            try
            {
                _DataRepository.GetSpecificProductToString(10);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }

            //Console.ReadLine();
            _DataRepository.CreateTransaction(2, 2, "17 wrzesnia");
            //Console.ReadLine();
            _DataRepository.CreateTransaction(5, 4, "13 wrzesnia");
            //Console.ReadLine();
            //_DataRepository.DeleteTransaction(1);
            //Console.ReadLine();

            //XMLConverter xmlConverter = new XMLConverter();
            //xmlConverter.writeObject(_DataRepository.GetSpecificProduct(0), "productXML.xml");
            //xmlConverter.writeObject(_DataRepository.GetSpecificClient(1), "clientXML.xml");
            //xmlConverter.writeCollection(_DataRepository.GetAllClients(), "clients.xml");
            //xmlConverter.writeCollection(_DataRepository.GetAllProducts(), "products.xml");
            //xmlConverter.writeCollection(_DataRepository.GetAllTransactions(), "transactions.xml");

            ////Product product = xmlConverter.readProduct("productXML.xml");
            //Client client = xmlConverter.readClient("clientXML.xml");
            //Console.WriteLine(client.ToString());

            JSONConverter jsonConverter = new JSONConverter();
            jsonConverter.writeCollection(_DataRepository.GetAllTransactions(), "transactions.txt");
            //Console.WriteLine(jsonConverter.readObservableCollection("transactions.txt"));
            foreach (var item in jsonConverter.readObservableCollection("transactions.txt"))
            {
                Console.WriteLine(item.ToString());
            }     
            Console.ReadKey();
            
        }
    }
}
