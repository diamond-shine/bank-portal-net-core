using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bank.Models;
using Bank.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bank.Controllers
{
    public class AccountController : Controller
    {
        private IRepository repository;
        public AccountController(IRepository repo) => repository = repo;
        public async Task<ViewResult> AccountDetails(int id) => View((await 
                                                   (from account in repository.Bankaccount
                                                    where account.Accountnumber == id 
                                                    select account).ToListAsync())[0]);

        public ViewResult AddAccount(int id)
        {
            AddAccountViewModel model = new AddAccountViewModel
            {
                AccountTypes = repository.Accounttypes,
                Branches = repository.Bankbranch,
                Employees = repository.Bankemployee,
                CustomerId = id
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult AddToAccount(AddAccountViewModel model)
        {
            if (ModelState.IsValid)
            {

                bool result = repository.Procedures.AddAccount
                    (
                        customerId: model.CustomerId,
                        branchId: model.BranchId,
                        managerId: model.EmployeeId,
                        accountType: model.AccountType,
                        initial: model.InitialAmount
                    );

                if (result)
                {
                    TempData["success"] = "Account added successfully!";
                }
                else
                {
                    TempData["error"] = "Account couldn't be created";
                }
                TempData["id"] = model.CustomerId;
                return RedirectToAction(nameof(AddToAccount));
            }

            model.AccountTypes = repository.Accounttypes;
            model.Branches = repository.Bankbranch;
            model.Employees = repository.Bankemployee;
            
            return View(nameof(AddAccount), model);
            
        }

        public async Task<IActionResult> AddToAccount()
        {
            int id = (int) TempData["id"];

            Bankcustomer bankCustomer = (await (from customer in repository.Bankcustomer
                                                where customer.Customerid == id
                                                select customer).ToListAsync())[0];

            return View("../Customer/Customer",bankCustomer);
        }
    }
}