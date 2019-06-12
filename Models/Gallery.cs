using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ArtAuction.Models
{
    [BsonIgnoreExtraElements]
    public class Gallery
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [Required]
        [StringLength(60, MinimumLength = 5)]
        public string Title { get; set; }
        [Required]
        [StringLength(90, MinimumLength = 3)]
        public string Address { get; set; }
        [Required]
        public DateTime Founded { get; set; }
        [Required]
        public string Movement { get; set; }
        [Required]
        [StringLength(2000, MinimumLength = 20)]
        public string About { get; set; }
        public List<Painting> Paintings { get; set; }
        public List<User> Representatives { get; set; }

        public bool HasCurrentUser(string email)
        {
           return Representatives.Count(us => us.Email == email) != 0;
        }
    }
}
