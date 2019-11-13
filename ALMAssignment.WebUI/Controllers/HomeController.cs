using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ALMAssignment.WebUI.Models;
using ALMAssignment.WebUI.Models.ViewModels;

namespace ALMAssignment.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly BankRepository _repo;

        public HomeController(BankRepository repo)
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var model = new CustomerAccountViewModel();
            model.Accounts = _repo.Accounts;
            model.Customers = _repo.Customers;

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
