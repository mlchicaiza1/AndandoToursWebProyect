using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AndandoToursWeb.Models;
using AndandoToursWeb.DataCMS;
using Microsoft.AspNetCore.Identity;
using AndandoToursWeb.Data;

namespace AndandoToursWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly AndandoRepositorio _repo;
        public HomeController(AndandoRepositorio repositorio)
        {
            this._repo = repositorio;
        }
        [OutputCache(Duration = 120, VaryByHeader = "User-Agent")]
        public async Task<IActionResult> Index()
        {
            var urlData = _repo.getUrlPage(HttpContext);
            string urlCanonica = urlData[0];
            var idVista = 1010;
            List<GetContenidoVista> contendido = await _repo.GetContenidoPaginaWeb(idVista);
            List<GetContenidoMultimedia> contenidoMultimedia = await _repo.GetContenidoMultimedia(idVista);
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            var metadatos = await _repo.GetMetadata(idVista);
            ViewBag.Title = metadatos[0].MetaTitulo;
            ViewBag.MetaDescription = metadatos[0].MetaDescripcion;
            ViewBag.CanonicalURL = urlCanonica + metadatos[0].MetaURL;
            ViewBag.GetContenidoVista = contendido;
            ViewBag.GetContenidoMult = contenidoMultimedia;
            return View();
        }
        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";
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
        public IActionResult Media()
        {
            ViewData["Message"] = "Media Page";
            return View();
        }
        public IActionResult sustainableTravel()
        {
            ViewData["Message"] = "Sustainable Travel";
            return View();
        }
        public IActionResult ourTeam()
        {
            ViewData["Message"] = "Our Team";
            return View();
        }
    }
}
