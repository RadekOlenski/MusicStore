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
    //Instead of using not meaningful numbers you can use const property like: "ProductType.Guitar"
    public enum ProductType
    {
        Guitar = 0,
        Keyboard = 1,
        Longplay = 2,
        LiveAlbum = 3,
    }
}
