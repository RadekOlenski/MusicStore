#region includes
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MusicStore
{
    [Serializable]
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

        public Transaction()
        {

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

        #region Overrides
        public override string ToString()
        {
            return "Transaction Date: " + this.Date;
        } 
        #endregion
       
    }
}
