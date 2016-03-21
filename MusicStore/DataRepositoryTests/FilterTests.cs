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
    }
}
