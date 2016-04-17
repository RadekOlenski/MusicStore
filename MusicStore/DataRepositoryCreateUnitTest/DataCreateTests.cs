using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicStore;

namespace DataRepositoryCreateUnitTest
{
    [TestClass]
    public class DataCreateTests
    {
        //System Under Test object (sut)
        private DataRepository sut;

        [TestInitialize]
        public void init()
        {
            //Initialization of sut
            sut = new DataRepository();
        }

        [TestMethod]
        //This method tests creating new Client Objects
        public void CreateClient()
        {
            for (int i = 0; i < 1000; i++)
            {
                int counter = sut.CountClients();
                sut.CreateClient("Adam", "Nowak", "Drzewna", "Lodz", 1990);
                Assert.AreEqual(counter + 1, sut.CountClients());
            }
            Assert.AreEqual(1000, sut.CountClients());
        }

        [TestMethod]
        //This method tests creating new Product Objects for every type of Product
        public void CreateProduct()
        {
            for (int i = 0; i < 1000; i++)
            {
                int counter = sut.CountProducts();
                sut.CreateProduct(ProductType.Guitar, "RX100", 1027.45);
                Assert.AreEqual(counter + 1, sut.CountProducts());
            }
            Assert.AreEqual(1000, sut.CountProducts());
        }

        [TestMethod]
        public void CreateTransaction()
        {
            for (int i = 0; i < 1000; i++)
            {
                int counter = sut.CountTransactions();
                sut.CreateTransaction(0, 0, "21.04.2000");
                Assert.AreEqual(counter + 1, sut.CountTransactions());
            }
            Assert.AreEqual(1000, sut.CountTransactions());
        }
    }
}
