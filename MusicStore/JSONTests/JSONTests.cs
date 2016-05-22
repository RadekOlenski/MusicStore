using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicStore;
using MusicStoreConsoleApplication;

namespace JSONTests
{
    [TestClass]
    public class JSONTests
    {
        [TestMethod]
        public void ClientSerializationTest()
        {
            Client client = new Client("Tadeusz", "Nowak", "Random Street 23", "Lodz", 2005);
            JSONConverter jscon = new JSONConverter();
            jscon.writeObject(client, "clients.txt");
            Client secondClient = jscon.readClient("clients.txt");
            Assert.AreEqual(client.ToString(), secondClient.ToString());
        }
    }
}
