using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AndandoToursWeb.DataCMS
{
    public class InsertImageServer
    {
        IHostingEnvironment _env;
        public InsertImageServer(IHostingEnvironment environment)
        {
            _env = environment;
        }
        public InsertImageServer()
        {

        }
        public async void ImageUpload(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var imagenPath = @"~wwwroot\images\";
                var uploadPath = _env.WebRootPath + imagenPath;

                //create directory
                if (!Directory.Exists(uploadPath))
                {
                    Directory.CreateDirectory(uploadPath);
                }
                // create file name 
                var fileName = Guid.NewGuid().ToString();
                var filenam = Path.GetFileName(fileName + "." + file.FileName.Split(".")[1].ToLower());
                string fullPath = uploadPath + filenam;

                imagenPath = imagenPath + @"\";
                var filePath = @".." + Path.Combine(imagenPath, filenam);

                using (var fileStream = new FileStream(fullPath, FileMode.Create))
                {
                    await file.CopyToAsync(fileStream);
                }
            }
        }
    }
}
