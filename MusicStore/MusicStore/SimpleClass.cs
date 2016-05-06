using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore
{
    public class SimpleClass
    {

        public string StringValue { get; set; }

        public int IntValue { get; set; }

        public SimpleClass(string StringValue, int IntValue)
        {
            this.StringValue = StringValue;
            this.IntValue = IntValue;
        }

    }
}
