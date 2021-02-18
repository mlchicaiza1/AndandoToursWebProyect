using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace AndandoToursWeb.Controllers
{
    public class islandHoppingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult product() {
            return View();
        }
        public IActionResult ih_expereince() {
            return View();
        }
        public IActionResult ih_vs_cruises()
        {
            return View();
        }
        public IActionResult serious_warnings()
        {
            return View();
        }
    }
}