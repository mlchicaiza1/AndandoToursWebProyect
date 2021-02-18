using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AndandoToursWeb.Models;
using AndandoToursWeb.Data;
using Microsoft.AspNetCore.Mvc;
namespace AndandoToursWeb.Controllers
{
    public class galapagos_daily_toursController : Controller
    {
        public async Task<IActionResult> dailyHome(int? id)
        {
            var urlProducto = getUrlPage(HttpContext);
            string urlCanonica = urlProducto[0];
            string[] words = urlProducto[1].Split('/');
            var idVista = 2037;
            //Caragar contenido islas y Dailytours para select
            var island = new List<Island>();
            island = await _repo.GetIsland();
            //Cargar Contenido texto e imagenes
            List<GetContenidoVista> contendido = await _repo.GetContenidoPaginaWeb(idVista);
            List<GetContenidoMultimedia> contenidoMultimedia = await _repo.GetContenidoMultimedia(idVista);
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            //Cargar metadatos para la vista con su respectiva url canonica
            var metadatos = await _repo.GetMetadata(idVista);
            ViewBag.Title = metadatos[0].MetaTitulo;
            ViewBag.MetaDescription = metadatos[0].MetaDescripcion;
            ViewBag.CanonicalURL = urlCanonica + metadatos[0].MetaURL;
            //Enviar datos a la vista Home
            ViewBag.GetContenidoVista = contendido;
            ViewBag.GetContenidoMult = contenidoMultimedia;
            ViewBag.Island = island;
            return View();
        }

        
        
        [Route("/tours/santa-cruz/{id?}")]
        public async Task<IActionResult> DailyTourIslandSantaCruz(int? id)
        {
            //url de la vista  
            var urlProducto = _repo.getUrlPage(HttpContext);
            string urlCanonica = urlProducto[0];
            string[] words = urlProducto[1].Split('/');
            var idVista = 2040;
            var breadcrumb = "Santa Cruz";
            //Cargar Contenido texto e imagenes
            List<GetContenidoVista> contendido = await _repo.GetContenidoPaginaWeb(idVista);
            List<GetContenidoMultimedia> contenidoMultimedia = await _repo.GetContenidoMultimedia(idVista);
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            //Cargar metadatos para la vista con su respectiva url canonica
            var metadatos = await _repo.GetMetadata(idVista);
            ViewBag.Title = metadatos[0].MetaTitulo;
            ViewBag.MetaDescription = metadatos[0].MetaDescripcion;
            ViewBag.CanonicalURL = urlCanonica + metadatos[0].MetaURL;
            //Enviar datos a la vista Home
            ViewBag.GetContenidoVista = contendido;
            ViewBag.GetContenidoMult = contenidoMultimedia;
            ViewBag.breadcrumb = breadcrumb;
            return View();
        }

        [Route("/tours/isabela/{id?}")]
        public async Task<IActionResult> DailyTourIslandIsabela(int? id)
        {
            //url de la vista  
            var urlProducto = _repo.getUrlPage(HttpContext);
            string urlCanonica = urlProducto[0];
            string[] words = urlProducto[1].Split('/');
            var idVista = 2038;
            var breadcrumb = "Isabela";
            //Cargar Contenido texto e imagenes
            List<GetContenidoVista> contendido = await _repo.GetContenidoPaginaWeb(idVista);
            List<GetContenidoMultimedia> contenidoMultimedia = await _repo.GetContenidoMultimedia(idVista);
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            //Cargar metadatos para la vista con su respectiva url canonica
            var metadatos = await _repo.GetMetadata(idVista);
            ViewBag.Title = metadatos[0].MetaTitulo;
            ViewBag.MetaDescription = metadatos[0].MetaDescripcion;
            ViewBag.CanonicalURL = urlCanonica + metadatos[0].MetaURL;
            //Enviar datos a la vista Home
            ViewBag.GetContenidoVista = contendido;
            ViewBag.GetContenidoMult = contenidoMultimedia;
            ViewBag.breadcrumb = breadcrumb;
            return View();
        }

        [Route("/tours/san-cristobal/{id?}")]
        public async Task<IActionResult> DailyTourIslandSanCristobal(int? id)
        {
            //url de la vista  
            var urlProducto = _repo.getUrlPage(HttpContext);
            string urlCanonica = urlProducto[0];
            string[] words = urlProducto[1].Split('/');
            var idVista = 2039;
            var breadcrumb = "San Cristobal";
            //Cargar Contenido texto e imagenes
            List<GetContenidoVista> contendido = await _repo.GetContenidoPaginaWeb(idVista);
            List<GetContenidoMultimedia> contenidoMultimedia = await _repo.GetContenidoMultimedia(idVista);
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            //Cargar metadatos para la vista con su respectiva url canonica
            var metadatos = await _repo.GetMetadata(idVista);
            ViewBag.Title = metadatos[0].MetaTitulo;
            ViewBag.MetaDescription = metadatos[0].MetaDescripcion;
            ViewBag.CanonicalURL = urlCanonica + metadatos[0].MetaURL;
            //Enviar datos a la vista Home
            ViewBag.GetContenidoVista = contendido;
            ViewBag.GetContenidoMult = contenidoMultimedia;
            ViewBag.breadcrumb = breadcrumb;
            return View();
        }


        [Route("/tours/isabela/sierra-negra")]
        [Route("/tours/isabela/tintoreras-islet")]
        [Route("/tours/isabela/cabo-rosa-tuneles")]
        [Route("/tours/san-cristobal/espanola-island")]
        [Route("/tours/san-cristobal/kicker-rock")]
        [Route("/tours/san-cristobal/pitt-point")]
        [Route("/tours/santa-cruz/bartolome-island-sullivan-bay")]
        [Route("/tours/santa-cruz/north-seymour")]
        [Route("/tours/santa-cruz/south-plazas")]
        [OutputCache(Duration = 120, VaryByHeader = "User-Agent")]
        public async Task<IActionResult> isabela()
        {
            var idVista = 0;
            var urlProducto = getUrlPage(HttpContext);
            string urlCanonica = urlProducto[0];
            var breadcrumb = "";
            var breadcrumbFinal = "";
            string[] words = urlProducto[1].Split('/');
            var price = "";
            //List<string> listDays = new List<string>();
            var listDays ="";
            //=====ID es null
            if (words.Count() == 4)
            {
                switch (words[3])
                {
                    case "sierra-negra":
                        idVista = 2027;
                        breadcrumb = "Isabela";
                        breadcrumbFinal = "Sierra Negra";
                        price = await getPrice(2038,0);
                        break;
                    case "tintoreras-islet":
                        idVista = 2029;
                        breadcrumb = "Isabela";
                        breadcrumbFinal = "Tintoreras Islet";
                        price = await getPrice(2038, 1);
                        break;
                    case "cabo-rosa-tuneles":
                        idVista = 2026;
                        breadcrumb = "Isabela";
                        breadcrumbFinal = "Cabo Rosa Tuneles";
                        price = await getPrice(2038, 2);
                        break;
                    case "espanola-island":
                        idVista = 2030;
                        breadcrumb = "San Cristobal";
                        breadcrumbFinal = "Española";
                        price = await getPrice(2039, 0);
                        listDays =  "0, 1, 2, 3, 5, 6 ";
                        
                        break;
                    case "kicker-rock":
                        idVista = 2031;
                        breadcrumb = "San Cristobal";
                        breadcrumbFinal = "Kicker Rock";
                        price = await getPrice(2039, 1);
                        listDays = "4";
                        break;
                    case "pitt-point":
                        idVista = 2032;
                        breadcrumb = "San Cristobal";
                        breadcrumbFinal = "Pitt Point";
                        price = await getPrice(2039, 2);
                        break;
                    case "bartolome-island-sullivan-bay":
                        idVista = 2033;
                        breadcrumb = "Santa Cruz";
                        breadcrumbFinal = "Bartolome";
                        price = await getPrice(2040, 0);
                        break;
                    case "north-seymour":
                        idVista = 2035;
                        breadcrumb = "Santa Cruz";
                        breadcrumbFinal = "North Plazas";
                        price = await getPrice(2040, 1);
                        listDays ="1,4";
                        break;
                    case "south-plazas":
                        idVista = 2036;
                        breadcrumb = "Santa Cruz";
                        breadcrumbFinal = "South Plazas";
                        price = await getPrice(2040, 2);
                        listDays = "5";
                        break;
                }
            }
            List<GetContenidoVista> contendido = await _repo.GetContenidoPaginaWeb(idVista);
            List<GetContenidoMultimedia> contenidoMultimedia = await _repo.GetContenidoMultimedia(idVista);
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            var metadatos = await _repo.GetMetadata(idVista);
            ViewBag.GetContenidoVista = contendido;
            ViewBag.GetContenidoMult = contenidoMultimedia;
            ViewBag.Title = metadatos[0].MetaTitulo;
            ViewBag.MetaDescription = metadatos[0].MetaDescripcion;
            ViewBag.CanonicalURL = urlCanonica + metadatos[0].MetaURL;
            ViewBag.breadcrumb = breadcrumb;
            ViewBag.breadcrumbFinal = breadcrumbFinal;
            ViewBag.price = price;
            ViewBag.listDays = listDays;
            return View();
        }

        public async Task<string> getPrice(int idIslandTour, int positionTour)
        {
            //Cargar Contenido texto e imagenes
            List<GetContenidoVista> contendido = await _repo.GetContenidoPaginaWeb(idIslandTour);
            string[] textCards;
            var cardsTours = new List<string>();
            for (int i=0; i<3;i++)
            {
                var textoCms = contendido[5+i].Parrafo;
                textCards = textoCms.Split('*');


                cardsTours.Add(Regex.Replace(textCards[3], "<.*?>", String.Empty).Replace("\n", "").Replace("&nbsp;", "").Replace("&ndash;", ""));
            }

            //Tomar solo los numeros de una cadena
            Match m = Regex.Match(cardsTours[positionTour], "(\\d+)");
            string num = string.Empty;

            if (m.Success)
            {
                num = m.Value;
            }
            string price = num;
            return price;
        }
        public IActionResult san_cristobal()
        {
            return View();
        }
        private readonly AndandoRepositorio _repo;
        public galapagos_daily_toursController(AndandoRepositorio repositorio)
        {
            this._repo = repositorio;
        }
        [Route("/Island")]
        public async Task<ActionResult<List<Island>>> Get()
        {
            return await _repo.GetIsland();
        }
        [Route("/DailyTour/{id}")]
        public async Task<ActionResult<List<Dailytour>>> Get(int id)
        {
            return await _repo.GetDailytours(id);
        }
        public List<String> getUrlPage(Microsoft.AspNetCore.Http.HttpContext context)
        {
            var host = $"{context.Request.Scheme}://{context.Request.Host}";
            var urlCategories = context.Request.Path.Value;
            List<string> urlPagina = new List<string>();
            urlPagina.Add(host);
            urlPagina.Add(urlCategories);

            return urlPagina;
        }
    }
}