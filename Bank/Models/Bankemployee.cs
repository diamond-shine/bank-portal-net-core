using System;
using System.Collections.Generic;

namespace Bank.Models
{
    public partial class Bankemployee
    {
        public Bankemployee()
        {
            Bankaccount = new HashSet<Bankaccount>();
        }

        public byte Empid { get; set; }
        public byte Branchid { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Province { get; set; }
        public string Postalcode { get; set; }
        public long Phone { get; set; }
        public string Email { get; set; }
        public byte? Managerid { get; set; }

        public virtual Bankbranch Branch { get; set; }
        public virtual ICollection<Bankaccount> Bankaccount { get; set; }
    }
}
