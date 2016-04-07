using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicStore.ConsoleApplication;
using System.Collections.Generic;
using MusicStore;

namespace DataRepositoryTests
{
    [TestClass]
    public class FillFromFileTests
    {
        FillRepositoryFromFile RepoFile = new FillRepositoryFromFile();

        [TestMethod]
        public void ReadFile()
        {           
            List <string> TestLines = RepoFile.ReadFile("clients.txt");
            foreach (var line in TestLines)
            {
                Console.WriteLine(line);
            }
        }

        [TestMethod]
        public void FillClients()
        {
            List<Client> clients = new List <Client> ();
            RepoFile.CreateClients(clients);
            foreach (Client client in clients)
            {
                Console.WriteLine("Client Name: {0} {1}, Street: {2}, City: {3}, Year of birth: {4}",
                    client.Name, client.Surname, client.Street, client.City, client.BirthYear);
            }

        }
    }
}
