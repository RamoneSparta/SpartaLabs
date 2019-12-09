using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab_27_MVC_CORE.Models;

namespace Lab_27_MVC_CORE.Controllers
{
    public class HomeController : Controller
    {
        public List<string> MyList = new List<string>();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
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

        public IActionResult MyAction()
        {
            MyList = new List<string>() { "This is a list", "This is a list again", "This is a list for the third time" };
            ViewBag.MyItem = "This is some data";
            ViewData["AnotherItem"] = "And some more data";
            return View(MyList);
        }
    }
}
