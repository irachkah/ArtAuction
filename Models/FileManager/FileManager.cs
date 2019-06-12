using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace ArtAuction.Models.FileManager
{
    public class FileManager : IFileManager
    {
        private readonly string _imagePath;

        public FileManager(IConfiguration config)
        {
            _imagePath = config["Path:PaintingImages"];
        }

        public async Task<string> SaveImage(IFormFile image)
        {
            var save_path = Path.Combine(_imagePath);
            if (!Directory.Exists(_imagePath))
            {
                Directory.CreateDirectory(save_path);
            }
             
            var mime = image.FileName.Substring(image.FileName.LastIndexOf('.'));
            var fileName = $"painting_{DateTime.Now:dd-MM-yyyy-HH-mm-ss}{mime}";

            using (var fileStream = new FileStream(Path.Combine(save_path, fileName), FileMode.Create))
            {
                await image.CopyToAsync(fileStream);
            }

            return fileName;
        }
    }
}
