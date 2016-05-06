#region includes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MusicStore
{
    public class MusicAlbum : Product
    {
        public uint Year { get; set; }
        public string Band { get; set; }

        public MusicAlbum(string Name, double Price, uint Year, string Band) : base(Name, Price)
        {
            this.Year = Year;
            this.Band = Band;
        }
    }
}
