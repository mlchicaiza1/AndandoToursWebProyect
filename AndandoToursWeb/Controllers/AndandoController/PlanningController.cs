using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using AndandoToursWeb.Models;
using AndandoToursWeb.Data;
using Microsoft.AspNetCore.Mvc;
namespace AndandoToursWeb.Controllers
{
    public class PlanningController : Controller
    {
        public string idVisit;
        private readonly AndandoRepositorio _repo;
        public PlanningController(AndandoRepositorio repositorio)
        {
            this._repo = repositorio;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult family_travel_honeymoons()
        {
            return View();
        }
        public IActionResult nature()
        {
            return View();
        }
        public async Task< IActionResult> landscapes()
        {
            var urlData = _repo.getUrlPage(HttpContext);
            string urlCanonica = urlData[0];

            //var metadatos = await _repo.GetMetadata(9);
            //List<GetContenidoVista> contendido = await _repo.GetContenidoPaginaWeb(9);
            //List<GetContenidoMultimedia> contenidoMultimedia = await _repo.GetContenidoMultimedia(9);
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.Title = "";
            ViewBag.MetaDescription = "";
            ViewBag.CanonicalURL = "";
            //ViewBag.GetContenidoVista = contendido;
            //ViewBag.GetContenidoMult = contenidoMultimedia;

            return View();
        }
        public IActionResult wildlife_calendar() {
            return View();
        }
        public IActionResult wildlife_map() {
            return View();
        }
        public IActionResult history()
        {
            return View();
        }
        public IActionResult activities()
        {
            return View();
        }
        public IActionResult brochure()
        {
            return View();
        }
        public IActionResult how_to_choose_itinerary()
        {
            return View();
        }
        public async Task<IActionResult> map()
        {

            var urlData = _repo.getUrlPage(HttpContext);
            string urlCanonica = urlData[0];

            //var metadatos = await _repo.GetMetadata(9);
            //List<GetContenidoVista> contendido = await _repo.GetContenidoPaginaWeb(9);
            //List<GetContenidoMultimedia> contenidoMultimedia = await _repo.GetContenidoMultimedia(9);
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.Title = "";
            ViewBag.MetaDescription = "";
            ViewBag.CanonicalURL = "";
            //ViewBag.GetContenidoVista = contendido;
            //ViewBag.GetContenidoMult = contenidoMultimedia;
            return View(await _repo.GetAllVisitor());
        }
        [Route("/VisitSiteIsland/{IdIsland}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorIsland(int IdIsland)
        {
            return await _repo.VisitorSiteFilterIsla(IdIsland);
        }
        [Route("/AllVisitor")]
        public async Task<ActionResult<List<VisitorSite>>> GetAllVisitor()
        {
            return await _repo.GetAllVisitor();
        }
        [Route("/Island1")]
        public async Task<ActionResult<List<Island>>> Get()
        {
            return await _repo.GetIsland();
        }
       

        //public async Task<IActionResult> visitor_sites(int IdVisitorSite) {
        //    return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        //    //return View();
        //}
        //[Route("/VisitorSite/{IdVisitorSite}")]
        //[HttpGet]
        //public async Task<ActionResult<List<VisitorSite>>> GetVisitor(int IdVisitorSite)
        //{
        //    return await _repo.GetVisitorSite(IdVisitorSite);
        //}
        [Route("/Wildlife/{idIsla}")]
        public async Task<ActionResult<List<Wildlife>>> GetFilterAnimal(int idIsla)
        {
            return await _repo.GetFilterAnimal(idIsla);
        }
        [Route("/Animals/{idAnimal}/{idIsla}")]
        public async Task<ActionResult<List<VisitorWildlife>>> GetVisitorFilterAnimal(string idAnimal, int idIsla)
        {
            return await _repo.GetVisitorFilterAnimal(idAnimal, idIsla);
        }
        public async Task< IActionResult> what_to_do() {

            var urlData = _repo.getUrlPage(HttpContext);
            string urlCanonica = urlData[0];
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.Title = "";
            ViewBag.MetaDescription = "";
            ViewBag.CanonicalURL = "";

            return View();
        }
        public IActionResult marine_Reserva()
        {
            return View();
        }
        public IActionResult gpn()
        {
            return View();
        }
        
    }
}