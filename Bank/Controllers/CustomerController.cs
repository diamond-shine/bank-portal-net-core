using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bank.Infrastructure;
using Bank.Models;
using Bank.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Bank.Controllers
{
    public class CustomerController : Controller
    {
        IRepository repository;

        public CustomerController(IRepository repo)
        {
            repository = repo;
        }

        public ViewResult Customers() => View(repository.Bankcustomer);

        [HttpPost]
        public async Task<IActionResult> Customer(string userName, string password)
        {
            Bankcustomer bankcustomer;
            try
            {
                bankcustomer = (await (from customer in repository.Bankcustomer
                                     where customer.Name == userName
                                     && customer.Password == password
                                     select customer).ToListAsync())[0];
            }
            catch (Exception)
            {
                bankcustomer = null;
            }
            if (bankcustomer != null)
            {
                return View(bankcustomer);
            }
            else
            {
                TempData["message"] = "Wrong user name or password!!!";

                return View("../Customer/Login");
            }
        }

        public ViewResult Login() => View();

        [HttpPost]
        public async Task<IActionResult> CustomerInfo(int id)
        {
            Bankcustomer bankCustomer;
            try
            {
                bankCustomer = (await (from customer in repository.Bankcustomer
                                      where customer.Customerid == id
                                      select customer).ToListAsync())[0];
            }
            catch (ArgumentOutOfRangeException)
            {
                bankCustomer = null;
            }
 
            if (bankCustomer != null)
            {
                return View(nameof(CustomerInfo), bankCustomer);
            }
            else
            {
                TempData["message"] = "ID not found";

                return View("../Home/Index");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddTransaction(int customerId, int accountNumber, decimal amount)
        {
            var bankCustomerTask = (from customer in repository.Bankcustomer
                                         where customer.Customerid == customerId
                                         select customer).ToListAsync();

            if (customerId != 0 && accountNumber != 0 && amount != 0)
            {
                bool result = repository.Procedures.AddTransaction(customerId, accountNumber, amount);

                if (result)
                {
                    TempData["success"] = $"Transaction of ${amount.ToString("#,##0.00")} was succesful";

                    return View(nameof(CustomerInfo), (await bankCustomerTask)[0]);
                }
            }
            TempData["error"] = "Error in trasaction";
            return View(nameof(CustomerInfo), (await bankCustomerTask)[0]);
        }
    }
}