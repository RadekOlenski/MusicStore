using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore
{
    public class DataLinqFilter
    {
        #region subsection a)
        public static List<Product> GetProductWithSpecifiedTitle(List<Product> list, string title)
        {
            var subset = from product in list where product.Name.Contains(title) select product;
            return subset.ToList();
        }
        #endregion

        #region subsection b)
        public static List<MusicAlbum> GetAlbumsWithSpecifiedIssueYear(List<MusicAlbum> list, uint minYear, uint maxYear)
        {
            return (from album in list where album.Year >= minYear && album.Year <= maxYear select album).ToList();
        }
        #endregion

        #region subsection c)
        public static List<string> GetAllBands(List<MusicAlbum> list)
        {
            return ((from album in list select album.Band).Distinct()).ToList();
        }
        #endregion

        //TODO subsection d)

        #region subsection e)
        public static MusicAlbum getMaxElement(List<MusicAlbum> list)
        {
            return (from album in list orderby album.Year descending select album).First();
        }
        #endregion

        //TODO subsection f)

        #region subsection g)
        public static List<Transaction> GetDistinctTransactions(List<Transaction> list)
        {
            return ((from tr in list select tr).Distinct(new TransactionEqualityComparer())).ToList();
            //return (list.GroupBy(customer => customer.ClientID + customer.ProductID).Select(group => group.First())).ToList();
        }
        #endregion

        #region subsection h)        //upgrade?
        public static List<SimpleClass> GetSimpleClassesWithSpecifiedIssueYear(List<MusicAlbum> list, int minYear, int maxYear)
        {
            List<SimpleClass> simpleClassItems = new List<SimpleClass>();
            var subset = from album in list where album.Year >= minYear && album.Year <= maxYear select album;
            foreach (var item in subset)
            {
                simpleClassItems.Add(new SimpleClass(item.Name, (int)item.Year));
            }
            return simpleClassItems;
        } 
        #endregion     




    }
}
