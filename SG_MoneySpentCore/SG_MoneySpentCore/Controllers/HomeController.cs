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
        public IActionResult Index(ItemSpent item)
        {
            item.Id = Guid.NewGuid().ToString("N");
            _context.ItemsSpent.Add(item);
            var user = _context.Users.First();
            user.Balance -= item.Value;
            _context.Users.Update(user);
            _context.SaveChanges();
            RefreshUser();
            return View(item);
        }

        public IActionResult Index(ItemSpent amount)
        {
            
            return View(amount);
        }

        public void RefreshUser()
        {
            List<Category> li = new List<Category>();
            li = _context.Categories.ToList();
            ViewBag.listofcat = li;
            List<User> users = new List<User>();
            users = _context.Users.ToList();
            ViewBag.user = users.First().Balance;
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
