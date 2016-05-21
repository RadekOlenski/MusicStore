#region includes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MusicStore
{
    public class Product
    {
        #region Constructor
        public Product(string Name, double Price)
        {
            this.Name = Name;
            this.Price = Price;
        }

        public Product()
        {
            this.Name = "default";
            this.Price = 0;
        }

        static Product()
        {
            _generalProductID = 0;
        }
        #endregion

        #region Variables

        private static int _generalProductID;

        #endregion

        #region Properties

        public string Name { get; set; }

        public double Price { get; set; }

        public static int GeneralProductID { get { return _generalProductID; } }

        #endregion

        #region Public Methods
        public static int GenerateProductID()
        {
            _generalProductID++;
            return GeneralProductID - 1;
        }

        public static void DeleteProductID()
        {
            _generalProductID--;
        }

        public override string ToString()
        {
            string result = "Product Type: " + this.GetType() + ", Name: " + this.Name + ", Price: " + this.Price;
            return result;
        }

        #endregion

    }
}
