using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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
        public string Artist { get; set; }
        [Required]
        [StringLength(30, MinimumLength = 3)]
        public string Style { get; set; }
        [Required]
        public string CreationDate { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string CurrentlyLocated { get; set; }
        public string OwnerId { get; set; }
        public bool IsBought { get; set; } = false;
        [Required]
        [StringLength(15, MinimumLength = 2)]
        public string Estimated { get; set; }
        public IFormFile Image { get; set; } = null;
    }
}
