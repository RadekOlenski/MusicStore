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
        public Client(string Name, string Surname, string Street, string City, int BirthYear)
        {
            _name = Name;
            _surname = Surname;
            _street = Street;
            _city = City;
            _birthYear = BirthYear;
        }
        #endregion

        #region Client Info Variables
        private string _name;
        private string _surname;
        private string _street;
        private string _city;
        private int _birthYear;
        #endregion
    }
}
