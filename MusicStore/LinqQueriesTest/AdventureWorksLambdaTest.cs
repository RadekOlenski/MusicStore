using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventureWorksDatabase;
using System.Linq;

namespace LinqQueriesTest
{
    [TestClass]
    public class AdventureWorksLambdaTest
    {
        [TestMethod]
        public void getProductNamesByVendorNameTest()
        {
            List<string> products = AdventureWorksLambda.getProductNamesByVendorName("International");
            Assert.AreEqual("Lower Head Race", products[0]);

            //Compare with LINQ without Lambda
            List<string> expected = AdventureWorksLinq.getProductNamesByVendorName("International");
            CollectionAssert.AreEqual(expected, products);
        }

        [TestMethod]
        public void getRecentlyReviewedProductsTest()
        {
            List<Product> products = AdventureWorksLambda.getRecentlyReviewedProducts(3);
            Assert.IsTrue(products.Count == 2);
        }

        [TestMethod]
        public void getNRecentlyReviewedProductsTest()
        {
            List<Product> products = AdventureWorksLambda.getNRecentlyReviewedProducts(1);
            Assert.IsTrue(products.Count == 1);
        }

        [TestMethod]
        public void getNProductsSortedByCategoryTest()
        {
            List<Product> products = AdventureWorksLambda.getNProductsSortedByCategory(10);
            Assert.IsTrue(products.Count == 10);
        }

        [TestMethod]
        public void getTotalStandardCostByCategoryTest()
        {
            AdventureWorksLinqToSqlDataContext db = new AdventureWorksLinqToSqlDataContext();
            var query = (from category in db.ProductCategories
                         select category).Take(1);
            decimal actual = AdventureWorksLambda.getTotalStandardCostByCategory(query.First());
            Assert.AreEqual((decimal)92092.8230, actual);
             
            decimal expected = AdventureWorksLinq.getTotalStandardCostByCategory(query.First());
            Assert.AreEqual(expected, actual);
        }
    }
}
