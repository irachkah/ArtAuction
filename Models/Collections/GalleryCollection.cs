using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ArtAuction.Models.Collections
{
    public class GalleryCollection : IEditableCollection<Gallery>
    {
        private readonly IMongoCollection<Gallery> _galleries;

        public GalleryCollection(string conStr)
        {
            var client = new MongoClient(conStr);
            var database = client.GetDatabase("ArtDB");
            _galleries = database.GetCollection<Gallery>("Galleries");
        }

        public List<Gallery> Objects
        {
            get
            {
                return _galleries.Find(_ => true).ToList();
            }
        }

        public void AddObject(Gallery obj)
        {
            _galleries.InsertOne(obj);
        }

        public void RemoveObject(string id)
        {
            _galleries.DeleteOne(ar => ar.Id == id);
        }

        public void UpdateObject(Gallery obj)
        {
            var filter = new BsonDocument("_id", new ObjectId(obj.Id));
            var res = _galleries.ReplaceOne(filter, obj);
        }

        public Gallery FindObject(string id)
        {
            var galleryFound = _galleries.Find(g => g.Id == id).ToList();
            return galleryFound[0];
        }
    }
}
