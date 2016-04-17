#region includes
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MusicStore
{
    public class Transaction
    {
        #region Constructor
        public Transaction(int ClientID, int ProductID, string Date)
        {
            GenerateTransactionID();
            this.ClientID = ClientID;
            this.ProductID = ProductID;
            this.Date = Date;
        }
        #endregion

        #region Properties
        private int _transactionID = 0;
        public int ClientID { get; set; }
        public int ProductID { get; set; }
        public string Date { get; set; }
        #endregion

        #region Methods
        void GenerateTransactionID()
        {
            _transactionID++;
        }
        #endregion

        public override string ToString()
        {
            return "Transaction Date: " + this.Date;
        }


    }
}
