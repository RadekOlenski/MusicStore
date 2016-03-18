using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MusicStore
{
    namespace DataRepositoryTests
    {
        [TestClass]
        public class DataCreationTests
        {
            [TestMethod]
            public void CreateClient()
            {
                DataRepository.CreateClient("Adam", "Nowak", "Drzewna", "Lodz", 1990);
            }

            [TestMethod]
            public void CreateProduct()
            {
                DataRepository.CreateProduct(ProductType.GUITAR, "RX100", 1027.45);
                DataRepository.CreateProduct(ProductType.KEYBOARD, "Kronos", 15499);
                DataRepository.CreateProduct(ProductType.LONGPLAY, "The Wall", 54.99);
                DataRepository.CreateProduct(ProductType.LIVEALBUM, "Live at Rome", 77.21);
            }
        }
    }
}
