using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicStore;

namespace DataRepositoryReadUnitTest
{
    [TestClass]
    public class FilterTests
    {
        //System Under Test object
        private DataRepository sut;

        [TestInitialize]
        public void init()
        {
            //Initialize of sut and example data
            sut = new DataRepository();
            sut.CreateProduct(ProductType.Keyboard, "Qwerty", 200);
            sut.CreateProduct(ProductType.Guitar, "ABCD", 10000);
            sut.CreateClient("Adam", "Nowak", "Drzewna", "Lodz", 2001);
            sut.CreateClient("Andrzej", "Jakiś", "Ulica", "Warszawa", 1998);
        }

        [TestCleanup]
        public void clean()
        {
            //Object cleanup
            sut.DeleteProduct(0);
            sut.DeleteProduct(1);
            sut.DeleteClient(0);
            sut.DeleteClient(0);
        }

        [TestMethod]
        public void FilterByClientAge()
        {
            string expectedString = "Client Name: Andrzej Jakiś, Street: Ulica, City: Warszawa, Year of birth: 1998\n";
            string actualString = sut.FilterByClientAge(18);
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void FilterByGreaterProductPrice()
        {
            string expectedString = "[1, Product Type: MusicStore.Guitar, Name: ABCD, Price: 10000]\n";
            string actualString = sut.FilterByGreaterProductPrice(200.99);
            Assert.AreEqual(expectedString, actualString);
        }
    }
}
