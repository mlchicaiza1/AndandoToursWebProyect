using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AndandoToursWeb.Models;
using AndandoToursWeb.Data;
using Microsoft.AspNetCore.Mvc;
namespace AndandoToursWeb.Controllers
{
    public class trip_plannerController : Controller
    {
        [Route("/trip-planner")]
        public async Task<IActionResult> tri_planner()
        {
            var cardsCruises = new List<BarcoWeb>();
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.Title = "Trip Finder – Ecuador and Galapagos tours";
            ViewBag.MetaDescription = "Ecuador and Galapagos tours - Andando Tours offers tours for every traveler going to Galapagos and Mainland Ecuador. What will your type of  story be? ";
            ViewBag.CanonicalURL = "/tours";
            ViewBag.ImagenesMenu = ImgMenu;
            return View();
        }
        public readonly AndandoRepositorio _repo;
        public trip_plannerController(AndandoRepositorio repositorio)
        {
            this._repo = repositorio;
        }

        //[Route("/BarcoBD")]
        //[HttpGet]
        //public async Task<ActionResult<List<BarcoWeb>>> Get()
        //{
        //    return await _repo.GetAll();
        //}
        [Route("/DisponibilidadBarcoPaMa")]
        [HttpGet]
        public async Task<ActionResult<List<Availability>>> GetDisponi()
        {
            return await _repo.GetDispo();
        }

        //[Route("/DispoOtrosBarcos")]
        //[HttpGet]
        //public async Task<ActionResult<List<Availability>>> GetDisponOtrosBarcos()
        //{
        //    return await _repo.GetDispoOtrosBarcos();
        //}

        [Route("/IslandHoppingPaquetes")]
        public async Task<ActionResult<List<ViewIslandHoppingPaquete>>> GetViewIslandHoppingPaquetes()
        {

            return await _repo.GetViewIslandHoppingPaquetes();
        }

        [Route("/GetIslandHoppPaqFindIDItinerario/{idItinerario}")]
        public async Task<ActionResult<List<ViewIslandHoppingPaquete>>> GetIslandHoppingPaqFindIDItinerario(int idItinerario)
        {
            return await _repo.GetIslandHoppingPaquetesFindIDItinerario(idItinerario);
        }
        [Route("/GetIslandIDItinerarioDetallado/{idItinerario}")]
        public async Task<ActionResult<List<ItinerarioBarco>>> GetIslandIDItinerarioDeta(int idItinerario)
        {
            return await _repo.GetPaquetesIDItinerarioDetallado(idItinerario);
        }
    }
}