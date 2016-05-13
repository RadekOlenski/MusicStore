using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventureWorksDatabase;
using System.Collections.Generic;
using System.Linq;

namespace LinqQueriesTest
{
    [TestClass]
    public class AdventureWorksLinqTest
    {
        [TestMethod]
        public void getProductNamesByVendorNameTest()
        {
            List<string> products = AdventureWorksLinq.getProductNamesByVendorName("International");
            Assert.AreEqual("Lower Head Race", products[0]);
        }

        [TestMethod]
        public void getRecentlyReviewedProductsTest()
        {
            List<Product> products = AdventureWorksLinq.getRecentlyReviewedProducts(3);
            Assert.IsTrue(products.Count == 2);
        }

        [TestMethod]
        public void getNRecentlyReviewedProductsTest()
        {
            List<Product> products = AdventureWorksLinq.getNRecentlyReviewedProducts(1);
            Assert.IsTrue(products.Count == 1);
        }

        [TestMethod]
        public void getNProductsSortedByCategoryTest()
        {
            List<Product> products = AdventureWorksLinq.getNProductsSortedByCategory(10);
            Assert.IsTrue(products.Count == 10);
        }

        [TestMethod]
        public void getTotalStandardCostByCategoryTest()
        {
            AdventureWorksLinqToSqlDataContext db = new AdventureWorksLinqToSqlDataContext();
            var query = (from category in db.ProductCategories
                         select category).Take(1);
            Assert.AreEqual((decimal)92092.8230, AdventureWorksLinq.getTotalStandardCostByCategory(query.First()));
        }
    }
}
