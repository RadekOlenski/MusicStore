using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicStore;

namespace DataRepositoryDeleteUnitTest
{
    [TestClass]
    public class DataDeleteTests
    {
        private DataRepository sut;

        [TestInitialize]
        public void init()
        {
            sut = new DataRepository();
            sut.CreateProduct(ProductType.Keyboard, "Qwerty", 20000);
            sut.CreateClient("Adam", "Nowak", "Drzewna", "Lodz", 1990);
            sut.CreateTransaction(1, 1, "21.04.2000");
        }

        [TestCleanup]
        public void clean()
        {
            //Object cleanup

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DeleteClient()
        {
            sut.DeleteClient(0);
            sut.GetSpecificClient(0);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DeleteProduct()
        {
            sut.DeleteProduct(1);
            sut.GetSpecificProduct(1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DeleteTransaction()
        {
            sut.DeleteTransaction(0);
            sut.GetSpecificTransaction(0);
        }
    }
}
