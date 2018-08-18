using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using JoeMatteson.Models;

namespace JoeMatteson.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Email"] = "Joseph1matteson@outlook.com";
            ViewData["Phone"] = "763-350-2822";
            ViewData["LinkedIn"] = "https://www.linkedin.com/in/joseph-matteson/";
            ViewData["GitHub"] = "https://github.com/jmatte123";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
