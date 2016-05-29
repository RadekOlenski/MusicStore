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
    public class LiveAlbum : MusicAlbum
    {
        public LiveAlbum(string Name, double Price, uint Year, string Band) : base(Name, Price, Year, Band)
        {

        }

        public LiveAlbum() { }

    }
}
