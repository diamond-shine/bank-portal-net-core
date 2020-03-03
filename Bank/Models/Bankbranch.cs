using System;
using System.Collections.Generic;

namespace Bank.Models
{
    public partial class Bankbranch
    {
        public Bankbranch()
        {
            Bankaccount = new HashSet<Bankaccount>();
            Bankemployee = new HashSet<Bankemployee>();
        }

        public byte Branchid { get; set; }
        public string Branchname { get; set; }
        public string Address { get; set; }
        public string Province { get; set; }
        public string Postalcode { get; set; }
        public long Phone { get; set; }

        public virtual ICollection<Bankaccount> Bankaccount { get; set; }
        public virtual ICollection<Bankemployee> Bankemployee { get; set; }
    }
}
