using System;
using System.Collections.Generic;

namespace Bank.Models
{
    public partial class Bankcustomer
    {
        public Bankcustomer()
        {
            Bankaccount = new HashSet<Bankaccount>();
            Banktransaction = new HashSet<Banktransaction>();
        }

        public int Customerid { get; set; }
        public string Name { get; set; }
        public long? Sinnumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Postalcode { get; set; }
        public long Phone { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Bankaccount> Bankaccount { get; set; }
        public virtual ICollection<Banktransaction> Banktransaction { get; set; }
    }
}
