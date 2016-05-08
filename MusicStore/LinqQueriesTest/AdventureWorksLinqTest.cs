using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AdventureWorksDatabase;

namespace LinqQueriesTest
{
    [TestClass]
    public class AdventureWorksLinqTest
    {
        [TestMethod]
        public void getProductNamesByVendorNameTest()
        {
            Console.WriteLine(AdventureWorksLinq.getProductNamesByVendorName("International"));
        }
    }
}
