using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AndandoToursWeb.Data;
using AndandoToursWeb.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace AndandoToursWeb.Controllers
{
    public class AboutController : Controller
    {
        private readonly AndandoRepositorio _repo;
        public AboutController(AndandoRepositorio repositorio)
        {
            this._repo = repositorio;
        }


        [Route("/about-us")]
        public async Task<ActionResult> Index()
        {
            
            ///Meta Tag + Canonical
            var idVista = 2022;


            var urlData = MyMethod(HttpContext);
            string urlCanonica = urlData[0];
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            var metadatos = await _repo.GetMetadata(idVista);
            ViewBag.Title = metadatos[0].MetaTitulo;
            ViewBag.MetaDescription = metadatos[0].MetaDescripcion;
            ViewBag.CanonicalURL = urlCanonica + metadatos[0].MetaURL;

            return View();
        }

        public List<String> MyMethod(Microsoft.AspNetCore.Http.HttpContext context)
        {
            var host = $"{context.Request.Scheme}://{context.Request.Host}";
            var urlCategories = context.Request.Path.Value;
            List<string> urlPagina = new List<string>();
            urlPagina.Add(host);
            urlPagina.Add(urlCategories);

            return urlPagina;
            // Other code
        }

        [Route("/about-us/media")]
        public async Task<ActionResult> Media()
        {
            ///Meta Tag + Canonical
            var idVista = 2025;
            var urlData = MyMethod(HttpContext);
            string urlCanonica = urlData[0];
            var metadatos = await _repo.GetMetadata(idVista);
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.Title = metadatos[0].MetaTitulo;
            ViewBag.MetaDescription = metadatos[0].MetaDescripcion;
            ViewBag.CanonicalURL = urlCanonica + metadatos[0].MetaURL;
            return View();
        }
        public async Task<IActionResult> sustainable_travel()
        {
            ViewData["Message"] = "Sustainable Travel";
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            return View();
        }
        public async Task<IActionResult> ourTeam()
        {
            ViewData["Message"] = "Our Team";
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            return View(await _repo.GetTeam());
        }

        [Route("/about-us/angermeyer-cruises")]
      
        public async Task<ActionResult> Angermeyer()
        {

            ///Meta Tag + Canonical
            var idVista = 2023;
            var urlData = MyMethod(HttpContext);
            string urlCanonica = urlData[0];
            var metadatos = await _repo.GetMetadata(idVista);
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.Title = metadatos[0].MetaTitulo;
            ViewBag.MetaDescription = metadatos[0].MetaDescripcion;
            ViewBag.CanonicalURL = urlCanonica + metadatos[0].MetaURL;

            return View();
        }
        public async Task<IActionResult> angermeyerHistory()
        {
            ViewData["Message"] = "Angermeyer History";
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            return View();
        }
    }
}