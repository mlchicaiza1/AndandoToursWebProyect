using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AndandoToursWeb.Models;
using AndandoToursWeb.Data;
using Microsoft.AspNetCore.Mvc;
namespace AndandoToursWeb.Controllers
{
    public class visitor_sitesController : Controller
    {
        private readonly AndandoRepositorio _repo;
        public visitor_sitesController(AndandoRepositorio repositorio)
        {
            this._repo = repositorio;
        }
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
        [Route("visitor-sites/tortuga-bay-galapagos-islands/")]
        public async Task<IActionResult> tortuga_bay_galapagos_islands() {
            int IdVisitorSite = 1;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/tortuga-bay-galapagos-islands/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorTortuga(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/arnaldo-tupiza-center-galapagos-islands/")]
        public async Task<IActionResult> arnaldo_tupiza_center_galapagos_islands()
        {
            int IdVisitorSite = 2;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/arnaldo-tupiza-center-galapagos-islands/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorArnaldo(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/asilo-de-la-paz/")]
        public async Task<IActionResult> asilo_de_la_paz()
        {
            int IdVisitorSite = 3;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/asilo-de-la-paz/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorAsilo(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/bachas-beach-galapagos-islands/")]
        public async Task<IActionResult> bachas_beach_galapagos_islands()
        {
            int IdVisitorSite = 4;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/bachas-beach-galapagos-islands/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorBachas(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/bainbridge-galapagos-islands/")]
        public async Task<IActionResult> bainbridge_galapagos_islands()
        {
            int IdVisitorSite = 5;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/bainbridge-galapagos-islands/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorBainbridge(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/baltra-airport-galapagos-islands/")]
        public async Task<IActionResult> baltra_airport_galapagos_islands()
        {
            int IdVisitorSite = 6;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/baltra-airport-galapagos-islands/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorBaltra(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/baroness-lookout-galapagos-islands/")]
        public async Task<IActionResult> baroness_lookout_galapagos_islands()
        {
            int IdVisitorSite = 7;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/baroness-lookout-galapagos-islands/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorBaaroness(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/bartolome-galapagos-islands/")]
        public async Task<IActionResult> bartolome_galapagos_islands()
        {
            int IdVisitorSite = 8;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/bartolome-galapagos-islands/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorBartolome(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/black-beach-galapagos-islands/")]
        public async Task<IActionResult> black_beach_galapagos_islands()
        {
            int IdVisitorSite = 9;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/black-beach-galapagos-islands/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorBlack(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/black-turtle-cove/")]
        public async Task<IActionResult> black_turtle_cove()
        {
            int IdVisitorSite = 10;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/black-turtle-cove/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorBlackCove(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/bucanero-cove-galapagos-islands/")]
        public async Task<IActionResult> bucanero_cove_galapagos_islands()
        {
            int IdVisitorSite = 11;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/bucanero-cove-galapagos-islands/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorBucanero(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/cerro-brujo/")]
        public async Task<IActionResult> cerro_brujo()
        {
            int IdVisitorSite = 12;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/cerro-brujo/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorBrujo(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/cerro-dragon-galapagos-islands/")]
        public async Task<IActionResult> cerro_dragon_galapagos_islands()
        {
            int IdVisitorSite = 13;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/cerro-dragon-galapagos-islands/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorDragon(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("/visitor-sites/charles-darwin-station-galapagos-islands/")]
        public async Task<IActionResult> charles_darwin_station_galapagos_islands()
        {
            int IdVisitorSite = 14;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/charles-darwin-station-galapagos-islands/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorCharles(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("/visitor-sites/daphne-galapagos-islands/")]
        public async Task<IActionResult> daphne_galapagos_islands()
        {
            int IdVisitorSite = 15;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/daphne-galapagos-islands/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorDaphne(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/devils-crown-galapagos-islands/")]
        public async Task<IActionResult> devils_crown_galapagos_islands()
        {
            int IdVisitorSite = 16;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/devils-crown-galapagos-islands/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorDevil(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/el-chato-galapagos-islands/")]
        public async Task<IActionResult> el_chato_galapagos_islands()
        {
            int IdVisitorSite = 17;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/el-chato-galapagos-islands/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorChato(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/el-junco-lagoon/")]
        public async Task<IActionResult> el_junco_lagoon()
        {
            int IdVisitorSite = 18;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/el-junco-lagoon/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorJunco(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/elizabeth-bay-galapagos-islands/")]
        public async Task<IActionResult> elizabeth_bay_galapagos_islands()
        {
            int IdVisitorSite = 19;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/elizabeth-bay-galapagos-islands/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorElizabeth(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/espumilla-beach-galapagos-islands/")]
        public async Task<IActionResult> espumilla_beach_galapagos_islands()
        {
            int IdVisitorSite = 20;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/espumilla-beach-galapagos-islands/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorEspumilla(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/gardner-bay-galapagos-islands/")]
        public async Task<IActionResult> gardner_bay_galapagos_islands()
        {
            int IdVisitorSite = 21;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/gardner-bay-galapagos-islands/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorGardnerBay(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/genovesa-island-darwin-bay-galapagos/")]
        public async Task<IActionResult> genovesa_island_darwin_bay_galapagos()
        {
            int IdVisitorSite = 22;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/genovesa-island-darwin-bay-galapagos/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorDarwinrBay(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/genovesa-island-el-barranco-galapagos-islands/")]
        public async Task<IActionResult> genovesa_island_el_barranco_galapagos_islands()
        {
            int IdVisitorSite = 23;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/genovesa-island-el-barranco-galapagos-islands/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorGenovesa(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/islet-champion-galapagos-islands/")]
        public async Task<IActionResult> islet_champion_galapagos_islands()
        {
            int IdVisitorSite = 24;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/islet-champion-galapagos-islands/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorChampion(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/islet-gardner-galapagos-islands/")]
        public async Task<IActionResult> islet_gardner_galapagos_islands()
        {
            int IdVisitorSite = 25;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/islet-gardner-galapagos-islands/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorGardner(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/islet-osborn-galapagos-islands/")]
        public async Task<IActionResult> islet_osborn_galapagos_islands()
        {
            int IdVisitorSite = 26;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/islet-osborn-galapagos-islands/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorOsborn(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/jacinto-gordillo-galapagos-islands/")]
        public async Task<IActionResult> jacinto_gordillo_galapagos_islands()
        {
            int IdVisitorSite = 27;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/jacinto-gordillo-galapagos-islands/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorGordillo(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/kicker-rock-leon-dormido-galapagos-islands/")]
        public async Task<IActionResult> kicker_rock_leon_dormido_galapagos_islands()
        {
            int IdVisitorSite = 28;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/kicker-rock-leon-dormido-galapagos-islands/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorLeon(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/las-grietas/")]
        public async Task<IActionResult> las_grietas()
        {
            int IdVisitorSite = 29;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/las-grietas/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorGrietas(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/lobos-island-galapagos-islands/")]
        public async Task<IActionResult> lobos_island_galapagos_islands()
        {
            int IdVisitorSite = 30;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/lobos-island-galapagos-islands/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorLobos(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/mangle-point-galapagos-islands/")]
        public async Task<IActionResult> mangle_point_galapagos_islands()
        {
            int IdVisitorSite = 31;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/mangle-point-galapagos-islands/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorMangle(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/mosquera-islet-galapagos-islands/")]
        public async Task<IActionResult> mosquera_islet_galapagos_islands()
        {
            int IdVisitorSite = 32;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/mosquera-islet-galapagos-islands/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorMonsequera(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/navigation-whale-dolphin-observation-galapagos-islands/")]
        public async Task<IActionResult> navigation_whale_dolphin_observation_galapagos_islands()
        {
            int IdVisitorSite = 33;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/navigation-whale-dolphin-observation-galapagos-islands/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorNavigation(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/north_seymour-galapagos-islands/")]
        public async Task<IActionResult> north_seymour_galapagos_islands()
        {
            int IdVisitorSite = 34;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/north_seymour-galapagos-islands/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorNorth(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/pinnacle-rock-galapagos-islands/")]
        public async Task<IActionResult> pinnacle_rock_galapagos_islands()
        {
            int IdVisitorSite = 35;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/pinnacle-rock-galapagos-islands/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorPinnacle(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/post-office-bay-galapagos-islands/")]
        public async Task<IActionResult> post_office_bay_galapagos_islands()
        {
            int IdVisitorSite = 36;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/post-office-bay-galapagos-islands/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorPost(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/puerto-ayora-galapagos-islands/")]
        public async Task<IActionResult> puerto_ayora_galapagos_islands()
        {
            int IdVisitorSite = 37;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/puerto-ayora-galapagos-islands/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorPuerto(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/puerto-baquerizo-moreno_galapagos-islands/")]
        public async Task<IActionResult> puerto_baquerizo_moreno_galapagos_islands()
        {
            int IdVisitorSite = 38;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/puerto-baquerizo-moreno_galapagos-islands/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorBaquerizo(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/puerto-chino/")]
        public async Task<IActionResult> puerto_chino()
        {
            int IdVisitorSite = 39;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/puerto-chino/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorChino(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/puerto-egas-galapagos-islands/")]
        public async Task<IActionResult> puerto_egas_galapagos_islands()
        {
            int IdVisitorSite = 40;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/puerto-egas-galapagos-islands/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorEgas(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/puerto-grande/")]
        public async Task<IActionResult> puerto_grande()
        {
            int IdVisitorSite = 41;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/puerto-grande/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorGrande(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/punta-cormorant-galapagos-islands/")]
        public async Task<IActionResult> punta_cormorant_galapagos_islands()
        {
            int IdVisitorSite = 42;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/punta-cormorant-galapagos-islands/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorCormorant(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/punta-espejo/")]
        public async Task<IActionResult> punta_espejo()
        {
            int IdVisitorSite = 43;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/punta-espejo/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorEspejo(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/punta-espinoza-galapagos-islands/")]
        public async Task<IActionResult> punta_espinoza_galapagos_islands()
        {
            int IdVisitorSite = 44;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/punta-espinoza-galapagos-islands/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorEspinoza(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/punta-moreno-galapagos-islands/")]
        public async Task<IActionResult> punta_moreno_galapagos_islands()
        {
            int IdVisitorSite = 45;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/punta-moreno-galapagos-islands/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorMoreno(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/punta-pitt-galapagos-islands/")]
        public async Task<IActionResult> punta_pitt_galapagos_islands()
        {
            int IdVisitorSite = 46;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/punta-pitt-galapagos-islands/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorPitt(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/punta-suarez-galapagos-islands/")]
        public async Task<IActionResult> punta_suarez_galapagos_islands()
        {
            int IdVisitorSite = 47;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/punta-suarez-galapagos-islands/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorSuarez(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/punta-vicente-roca-galapagos-islands/")]
        public async Task<IActionResult> punta_vicente_roca_galapagos_islands()
        {
            int IdVisitorSite = 48;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/punta-vicente-roca-galapagos-islands/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorVicente(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/rabida-galapagos-islands/")]
        public async Task<IActionResult> rabida_galapagos_islands()
        {
            int IdVisitorSite = 49;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/rabida-galapagos-islands/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorRabida(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/san-cristobal-intepretation-center-galapagos-islands/")]
        public async Task<IActionResult> san_cristobal_intepretation_center_galapagos_islands()
        {
            int IdVisitorSite = 50;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/san-cristobal-intepretation-center-galapagos-islands/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorCristobal(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/santa-cruz-highlands-galapagos-islands/")]
        public async Task<IActionResult> santa_cruz_highlands_galapagos_islands()
        {
            int IdVisitorSite = 51;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/santa-cruz-highlands-galapagos-islands/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorHighlands(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/santa-fe-galapagos-islands/")]
        public async Task<IActionResult> santa_fe_galapagos_islands()
        {
            int IdVisitorSite = 52;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/santa-fe-galapagos-islands/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorSantaFe(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/sierra-negra-galapagos-islands/")]
        public async Task<IActionResult> sierra_negra_galapagos_islands()
        {
            int IdVisitorSite = 53;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/sierra-negra-galapagos-islands/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorSierra(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/sombrero-chino-galapagos-islands/")]
        public async Task<IActionResult> sombrero_chino_galapagos_islands()
        {
            int IdVisitorSite = 54;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/sombrero-chino-galapagos-islands/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorSombrero(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/south-plaza-station-galapagos-islands/")]
        public async Task<IActionResult> south_plaza_station_galapagos_islands()
        {
            int IdVisitorSite = 55;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/south-plaza-station-galapagos-islands/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorSouth(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/sullivan-bay-galapagos-islands/")]
        public async Task<IActionResult> sullivan_bay_galapagos_islands()
        {
            int IdVisitorSite = 56;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/sullivan-bay-galapagos-islands/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorSullivan(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/tagus-cove-galapagos-islands/")]
        public async Task<IActionResult> tagus_cove_galapagos_islands()
        {
            int IdVisitorSite = 57;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/tagus-cove-galapagos-islands/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorTagus(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/tijeretas-hill-galapagos-islands/")]
        public async Task<IActionResult> tijeretas_hill_galapagos_islands()
        {
            int IdVisitorSite = 58;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/tijeretas-hill-galapagos-islands/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorTijeretas(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/tintoreras-islet-galapagos-islands/")]
        public async Task<IActionResult> tintoreras_islet_galapagos_islands()
        {
            int IdVisitorSite = 59;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/tintoreras-islet-galapagos-islands/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorTintoreras(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/twin-craters-galapagos-islands/")]
        public async Task<IActionResult> twin_craters_galapagos_islands()
        {
            int IdVisitorSite = 60;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/twin-craters-galapagos-islands/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorTwin(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/urbina-bay-galapagos-islands/")]
        public async Task<IActionResult> urbina_bay_galapagos_islands()
        {
            int IdVisitorSite = 61;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/urbina-bay-galapagos-islands/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorUrbina(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
        [Route("visitor-sites/wall-of-tears-galapagos-islands/")]
        public async Task<IActionResult> wall_of_tears_galapagos_islands()
        {
            int IdVisitorSite = 62;
            //Imagenes Menu
            List<GetContenidoMultimedia> ImgMenu = await _repo.GetImgMenu();
            ViewBag.ImagenesMenu = ImgMenu;
            ViewBag.IdVisitorSite = IdVisitorSite;
            return View(await _repo.GetInfoVisitorSite(IdVisitorSite));
        }
        [Route("/visitor-sites/wall-of-tears-galapagos-islands/{IdVisitorSite}")]
        [HttpGet]
        public async Task<ActionResult<List<VisitorSite>>> GetVisitorWall(int IdVisitorSite)
        {
            return await _repo.GetVisitorSite(IdVisitorSite);
        }
    }
}
