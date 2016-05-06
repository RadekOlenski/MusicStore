using MusicStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MusicStore
{
    public class TransactionEqualityComparer : IEqualityComparer<Transaction>
    {
        public Func<Transaction, object> KeySelector { get; set; }

        public TransactionEqualityComparer()
        {

        }

        public TransactionEqualityComparer(Func<Transaction, object> keySelector)
        {
            KeySelector = keySelector;
        }

        public bool Equals(Transaction x, Transaction y)
        {
            return x.ClientID.Equals(y.ClientID) && x.ProductID.Equals(y.ProductID);
        }

        public int GetHashCode(Transaction obj)
        {
            return (obj.ClientID + obj.ProductID).GetHashCode();
        }
    }
}
