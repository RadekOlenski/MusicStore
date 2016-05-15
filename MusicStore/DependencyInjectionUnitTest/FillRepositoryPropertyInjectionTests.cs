using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicStore;
using MusicStore.ConsoleApplication;

namespace DependencyInjectionUnitTest
{
    [TestClass]
    public class FillRepositoryPropertyInjectionTests
    {
        DataRepository sut;

        [TestInitialize]
        public void init()
        {
            sut = new DataRepository();
        }

        [TestMethod]
        public void AfterCreationStateOfDataRepository()
        {
            Assert.IsNull(sut.FillRepository);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void NoInjectionDefinedInDataRepository()
        {
            sut.FillClients();
        }

        [TestMethod]
        public void PropertyInjectionDataRepository()
        {
            FillRepository _FillRepository = new FillRepository();
            sut.FillRepository = _FillRepository;
            sut.FillClients();
            Assert.AreEqual(5, sut.CountClients());
            sut.FillProducts();
            Assert.AreEqual(4, sut.CountProducts());
            sut.FillTransactions();
            Assert.AreEqual(1, sut.CountTransactions());
        }

        [TestMethod]
        public void PropertyInjectionDataRepositoryFromFile()
        {
            //FillRepositoryFromFile _FillRepositoryFromFile = new FillRepositoryFromFile();
            //sut.FillRepository = _FillRepositoryFromFile;
            //sut.FillClients();
            //Assert.AreEqual(4, sut.CountClients());
            //sut.FillProducts();
            //Assert.AreEqual(5, sut.CountProducts());
            //sut.FillTransactions();
            //Assert.AreEqual(2, sut.CountTransactions());
        }
    }
}
