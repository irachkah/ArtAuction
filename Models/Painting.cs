using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using ArtAuction.ViewModels;
using Microsoft.AspNetCore.Http;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ArtAuction.Models
{
    [BsonIgnoreExtraElements]
    public class Painting
    {
       //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Style { get; set; }
        public string CreationDate { get; set; }
        public string CurrentlyLocated { get; set; } = "OnAuction";
        public bool IsBought { get; set; } = false;
        public string OwnerId { get; set; }
        public string OwnerName { get; set; }
        public string Estimated { get; set; }
        public string ImgId { get; set; }

        public Painting(PaintingViewModel vm)
        {
            Title = vm.Title;
            Artist = vm.Artist;
            Style = vm.Style;
            CreationDate = vm.CreationDate;
            CurrentlyLocated = vm.CurrentlyLocated;
            OwnerId = vm.OwnerId;
            IsBought = vm.IsBought;
            Estimated = vm.Estimated;
        }
    }
}
