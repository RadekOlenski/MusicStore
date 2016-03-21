﻿using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MusicStore;

namespace DataRepositoryTests
{
   
    [TestClass]
    public class DataUpdateTests
    {
        [TestMethod]
        public void UpdateClientName()
        {
            DataRepository.GetSpecificClient(0);
            DataRepository.UpdateClientName(0, "Krystian");
            DataRepository.GetSpecificClient(0);
        }

        [TestMethod]
        public void UpdateClientSurname()
        {
            DataRepository.GetSpecificClient(0);
            DataRepository.UpdateClientSurname(0, "Smith");
            DataRepository.GetSpecificClient(0);
        }

        [TestMethod]
        public void UpdateClientStreet()
        {
            DataRepository.GetSpecificClient(0);
            DataRepository.UpdateClientStreet(0, "Piotrkowska 23");
            DataRepository.GetSpecificClient(0);
        }

        [TestMethod]
        public void UpdateClientCity()
        {
            DataRepository.GetSpecificClient(0);
            DataRepository.UpdateClientName(0, "Washington DC");
            DataRepository.GetSpecificClient(0);
        }

        [TestMethod]
        public void UpdateClientBirthYear()
        {
            DataRepository.GetSpecificClient(0);
            DataRepository.UpdateClientBirthYear(0, 2015);
            DataRepository.GetSpecificClient(0);
        }
    }
}