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
        }
    }
}
