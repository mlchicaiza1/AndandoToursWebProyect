using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
namespace AndandoToursWeb.Controllers
{
    public class contactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
