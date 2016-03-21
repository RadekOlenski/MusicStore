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
        #endregion

        #region Variables
        private static int _productID = 0;

        public string Name { get; set; }

        public double Price { get; set; }
        #endregion

        #region Public Methods
        public static int GenerateProductID()
        {
                _productID++;
                return _productID - 1;
        }
        #endregion

    }
}
