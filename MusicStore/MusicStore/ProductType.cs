#region includes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MusicStore
{
    //This class is created to store const values representing different types of products. These values can be accessed in every other class
    //Instead of using not meaningful numbers you can use const property like: "ProductType.GUITAR"
    public static class ProductType
    {
        public const int GUITAR = 0;
        public const int KEYBOARD = 1;
        public const int LONGPLAY = 2;
        public const int LIVEALBUM = 3;
    }
}
