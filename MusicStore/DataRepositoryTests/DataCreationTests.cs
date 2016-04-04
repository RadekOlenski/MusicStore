using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicStore;

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
            DataRepository.CreateClient("Radek", "Olenski", "Pierwsza", "Lodz", 1994);
            DataRepository.CreateClient("Marcin", "Jozwik", "Druga", "Lodz", 1995);
        }

        [TestMethod]
        //This method tests creating new Product Objects for every type of Product
        public void CreateProduct()
        {
            DataRepository.CreateProduct(ProductType.Guitar, "RX100", 1027.45);
            DataRepository.CreateProduct(ProductType.Keyboard, "Kronos", 15499);
            DataRepository.CreateProduct(ProductType.Longplay, "The Wall", 54.99);
            DataRepository.CreateProduct(ProductType.LiveAlbum, "Live at Rome", 77.21);
        }

        [TestMethod]
        public void CreateTransaction()
        {
            DataRepository.CreateTransaction(1, 2, "21.04.2000");
        }
    }
    #endregion


}

