using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace PriseEnMain.Controllers
{
    public class HelloWordController : Controller
    {
        // 
        // GET: /HelloWorld/
        public IActionResult Index()
        {
            return View();
        }

        // GET: /HelloWorld/Welcome/ 

        // Requires using System.Text.Encodings.Web;
        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }
    }
}
