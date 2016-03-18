#region includes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MusicStore
{
    public class Client
    {

        #region Constructor
        public Client(string name, string surname, string street, string city, int birthYear)
        {
            Name = name;
            Surname = surname;
            Street = street;
            City = city;
            BirthYear = birthYear;
        }
        #endregion

        #region Client Info Variables
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int BirthYear { get; set; }
        #endregion
    }
}
