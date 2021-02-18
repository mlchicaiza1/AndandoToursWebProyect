using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AndandoToursWeb.Data;
using AndandoToursWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace AndandoToursWeb.Controllers
{
    public class blogController : Controller
    {

        private readonly AndandoRepositorio _repo;
        public blogController(AndandoRepositorio repositorio)
        {
            this._repo = repositorio;

        }

        [Route("blog")]
        public async Task<ActionResult>  blogHome()
        {
            var urlData =  _repo.getUrlPage(HttpContext);
            string urlCanonica = urlData[0];
            var idVista = 2061;
            var metadatos = await _repo.GetMetadata(idVista);
            var cards = await _repo.GetAll();
            List<GetContenidoVista> contendido = await _repo.GetContenidoPaginaWeb(idVista);
            List<GetContenidoMultimedia> contenidoMultimedia = await _repo.GetContenidoMultimedia(idVista);
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.Title = metadatos[0].MetaTitulo;
            ViewBag.MetaDescription = metadatos[0].MetaDescripcion;
            ViewBag.CanonicalURL = urlCanonica + metadatos[0].MetaURL;
            ViewBag.GetContenidoVista = contendido;
            ViewBag.GetContenidoMult = contenidoMultimedia;
            return View();
        }

        [Route("/blog/ecuador-cloud-forest")]
        public async Task<ActionResult> ecuador_cloud_forest()
        {
            var urlData = _repo.getUrlPage(HttpContext);
            string urlCanonica = urlData[0];
            var idVista = 2058;
            var metadatos = await _repo.GetMetadata(idVista);
            var cards = await _repo.GetAll();
            List<GetContenidoVista> contendido = await _repo.GetContenidoPaginaWeb(idVista);
            List<GetContenidoMultimedia> contenidoMultimedia = await _repo.GetContenidoMultimedia(idVista);
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.Title = metadatos[0].MetaTitulo;
            ViewBag.MetaDescription = metadatos[0].MetaDescripcion;
            ViewBag.CanonicalURL = urlCanonica + metadatos[0].MetaURL;
            ViewBag.GetContenidoVista = contendido;
            ViewBag.GetContenidoMult = contenidoMultimedia;
            return View();
        }
        [Route("/blog/ecuador-galapagos-travel-tips")]
        public async Task<ActionResult> ecuador_galapagos_travel_tips()
        {
            var urlData = _repo.getUrlPage(HttpContext);
            string urlCanonica = urlData[0];
            var idVista = 2059;
            var metadatos = await _repo.GetMetadata(idVista);
            var cards = await _repo.GetAll();
            List<GetContenidoVista> contendido = await _repo.GetContenidoPaginaWeb(idVista);
            List<GetContenidoMultimedia> contenidoMultimedia = await _repo.GetContenidoMultimedia(idVista);
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.Title = metadatos[0].MetaTitulo;
            ViewBag.MetaDescription = metadatos[0].MetaDescripcion;
            ViewBag.CanonicalURL = urlCanonica + metadatos[0].MetaURL;
            ViewBag.GetContenidoVista = contendido;
            ViewBag.GetContenidoMult = contenidoMultimedia;
            return View();
        }

        [Route("/blog/galapagos-gay-cruises")]
        public async Task<ActionResult> galapagos_gay_cruises()
        {
            var urlData = _repo.getUrlPage(HttpContext);
            string urlCanonica = urlData[0];
            var idVista = 2060;
            var metadatos = await _repo.GetMetadata(idVista);
            var cards = await _repo.GetAll();
            List<GetContenidoVista> contendido = await _repo.GetContenidoPaginaWeb(idVista);
            List<GetContenidoMultimedia> contenidoMultimedia = await _repo.GetContenidoMultimedia(idVista);
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.Title = metadatos[0].MetaTitulo;
            ViewBag.MetaDescription = metadatos[0].MetaDescripcion;
            ViewBag.CanonicalURL = urlCanonica + metadatos[0].MetaURL;
            ViewBag.GetContenidoVista = contendido;
            ViewBag.GetContenidoMult = contenidoMultimedia;
            return View();
        }

        [Route("/blog/galapagos-cruises-for-seniors")]
        public async Task<ActionResult> galapagos_cruises_for_seniors()
        {
            var urlData = _repo.getUrlPage(HttpContext);
            string urlCanonica = urlData[0];
            var idVista = 3048;
            var metadatos = await _repo.GetMetadata(idVista);
            var cards = await _repo.GetAll();
            List<GetContenidoVista> contendido = await _repo.GetContenidoPaginaWeb(idVista);
            List<GetContenidoMultimedia> contenidoMultimedia = await _repo.GetContenidoMultimedia(idVista);
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.Title = metadatos[0].MetaTitulo;
            ViewBag.MetaDescription = metadatos[0].MetaDescripcion;
            ViewBag.CanonicalURL = urlCanonica + metadatos[0].MetaURL;
            ViewBag.GetContenidoVista = contendido;
            ViewBag.GetContenidoMult = contenidoMultimedia;
            return View();
        }

        [Route("/blog/travel-insurance")]
        public async Task<ActionResult> travel_insurance()
        {
            var urlData = _repo.getUrlPage(HttpContext);
            string urlCanonica = urlData[0];
            var idVista = 3050;
            var metadatos = await _repo.GetMetadata(idVista);
            var cards = await _repo.GetAll();
            List<GetContenidoVista> contendido = await _repo.GetContenidoPaginaWeb(idVista);
            List<GetContenidoMultimedia> contenidoMultimedia = await _repo.GetContenidoMultimedia(idVista);
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.Title = metadatos[0].MetaTitulo;
            ViewBag.MetaDescription = metadatos[0].MetaDescripcion;
            ViewBag.CanonicalURL = urlCanonica + metadatos[0].MetaURL;
            ViewBag.GetContenidoVista = contendido;
            ViewBag.GetContenidoMult = contenidoMultimedia;
            return View();
        }

        [Route("/blog/travel-story/ideal-vacation-for-photographers-and-nature-lovers")]
        public async Task<ActionResult> ideal_vacation_photographers_nature_lovers()
        {
            var urlData = _repo.getUrlPage(HttpContext);
            string urlCanonica = urlData[0];
            var idVista = 3051;
            var metadatos = await _repo.GetMetadata(idVista);
            var cards = await _repo.GetAll();
            List<GetContenidoVista> contendido = await _repo.GetContenidoPaginaWeb(idVista);
            List<GetContenidoMultimedia> contenidoMultimedia = await _repo.GetContenidoMultimedia(idVista);
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.Title = metadatos[0].MetaTitulo;
            ViewBag.MetaDescription = metadatos[0].MetaDescripcion;
            ViewBag.CanonicalURL = urlCanonica + metadatos[0].MetaURL;
            ViewBag.GetContenidoVista = contendido;
            ViewBag.GetContenidoMult = contenidoMultimedia;
            return View();
        }
        public IActionResult blogPost()
        {
            return View();
        }
        [Route("/blog/8-reasons-why-visit-galapagos")]
        [Route("/blog/marine-sanctuary")]
        public async Task<IActionResult> ReasonsWhy()
        {
            var urlData = _repo.getUrlPage(HttpContext);
            string urlCanonica = urlData[0];
            string[] words = urlData[1].Split('/');
            var idVista = 0;
            if (words.Count() == 3)
            {
                switch (words[2])
                {
                    case "8-reasons-why-visit-galapagos":
                        idVista = 2053;
                        break;
                    case "marine-sanctuary":
                        idVista = 3049;
                        break;
                }
            }
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
        [Route("/blog/best-time-to-visit-the-ecuadorian-amazon")]
        public async Task<IActionResult> bestTime()
        {
            var urlData = _repo.getUrlPage(HttpContext);
            string urlCanonica = urlData[0];
            var idVista = 2054;
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
        [Route("/blog/best-way-to-travel-galapagos")]
        public async Task<IActionResult> bestAway()
        {
            var urlData = _repo.getUrlPage(HttpContext);
            string urlCanonica = urlData[0];
            var idVista = 2055;
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
        [Route("/blog/galapagos-vs-caribbean-cruises")]
        public async Task<IActionResult> galapagosCaribean()
        {
            var urlData = _repo.getUrlPage(HttpContext);
            string urlCanonica = urlData[0];
            var idVista = 2056;
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
        [Route("/blog/galapagos-cruise-categories")]
        public async Task<IActionResult> galapagos()
        {
            var urlData = _repo.getUrlPage(HttpContext);
            string urlCanonica = urlData[0];
            var idVista = 2057;
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
        public ActionResult cruises_for_single_adventurers() {
            return View("cruises-for-single-adventurers");
        }
    }
}