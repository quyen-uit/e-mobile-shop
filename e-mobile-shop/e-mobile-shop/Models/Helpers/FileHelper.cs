using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace e_mobile_shop.Models.Helpers
{
    public class FileHelper
    {

        public static string UploadedFile(IFormFile file, string folder)
        {
            string uniqueFileName = null;
            if (file != null)
            {
                //string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, folder);
                string uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folder);
                uniqueFileName = "new" + Guid.NewGuid().ToString() + "." + file.FileName.Split(".")[1].ToLower();
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
