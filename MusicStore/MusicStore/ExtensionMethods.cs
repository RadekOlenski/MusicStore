using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore
{
    public static class ExtensionMethods
    {
        public static Client GetBestBuyingClient(this DataRepository repo)
        {

            int bestClientID = repo.GetAllTransactions()
                                    .GroupBy(t => t.ClientID)
                                    .OrderByDescending(gp => gp.Count())
                                    .First().Key;
            return repo.GetSpecificClient(bestClientID);
        }

        public static List<Client>[] GetClientsInGroupsOfTen(this DataRepository repo)
        {
            int rows = (repo.GetAllClients().Count - 1) / 10 + 1;
            if (rows > 0)
            {
                List<Client>[] tempClients = new List<Client>[rows];
                for (int i = 0; i < rows; i++)
                {
                    tempClients[i] = new List<Client>();
                    for (int j = 0; j < 10; j++)
                    {
                        if (i * 10 + j < repo.GetAllClients().Count)
                        {
                            tempClients[i].Add((repo.GetAllClients()[i * 10 + j]));
                        }
                    }
                }
               
                    return tempClients;
            }
            else return null;
        }

        public static List<Product> GetNotBoughtProducts(this DataRepository repo)
        {
            var notBoughtProducts = repo.GetAllProducts().Keys.Except( repo.GetAllTransactions().Select(t => t.ProductID ));
            List<Product> products = new List<Product>();
            foreach (var ID in notBoughtProducts)
            {
                products.Add(repo.GetSpecificProduct(ID));
            }
            
            return products;
        }
    }
}
