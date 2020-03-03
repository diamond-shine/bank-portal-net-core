using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bank.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bank.Controllers
{
    public class TransactionController : Controller
    {
        private IRepository repository;
        public TransactionController(IRepository repo) => repository = repo;
        public async Task<ViewResult> AllTransactions(int id)
        {
            var trasactions = (from t in repository.Banktransaction
                               where t.Customerid == id
                               orderby t.TransactionDate
                               select t).ToListAsync();

            ViewBag.NumOfTransactions = repository.Procedures.GetNumOfTransactions(id);

            return View(await trasactions);
        }

        public async Task<ViewResult> Transactions(int id, int aId)
        {
            var trasactions = (from t in repository.Banktransaction
                                                       where t.Customerid == id && t.Accountnumber == aId
                                                       select t).ToListAsync();

            ViewBag.Date = $"{DateTime.Now.ToShortDateString()} {DateTime.Now.ToShortTimeString()}";
            return View(await trasactions);
        }
    }
}