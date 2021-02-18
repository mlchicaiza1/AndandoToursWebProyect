using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AndandoToursWeb.DataCMS;
using AndandoToursWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AndandoToursWeb.Controllers
{
    public class ActividadUsuarioController : Controller
    {
        private readonly CmsAndandoRepositorio _repo;
        private readonly UserManager<ApplicationUser> _userManager;

        public ActividadUsuarioController(CmsAndandoRepositorio repositorio, UserManager<ApplicationUser> userManeger)
        {
            this._repo = repositorio;
            this._userManager = userManeger;
        }

        [Authorize(Roles = "Administrator")]
        [Route("/AndandoCms/ActividadUsuarios")]
        public IActionResult ActividadUsuario()
        {
            return View();
        }

        [Route("/ActividadUsuarios")]
        [HttpGet]
        public async Task<ActionResult<List<GetRegistroActividadUsuarios>>> GetActividadUsuarios()
        {
            return await _repo.GetActividadUsuarios();
        }
    }
}