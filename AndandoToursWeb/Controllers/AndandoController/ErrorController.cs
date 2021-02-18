using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AndandoToursWeb.Data;
using AndandoToursWeb.Models;
using Microsoft.AspNetCore.Mvc;
namespace AndandoToursWeb.Controllers
{
    public class ErrorController : Controller
    {
        private readonly AndandoRepositorio _repo;

        public ErrorController(AndandoRepositorio repositorio /*ApisRoyal_GoldenData repositorioRoyal*/)
        {
            this._repo = repositorio;


        }

        [Route("Error/{statusCode}")]
        [Route("Error")]
        
        public async Task<IActionResult> Index()
        {
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            return View();
        }
    }
}
