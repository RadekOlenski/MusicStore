using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureWorksDatabase
{
    public class AdventureWorksLambda
    {
        private static AdventureWorksLinqToSqlDataContext db = new AdventureWorksLinqToSqlDataContext();

        #region subsection a)
        public static List<string> getProductNamesByVendorName(string vendorName)
        {
            var products = from product in db.Products
                           join productVendor in db.ProductVendors
                           on product.ProductID equals productVendor.ProductID
                           join vendor in db.Vendors
                           on productVendor.BusinessEntityID equals vendor.BusinessEntityID
                           select new { ProductName = product.Name, VendorName = vendor.Name };

            List<string> result = new List<string>();
            foreach (var item in products.Where(n => n.VendorName.Equals(vendorName)))
            {
                result.Add(item.ProductName);
            }
            return result;
        }
        #endregion

        #region subsection b)
        public static List<Product> getRecentlyReviewedProducts(int howManyReviews)
        {
            List<Product> result = new List<Product>();
            var query = (from productReview in db.ProductReviews
                         orderby productReview.ProductReviewID descending
                         select productReview.ProductID).Take(howManyReviews);

            foreach (var item in db.Products.Where(n => query.Contains(n.ProductID)))
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

            foreach (var item in db.Products.Where(n => query.Contains(n.ProductID)))
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

            decimal result = 0;
            foreach (var item in db.Products.Where(n => query.Contains(n.ProductSubcategory.ProductSubcategoryID)))
            {
                result += item.StandardCost;
            }
            return result;
        }
        #endregion

    }
}
