using System.Collections.Generic;
using System.Linq;

using MongoDB.Bson;
using MongoDB.Driver;

namespace ArtAuction.Models.Collections
{
    public class PaintingCollection : IPaintingCollection
    {
        private readonly IMongoCollection<Painting> _paintings;
        private List<Painting> paintingsList;

        public PaintingCollection(string conStr)
        {
            var client = new MongoClient(conStr);
            var database = client.GetDatabase("ArtDB");
            _paintings = database.GetCollection<Painting>("Paintings");
        }

        public List<Painting> Objects
        {
            get
            {
                return new List<Painting>(_paintings.Find(_ => true).ToList().OrderBy(p => p.Title));
            }
        }

        public void AddObject(Painting obj)
        {
            _paintings.InsertOne(obj);
        }

        public void RemoveObject(string id)
        {
            _paintings.DeleteOne(p => p.Id == id);
        }

        public void UpdateObject(Painting obj)
        {
            var filter = new BsonDocument("_id", new ObjectId(obj.Id));
            var res = _paintings.ReplaceOne(filter, obj);
        }

        public Painting FindObject(string id)
        {
            var paintingFound = _paintings.Find(ar => ar.Id == id).ToList();
            return paintingFound[0];
        }

        public List<Painting> GetArtistPaintings(string artistId)
        {
            paintingsList = Objects.FindAll(p => p.ArtistId == artistId).OrderBy(p => p.Title).ToList();
            return paintingsList;
        }

        public List<Painting> GetAuctionPaintings(string auctionId)
        {
            paintingsList = Objects.FindAll(p => p.AuctionId == auctionId).OrderBy(p => p.Title).ToList();
            return paintingsList;
        }

        public List<Painting> GetOwnerPaintings(string ownerId)
        {
            paintingsList = Objects.FindAll(p => p.OwnerId == ownerId).OrderBy(p => p.Title).ToList();
            return paintingsList;
        }

        public void RemoveArtistPaintings(string artistId)
        {
            var filter = new BsonDocument("ArtistId", artistId);
            _paintings.DeleteMany(filter);
        }
    }
}
