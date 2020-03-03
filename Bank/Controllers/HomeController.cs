using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bank.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bank.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index() => View();
    }
}