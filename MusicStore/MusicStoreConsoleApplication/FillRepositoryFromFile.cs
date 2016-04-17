using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.ConsoleApplication
{
    public class FillRepositoryFromFile : IFillRepository
    {

        public void CreateClients(List<Client> Clients)
        {
            foreach ( string line in FileToString("clients.txt"))
            {
                string[] parts = line.Split(';');
                if (parts.Length == 5)
                {
                    Clients.Add(new Client(parts[0], parts[1], parts[2], parts[3], Int32.Parse(parts[4])));
                }
            }
        }

        public void CreateProducts(Dictionary<int, Product> Products)
        {
            foreach (string line in FileToString("products.txt"))
            {
                string[] parts = line.Split(';');
                if (parts.Length == 2)
                {
                    Products.Add(Product.GenerateProductID(), new Product(parts[0], Int32.Parse(parts[1]))); 
                }
            }
        }

        public void CreateTransactions(ObservableCollection<Transaction> Transactions)
        {
            foreach (string line in FileToString("transactions.txt"))
            {
                string[] parts = line.Split(';');
                if (parts.Length == 3)
                {
                    Transactions.Add(new Transaction(Int32.Parse(parts[0]), Int32.Parse(parts[1]), parts[2] ));
                }
            }
        }

        public List<string> FileToString(string FilePath)
        {
            return File.ReadLines(FilePath).ToList();           
        }
    }
}
