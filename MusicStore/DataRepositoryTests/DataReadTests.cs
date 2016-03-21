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
        [TestMethod]
        //This method tests printing out every Product from Products Dictionary, along with its properties
        public void ReadAllProducts()
        {
            DataRepository.ReadAllProducts();
        }

        [TestMethod]
        //This method tests printing out every Client from Clients List
        public void ReadAllClients()
        {
            DataRepository.ReadAllClients();
        }

        [TestMethod]
        public void ReadAllTransactions()
        {
            DataRepository.ReadAllTransactions();
        }

        [TestMethod]
        public void GetSpecificClient()
        {
            DataRepository.GetSpecificClient(2);   
        }

        [TestMethod]
        public void GetSpecificProduct()
        {
            DataRepository.GetSpecificProduct(3);
        }

        [TestMethod]
        public void GetSpecificTransaction()
        {
            DataRepository.GetSpecificTransaction(0);
        }
    }
    #endregion
}
