using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bank.Models
{
    public class Repository: IRepository
    {
        private ModelContext context;
        public ProceduresDbContext Procedures { get; }

        public Repository(ModelContext ctx, ProceduresDbContext procedures)
        {
            context = ctx;
            Procedures = procedures;
        }

        public IQueryable<Accounttypes> Accounttypes => context.Accounttypes
                                                            .Include(at => at.Bankaccount)
                                                                .ThenInclude(a => a.AccounttypeNavigation);
        public IQueryable<Bankaccount> Bankaccount => context.Bankaccount
                                                        .Include(a => a.Banktransaction)
                                                            .ThenInclude(bt => bt.AccountnumberNavigation)
                                                        .Include(a => a.AccounttypeNavigation);
        public IQueryable<Bankbranch> Bankbranch => context.Bankbranch;
        public IQueryable<Bankcustomer> Bankcustomer => context.Bankcustomer
                                                            .Include(c => c.Banktransaction)
                                                                .ThenInclude(bt => bt.Customer) //include customer to transactions
                                                            .Include(c => c.Bankaccount)
                                                                .ThenInclude(a => a.Customer) // include customer to accounts
                                                            .Include(c => c.Bankaccount)
                                                                 .ThenInclude(a => a.AccounttypeNavigation); // include accountType to accounts
        public IQueryable<Bankemployee> Bankemployee => context.Bankemployee;
        public IQueryable<Banktransaction> Banktransaction => context.Banktransaction;

    }
}
