using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Models
{
    public enum AccountType { Checking, Savings, Investment}
    public class Account
    {
        public int AccountNumber { get; set; }
        public int ManagerId { get; set; }
        public decimal Balance { get; set; }
        public AccountType AccountType { get; set; }
    }
}
