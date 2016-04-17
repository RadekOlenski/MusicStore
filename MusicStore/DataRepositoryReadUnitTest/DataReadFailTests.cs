using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicStore;

namespace DataRepositoryTests
{
    [TestClass]
    public class DataReadFailTests
    {
        //System Under Test object
        public DataRepository sut;

        [TestInitialize]
        public void init()
        {
            //Initialize of sut and example data
            sut = new DataRepository();
        }

        [TestCleanup]
        public void clean()
        {
            //Object cleanup
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ReadAllProductsFail()
        {
            sut.ReadAllProducts();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ReadAllClientsFail()
        {
            sut.ReadAllClients();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ReadAllTransactionsFail()
        {
            sut.ReadAllTransactions();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetSpecificClientFail()
        {
            sut.GetSpecificClient(0);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GetSpecificProductFail()
        {
            sut.GetSpecificProduct(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void GetSpecificTransactionFail()
        {
            sut.GetSpecificTransaction(0);
        }
    }
}
