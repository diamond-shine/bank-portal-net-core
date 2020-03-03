using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Models
{
    public interface IRepository
    {
        ProceduresDbContext Procedures { get; }
        IQueryable<Accounttypes> Accounttypes { get; }
        IQueryable<Bankaccount> Bankaccount { get; }
        IQueryable<Bankbranch> Bankbranch { get; }
        IQueryable<Bankcustomer> Bankcustomer { get; }
        IQueryable<Bankemployee> Bankemployee { get; }
        IQueryable<Banktransaction> Banktransaction { get; }

    }
}
