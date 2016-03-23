using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicStore;

namespace DataRepositoryTests
{
    [TestClass]
    public class FilterTests
    {
        [TestMethod]
        public void FilterByClientAge()
        {
            DataRepository.FilterByClientAge(18);
        }

        [TestMethod]
        public void FilterByGreaterProductPrice()
        {
            DataRepository.FilterByGreaterProductPrice(200.99);
        }
    }
}
