using System;
using System.Collections.Generic;

namespace Bank.Models
{
    public partial class Bankaccount
    {
        public Bankaccount()
        {
            Banktransaction = new HashSet<Banktransaction>();
        }

        public int Accountnumber { get; set; }
        public int Customerid { get; set; }
        public byte Branchid { get; set; }
        public byte Managerid { get; set; }
        public byte Accounttype { get; set; }
        public decimal Balance { get; set; }

        public virtual Accounttypes AccounttypeNavigation { get; set; }
        public virtual Bankbranch Branch { get; set; }
        public virtual Bankcustomer Customer { get; set; }
        public virtual Bankemployee Manager { get; set; }
        public virtual ICollection<Banktransaction> Banktransaction { get; set; }
    }
}
