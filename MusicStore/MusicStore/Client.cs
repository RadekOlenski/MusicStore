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
            GenerateClientID();
            this.Name = Name;
            this.Surname = Surname;
            this.Street = Street;
            this.City = City;
            this.BirthYear = BirthYear;
        }
        #endregion
       
        #region Variables

        private static int _generalClientID = 0;

        #endregion

        #region Properties
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int BirthYear { get; set; }
        public static int GeneralClientID { get { return _generalClientID; } }
        #endregion

        #region Methods
        public static int GenerateClientID()
        {
            _generalClientID++;
            return GeneralClientID - 1;
        }
        #endregion
    }
}