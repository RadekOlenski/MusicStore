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
            _name = Name;
            _price = Price;
        }
        #endregion

        #region Private Variables
        private static int _productID = 0;

        private string _name;

        private double _price;
        #endregion

        #region Public Methods
        public static int GenerateProductID()
        {
            //TODO: ID generation ??
            _productID++;
            return _productID;
        }
        #endregion

    }
}
