using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorksDatabase
{
    public class AdventureWorksLinq
    {
        private static AdventureWorksLinqToSqlDataContext db = new AdventureWorksLinqToSqlDataContext();

        #region subsection a)
        public static List<string> getProductNamesByVendorName(string vendorName)
        {
            var query = from vendor in db.Vendors
                        join productVendor in db.ProductVendors
                        on vendor.BusinessEntityID equals productVendor.BusinessEntityID
                        where vendor.Name == vendorName
                        select productVendor.ProductID;

            return (from product in db.Products
                    where query.Contains(product.ProductID)
                    select product.Name).ToList();
        }
        #endregion

        #region subsection b)
        public static List<Product> getRecentlyReviewedProducts(int howManyReviews)
        {
            List<Product> result = new List<Product>();
            var query = (from productReview in db.ProductReviews
                         orderby productReview.ProductReviewID descending
                         select productReview.ProductID).Take(howManyReviews);

            var subset = from product in db.Products
                         where query.Contains(product.ProductID)
                         select product;
            foreach (var item in subset)
            {
                result.Add(item);
            }
            return result;
        }
        #endregion

        #region subsection c)
        public static List<Product> getNRecentlyReviewedProducts(int howManyProducts)
        {
            List<Product> result = new List<Product>();
            var query = (from productReview in db.ProductReviews
                         orderby productReview.ReviewDate descending
                         select productReview.ProductID).Take(howManyProducts);

            var subset = from product in db.Products
                         where query.Contains(product.ProductID)
                         select product;
            foreach (var item in subset)
            {
                result.Add(item);
            }
            return result;
        }
        #endregion

        #region subsection d)
        public static List<Product> getNProductsSortedByCategory(int howManyProducts)
        {
            var query = (from product in db.Products
                         join subcategory in db.ProductSubcategories
                         on product.ProductSubcategoryID equals subcategory.ProductSubcategoryID
                         join productCategory in db.ProductCategories
                         on subcategory.ProductCategoryID equals productCategory.ProductCategoryID
                         orderby product.Name ascending
                         orderby productCategory.Name ascending
                         select product).Take(howManyProducts);
            List<Product> result = new List<Product>();
            foreach (Product product in query)
            {
                result.Add(product);
            }
            return result;
        }
        #endregion

        #region subsection e)
        public static decimal getTotalStandardCostByCategory(ProductCategory category)
        {
            var query = from productCategory in db.ProductCategories
                        join subcategory in db.ProductSubcategories
                        on productCategory.ProductCategoryID equals subcategory.ProductCategoryID
                        where productCategory.Name == category.Name
                        select subcategory.ProductSubcategoryID;

            var resultQuery = from product in db.Products 
                    where query.Contains(product.ProductSubcategory.ProductSubcategoryID)
                    select product.StandardCost;

            decimal result = 0;
            foreach (var item in resultQuery)
            {
                result += item;
            }
            return result;
        }
        #endregion
    }
}
