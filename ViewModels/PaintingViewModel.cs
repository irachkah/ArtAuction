using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Internal;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ArtAuction.ViewModels
{
    public class PaintingViewModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Style { get; set; }
        [Required]
        public string CreationDate { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string CurrentlyLocated { get; set; }
        public string OwnerId { get; set; }
        public string ArtistId { get; set; }
        public bool IsBought { get; set; } = false;
        [Required]
        [StringLength(15, MinimumLength = 2)]
        public string Estimated { get; set; }
        [Required]
        [DataType(DataType.Upload)]
        [FileExtensions("jpg,jpeg,png,gif", ErrorMessage = "Image extension must be jpg, jpeg, png or gif")]
        public IFormFile Image { get; set; }

        /*public bool ValidateImage()
        {
            string[] extensions = {"png, jpg, jpeg"};
            var mime = Image.FileName.Substring(Image.FileName.LastIndexOf('.'));
            return extensions.IndexOf(mime) != 0;
        }*/
    }
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public class FileExtensionsAttribute : ValidationAttribute
    {
        private List<string> AllowedExtensions { get; set; }

        public FileExtensionsAttribute(string fileExtensions)
        {
            AllowedExtensions = fileExtensions.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        }

        public override bool IsValid(object value)
        {
            if (value is IFormFile file)
            {
                var fileName = file.FileName;

                return AllowedExtensions.Any(y => fileName.EndsWith(y));
            }

            return true;
        }
    }


}
