using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ArtAuction.Models
{
    [BsonIgnoreExtraElements]
    public class Auction
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Title { get; set; }
        //[BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        [Required]
        public DateTime StartDateTime { get; set; }
        [Required]
        public DateTime EndDateTime { get; set; }
        [Required]
        [StringLength(1000, MinimumLength = 5)]
        public string Description { get; set; }
        public List<Painting> Paintings { get; set; }
    }
}
