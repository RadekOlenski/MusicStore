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
            _DataRepository.FillRepository = new FillRepository();
            _DataRepository.FillClients();
            _DataRepository.FillProducts();
            _DataRepository.FillTransactions();
            DataService _DataService = new DataService(_DataRepository);
            _DataRepository.CreateTransaction(2, 2, "17 wrzesnia");
            _DataRepository.CreateTransaction(5, 4, "13 wrzesnia");



            TxtPROConverter pro = new TxtPROConverter();
            //pro.writeClientsList(_DataRepository.GetAllClients(), "tclients.txt");
            pro.writeObject(new Client("Tadeusz",BirthYear:2010), "myclient.txt");
            pro.writeObject(new Product("Tadeusz 2000",34.99), "myproduct.txt");
            //Console.WriteLine(pro.readClient("myclient.txt").ToString());
            //Console.WriteLine(pro.readProduct("myproduct.txt").ToString());

            Console.WriteLine("SERIALIZACJA:");
            Serializer serializer = new Serializer(_DataRepository);
            serializer.start();

            Console.ReadKey();
            
        }
    }
}
