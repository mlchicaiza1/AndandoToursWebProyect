using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AndandoToursWeb.Controllers
{
    public class ImgenUploadController : Controller
    {
        IHostingEnvironment _env;
        // GET: ImgenUpload
        public ImgenUploadController(IHostingEnvironment environment)
        {
            _env = environment;
        }
        [HttpPost]
        public async Task<IActionResult> ImageUploadInsert(IFormFile files)
        {
            var jsonResult = Json(new { status = "Error" });
            if (files != null && files.Length > 0)
            {
                var imagenPath = @"\images\";
                var uploadPath = _env.WebRootPath + imagenPath;

                //create directory
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }
                // create file name 
                var fileName = files.FileName;
                var filenam = Path.GetFileName(fileName);
                string fullPath = uploadPath + filenam;

                imagenPath = imagenPath + @"\";
                var filePath = @".." + Path.Combine(imagenPath, filenam);

                using (var fileStream = new FileStream(fullPath, FileMode.Create))
                {
                    await files.CopyToAsync(fileStream);
                }
                jsonResult = Json(new { status = "ok" });
                ViewData["FileLocation"] = filePath;

                return jsonResult;
            }
            else
            {

                return jsonResult;
            }

        }
        public ActionResult Index()
        {
            return View();
        }
    }
}