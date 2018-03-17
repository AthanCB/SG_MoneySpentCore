using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SG_MoneySpentCore.Data;
using SG_MoneySpentCore.Models;

namespace SG_MoneySpentCore.Controllers
{
    public class HomeController : Controller
    {
        public HomeController(SpentContext context)
        {
            _context = context;
        }
        private SpentContext _context;
        public IActionResult Index()
        {
            RefreshUser();
            return View();
        }
       

        [HttpPost]
        public IActionResult Index(Balance item)
        {
            item.Id = Guid.NewGuid().ToString("N");
            var user = _context.Users.First();
            if (item.Type.Equals(BalanceType.Add))
            {
                item.CategoryId = _context.Categories.FirstOrDefault(x => x.Name.Equals("Earn")).Id;
                user.Balance += item.Value;
                _context.Balances.Add(item);
            }
            else
            {
                user.Balance -= item.Value;
                item.Value = -item.Value;
                _context.Balances.Add(item);

            }
            
            _context.Users.Update(user);
            _context.SaveChanges();
            RefreshUser();
            return View(item);
        }

       
        public void RefreshUser()
        {
            List<Category> li = new List<Category>();
            li = _context.Categories.ToList();
            ViewBag.listofcat = li;
            List<User> users = new List<User>();
            users = _context.Users.ToList();
            ViewBag.user = users.First().Balance;
            ViewBag.listofbalances = _context.Balances.ToList();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Pie()
        {
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
