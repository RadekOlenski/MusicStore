using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicStore.ConsoleApplication;
using MusicStore;

namespace DependencyInjectionUnitTest
{
    [TestClass]
    public class DataServiceConstructorInjectionTests
    {
        DataService sut;
        DataRepository _DataRepository = new DataRepository(); 

        [TestInitialize]
        public void init()
        {
            sut = new DataService(_DataRepository);
        }

        [TestMethod]
        public void AfterCreationCIDataService()
        {
            Assert.IsNotNull(sut.DataRepository);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ConstructorInjectionDataService()
        {
            sut.DataRepository.CreateClient("Test", "Testowy", "Testowa", "Testowo", 2016);
            sut.DataRepository.CreateProduct(ProductType.LiveAlbum, "Test", 20537);
            sut.DataRepository.CreateTransaction(0, 0, "19.02.1870");
            sut.DataRepository = _DataRepository;

            Assert.AreEqual(1, sut.CountClients());
            Assert.AreEqual(1, sut.CountProducts());
            Assert.AreEqual(1, sut.CountTransactions());

            sut.UpdateClientName(0, "Jerzy");
            Assert.IsTrue(sut.GetSpecificClient(0).Contains("Jerzy"));

            sut.DeleteClient(0);
            sut.GetSpecificClient(0);
            sut.ReadAllClients();

            sut.DataRepository.CreateClient("Test", "Testowy", "Testowa", "Testowo", 2016);
            string expectedString = "Client Name: Test Testowy, Street: Testowa, City: Testowo, Year of birth: 2016\n";
            Assert.AreEqual(expectedString, sut.ReadAllClients());

            sut.DataRepository.CreateProduct(ProductType.Guitar, "123245", 194772);
            Assert.AreEqual(2, sut.CountProducts());
        }
    }
}
