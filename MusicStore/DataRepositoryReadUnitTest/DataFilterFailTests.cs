using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicStore;

namespace DataRepositoryReadUnitTest
{
    [TestClass]
    public class DataFilterFailTests
    {
        //System Under Test object
        private DataRepository sut;

        [TestInitialize]
        public void init()
        {
            //Initialize of sut and example data
            sut = new DataRepository();
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void FilterByClientAgeFail()
        {
            sut.FilterByClientAge(18);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void FilterByGreaterProductPriceFail()
        {
            sut.FilterByGreaterProductPrice(200.99);
        }
    }
}
