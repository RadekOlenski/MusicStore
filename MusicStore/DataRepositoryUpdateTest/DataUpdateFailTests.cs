using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicStore;

namespace DataRepositoryUpdateUnitTest
{
    [TestClass]
    public class DataUpdateFailTests
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
        public void UpdateClientNameFail()
        {
            sut.UpdateClientName(0, "Krystian");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void UpdateClientSurnameFail()
        {
            sut.UpdateClientSurname(1, "Smith");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void UpdateClientStreetFail()
        {
            sut.UpdateClientStreet(0, "Piotrkowska 23");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void UpdateClientCityFail()
        {
            sut.UpdateClientCity(1, "Washington DC");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void UpdateClientBirthYearFail()
        {
            sut.UpdateClientBirthYear(10, 2015);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void UpdateProductNameFail()
        {
            sut.UpdateProductName(250, "Ibanez 23475H");
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void UpdateProductPriceFail()
        {
            sut.UpdateProductPrice(13, 349.90);
        }
    }
}
