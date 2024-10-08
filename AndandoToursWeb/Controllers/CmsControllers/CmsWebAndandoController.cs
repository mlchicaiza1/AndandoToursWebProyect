﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AndandoToursWeb.DataCMS;
using AndandoToursWeb.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.NodeServices;
using Newtonsoft.Json;
using System.Dynamic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Caching.Memory;
using AndandoToursWeb.Data;
using AndandoToursWeb.Models.ModelsCMS;
using AndandoToursWeb.Models.ModelsAndandoTours;

namespace AndandoToursWeb.Controllers
{
    [Authorize(Roles = "Administrator,User")]
    public class CmsWebAndandoController : Controller
    {
        IHostingEnvironment _env;
        private readonly IMemoryCache cacheImg;
        private readonly AndandoRepositorio _repoAndando;
        private readonly CmsAndandoRepositorio _repo;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly INodeServices _nodeServices;

        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(HttpContext.User);

            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Identity/Account");
            }
            else
            {
                var claim = User.Claims.ToList();
                ApplicationUser user = _userManager.FindByIdAsync(userId).Result;

                ViewBag.idUser = user;
                return View();
            }

        }

        public IActionResult CrearContenidoPagina()
        {

            return View();
        }


        public IActionResult ActualizarCards(int id)
        {
           var cards= _repoAndando.GetCards(id);

            return View(cards);
        }

        [HttpPost]
        public JsonResult CrearContenidoPagina(CreateContenido nPagina)
        {
            
            try
            {
               var idVista= _repo.NewContenidoPaginaWeb(nPagina);
                return Json(idVista);
            }
            catch
            {
                return Json("Error");
            }
            

        }


        [HttpPost]

        public JsonResult CrearItinerario(ItinEcuadorBtn model)
        {
            try
            {
                _repo.AddItinearioEcu(model);

                return Json("Guardado");
            }
            catch (Exception ex)
            {
                return Json(ex);
            }
        }


        public JsonResult CrearCards(CardsAndando model)
        {
           
            try
            {

                if (model.file != null && model.file.Length > 0)
                {
                    var imagePath = @"\images\imageCards\";

                    var uploadPath = _env.WebRootPath + imagePath;

                    //Create Directory

                    if (!Directory.Exists(uploadPath))
                    {
                        Directory.CreateDirectory(uploadPath);
                    }
                    //Create uniq file nmae

                    var uiqFileName = Guid.NewGuid();

                    var filename = Path.GetFileName(model.file.FileName);

                    string fullPath = uploadPath + filename;

                    imagePath = imagePath + @"\";

                    var filePath = @".." + Path.Combine(imagePath, filename);

                    using (var filestream = new FileStream(fullPath, FileMode.Create))
                    {
                        model.file.CopyToAsync(filestream);
                    }

                    ViewBag.filePath = filePath;

                     _repo.CreateCards(model);
                }


               
                return Json("Creado");
            }
            catch
            {
                return Json("Error");
            }


        }

        public JsonResult ActualizarCards(CardsAndando model)
        {

            try
            {
                _repo.UpdateCards(model);
                return Json("Creado");
            }
            catch
            {
                return Json("Error");
            }


        }

        public async Task<IActionResult> ImageUpload(IFormFile file)
        {
            if (file != null && file.Length>0)
            {
                var imagePath = @"\images\imageCards\";

                var uploadPath = _env.WebRootPath + imagePath;

                //Create Directory

                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }
                //Create uniq file nmae

                var uiqFileName = Guid.NewGuid();

                var filename = Path.GetFileName(file.FileName);

                string fullPath = uploadPath + filename;

                imagePath = imagePath + @"\";

                var filePath = @".." + Path.Combine(imagePath, filename);

                using(var filestream= new FileStream(fullPath, FileMode.Create))
                {
                    await file.CopyToAsync(filestream);
                }

                ViewBag.filePath = filePath;


            }

            return View("../CmsWebAndando/CrearContenidoPagina");
        }


        [Route("/PaginasWeb")]
        public ActionResult PaginasAndandoWeb(string categoria)
        {
            ViewBag.categoria = categoria;
            return View();
        }

        [Route("/PaginasWeb/CmsText")]
        public ActionResult CmsTextoWebAndando(string id)
        {
            ViewBag.id = id;
            return View();
        }

        [Route("/PaginasWeb/CmsImagen")]
        public ActionResult CmsImagenesAndando(string id)
        {
            ViewBag.id = id;
            return View();
        }
        public ActionResult editaImagen_modal()
        {
            return View();
        }



        public async Task<IActionResult> IndexAsync()
        {
            dynamic context = new ExpandoObject();
            context.title = "test title from c#";
            context.meta = "<meta number='1'><meta number='2'>";
            var jsonData = JsonConvert.SerializeObject(context);
            var r = await _nodeServices.InvokeAsync<string>(@"\\<mypath>\vue-server-render\vue-ssr\dotnetAdapter.js", context).ConfigureAwait(false);
            return Content(r, "text/html");
        }

        public CmsWebAndandoController(CmsAndandoRepositorio repositorio, AndandoRepositorio repoAndando, INodeServices nodeServices, IHostingEnvironment enviroment, UserManager<ApplicationUser> userManeger)
        {
            this._repo = repositorio;
            this._repoAndando = repoAndando;
            this._nodeServices = nodeServices;
            this._userManager = userManeger;
            this._env = enviroment;
        }

        [Route("/VistaAndando/{categoria}")]
        [HttpGet]
        public async Task<ActionResult<List<VistaAndando>>> GetVistaAndando(string categoria)
        {
            return await _repo.GetVistaAndandoWeb(categoria);
        }

        [Route("/ContenidoVistaCMS/{idVista}")]
        [HttpGet]
        public async Task<ActionResult<List<GetContenidoPagina>>> GetContenido(int idVista)
        {
            return await _repo.GetContenidoPAginaWeb(idVista);
        }
        [Route("/ContenidoImagenes/{idVista}")]
        [HttpGet]
        public async Task<ActionResult<List<Multimedia>>> GetImagen(int idVista)
        {
            return await _repo.GetImagenWeb(idVista);
        }
        //[Route("/actualizarParrafo/{idtitulo}/{idparrafo}/{parrafo}")]
        [Route("/ContenidoMetaDatos/{idVista}")]
        [HttpGet]
        public async Task<ActionResult<List<MetadataCMS>>> GetMeta(int idVista)
        {
            return await _repo.GetMetadata(idVista);
        }

        [Route("/ImgMenu")]
        [HttpGet]
        public async Task<ActionResult<List<GetContenidoMultimedia>>> GetMenu()
        {
            return await _repoAndando.GetImgMenu();
        }

        
        [HttpPost]
        public async Task<IActionResult> ImageUploadInsert(IFormFile files, string name, string nombreDefecto, string ruta,int idImagen, String idImage)
        {
            var jsonResult = Json(new { status = "Error" });
            if (files != null && files.Length > 0)
            {
                var imagenPath = @""+ruta+ "/";
                var uploadPath = _env.WebRootPath + imagenPath;
                //ruta del la imagen 
                //var imagenPathWeb = @"C:\\inetpub\\wwwroot\WebSite\\Principal\\wwwroot\\" + imagenPath+ "/";
                var uploadPathWeb = uploadPath;
                //create directory
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }
                // create file name 
                var fileName = files.FileName;
                var filenam = "";
                //Actualizar Nombre
                if (name != null)
                {
                    _repo.UpdateImagenes(idImagen,name);
                    //pruebas de cambios
                    filenam = Path.GetFileName(name);
                    filenam = Path.GetFileName(name);
                }
                else
                {
                    filenam = Path.GetFileName(nombreDefecto);
                }
                string extension = System.IO.Path.GetExtension(files.FileName);
                string fullPath = uploadPath + filenam + extension;
                //web
                string fullPathWeb = uploadPathWeb + filenam + extension;
                
                imagenPath = imagenPath + @"\";
                var filePath = @".." + Path.Combine(imagenPath, filenam + extension);
                //web    
                using (var fileStream = new FileStream(fullPath, FileMode.Create))
                {
                    await files.CopyToAsync(fileStream);
                }
               
               jsonResult = Json(new { status = "ok" });
                ViewData["FileLocation"] = filePath;
                //Registro de actividad
                var urlData = getUrlPage(HttpContext);
                var RegActividad = new RegistroActividades();
                RegActividad.Pagina = urlData.ToString();
                RegActividad.Seccion = "Imagen";
                RegActividad.Titulo = nombreDefecto;
                RegActividad.ImagenNombre = nombreDefecto;
                RegActividad.Texto = false;
                RegActividad.Imagen = true;
                MemoryCacheEntryOptions cacheExpiration = new MemoryCacheEntryOptions();
                cacheExpiration.AbsoluteExpiration = DateTime.Now.AddMinutes(1);
                cacheExpiration.Priority = CacheItemPriority.High;

                return Redirect("../../../PaginasWeb/CmsImagen?id="+ idImage);
            }
            else
            {
                ViewData["Success"] = "Error successfully.";
                return jsonResult;
            }

        }

        [HttpPost]
        public void UpdateParrafo([FromBody] Parrafo parrafoData)
        {

          _repo.UpdateContenidoPAginaWeb(parrafoData.IdTitulo,parrafoData.IdParrafo, parrafoData.ContenidoParrafo);
            
        }
        [HttpPost]
        public void RegistroActividad([FromBody] RegistroActividades regActiv)
        {
            
            var userId = _userManager.GetUserId(HttpContext.User);
            _repo.RegistroActividades(userId,regActiv.UrlPagina ,regActiv.Pagina,regActiv.Seccion,regActiv.Titulo,regActiv.ImagenNombre,regActiv.Texto,regActiv.Imagen);
        }

        [HttpPost]
        public void UpdateTitulo([FromBody] Titulo tituloData)
        {

            _repo.UpdateTituloPAginaWeb(tituloData.IdTitulo,tituloData.contenidoTitulo);
        }
        [HttpPost]
        public void UpdateMetadata([FromBody] Metadata MetaData)
        {
            _repo.UpdateMetadataPaginaWeb(MetaData.idVista,MetaData.MetaTitulo,MetaData.MetaDescripcion,MetaData.MetaURL);
        }
        
        [HttpPost]
        public void UpdateNombreImg(string  nombreImagen, int idImagen)
        {

            _repo.UpdateImagenes(idImagen, nombreImagen);
        }

        [HttpPost]
        public void UpdateNombreImgMenu(string nombreImagen, int idImagen)
        {

            _repo.UpdateImagenesMenu(idImagen, nombreImagen);
        }

        public List<String> getUrlPage(Microsoft.AspNetCore.Http.HttpContext context)
        {
            var host = $"{context.Request.Scheme}://{context.Request.Host}";
            var urlCategories = context.Request.Path.Value;
            List<string> urlPagina = new List<string>();
            urlPagina.Add(host);
            urlPagina.Add(urlCategories);

            return urlPagina;
            // Other code
        }
    }

   
}