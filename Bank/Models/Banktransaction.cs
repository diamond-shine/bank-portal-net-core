using System;
using System.Collections.Generic;

namespace Bank.Models
{
    public partial class Banktransaction
    {
        public int Transactionid { get; set; }
        public int? Customerid { get; set; }
        public int? Accountnumber { get; set; }
        public decimal Amount { get; set; }
        public DateTime TransactionDate { get; set; }

        public virtual Bankaccount AccountnumberNavigation { get; set; }
        public virtual Bankcustomer Customer { get; set; }
    }
}
