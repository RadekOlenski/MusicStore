using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore
{
    public static class DataLambdaFilter
    {
        #region subsection a)
        public static List<Product> GetProductWithSpecifiedTitle(List<Product> list, string title)
        {          
            return (list.Where(a => a.Name.Contains(title))).ToList();
        }
        #endregion
       
        #region subsection b)
        public static List<MusicAlbum> GetAlbumsWithSpecifiedIssueYear(List<MusicAlbum> list, uint minYear, uint maxYear)
        {
            return (list.Where( a => a.Year >= minYear && a.Year <= maxYear )).ToList();
        }
        #endregion

        #region subsection c)
        public static List<string> GetAllBands(List<MusicAlbum> list)
        {
            return (list.GroupBy(a => a.Band).Select(group => group.First()).Select(g => g.Band).ToList());
        }
        #endregion

        #region subsection d)
        public static void CompareLists(List<Product> list1, List<Product> list2)
        {
            foreach (var item in list2)
            {
                Console.WriteLine("Obiekt 1: {0}, Obiekt2: {1}", list1.Where(a => a.Name.CompareTo(item.Name) < 0), item.Name);
            }
        }
        #endregion

        #region subsection e)
        public static MusicAlbum getMaxElement(List<MusicAlbum> list)
        {
            return list.Aggregate((a1, a2) => a1.Year > a2.Year ? a1 : a2);
        }
        #endregion

        #region f)
        public static int[] getClientsIDWithTransactions(List<Transaction> transactions)
        {
            var clientIDs = transactions.GroupBy(x => x.ClientID)
                                         .Where(g => g.Count() > 1)
                                         .Select(g => g.Key)
                                         .ToArray();
            return clientIDs;
        }
        #endregion

        #region subsection g)
        public static List<Transaction> GetDistinctTransactions(List<Transaction> list)
        {
            return (list.Distinct(new TransactionEqualityComparer(a => new { a.ClientID, a.ProductID }))).ToList();
        }
        #endregion

        #region subsection h)
        public static List<SimpleClass> GetSimpleClassesWithSpecifiedIssueYear(List<MusicAlbum> list, int minYear, int maxYear)
        {
            List<SimpleClass> simpleClassItems = new List<SimpleClass>();
            var subset = (list.Where(a => a.Year >= minYear && a.Year <= maxYear)).ToList();
            foreach (var item in subset)
            {
                simpleClassItems.Add(new SimpleClass(item.Name, (int)item.Year));
            }
            return simpleClassItems;
        }
        #endregion
    }
}
