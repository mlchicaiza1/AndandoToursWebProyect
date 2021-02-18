using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AndandoToursWeb.Data;
using AndandoToursWeb.Models;
using Microsoft.AspNetCore.Mvc;
 namespace AndandoToursWeb.Controllers
{
    public class thank_you_pageController : Controller
    {
        private readonly AndandoRepositorio _repo;
        public thank_you_pageController(AndandoRepositorio repositorio)
        {
            this._repo = repositorio;
        }
        public async Task<IActionResult> thank_you_page_availability(string Email, string Name, string FechaDesde,
            string FechaFin, string NumeroPax, string Budget, string Observacion, string taylor,
            string IP, string CountryCode, string CityName)
        {


            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;

            return View(_repo.SendEmailTaylorMade(
                 Email, Name, FechaDesde,
             FechaFin, NumeroPax, Budget, Observacion, taylor,
             IP, CountryCode, CityName));



        }


        public async Task<IActionResult> thank_you_page_Andando(string Email, string Name, string FechaDesde,
           string NumeroPax, string Category,   string taylor,
          string IP, string CountryCode, string CityName, string TipoTours)
        {


            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;

            return View(_repo.SendEmailPackage(
                 Email, Name, FechaDesde,
              NumeroPax, Category,  taylor,
             IP, CountryCode, CityName, TipoTours));


        }
        public IActionResult thank_you_page_island_hopping(string email, string name, string taylor, string obser)
        {
            return View(_repo.SendEmail(email, name, taylor, obser));
        }
        public IActionResult thank_you_page_cruise()
        {
            return View();
        }

        [Route("/thank-you-tours/")]
        public async  Task< IActionResult> thank_you_page_daily_tours()
        {
            var urlData = _repo.getUrlPage(HttpContext);
            string urlCanonica = urlData[0];
            var idVista = 3055;
            //Cargar Mapa
            //Cargar Contenido texto e imagenes
            List<GetContenidoVista> contendido = await _repo.GetContenidoPaginaWeb(idVista);
            //Cargar cards Ecuador Itinerarios
            List<GetContenidoVista> contendidoCards = await _repo.GetContenidoPaginaWeb(2049);
            List<GetContenidoMultimedia> contenidoMultimedia = await _repo.GetContenidoMultimedia(2049);
            //Enviar datos a la vista Home
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.GetContenidoVista = contendido;
            ViewBag.GetContenidoMult = contenidoMultimedia;
            ViewBag.GetCards = contendidoCards;
            return View();
        }

        [Route("/thank-you-andando/")]
        public async Task<IActionResult> thank_you_page_tailor_made()
        {

            var urlData = _repo.getUrlPage(HttpContext);
            string urlCanonica = urlData[0];
            var idVista = 3056;
            //Cargar Mapa
            //Cargar Contenido texto e imagenes
            List<GetContenidoVista> contendido = await _repo.GetContenidoPaginaWeb(idVista);
            List<GetContenidoMultimedia> contenidoMultimedia = await _repo.GetContenidoMultimedia(idVista);
            //Enviar datos a la vista Home
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.GetContenidoVista = contendido;
            ViewBag.GetContenidoMult = contenidoMultimedia;
            return View();
        }

        [Route("/thank-you-page-availability/")]
        public async Task<IActionResult> thank_you_page_availabilityTripPlanner()
        {

            var urlData = _repo.getUrlPage(HttpContext);
            string urlCanonica = urlData[0];
            var idVista = 3056;
            //Cargar Mapa
            //Cargar Contenido texto e imagenes
            List<GetContenidoVista> contendido = await _repo.GetContenidoPaginaWeb(idVista);
            List<GetContenidoMultimedia> contenidoMultimedia = await _repo.GetContenidoMultimedia(idVista);
            //Enviar datos a la vista Home
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.GetContenidoVista = contendido;
            ViewBag.GetContenidoMult = contenidoMultimedia;
            return View();
        }



    }
}