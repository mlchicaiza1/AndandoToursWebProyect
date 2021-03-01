using AndandoToursWeb.Data;
using AndandoToursWeb.Models;
//using AndandoTour3_0Core.Models.ModelApiGoldenGalapagos;
//using AndandoTour3_0Core.Models.ModelApiRoyal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace AndandoToursWeb.Controllers
{
    public class CruisesController : Controller
    {
        public const string SessionKeyBarco = "_barco";

        private readonly AndandoRepositorio _repo;
        //private readonly ApisRoyal_GoldenData _repoRoyal;
        public CruisesController(AndandoRepositorio repositorio)
        {
            this._repo = repositorio;
            //this._repoRoyal = repositorioRoyal;

        }
        public async Task< ActionResult> CruisesHome(int idbarco, string url)
        {
            var urlData = _repo.getUrlPage(HttpContext);
            string urlCanonica = urlData[0];
            var cardsCruises = new List<BarcoWeb>();
            var cards = new List<int> { 73, 85, 70, 93, 92, 88, 111, 96, 90 };
            cardsCruises = await CruisesCardsOrden(cards);
            
            var metadatos = await _repo.GetMetadata(9);
            List<GetContenidoVista> contendido = await _repo.GetContenidoPaginaWeb(9);
            List<GetContenidoMultimedia> contenidoMultimedia = await _repo.GetContenidoMultimedia(9);
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.Title = metadatos[0].MetaTitulo;
            ViewBag.MetaDescription = metadatos[0].MetaDescripcion;
            ViewBag.CanonicalURL = urlCanonica + metadatos[0].MetaURL;
            ViewBag.GetContenidoVista = contendido;
            ViewBag.GetContenidoMult = contenidoMultimedia;
            ViewBag.CardsCruises = cardsCruises;
            return View();
        }
        public async Task<ActionResult> cruise_experience()
        {
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            return View();
        }
        public async Task<ActionResult> how_to_choose_cruises()
        {
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            return View();
        }


        [Route("/blog/cruises-for-single-adventurers")]
        public async Task<ActionResult> solo_cruises()
        {
            ///Meta Tag + Canonical
            var idVista = 2042;
            var urlData = _repo.getUrlPage(HttpContext);
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


        //public ActionResult family()
        //{
        //    return View("family/family_cruises");
        //}

        [Route("/cruises/family")]
        //public async Task<ActionResult> family_cruises()
        //{
        //    ///Meta Tag + Canonical

        //    return View();
        //} 

        public async Task<ActionResult> CruisesFamily(int idbarco, string url)
        {
            var idVista = 2048;
            var urlData = _repo.getUrlPage(HttpContext);
            string urlCanonica = urlData[0];
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            var metadatos = await _repo.GetMetadata(idVista);
            ViewBag.Title = metadatos[0].MetaTitulo;
            ViewBag.MetaDescription = metadatos[0].MetaDescripcion;
            ViewBag.MetaKeywords = metadatos[0].MetaKeywords;
            ViewBag.CanonicalURL = urlCanonica + metadatos[0].MetaURL;

            var cards = await _repo.GetAll();
  
            return View(cards);
        }



        public async  Task<ActionResult> CruisesCategoria(int idbarco, string url)
        {

            var urlData = _repo.getUrlPage(HttpContext);
            string urlCanonica = urlData[0];
            string[] words = urlData[1].Split('/');
            var idVista = 0;
            var cardsCruises= new List<BarcoWeb>();
            if (idbarco != 0)
            {
                HttpContext.Session.SetInt32(SessionKeyBarco, idbarco);
                return RedirectToRoute(url);
            }
           
            var Breadcrumbitem="";
            var cards = new List<int>();
            if (words.Count() == 2)
            {
                switch (words[1])
                {
                    case "sailing-cruises":
                        idVista = 5;
                        cards = new List<int> { 85, 93, 105 };
                        cardsCruises = await CruisesCardsOrden(cards);
                        Breadcrumbitem = "Sailing Cruises";
                        break;
                }
            }
            if (words.Count() == 3)
            {
                switch (words[2])
                {
                    case "galapagos-catamarans":
                        idVista = 1;
                        cards = new List<int> { 111, 92, 70, 87, 96 };
                        cardsCruises = await CruisesCardsOrden(cards);
                        Breadcrumbitem = "Galapagos Catamarans";
                        break;
                    case "high-end":
                        idVista = 3;
                        cards = new List<int> { 73, 122, 125 };
                        cardsCruises = await CruisesCardsOrden(cards);
                        Breadcrumbitem = "High End";
                        break;
                    case "mid-range-cruises":
                        idVista = 4;
                        cards = new List<int> { 70, 88, 87, 96, 105 };
                        cardsCruises = await CruisesCardsOrden(cards);
                        Breadcrumbitem = "High End";
                        break;
                    case "budget":
                        idVista = 6;
                        cards = new List<int> { 90, 98, 93 };
                        cardsCruises = await CruisesCardsOrden(cards);
                        Breadcrumbitem = "High End";
                        break;
                    case "galapagos-yachts":
                        idVista = 7;
                        cards = new List<int> { 115, 73, 88 };
                        cardsCruises = await CruisesCardsOrden(cards);
                        Breadcrumbitem = "Galapagos Yachts";
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
            ViewBag.CardsCruises = cardsCruises;
            ViewBag.Breadcrumbitem = Breadcrumbitem;
            return View();
        }
        
        [Route("/galapagos-cruises/high-end")]
        public async Task<ActionResult> CruisesHigh_End()
        {
            var idVista = 3;
            var urlData = _repo.getUrlPage(HttpContext);
            string urlCanonica = urlData[0];
            var cards = new List<int> { 73, 122, 125 };
            var cardsCruises = await CruisesCardsOrden(cards);
           

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
            ViewBag.CardsCruises = cardsCruises;
            ViewBag.Breadcrumbitem = "High End";
            return View();
        }

        [Route("galapagos-luxury-cruise")]
        public async Task<ActionResult> CruisesLuxury(int idbarco, string url)
        {
            var urlData = _repo.getUrlPage(HttpContext);
            string urlCanonica = urlData[0];
            //string[] words = urlData[1].Split('/');
            var idVista = 2;
            var cardsCruises = new List<BarcoWeb>();
            var cards = new List<int> { 115, 92, 103, 111 };
            cardsCruises = await CruisesCardsOrden(cards);
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
            ViewBag.CardsCruises = cardsCruises;
            return View();
        }
       
        
        public async Task<List<BarcoWeb>> CruisesCardsOrden(List<int> cards)
        {
            var barcosCards = new List<BarcoWeb>();
            var cardsCruises = new List<BarcoWeb>();
            cardsCruises = await _repo.GetAll();
            int i = 0;
            while (cards.Count > i)
            {
                foreach (var dat in cardsCruises)
                {
                    if (cards[i] == dat.IdBarco)
                    {
                        barcosCards.Add(dat);
                        i++;
                        if (i == cards.Count)
                            break;
                    }
                }
            }

            return barcosCards;
        }

        [Route("/cruises/availability/{id ?}")]
        public async Task<ActionResult> CruisesDiponibilidad()
        {
            var urlData = _repo.getUrlPage(HttpContext);
            string urlCanonica = urlData[0];
            var idVista = 2047;
            var metadatos = await _repo.GetMetadata(idVista);
            List<GetContenidoVista> contendido = await _repo.GetContenidoPaginaWeb(idVista);
            //List<GetContenidoMultimedia> contenidoMultimedia = await _repo.GetContenidoMultimedia(idVista);
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.Title = metadatos[0].MetaTitulo;
            ViewBag.MetaDescription = metadatos[0].MetaDescripcion;
            ViewBag.CanonicalURL = urlCanonica + metadatos[0].MetaURL;
            ViewBag.GetContenidoVista = contendido;
            //ViewBag.GetContenidoMult = contenidoMultimedia;
            return View();
        }

        [Route("/sailing-cruises/mary-anne/{id?}/{idItinerario?}", Name = "/sailing-cruises/mary-anne")]
        public async Task<ActionResult> CruisesMary(int? id, int? idItinerario)
        {
            var urlProducto = _repo.getUrlPage(HttpContext);
            string urlCanonica = urlProducto[0];
            string[] words = urlProducto[1].Split('/');
            var idVista = 2015;
            int idBarco = 85;
            var cardsCruises = new List<BarcoWeb>();
            var cards = new List<int>() { 93, 105, 70 };
            cardsCruises = await CruisesCardsOrden(cards);
            List<GetContenidoVista> contendido = await _repo.GetContenidoPaginaWeb(idVista);
            List<GetContenidoMultimedia> contenidoMultimedia = await _repo.GetContenidoMultimedia(idVista);
            List<ItinerarioBarco> filtroAm = new List<ItinerarioBarco>();
            List<ItinerarioBarco> filtroPm = new List<ItinerarioBarco>();
            List<ItinerarioBarco> dias = new List<ItinerarioBarco>();
            List<BarcoWeb> barcos = new List<BarcoWeb>();
            var features = await _repo.GetFeaturesProduct(idBarco);
            string[] incluye;
            string[] excluye;
            var datosBarcos = await _repo.GetAll();
            foreach (var dat in datosBarcos)
            {
                if (idBarco == dat.IdBarco)
                {
                    barcos.Add(dat);
                    incluye = dat.BarcoIncluyeEn.Split('•');
                    excluye = dat.BarcoNoincluyeEn.Split('•');
                    ViewBag.Incluye = incluye;
                    ViewBag.Excluye = excluye;
                }
            }
            var getBtnItinerarios = await _repo.GetItinerBarcoBtn(idBarco);
            if (idItinerario == null)
            {

                var datosItinerarios = await _repo.GetItinerBarco(getBtnItinerarios[0].IDBarco, getBtnItinerarios[0].IDBarcoItinerario);
                ViewBag.GetItinerarios = datosItinerarios;
                var cont = 0;
                foreach (var dat in datosItinerarios)
                {
                    if (cont == 0)
                    {
                        dias.Add(dat);
                        cont++;
                    }
                    else
                    {
                        if (cont == dat.DiaNumero)
                        {
                            dias.Add(dat);
                            cont++;
                        }
                    }
                    if (dat.DiaParte == "AM")
                    {
                        filtroAm.Add(dat);
                    }
                    else
                    {
                        if (dat.DiaParte == "PM")
                        {
                            filtroPm.Add(dat);
                        }
                    }

                }
            }
            else
            {
                int idItinerario_1 = idItinerario.Value;
                var datosItinerarios = await _repo.GetItinerBarco(idBarco, idItinerario_1);
                ViewBag.GetItinerarios = datosItinerarios;
            }

            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            var metadatos = await _repo.GetMetadata(idVista);
            ViewBag.Title = metadatos[0].MetaTitulo;
            ViewBag.MetaDescription = metadatos[0].MetaDescripcion;
            ViewBag.CanonicalURL = urlCanonica + metadatos[0].MetaURL;
            ViewBag.GetBtnItinerarios = getBtnItinerarios;
            ViewBag.GetFiltrosAm = filtroAm;
            ViewBag.GetFiltrosPm = filtroPm;
            ViewBag.GetDias = dias;
            ViewBag.GetBarcos = barcos;
            ViewBag.GetFeatures = features;
            ViewBag.GetContenidoVista = contendido;
            ViewBag.GetContenidoMult = contenidoMultimedia;
            ViewBag.GetFeatures = features;
            ViewBag.CardsCruises = cardsCruises;
            return View();
        }
        [Route("/Cruises/CruisesProduct/{id?}/{idItinerario?}")]
        [Route("/galapagos-cruises/tip-top-ii/{id?}/{idItinerario?}",Name = "/galapagos-cruises/tip-top-ii")]
        [Route("/galapagos-cruises/archipel/{id?}/{idItinerario?}", Name = "/galapagos-cruises/archipel")]
        [Route("/sailing-cruises/nemo-iii/{id?}/{idItinerario?}", Name = "/sailing-cruises/nemo-iii")]
        [Route("/galapagos-cruises/odyssey/{id?}/{idItinerario?}", Name = "/galapagos-cruises/odyssey")]
        [Route("/galapagos-cruises/treasure/{id?}/{idItinerario?}", Name = "/galapagos-cruises/treasure")]
        public async Task<ActionResult> CruisesProduct(int? id, int? idItinerario)
        {
            int idBarco = 0;
            var urlProducto = _repo.getUrlPage(HttpContext);
            string[] words = urlProducto[1].Split('/');
            string urlCanonica = urlProducto[0];
            var cardsCruises = new List<BarcoWeb>();
            var cards = new List<int>();
            var idVista = 0;
            if (words.Count() == 3)
            {
                switch (words[2])
                {
                    case "tip-top-ii":
                        idVista = 8;
                        idBarco = 70;
                        cards = new List<int> { 88, 87, 96 };
                        cardsCruises = await CruisesCardsOrden(cards);
                        break;
                    case "archipel":
                        idVista = 11;
                        idBarco = 96;
                        cards = new List<int> { 70, 87, 88 };
                        cardsCruises = await CruisesCardsOrden(cards);
                        break;
                    case "elite":
                        idVista = 12;
                        idBarco = 111;
                        break;
                    case "nemo-iii":
                        idVista = 2017;
                        idBarco = 105;
                        cards = new List<int> { 85, 93, 96 };
                        cardsCruises = await CruisesCardsOrden(cards);
                        break;
                    case "odyssey":
                        idVista = 2019;
                        idBarco = 88;
                        cards = new List<int> { 70, 87, 96 };
                        cardsCruises = await CruisesCardsOrden(cards);
                        break;
                    case "treasure":
                        idVista = 2021;
                        idBarco = 87;
                        cards = new List<int> { 70, 88, 96 };
                        cardsCruises = await CruisesCardsOrden(cards);
                        break;
                }
            }
            //=====ID es null
            List<GetContenidoVista> contendido = await _repo.GetContenidoPaginaWeb(idVista);
            List<GetContenidoMultimedia> contenidoMultimedia = await _repo.GetContenidoMultimedia(idVista);
            List<ItinerarioBarco> filtroAm = new List<ItinerarioBarco>();
            List<ItinerarioBarco> filtroPm = new List<ItinerarioBarco>();
            List<ItinerarioBarco> dias = new List<ItinerarioBarco>();
            List<BarcoWeb> barcos = new List<BarcoWeb>();
            var features = await _repo.GetFeaturesProduct(idBarco);
            var datosBarcos = await _repo.GetAll();
            string[] incluye;
            string[] excluye;

            foreach (var dat in datosBarcos)
            {
                if (idBarco == dat.IdBarco)
                {
                    barcos.Add(dat);
                    incluye = dat.BarcoIncluyeEn.Split('•');
                    excluye = dat.BarcoNoincluyeEn.Split('•');
                    ViewBag.Incluye = incluye;
                    ViewBag.Excluye = excluye;
                }
            }
            var getBtnItinerarios = await _repo.GetItinerBarcoBtn(idBarco);
            if (idItinerario == null)
            {
                var datosItinerarios = await _repo.GetItinerBarco(getBtnItinerarios[0].IDBarco, getBtnItinerarios[0].IDBarcoItinerario);
                ViewBag.GetItinerarios = datosItinerarios;
                var cont = 0;
                foreach (var dat in datosItinerarios)
                {
                    if (cont == 0)
                    {
                        dias.Add(dat);
                        cont++;
                    }
                    else
                    {
                        if (cont == dat.DiaNumero)
                        {
                            dias.Add(dat);
                            cont++;
                        }
                    }
                    if (dat.DiaParte == "AM")
                    {
                        filtroAm.Add(dat);
                    }
                    else
                    {
                        if (dat.DiaParte == "PM")
                        {
                            filtroPm.Add(dat);
                        }
                    }

                }
            }
            else
            {
                int idItinerario_1 = idItinerario.Value;
                var datosItinerarios = await _repo.GetItinerBarco(idBarco, idItinerario_1);
                ViewBag.GetItinerarios = datosItinerarios;
            }
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            var metadatos = await _repo.GetMetadata(idVista);
            ViewBag.Title = metadatos[0].MetaTitulo;
            ViewBag.MetaDescription = metadatos[0].MetaDescripcion;
            ViewBag.CanonicalURL = urlCanonica + metadatos[0].MetaURL;
            ViewBag.GetContenidoVista = contendido;
            ViewBag.GetFeatures = features;
            ViewBag.GetBtnItinerarios = getBtnItinerarios;
            ViewBag.GetFiltrosAm = filtroAm;
            ViewBag.GetFiltrosPm = filtroPm;
            ViewBag.GetDias = dias;
            ViewBag.GetBarcos = barcos;
            ViewBag.GetContenidoMult = contenidoMultimedia;
            ViewBag.CardsCruises = cardsCruises;
            return View();
        }

        [Route("/galapagos-cruises/passion-yacht/{id?}/{idItinerario?}", Name = "/galapagos-cruises/passion-yacht")]

        [OutputCache(Duration = 120, VaryByHeader = "User-Agent")]
        public async Task<ActionResult> CruisesProductPassion(int? id, int? idItinerario)
        {
            //var idBarcoTemp = HttpContext.Session.GetInt32(SessionKeyBarco);
            var urlProducto = _repo.getUrlPage(HttpContext);
            string urlCanonica = urlProducto[0];
            string[] words = urlProducto[1].Split('/');
            var idVista = 14;
            int idBarco = 73;
            var cardsCruises = new List<BarcoWeb>();
            var cards = new List<int>() { 115, 92, 88 };
            cardsCruises = await CruisesCardsOrden(cards);
            List<GetContenidoVista> contendido = await _repo.GetContenidoPaginaWeb(idVista);
            List<GetContenidoMultimedia> contenidoMultimedia = await _repo.GetContenidoMultimedia(idVista);
            List<ItinerarioBarco> filtroAm = new List<ItinerarioBarco>();
            List<ItinerarioBarco> filtroPm = new List<ItinerarioBarco>();
            List<ItinerarioBarco> dias = new List<ItinerarioBarco>();
            List<BarcoWeb> barcos = new List<BarcoWeb>();
            var features = await _repo.GetFeaturesProduct(idBarco);
            string[] incluye;
            string[] excluye;
            var datosBarcos = await _repo.GetAll();
            foreach (var dat in datosBarcos)
            {
                if (idBarco == dat.IdBarco)
                {
                    barcos.Add(dat);
                    incluye = dat.BarcoIncluyeEn.Split('•');
                    excluye = dat.BarcoNoincluyeEn.Split('•');
                    ViewBag.Incluye = incluye;
                    ViewBag.Excluye = excluye;
                }
            }
            var getBtnItinerarios = await _repo.GetItinerBarcoBtn(idBarco);
            if (idItinerario == null)
            {

                var datosItinerarios = await _repo.GetItinerBarco(getBtnItinerarios[0].IDBarco, getBtnItinerarios[0].IDBarcoItinerario);
                ViewBag.GetItinerarios = datosItinerarios;
                var cont = 0;
                foreach (var dat in datosItinerarios)
                {
                    if (cont == 0)
                    {
                        dias.Add(dat);
                        cont++;
                    }
                    else
                    {
                        if (cont == dat.DiaNumero)
                        {
                            dias.Add(dat);
                            cont++;
                        }
                    }
                    if (dat.DiaParte == "AM")
                    {
                        filtroAm.Add(dat);
                    }
                    else
                    {
                        if (dat.DiaParte == "PM")
                        {
                            filtroPm.Add(dat);
                        }
                    }

                }
            }
            else
            {
                int idItinerario_1 = idItinerario.Value;
                var datosItinerarios = await _repo.GetItinerBarco(idBarco, idItinerario_1);
                ViewBag.GetItinerarios = datosItinerarios;
            }

            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ///Meta Tag + Canonical
            var metadatos = await _repo.GetMetadata(idVista);
            ViewBag.Title = metadatos[0].MetaTitulo;
            ViewBag.MetaDescription = metadatos[0].MetaDescripcion;
            ViewBag.CanonicalURL = urlCanonica + metadatos[0].MetaURL;


            ViewBag.GetBtnItinerarios = getBtnItinerarios;
            ViewBag.GetFiltrosAm = filtroAm;
            ViewBag.GetFiltrosPm = filtroPm;
            ViewBag.GetDias = dias;
            ViewBag.GetBarcos = barcos;
            ViewBag.GetFeatures = features;
            ViewBag.GetContenidoVista = await _repo.GetContenidoPaginaWeb(idVista);
            ViewBag.GetContenidoMult = await _repo.GetContenidoMultimedia(idVista);
            ViewBag.GetFeatures = features;
            ViewBag.CardsCruises = cardsCruises;
            return View();
        }

        [Route("/galapagos-cruises/endemic/{id?}/{idItinerario?}", Name = "/galapagos-cruises/endemic")]
        public async Task<ActionResult> CruisesProductEndemic(int? id, int? idItinerario)
        {
            var urlProducto = _repo.getUrlPage(HttpContext);
            string urlCanonica = urlProducto[0];
            string[] words = urlProducto[1].Split('/');
            var idVista = 2010;
            //=====ID es null
            int idBarco = 110;
            var cardsCruises = new List<BarcoWeb>();
            var cards = new List<int>() { 115, 111, 103 };
            cardsCruises = await CruisesCardsOrden(cards);
            List<GetContenidoVista> contendido = await _repo.GetContenidoPaginaWeb(idVista);
            List<GetContenidoMultimedia> contenidoMultimedia = await _repo.GetContenidoMultimedia(idVista);
            List<ItinerarioBarco> filtroAm = new List<ItinerarioBarco>();
            List<ItinerarioBarco> filtroPm = new List<ItinerarioBarco>();
            List<ItinerarioBarco> dias = new List<ItinerarioBarco>();
            List<BarcoWeb> barcos = new List<BarcoWeb>();
            var features = await _repo.GetFeaturesProduct(idBarco);
            string[] incluye;
            string[] excluye;
            var datosBarcos = await _repo.GetAll();
            foreach (var dat in datosBarcos)
            {
                if (idBarco == dat.IdBarco)
                {
                    barcos.Add(dat);
                    incluye = dat.BarcoIncluyeEn.Split('•');
                    excluye = dat.BarcoNoincluyeEn.Split('•');
                    ViewBag.Incluye = incluye;
                    ViewBag.Excluye = excluye;
                }
            }
            var getBtnItinerarios = await _repo.GetItinerBarcoBtn(idBarco);
            if (idItinerario == null)
            {

                var datosItinerarios = await _repo.GetItinerBarco(getBtnItinerarios[0].IDBarco, getBtnItinerarios[0].IDBarcoItinerario);
                ViewBag.GetItinerarios = datosItinerarios;
                var cont = 0;
                foreach (var dat in datosItinerarios)
                {
                    if (cont == 0)
                    {
                        dias.Add(dat);
                        cont++;
                    }
                    else
                    {
                        if (cont == dat.DiaNumero)
                        {
                            dias.Add(dat);
                            cont++;
                        }
                    }
                    if (dat.DiaParte == "AM")
                    {
                        filtroAm.Add(dat);
                    }
                    else
                    {
                        if (dat.DiaParte == "PM")
                        {
                            filtroPm.Add(dat);
                        }
                    }

                }
            }
            else
            {
                int idItinerario_1 = idItinerario.Value;
                var datosItinerarios = await _repo.GetItinerBarco(idBarco, idItinerario_1);
                ViewBag.GetItinerarios = datosItinerarios;
            }
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            var metadatos = await _repo.GetMetadata(idVista);
            ViewBag.Title = metadatos[0].MetaTitulo;
            ViewBag.MetaDescription = metadatos[0].MetaDescripcion;
            ViewBag.GetBtnItinerarios = getBtnItinerarios;
            ViewBag.GetFiltrosAm = filtroAm;
            ViewBag.GetFiltrosPm = filtroPm;
            ViewBag.GetDias = dias;
            ViewBag.GetBarcos = barcos;
            ViewBag.GetFeatures = features;
            ViewBag.GetContenidoVista = contendido;
            ViewBag.GetContenidoMult = contenidoMultimedia;
            ViewBag.CardsCruises = cardsCruises;
            return View();
        }

        [Route("/galapagos-cruises/elite/{id?}/{idItinerario?}", Name = "/galapagos-cruises/elite")]
        public async Task<ActionResult> CruisesProductElite(int? id, int? idItinerario)
        {
            var urlProducto = _repo.getUrlPage(HttpContext);
            string urlCanonica = urlProducto[0];
            string[] words = urlProducto[1].Split('/');
            var idVista = 12;
            int idBarco =111;
            //=====ID es null
            var cardsCruises = new List<BarcoWeb>();
            var cards = new List<int>() {103, 115, 92 };
            cardsCruises = await CruisesCardsOrden(cards);
            List<GetContenidoVista> contendido = await _repo.GetContenidoPaginaWeb(idVista);
            List<GetContenidoMultimedia> contenidoMultimedia = await _repo.GetContenidoMultimedia(idVista);
            List<ItinerarioBarco> filtroAm = new List<ItinerarioBarco>();
            List<ItinerarioBarco> filtroPm = new List<ItinerarioBarco>();
            List<ItinerarioBarco> dias = new List<ItinerarioBarco>();
            List<BarcoWeb> barcos = new List<BarcoWeb>();
            var features = await _repo.GetFeaturesProduct(idBarco);
            string[] incluye;
            string[] excluye;
            var datosBarcos = await _repo.GetAll();
            foreach (var dat in datosBarcos)
            {
                if (idBarco == dat.IdBarco)
                {
                    barcos.Add(dat);
                    incluye = dat.BarcoIncluyeEn.Split('•');
                    excluye = dat.BarcoNoincluyeEn.Split('•');
                    ViewBag.Incluye = incluye;
                    ViewBag.Excluye = excluye;
                }
            }
            var getBtnItinerarios = await _repo.GetItinerBarcoBtn(idBarco);
            if (idItinerario == null)
            {

                var datosItinerarios = await _repo.GetItinerBarco(getBtnItinerarios[0].IDBarco, getBtnItinerarios[0].IDBarcoItinerario);
                ViewBag.GetItinerarios = datosItinerarios;
                var cont = 0;
                foreach (var dat in datosItinerarios)
                {
                    if (cont == 0)
                    {
                        dias.Add(dat);
                        cont++;
                    }
                    else
                    {
                        if (cont == dat.DiaNumero)
                        {
                            dias.Add(dat);
                            cont++;
                        }
                    }
                    if (dat.DiaParte == "AM")
                    {
                        filtroAm.Add(dat);
                    }
                    else
                    {
                        if (dat.DiaParte == "PM")
                        {
                            filtroPm.Add(dat);
                        }
                    }

                }
            }
            else
            {
                int idItinerario_1 = idItinerario.Value;
                var datosItinerarios = await _repo.GetItinerBarco(idBarco, idItinerario_1);
                ViewBag.GetItinerarios = datosItinerarios;
            }
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            //Cargar metadatos para la vista con su respectiva url canonica
            var metadatos = await _repo.GetMetadata(idVista);
            ViewBag.Title = metadatos[0].MetaTitulo;
            ViewBag.MetaDescription = metadatos[0].MetaDescripcion;
            ViewBag.CanonicalURL = urlCanonica + metadatos[0].MetaURL;
            //Cargar Itinenarios 
            ViewBag.GetBtnItinerarios = getBtnItinerarios;
            ViewBag.GetFiltrosAm = filtroAm;
            ViewBag.GetFiltrosPm = filtroPm;
            ViewBag.GetDias = dias;
            //Cargar Barcos para las cards
            ViewBag.GetBarcos = barcos;
            ViewBag.GetFeatures = features;
            //Cargar contenidos, texto e imagenes
            ViewBag.GetContenidoVista = contendido;
            ViewBag.GetContenidoMult = contenidoMultimedia;
            ViewBag.GetFeatures = features;
            ViewBag.CardsCruises = cardsCruises;
            return View();
        }

        [Route("/galapagos-cruises/fragata/{id?}/{idItinerario?}", Name = "/galapagos-cruises/fragata")]
        [Route("/galapagos-cruises/golondrina/{id?}/{idItinerario?}", Name = "/galapagos-cruises/golondrina")]
        public async Task<ActionResult> CruisesProductFragataGolondrina(int? id, int? idItinerario)
        {
            //var idBarcoTemp = HttpContext.Session.GetInt32(SessionKeyBarco);
            var urlProducto = _repo.getUrlPage(HttpContext);
            string urlCanonica = urlProducto[0];
            string[] words = urlProducto[1].Split('/');
            var idVista = 0;
            int idBarco = 0;
            //=====ID es null
            var cardsCruises = new List<BarcoWeb>();
            var cards = new List<int>();
            if (words.Count() == 3)
            {
                switch (words[2])
                {
                    case "fragata":
                        idVista = 2011;
                        idBarco = 98;
                        cards = new List<int> { 93, 98 ,85};
                        cardsCruises = await CruisesCardsOrden(cards);
                        break;
                    case "golondrina":
                        idVista = 2012;
                        idBarco = 90;
                        cards = new List<int> { 93, 90, 85 };
                        cardsCruises = await CruisesCardsOrden(cards);
                        break;
                }
            }
            
            List<GetContenidoVista> contendido = await _repo.GetContenidoPaginaWeb(idVista);
            List<GetContenidoMultimedia> contenidoMultimedia = await _repo.GetContenidoMultimedia(idVista);
            List<ItinerarioBarco> filtroAm = new List<ItinerarioBarco>();
            List<ItinerarioBarco> filtroPm = new List<ItinerarioBarco>();
            List<ItinerarioBarco> dias = new List<ItinerarioBarco>();
            List<BarcoWeb> barcos = new List<BarcoWeb>();
            var features = await _repo.GetFeaturesProduct(idBarco);
            string[] incluye;
            string[] excluye;
            var datosBarcos = await _repo.GetAll();
            foreach (var dat in datosBarcos)
            {
                if (idBarco == dat.IdBarco)
                {
                    barcos.Add(dat);
                    incluye = dat.BarcoIncluyeEn.Split('•');
                    excluye = dat.BarcoNoincluyeEn.Split('•');
                    ViewBag.Incluye = incluye;
                    ViewBag.Excluye = excluye;
                }
            }
            var getBtnItinerarios = await _repo.GetItinerBarcoBtn(idBarco);
            if (idItinerario == null)
            {

                var datosItinerarios = await _repo.GetItinerBarco(getBtnItinerarios[0].IDBarco, getBtnItinerarios[0].IDBarcoItinerario);
                ViewBag.GetItinerarios = datosItinerarios;
                var cont = 0;
                foreach (var dat in datosItinerarios)
                {
                    if (cont == 0)
                    {
                        dias.Add(dat);
                        cont++;
                    }
                    else
                    {
                        if (cont == dat.DiaNumero)
                        {
                            dias.Add(dat);
                            cont++;
                        }
                    }
                    if (dat.DiaParte == "AM")
                    {
                        filtroAm.Add(dat);
                    }
                    else
                    {
                        if (dat.DiaParte == "PM")
                        {
                            filtroPm.Add(dat);
                        }
                    }

                }
            }
            else
            {
                int idItinerario_1 = idItinerario.Value;
                var datosItinerarios = await _repo.GetItinerBarco(idBarco, idItinerario_1);
                ViewBag.GetItinerarios = datosItinerarios;
            }
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            var metadatos = await _repo.GetMetadata(idVista);
            ViewBag.Title = metadatos[0].MetaTitulo;
            ViewBag.MetaDescription = metadatos[0].MetaDescripcion;
            ViewBag.CanonicalURL = urlCanonica + metadatos[0].MetaURL;
            ViewBag.GetBtnItinerarios = getBtnItinerarios;
            ViewBag.GetFiltrosAm = filtroAm;
            ViewBag.GetFiltrosPm = filtroPm;
            ViewBag.GetDias = dias;
            ViewBag.GetBarcos = barcos;
            ViewBag.GetFeatures = features;
            ViewBag.GetContenidoVista = contendido;
            ViewBag.GetContenidoMult = contenidoMultimedia;
            ViewBag.GetFeatures = features;
            ViewBag.CardsCruises = cardsCruises;
            return View();
        }


        [Route("/galapagos-cruises/grand-majestic/{id?}/{idItinerario?}", Name = "/galapagos-cruises/grand-majestic")]
        [Route("/galapagos-cruises/infinity/{id?}/{idItinerario?}", Name = "/galapagos-cruises/infinity")]
        [Route("/sailing-cruises/nemo-ii/{id?}/{idItinerario?}", Name = "/sailing-cruises/nemo-ii")]
        [Route("/galapagos-cruises/ocean-spray/{id?}/{idItinerario?}", Name = "/galapagos-cruises/ocean-spray")]
        [Route("/galapagos-cruises/theory/{id?}/{idItinerario?}", Name = "/galapagos-cruises/theory")]
        [Route("/galapagos-cruises/alya-catamaran/{id?}/{idItinerario?}", Name = "/galapagos-cruises/alya-catamaran")]
        public async Task<ActionResult> CruisesProductGroup_1(int? id, int? idItinerario)
        {
            var urlProducto = _repo.getUrlPage(HttpContext);
            string urlCanonica = urlProducto[0];
            string[] words = urlProducto[1].Split('/');
            var idVista = 0;
            int idBarco = 0;
            //=====ID es null
            var cardsCruises = new List<BarcoWeb>();
            var cards = new List<int>();
            if (words.Count() == 3)
            {
                switch (words[2])
                {
                    case "grand-majestic":
                        idVista = 2013;
                        idBarco = 125;
                        cards = new List<int> {73,122, 96 };
                        cardsCruises = await CruisesCardsOrden(cards);
                        break;
                    case "infinity":
                        idVista = 2014;
                        idBarco = 122;
                        cards = new List<int> {73, 125, 70 };
                        cardsCruises = await CruisesCardsOrden(cards);
                        break;
                    case "nemo-ii":
                        idVista = 2016;
                        idBarco = 93;
                        cards = new List<int> {85, 105, 96 };
                        cardsCruises = await CruisesCardsOrden(cards);
                        break;
                    case "ocean-spray":
                        idVista = 2018;
                        idBarco = 92;
                        cards = new List<int> { 115, 73, 88};
                        cardsCruises = await CruisesCardsOrden(cards);
                        break;
                    case "theory":
                        idVista = 2020;
                        idBarco = 115;
                        cards = new List<int> { 111, 103, 73 };
                        cardsCruises = await CruisesCardsOrden(cards);
                        break;
                    case "alya-catamaran":
                        idVista = 10;
                        idBarco = 103;
                        cards = new List<int> { 115, 92, 70 };
                        cardsCruises = await CruisesCardsOrden(cards);
                        break;
                }
            }

            List<GetContenidoVista> contendido = await _repo.GetContenidoPaginaWeb(idVista);
            List<GetContenidoMultimedia> contenidoMultimedia = await _repo.GetContenidoMultimedia(idVista);
            List<ItinerarioBarco> filtroAm = new List<ItinerarioBarco>();
            List<ItinerarioBarco> filtroPm = new List<ItinerarioBarco>();
            List<ItinerarioBarco> dias = new List<ItinerarioBarco>();
            List<BarcoWeb> barcos = new List<BarcoWeb>();
            var features = await _repo.GetFeaturesProduct(idBarco);
            string[] incluye;
            string[] excluye;
            var datosBarcos = await _repo.GetAll();
            foreach (var dat in datosBarcos)
            {
                if (idBarco == dat.IdBarco)
                {
                    barcos.Add(dat);
                    incluye = dat.BarcoIncluyeEn.Split('•');
                    excluye = dat.BarcoNoincluyeEn.Split('•');
                    ViewBag.Incluye = incluye;
                    ViewBag.Excluye = excluye;
                }
            }
            var getBtnItinerarios = await _repo.GetItinerBarcoBtn(idBarco);
            if (idItinerario == null)
            {

                var datosItinerarios = await _repo.GetItinerBarco(getBtnItinerarios[0].IDBarco, getBtnItinerarios[0].IDBarcoItinerario);
                ViewBag.GetItinerarios = datosItinerarios;
                var cont = 0;
                foreach (var dat in datosItinerarios)
                {
                    if (cont == 0)
                    {
                        dias.Add(dat);
                        cont++;
                    }
                    else
                    {
                        if (cont == dat.DiaNumero)
                        {
                            dias.Add(dat);
                            cont++;
                        }
                    }
                    if (dat.DiaParte == "AM")
                    {
                        filtroAm.Add(dat);
                    }
                    else
                    {
                        if (dat.DiaParte == "PM")
                        {
                            filtroPm.Add(dat);
                        }
                    }

                }
            }
            else
            {
                int idItinerario_1 = idItinerario.Value;
                var datosItinerarios = await _repo.GetItinerBarco(idBarco, idItinerario_1);
                ViewBag.GetItinerarios = datosItinerarios;
            }
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            var metadatos = await _repo.GetMetadata(idVista);
            ViewBag.Title = metadatos[0].MetaTitulo;
            ViewBag.MetaDescription = metadatos[0].MetaDescripcion;
            ViewBag.CanonicalURL = urlCanonica + metadatos[0].MetaURL;
            ViewBag.GetBtnItinerarios = getBtnItinerarios;
            ViewBag.GetFiltrosAm = filtroAm;
            ViewBag.GetFiltrosPm = filtroPm;
            ViewBag.GetDias = dias;
            ViewBag.GetBarcos = barcos;
            ViewBag.GetFeatures = features;
            ViewBag.GetContenidoVista = contendido;
            ViewBag.GetContenidoMult = contenidoMultimedia;
            ViewBag.GetFeatures = features;
            ViewBag.CardsCruises = cardsCruises;
            return View();
        }
        [Route("/cruises/yacht-charters/{id?}/{idItinerario?}")]
        public async Task<ActionResult> CruisesCharter()
        {

            var urlData = _repo.getUrlPage(HttpContext);
            string urlCanonica = urlData[0];
            int idVista = 1011;
            var cardsCruises = new List<BarcoWeb>();
            var cards = new List<int>() {85,73, 103 };
            cardsCruises = await CruisesCardsOrden(cards);
            var metadatos = await _repo.GetMetadata(idVista);
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
            ViewBag.CardsCruises = cardsCruises;
            return View();
        }
        public async Task<ActionResult> cruises_charter()
        {
            string url = "http://api.visitgalapagos.travel/api/Availability";
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6Implc3VzQGFuZGFuZG90b3Vycy5jb20iLCJKTENvZGUiOiJUdUZ1dHVyb1NlRW5jdWVudHJhIEFxdWkiLCJqdGkiOiJkOTVkMGRmZS02ZWE4LTRhMGEtYTc5MS0xMjE5MGJkNDQ3MTEiLCJleHAiOjE2MDM5MjU3NTR9.qNp2FC88pjWDiMCFg4zj_PmzsvwEH0YZVaGj7kDlrsY");
            var json = await httpClient.GetStringAsync(url);
            List<Availability> dispoList = JsonConvert.DeserializeObject<List<Availability>>(json);
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            return View(dispoList);
        }
        
        [Route("/BarcoBD")]
        [HttpGet]
        public async Task<ActionResult<List<BarcoWeb>>> Get()
        {
            return await _repo.GetAll();
        }
        public async Task<ActionResult<List<ItinerBarcoBtn>>> GetItineraBarcoBtn(int idBarco)
        {
            return await _repo.GetItinerBarcoBtn(idBarco);
        }
        [Route("/GetItinerario/{idBarco}/{idItinerario}")]
        [HttpGet]
        public async Task<ActionResult<List<ItinerarioBarco>>> GetItinBarco(int idBarco, int idItinerario)
        {
            return await _repo.GetItinerBarco(idBarco, idItinerario);
        }
        //Itinerario con ajax form view bag
        [HttpPost]
        public async Task<IActionResult> GetItinerario(int idBarco, int idItinerario)
        {
            List<ItinerarioBarco> filtroAm = new List<ItinerarioBarco>();
            List<ItinerarioBarco> filtroPm = new List<ItinerarioBarco>();
            List<ItinerarioBarco> dias = new List<ItinerarioBarco>();
            List<ItinerarioBarco> itiActividades = new List<ItinerarioBarco>();
            List<ItinerarioBarco> itiActiFiltro = new List<ItinerarioBarco>();
            int cont = 0,contAct=1;
            var getItiner = await _repo.GetItinerBarco(idBarco, idItinerario);
            ViewBag.GetItiner = getItiner;
            //var newList = itiActividades.Select(getIti => getItiner.Where(item => item.ItiHiking == true).ToList()).ToList();
            //foreach (var grouping in getItiner.GroupBy(t => t.ItiHiking).Where(t => t == true))
            //{
            //    imprime = string.Format("'{0}' está repetido {1} veces.", grouping.Key, grouping.Count());
            //}
            foreach (var dat in getItiner)
            {
                if(cont == 0)
                {
                    dias.Add(dat);
                    cont++;
                }
                else
                {
                    if (cont == dat.DiaNumero)
                    {
                        dias.Add(dat);
                        cont++;
                    }
                }                
                if (dat.DiaParte == "AM")
                {
                    filtroAm.Add(dat);
                }
                else
                {
                    if (dat.DiaParte == "PM")
                    {
                        filtroPm.Add(dat);
                    }
                }
                if (dat.ItiHiking == true)
                {
                    itiActividades.Add(dat);
                }
            }
            
            foreach (var actividad in itiActividades)
            {
                
                    if (contAct == actividad.DiaNumero)
                    {
                        itiActiFiltro.Add(actividad);
                        cont++;
                    }
            } 
            ViewBag.GetItinHiking = itiActiFiltro;
            ViewBag.GetFiltroAm = filtroAm;
            ViewBag.GetFiltroPm = filtroPm;
            ViewBag.GetDias = dias;
            return View("itinerarioBarco");
        }

        [Route("/Dispo")]
        [HttpGet]
        public async Task<ActionResult<List<Availability>>> GetDisponi()
        {
            return await _repo.GetDispo();
        }

        [Route("/DispoOtrosBarcos")]
        [HttpGet]
        public async Task<ActionResult<List<Availability>>> GetDisponOtrosBarcos()
        {
            return await _repo.GetDispoOtrosBarcos();
        }

       
        [Route("/ContenidoVista/{idVista}")]
        [HttpGet]
        public async Task<ActionResult<List<GetContenidoVista>>> GetContenidoPagina(int idVista)
        {
            return await _repo.GetContenidoPaginaWeb(idVista);
        }

        [Route("/ContenidoVistaMultimedia/{idVista}")]
        [HttpGet]
        public async Task<ActionResult<List<GetContenidoMultimedia>>> GetContenidoMultimedia(int idVista)
        {
            return await _repo.GetContenidoMultimedia(idVista);
        }
        [Route("/CategoriaBarco")]
        [HttpGet]
        public async Task<ActionResult<List<CategoriaBarco>>> GetCategoriaBarco()
        {
            return await _repo.GetCategoriaBarcos();
        }

        [HttpPost]
        public void CreateLeadsBoats([FromBody] LeadsBoats leadsBoatsData)
        {
            _repo.CreateLeadsBoats(leadsBoatsData.NombreBarco,leadsBoatsData.Itinerario,leadsBoatsData.Noches,leadsBoatsData.SalCodigo,leadsBoatsData.Correo,leadsBoatsData.Nombre,leadsBoatsData.NummeroMax,leadsBoatsData.Observacion);
        }
    }
}