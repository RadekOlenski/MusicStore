using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore.ConsoleApplication
{
    public class FillRepository : IFillRepository
    {
        public void CreateClients(List<Client> Clients)
        {
            Clients.Add(new Client("Marcin", "Jóźwik", "AOPŁ 10", "Łódź", 1995));
            Clients.Add(new Client("Bartek", "Jóźwik", "AOPŁ 15", "Łódź", 1995));
            Clients.Add(new Client("Marcin", "Jóźwik", "AOPŁ 10", "Łódź", 1945));
            Clients.Add(new Client("Marcin", "Nowak", "AOPŁ 20", "Łódź", 1995));
            Clients.Add(new Client("Adam", "Jóźwik", "AOPŁ 10", "Łódź", 1995));
        }

        public void CreateProducts(Dictionary<int, Product> Products)
        {
            Products.Add(Product.GenerateProductID(), new Guitar("RX100", 1027.45));
            Products.Add(Product.GenerateProductID(), new Keyboard("Kronos", 15499));
            Products.Add(Product.GenerateProductID(), new LongPlay("The Wall", 54.99));
            Products.Add(Product.GenerateProductID(), new LiveAlbum("Live at Rome", 77.21));
        }

        public void CreateTransactions(ObservableCollection<Transaction> Transactions)
        {
            Transactions.Add(new Transaction(1, 2, "21.04.2000"));
        }
    }
}
