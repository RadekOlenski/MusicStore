using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using MusicStore;
using System.Linq;

namespace LinqQueriesTest
{
    [TestClass]
    public class LambdaTest
    {
        #region a)
        [TestMethod]
        public void GetProductWithSpecifiedTitleLambdaTest()
        {
            List<Product> products = new List<Product>
            {
                new Product("CommonName",201),
                new Product("CommonName",202),
                new Product("VeryCommonName",202),
                new Product("SpecialName",203),
                new Product("SpecialName",203),
            };

            foreach (var product in DataLambdaFilter.GetProductWithSpecifiedTitle(products, "SpecialName"))
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

            Assert.AreEqual(3, (from album in DataLambdaFilter.GetAlbumsWithSpecifiedIssueYear(albums, 1991, 1995) select album).Count());
        }
        #endregion

        #region c)
        [TestMethod]
        public void GetAllBandsLambdaTest()
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
            Assert.AreEqual(3, DataLambdaFilter.GetAllBands(albums).Count);
        }

        [TestMethod]
        public void GetAllBandsStringsComparisonLambdaTest()
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

            var albumBands = DataLambdaFilter.GetAllBands(albums);
            Assert.AreEqual(1, (from album in albumBands where album.Contains("Pink Floyd") select album).Count());
        }
        #endregion

        #region d)
        [TestMethod]
        public void CompareListsLambdaTest()
        {
            List<Product> products = new List<Product>
            {
                new Product("CommonName",201),
                new Product("CommonName",202),
                new Product("VeryCommonName",202),
                new Product("SpecialName",203),
                new Product("SpecialName",203),
            };

            List<Product> products2 = new List<Product>
            {
                new Product("AommonName",201),
                new Product("DmonName",202),
                new Product("VeryCommonName",202),
                new Product("USpecialName",203),
                new Product("POSpecialName",203),
            };

            DataLinqFilter.CompareLists(products, products2);
        }
        #endregion

        #region e)
        [TestMethod]
        public void GetMaxElementLambdaTest()
        {
            List<MusicAlbum> albums = new List<MusicAlbum>
            {
                new MusicAlbum("TestName",201,1990,"Pink Floyd"),
                new MusicAlbum("TestName",202,1991,"Metallica"),
                new MusicAlbum("TestName",203,1992,"Dire Straits"),
            };

            Assert.AreEqual((uint)1992, DataLambdaFilter.getMaxElement(albums).Year);
        }
        #endregion

        #region g)
        [TestMethod]
        public void GetDistinctTransactionsLambda()
        {
            List<Transaction> transactions = new List<Transaction>
            {
                new Transaction(1,1,"25 wrzesnia"),
                new Transaction(2,2,"18 wrzesnia"),
                new Transaction(2,2,"19 wrzesnia"),
                new Transaction(2,2,"18 wrzesnia"),
            };

            Assert.AreEqual(2, DataLambdaFilter.GetDistinctTransactions(transactions).Count);
        }
        #endregion

        #region h)
        [TestMethod]
        public void GetSimpleClassesWithSpecifiedIssueYearLambdaTest()
        {
            List<MusicAlbum> albums = new List<MusicAlbum>
            {
                new MusicAlbum("TestName",201,1990,"Pink Floyd"),
                new MusicAlbum("TestName",202,1991,"Metallica"),
                new MusicAlbum("TestName",203,1992,"Dire Straits"),
                new MusicAlbum("TestName",203,1995,"Dire Straits"),
                new MusicAlbum("TestName",203,1996,"Dire Straits")
            };

            foreach (var item in DataLambdaFilter.GetSimpleClassesWithSpecifiedIssueYear(albums, 1991, 1995))
            {
                Assert.IsInstanceOfType(item, typeof(SimpleClass));
            }
        }
        #endregion
    }
}
