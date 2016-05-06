using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MusicStore;

namespace LinqQueriesTest
{
    [TestClass]
    public class LinqQueriesTest
    {
        #region a)
        [TestMethod]
        public void GetProductWithSpecifiedTitleTest()
        {
            List<Product> products = new List<Product>
            {
                new Product("CommonName",201),
                new Product("CommonName",202),
                new Product("VeryCommonName",202),
                new Product("SpecialName",203),
                new Product("SpecialName",203),
            };

            foreach (var product in DataLinqFilter.GetProductWithSpecifiedTitle(products, "SpecialName"))
            {
                Assert.AreEqual("SpecialName", product.Name);
            }

        }
        #endregion

        #region b)
        [TestMethod]
        public void GetAlbumsWithSpecifiedIssueYearTest()
        {
            List<MusicAlbum> albums = new List<MusicAlbum>
            {
                new MusicAlbum("TestName",201,1990,"Pink Floyd"),
                new MusicAlbum("TestName",202,1991,"Metallica"),
                new MusicAlbum("TestName",203,1992,"Dire Straits"),
                new MusicAlbum("TestName",203,1995,"Dire Straits"),
                new MusicAlbum("TestName",203,1996,"Dire Straits")
            };

            Assert.AreEqual(3, (from album in DataLinqFilter.GetAlbumsWithSpecifiedIssueYear(albums, 1991, 1995) select album).Count());
        }
        #endregion

        #region c)
        [TestMethod]
        public void GetAllBandsTest()
        {
            List<MusicAlbum> albums = new List<MusicAlbum>
            {
                new MusicAlbum("TestName",200,2200,"Pink Floyd"),
                new MusicAlbum("TestName",200,2100,"Pink Floyd"),
                new MusicAlbum("TestName",200,2000,"Pink Floyd"),
                new MusicAlbum("TestName",201,2005,"Pink Floyd"),
                new MusicAlbum("TestName",202,2006,"Metallica"),
                new MusicAlbum("TestName",203,2007,"Dire Straits")
            };
            Assert.AreEqual(3, DataLinqFilter.GetAllBands(albums).Count);
        }

        [TestMethod]
        public void GetAllBandsStringsComparisonTest()
        {
            List<MusicAlbum> albums = new List<MusicAlbum>
            {
                new MusicAlbum("TestName",200,2200,"Pink Floyd"),
                new MusicAlbum("TestName",200,2100,"Pink Floyd"),
                new MusicAlbum("TestName",200,2000,"Pink Floyd"),
                new MusicAlbum("TestName",201,2005,"Pink Floyd"),
                new MusicAlbum("TestName",202,2006,"Metallica"),
                new MusicAlbum("TestName",203,2007,"Dire Straits")
            };

            var albumBands = DataLinqFilter.GetAllBands(albums);
            Assert.AreEqual(1, (from album in albumBands where album.Contains("Pink Floyd") select album).Count());
        }
        #endregion

        #region e)
        [TestMethod]
        public void GetMaxElementLinqTest()
        {
            List<MusicAlbum> albums = new List<MusicAlbum>
            {
                new MusicAlbum("TestName",201,1990,"Pink Floyd"),
                new MusicAlbum("TestName",202,1991,"Metallica"),
                new MusicAlbum("TestName",203,1992,"Dire Straits"),
            };

            Assert.AreEqual((uint)1992, DataLinqFilter.getMaxElement(albums).Year);
        }
        #endregion

        #region g)
        [TestMethod]
        public void GetDistinctTransactionsLinq()
        {
            List<Transaction> transactions = new List<Transaction>
            {
                new Transaction(1,1,"25 wrzesnia"),
                new Transaction(2,2,"18 wrzesnia"),
                new Transaction(2,2,"19 wrzesnia"),
                new Transaction(2,2,"18 wrzesnia"),
            };

            Assert.AreEqual(2, DataLinqFilter.GetDistinctTransactions(transactions).Count);
        }
        #endregion

        #region h)
        [TestMethod]
        public void GetSimpleClassesWithSpecifiedIssueYearTest()
        {
            List<MusicAlbum> albums = new List<MusicAlbum>
            {
                new MusicAlbum("TestName",201,1990,"Pink Floyd"),
                new MusicAlbum("TestName",202,1991,"Metallica"),
                new MusicAlbum("TestName",203,1992,"Dire Straits"),
                new MusicAlbum("TestName",203,1995,"Dire Straits"),
                new MusicAlbum("TestName",203,1996,"Dire Straits")
            };

            foreach (var item in DataLinqFilter.GetSimpleClassesWithSpecifiedIssueYear(albums, 1991, 1995))
            {
                Assert.IsInstanceOfType(item, typeof(SimpleClass));
            }
        } 
        #endregion

    }
}
