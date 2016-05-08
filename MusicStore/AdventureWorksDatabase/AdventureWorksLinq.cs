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
            List<string> result;
            var VendorID = from vendor in db.Vendors
                           where vendor.Name == vendorName
                           select vendor.BusinessEntityID;

            var ProductID = from productVendor in db.ProductVendors
                            where VendorID.Contains(productVendor.BusinessEntityID)
                            select productVendor.ProductID;

            result = (from product in db.Products
                     where ProductID.Contains(product.ProductID)
                     select product.Name).ToList();
            return result;
        }
        #endregion
    }
}
