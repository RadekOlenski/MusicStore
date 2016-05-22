#region includes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MusicStore
{
    [Serializable]
    public class Client
    {
        #region Constructor
        public Client(string Name = "None", string Surname = "None" , string Street = "None", string City = "None" , int BirthYear = 1900)
        {
            GenerateClientID();
            this.Name = Name;
            this.Surname = Surname;
            this.Street = Street;
            this.City = City;
            this.BirthYear = BirthYear;
        }

        public Client()
        {

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

        public override string ToString()
        {
            return "Client Name: " + this.Name + " " + this.Surname + ", Street: " + this.Street + ", City: " + this.City + ", Year of birth: " + this.BirthYear;
        }
        #endregion
    }
}