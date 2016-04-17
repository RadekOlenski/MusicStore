using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicStore;

namespace DataRepositoryDeleteUnitTest
{
    [TestClass]
    public class DataDeleteFailTests
    {
        private DataRepository sut;

        [TestInitialize]
        public void init()
        {
            sut = new DataRepository();
        }

        [TestCleanup]
        public void clean()
        {
            //Object cleanup
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DeleteClientFail()
        {
            sut.DeleteClient(0);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DeleteProductFail()
        {
            sut.DeleteProduct(0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void DeleteTransactionFail()
        {
            sut.DeleteTransaction(0);
        }
    }
}
