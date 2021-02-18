using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AndandoToursWeb.Data;
using AndandoToursWeb.Models;
using Microsoft.AspNetCore.Mvc;
namespace AndandoToursWeb.Controllers
{
    public class plan_your_tripController : Controller


    {


        private readonly AndandoRepositorio _repo;
        public plan_your_tripController(AndandoRepositorio repositorio)
        {
            this._repo = repositorio;
        }


        public IActionResult Index()
        {
            return View();
        }
        [Route("plan-your-trip/mainland-ecuador")]        
        public async Task<ActionResult> mainland_ecuador()
        {

            ///Meta Tag + Canonical
            var idVista = 2044;
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



        [Route("plan-your-trip/galapagos-travel-information")]
       

        public async Task<ActionResult> galapagos_travel_information()
        {

            ///Meta Tag + Canonical
            var idVista = 2043;
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



        [Route("plan-your-trip/galapagos-travel-recommendations")]
       

            public async Task<ActionResult> galapagos_travel_recommendations()
            {

                ///Meta Tag + Canonical
                var idVista = 2024;
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

        [Route("plan-your-trip/ecuador-travel-recommendations")]
        public async Task<IActionResult> ecuador_travel_recomendations()
        {


            ///Meta Tag + Canonical
            var idVista = 2041;
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
         
      

        [Route("plan-your-trip/mainland-ecuador/costs")]
       

        public async Task<IActionResult> ecuador_costs()
        {


            ///Meta Tag + Canonical
            var idVista = 2046;
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


        [Route("plan-your-trip/galapagos-travel-information/costs")]
       


        public async Task<IActionResult> galapagos_costs()
        {


            ///Meta Tag + Canonical
            var idVista = 2045;
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


        [Route("plan-your-trip/mainland-ecuador/tipping")]
        public IActionResult tipping_ecuador() {
            return View();
        }
        public IActionResult tipping_galapagos() {
            return View();
        }
    }
}
