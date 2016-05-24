using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore
{
    public interface ITXTSerializable
    {
        string ToSerialize();
        int CountArguments();
    }
}
