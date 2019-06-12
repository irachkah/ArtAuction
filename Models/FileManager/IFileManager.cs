using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ArtAuction.Models.FileManager
{
   public interface IFileManager
   {
       Task<string> SaveImage(IFormFile image);
   }
}
