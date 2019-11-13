using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ALMAssignment.WebUI.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ALMAssignment.WebUI.Controllers
{
    public class AccountController : Controller
    {
        private readonly BankRepository repo;

        public AccountController(BankRepository repo)
        {
            this.repo = repo;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Transfer()
        {
            return View();
        }

        public IActionResult Deposit(decimal amount, int accountId)
        {
            var account = repo.Accounts.Where(m => m.AccountID == accountId).SingleOrDefault();

            if (account == null)
            {
                TempData["info"] = "Account id not found.";
            }
            else
            {
                try
                {
                    account.Deposit(amount);
                    TempData["info"] = "Deposit successful, new balance: " + account.Balance;
                }
                catch (Exception e)
                {
                    TempData["info"] = "Failed to deposit, make sure amount is a valid positive amount.";
                }
            }

            return RedirectToAction("Transfer");
        }

        public IActionResult Withdraw(decimal amount, int accountId)
        {
            var account = repo.Accounts.Where(m => m.AccountID == accountId).SingleOrDefault();

            if (account == null)
            {
                TempData["info"] = "Account id not found.";
            }
            else
            {
                try
                {
                    account.Withdraw(amount);
                    TempData["info"] = "Withdrawal successful, new balance: " + account.Balance;
                }
                catch (Exception e)
                {
                    TempData["info"] = "Failed to withdraw, make sure amount is a valid positive amount.";
                }
            }

            return RedirectToAction("Transfer");
        }
    }
}
