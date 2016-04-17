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
            _DataRepository.CreateProduct(ProductType.Keyboard, "Dupa", 100);
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
                _DataRepository.GetSpecificProduct(10);
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
            _DataRepository.CreateTransaction(2, 2, "17 wrzesnia");
            Console.ReadLine();
            _DataRepository.CreateTransaction(5, 4, "13 wrzesnia");
            Console.ReadLine();
            _DataRepository.DeleteTransaction(1);
            Console.ReadLine();
        }
    }
}
