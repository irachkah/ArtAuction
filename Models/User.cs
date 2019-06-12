using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ArtAuction.Models
{
    [BsonIgnoreExtraElements]
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; } = "User";
        public bool IsRepresentative { get; set; }
        public string Gallery { get; set; }
        public string GalleryId { get; set; } = "";
        public List<Painting> Paintings { get; set; }

        public User(string fname, 
            string lname,
            string country, 
            string city, 
            bool represent, 
            string gallery, 
            string email, 
            string password)
        {
            FirstName = fname;
            LastName = lname;
            Country = country;
            City = city;
            Email = email;
            IsRepresentative = represent;
            Gallery = gallery;
            Password = password;
        }
    }
}
