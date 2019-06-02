using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ArtAuction.Models
{
    [BsonIgnoreExtraElements]
    public class Artist
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string BirthPlace { get; set; }
        public DateTime DeathDate { get; set; }
        public string DeathPlace { get; set; }
        // transform to lists of proper data type
        [Required]
        public string Styles { get; set; }
        public List<Painting> Paintings { get; set; }
    }
}
