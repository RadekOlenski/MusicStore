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
    public class Guitar : Instrument
    {
        public Guitar(string Name, double Price) : base(Name, Price)
        {

        }

        public Guitar()
        {

        }
        
    }
}
