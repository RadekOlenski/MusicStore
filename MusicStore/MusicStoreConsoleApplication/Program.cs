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
            _DataRepository.FillRepository = new FillRepository();
            _DataRepository.FillClients();
            _DataRepository.FillProducts();
            _DataRepository.FillTransactions();
            Console.WriteLine(_DataRepository.ReadAllClients());
            Console.WriteLine(_DataRepository.ReadAllProducts());
            Console.WriteLine(_DataRepository.ReadAllTransactions());

            DataService _DataService = new DataService();
            _DataService.DataRepository = _DataRepository;

            Console.ReadLine();
        }
    }
}
