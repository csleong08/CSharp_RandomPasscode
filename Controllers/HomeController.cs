using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RandomPasscode.Models;

namespace RandomPasscode.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            if(HttpContext.Session.GetInt32("Counter") == null)
            {
                HttpContext.Session.SetInt32("Counter", 0);
                int? IntVariable = HttpContext.Session.GetInt32("Counter");
            }

            return View("Index");
        }

        [HttpPost("create")]
        public IActionResult Create()
        {
            Random rand = new Random();
            var chars = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            var RandomPasscode = new char[14];
            for (int i = 0; i<RandomPasscode.Length; i++)
            {
                RandomPasscode[i] = chars[rand.Next(chars.Length)];
            }
            ViewBag.NewPasscode = new String(RandomPasscode); 

            int? IntVariable = HttpContext.Session.GetInt32("Counter");
            int counter = IntVariable.GetValueOrDefault() +1;
            HttpContext.Session.SetInt32("Counter", counter);
            // Alternate ViewBag Method:
            ViewBag.Counter = IntVariable;
            return View("Index");
        }
        [HttpGet]
        [Route("reset")]
        public IActionResult Reset()
        {
            HttpContext.Session.Clear();
            return View("Index");
        }
    }
}
