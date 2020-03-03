using System;
using System.Collections.Generic;

namespace Bank.Models
{
    public partial class Accounttypes
    {
        public Accounttypes()
        {
            Bankaccount = new HashSet<Bankaccount>();
        }

        public byte Typeid { get; set; }
        public string Typename { get; set; }

        public virtual ICollection<Bankaccount> Bankaccount { get; set; }
    }
}
