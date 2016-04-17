using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicStore;

namespace DataRepositoryTests
{
    #region Read Tests
    [TestClass]
    //This test class contains methods responsible for testing of printing out elements and properties
    //of objects in DataRepository Class collections
    public class DataReadTests
    {
        //System Under Test object
        public DataRepository sut;

        [TestInitialize]
        public void init()
        {
            //Initialize of sut and example data
            sut = new DataRepository();
            sut.CreateProduct(ProductType.Keyboard, "Qwerty", 20000);
            sut.CreateProduct(ProductType.Guitar, "ABCD", 10000);
            sut.CreateClient("Adam", "Nowak", "Drzewna", "Lodz", 1990);
            sut.CreateClient("Andrzej", "Jakiś", "Ulica", "Warszawa", 1975);
            sut.CreateTransaction(1, 1, "21.04.2000");
            sut.CreateTransaction(1, 0, "22.10.2010");
        }

        [TestCleanup]
        public void clean()
        {
            //Object cleanup
            sut.DeleteProduct(0);
            sut.DeleteProduct(1);
            sut.DeleteClient(0);
            sut.DeleteClient(0);
            sut.DeleteTransaction(0);
            sut.DeleteTransaction(0);
        }

        [TestMethod]
        public void ReadAllProducts()
        {
            string expectedString = "[0, Product Type: MusicStore.Keyboard, Name: Qwerty, Price: 20000]\n"
                                    + "[1, Product Type: MusicStore.Guitar, Name: ABCD, Price: 10000]\n";
            string actualString = sut.ReadAllProducts();
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void ReadAllClients()
        {
            string expectedString = "Client Name: Adam Nowak, Street: Drzewna, City: Lodz, Year of birth: 1990\n"
                                    + "Client Name: Andrzej Jakiś, Street: Ulica, City: Warszawa, Year of birth: 1975\n";
            string actualString = sut.ReadAllClients();
            Assert.AreEqual(expectedString, actualString);

        }

        [TestMethod]
        public void ReadAllTransactions()
        {
            string expectedString = "Client Name: Andrzej Jakiś, Street: Ulica, City: Warszawa, Year of birth: 1975\n"
                                    + "Product Type: MusicStore.Guitar, Name: ABCD, Price: 10000\n"
                                    + "Transaction Date: 21.04.2000\n"
                                    + "Client Name: Andrzej Jakiś, Street: Ulica, City: Warszawa, Year of birth: 1975\n"
                                    + "Product Type: MusicStore.Keyboard, Name: Qwerty, Price: 20000\n"
                                    + "Transaction Date: 22.10.2010\n";
            string actualString = sut.ReadAllTransactions();
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void GetSpecificClient()
        {
            string expectedString = "Client Name: Adam Nowak, Street: Drzewna, City: Lodz, Year of birth: 1990";
            string actualString = sut.GetSpecificClient(0);
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void GetSpecificProduct()
        {
            string expectedString = "[0, Product Type: MusicStore.Keyboard, Name: Qwerty, Price: 20000]";
            string actualString = sut.GetSpecificProduct(0);
            Assert.AreEqual(expectedString, actualString);
        }

        [TestMethod]
        public void GetSpecificTransaction()
        {
            string expectedString = "Client Name: Andrzej Jakiś, Street: Ulica, City: Warszawa, Year of birth: 1975\n"
                                   + "Product Type: MusicStore.Guitar, Name: ABCD, Price: 10000\n"
                                   + "Transaction Date: 21.04.2000\n";
            string actualString = sut.GetSpecificTransaction(0);
            sut.GetSpecificTransaction(0);
            Assert.AreEqual(expectedString, actualString);
        }
    }
    #endregion
}
