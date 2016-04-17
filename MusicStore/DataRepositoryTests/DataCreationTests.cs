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
        //System Under Test object (sut)
        private DataRepository sut;

        [TestInitialize]
        private void init()
        {
            //Initialization of sut
            sut = new DataRepository();
        }

        [TestMethod]
        //This method tests creating new Client Objects
        public void CreateClient()
        {
            for (int i = 0; i < 10; i++)
            {
                try
                {
                    sut.CreateClient("Adam", "Nowak", "Drzewna", "Lodz", 1990);
                }
                catch (NullReferenceException)
                {
                    Assert.Fail();
                }
                
            }

            //sut.CreateClient("Adam", "Nowak", "Drzewna", "Lodz", 1990);
            //sut.CreateClient("Radek", "Olenski", "Pierwsza", "Lodz", 1994);
            //sut.CreateClient("Marcin", "Jozwik", "Druga", "Lodz", 1995);
        }

        [TestMethod]
        //This method tests creating new Product Objects for every type of Product
        public void CreateProduct()
        {
            sut.CreateProduct(ProductType.Guitar, "RX100", 1027.45);
            sut.CreateProduct(ProductType.Keyboard, "Kronos", 15499);
            sut.CreateProduct(ProductType.Longplay, "The Wall", 54.99);
            sut.CreateProduct(ProductType.LiveAlbum, "Live at Rome", 77.21);
        }

        [TestMethod]
        public void CreateTransaction()
        {
            sut.CreateTransaction(1, 2, "21.04.2000");
        }
    }
    #endregion


}

