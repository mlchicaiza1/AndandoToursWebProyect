using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AndandoToursWeb.Data;
using AndandoToursWeb.Models;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
namespace AndandoToursWeb.Controllers
{
    public class ecuador_itinerariesController : Controller
    {
        private readonly AndandoRepositorio _repo;
        public ecuador_itinerariesController(AndandoRepositorio repositorio)
        {
            this._repo = repositorio;
        }
        [Route("/ecuador-itineraries")]
        public async Task<IActionResult> EcuadorHome()
        {
            var urlData = _repo.getUrlPage(HttpContext);
            string urlCanonica = urlData[0];
            var idVista = 2049;
            //Cargar Mapa
            var mapa= await _repo.GetMapa();
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
            ViewBag.GetMapa = mapa;
            return View();
        }
        [Route("/ecuador-itineraries/amazon-tours-ecuador")]
        public async Task<IActionResult> ecuador_productos(int? idItinerario)
        {
            var urlData = _repo.getUrlPage(HttpContext);
            string urlCanonica = urlData[0];
            string[] words = urlData[1].Split('/');
            var idVista = 0;
            var price = "";
            idVista = 2050;
            price = await getPrice(2049, 0);
            //itinerarios 
            var getItinerariosBtnEc = await _repo.GetItinerEcuadorBtn(idVista);
            var datosItinerarios = await _repo.GetItinerEcuadorDeta(getItinerariosBtnEc[0].IdItinerarioBtn);
            List<GetContenidoVista> contendido = await _repo.GetContenidoPaginaWeb(idVista);
            List<GetContenidoMultimedia> contenidoMultimedia = await _repo.GetContenidoMultimedia(idVista);
            //form ipadrres
            var remoteIpAddress = HttpContext.Features.Get<IHttpConnectionFeature>()?.RemoteIpAddress;

            IPHostEntry heserver = Dns.GetHostEntry(Dns.GetHostName());

            var ipAddress = heserver.AddressList.ToList().Where(p => p.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).FirstOrDefault().ToString();


            ViewData["IP"] = ipAddress;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            var metadatos = await _repo.GetMetadata(idVista);
            ViewBag.Title = metadatos[0].MetaTitulo;
            ViewBag.MetaDescription = metadatos[0].MetaDescripcion;
            ViewBag.GetBtnItinerarios = getItinerariosBtnEc;
            ViewBag.ItinerariosEc = datosItinerarios;
            ViewBag.GetContenidoVista = contendido;
            ViewBag.GetContenidoMult = contenidoMultimedia;
            ViewBag.Price = price;
            return View();
        }
        [Route("/GetMapaEcItiner")]
        [HttpGet]
        public async Task<ActionResult<List<Map>>> GetMap()
        {
            return await _repo.GetMapa();
        }
        //itinerarios
        [HttpPost]
        public async Task<IActionResult> GetItinEcuadorProd(int idItinerario)
        {
            var datosItinerarios = await _repo.GetItinerEcuadorDeta(idItinerario);
            ViewBag.ItinerariosEc = datosItinerarios;
            return View("itinerariosEc");
        }
        //Itinerario boton
        public async Task<ActionResult<List<ItinEcuadorBtn>>> GetItineraEcBtn(int idVista)
        {
            return await _repo.GetItinerEcuadorBtn(idVista);
        }
        [Route("/ecuador-itineraries/cloud-forest")]
        public async Task<IActionResult> cloud_forest(int? idItinerario)
        {
            var urlData = _repo.getUrlPage(HttpContext);
            string urlCanonica = urlData[0];
            var idVista = 2051;
            var price = "";
            price = await getPrice(2049, 4);
            //form ipadrres
            var remoteIpAddress = HttpContext.Features.Get<IHttpConnectionFeature>()?.RemoteIpAddress;

            IPHostEntry heserver = Dns.GetHostEntry(Dns.GetHostName());

            var ipAddress = heserver.AddressList.ToList().Where(p => p.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).FirstOrDefault().ToString();


            ViewData["IP"] = ipAddress;
            //itinerarios 
            var getItinerariosBtnEc = await _repo.GetItinerEcuadorBtn(idVista);
            var datosItinerarios = await _repo.GetItinerEcuadorDeta(getItinerariosBtnEc[0].IdItinerarioBtn);
            List<GetContenidoVista> contendido = await _repo.GetContenidoPaginaWeb(idVista);
            List<GetContenidoMultimedia> contenidoMultimedia = await _repo.GetContenidoMultimedia(idVista);
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            var metadatos = await _repo.GetMetadata(idVista);
            ViewBag.Title = metadatos[0].MetaTitulo;
            ViewBag.MetaDescription = metadatos[0].MetaDescripcion;
            ViewBag.GetBtnItinerarios = getItinerariosBtnEc;
            ViewBag.ItinerariosEc = datosItinerarios;
            ViewBag.GetContenidoVista = contendido;
            ViewBag.GetContenidoMult = contenidoMultimedia;
            ViewBag.Price = price;
            return View();
        }
        
        [Route("/ecuador-itineraries/austral-paths")]
        [Route("/ecuador-itineraries/avenue-of-volcanoes")]
        [Route("/ecuador-itineraries/magical-north")]
        public async Task<IActionResult> austrialNorth(int? idItinerario)
        {
            var urlData = _repo.getUrlPage(HttpContext);
            string urlCanonica = urlData[0];
            string[] words = urlData[1].Split('/');
            var idVista = 0;
            var price = "";
            //form ipadrres
            var remoteIpAddress = HttpContext.Features.Get<IHttpConnectionFeature>()?.RemoteIpAddress;

            IPHostEntry heserver = Dns.GetHostEntry(Dns.GetHostName());
            var ipAddress = heserver.AddressList.ToList().Where(p => p.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork).FirstOrDefault().ToString();
            ViewData["IP"] = ipAddress;
            //vista
            if (words.Count() == 3)
            {
                switch (words[2])
                {
                    case "avenue-of-volcanoes":
                        idVista = 3052;
                        price = await getPrice(2049, 1);
                        break;
                    case "austral-paths":
                        idVista = 3053;
                        price = await getPrice(2049, 3);
                        break;
                    case "magical-north":
                        idVista = 3054;
                        price = await getPrice(2049, 2);
                        break;
                }
            }
            //itinerarios 
            var getItinerariosBtnEc = await _repo.GetItinerEcuadorBtn(idVista);
            var datosItinerarios = await _repo.GetItinerEcuadorDeta(getItinerariosBtnEc[0].IdItinerarioBtn);
            List<GetContenidoVista> contendido = await _repo.GetContenidoPaginaWeb(idVista);
            List<GetContenidoMultimedia> contenidoMultimedia = await _repo.GetContenidoMultimedia(idVista);
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            var metadatos = await _repo.GetMetadata(idVista);
            ViewBag.Title = metadatos[0].MetaTitulo;
            ViewBag.MetaDescription = metadatos[0].MetaDescripcion;
            ViewBag.GetBtnItinerarios = getItinerariosBtnEc;
            ViewBag.ItinerariosEc = datosItinerarios;
            ViewBag.GetContenidoVista = contendido;
            ViewBag.GetContenidoMult = contenidoMultimedia;
            ViewBag.Price = price;
            return View();
        }

        public async Task<string> getPrice(int idIslandTour, int positionTour)
        {
            //Cargar Contenido texto e imagenes
            List<GetContenidoVista> contendido = await _repo.GetContenidoPaginaWeb(idIslandTour);
            string[] textCards;
            var cardsTours = new List<string>();
            for (int i = 0; i < 5; i++)
            {
                var textoCms = contendido[9 + i].Parrafo;
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
        //Mapa modal
        [Route("/GetModalHotel/{idHotel ?}")]
        public async Task<IActionResult> GetModalHotel(int idHotel)
        {
            var getItiner = await _repo.GetMapa();
            List<Map> filtroMapa = new List<Map>();
            foreach (var dat in getItiner)
            {
                if(dat.IdMapaHotel == idHotel)
                {
                    filtroMapa.Add(dat);
                }
            }
            ViewBag.GetHotel = filtroMapa;
            return View();
        }
    }
}