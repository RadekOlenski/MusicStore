using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicStore;

namespace DataRepositoryUpdateUnitTest
{

    [TestClass]
    public class DataUpdateTests
    {
        //System Under Test object
        private DataRepository sut;

        [TestInitialize]
        public void init()
        {
            //Initialize of sut and example data
            sut = new DataRepository();
            sut.CreateProduct(ProductType.Keyboard, "Qwerty", 20000);
            sut.CreateProduct(ProductType.Guitar, "ABCD", 10000);
            sut.CreateClient("Adam", "Nowak", "Drzewna", "Lodz", 1990);
            sut.CreateClient("Andrzej", "Jakiś", "Ulica", "Warszawa", 1975);
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
        public void UpdateClientName()
        {
            sut.UpdateClientName(0, "Krystian");
            Assert.IsTrue(sut.GetSpecificClientToString(0).Contains("Krystian"));
        }

        [TestMethod]
        public void UpdateClientSurname()
        {
            sut.UpdateClientSurname(1, "Smith");
            Assert.IsTrue(sut.GetSpecificClientToString(1).Contains("Smith"));
        }

        [TestMethod]
        public void UpdateClientStreet()
        {
            sut.UpdateClientStreet(0, "Piotrkowska 23");
            Assert.IsTrue(sut.GetSpecificClientToString(0).Contains("Piotrkowska 23"));
        }

        [TestMethod]
        public void UpdateClientCity()
        {
            sut.UpdateClientCity(1, "Washington DC");
            Assert.IsTrue(sut.GetSpecificClientToString(1).Contains("Washington DC"));
        }

        [TestMethod]
        public void UpdateClientBirthYear()
        {
            sut.UpdateClientBirthYear(0, 2015);
            Assert.IsTrue(sut.GetSpecificClientToString(0).Contains("2015"));
        }

        [TestMethod]
        public void UpdateProductName()
        {
            sut.UpdateProductName(0, "Ibanez 23475H");
            Assert.IsTrue(sut.GetSpecificProductToString(0).Contains("Ibanez 23475H"));
        }

        [TestMethod]
        public void UpdateProductPrice()
        {
            sut.UpdateProductPrice(1, 349.90);
            Assert.IsTrue(sut.GetSpecificProductToString(1).Contains("349.9"));
        }
    }
}
