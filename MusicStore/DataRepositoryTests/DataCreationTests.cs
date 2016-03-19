using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MusicStore
{
    namespace DataRepositoryTests
    {
        #region Creation Tests
        [TestClass]
        //This test class contains methods responsible for checking objects creating in collections from DataRepository Class
        public class DataCreationTests
        {
            [TestMethod]
            //This method tests creating new Client Objects
            public void CreateClient()
            {
                DataRepository.CreateClient("Adam", "Nowak", "Drzewna", "Lodz", 1990);
            }

            [TestMethod]
            //This method tests creating new Product Objects for every type of Product
            public void CreateProduct()
            {
                DataRepository.CreateProduct(ProductType.GUITAR, "RX100", 1027.45);
                DataRepository.CreateProduct(ProductType.KEYBOARD, "Kronos", 15499);
                DataRepository.CreateProduct(ProductType.LONGPLAY, "The Wall", 54.99);
                DataRepository.CreateProduct(ProductType.LIVEALBUM, "Live at Rome", 77.21);
            }
        }
        #endregion

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
        }
        #endregion
    }
}
