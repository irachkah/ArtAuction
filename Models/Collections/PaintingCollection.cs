using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Driver;

namespace ArtAuction.Models.Collections
{
    public class PaintingCollection : IPaintingCollection
    {
        private readonly IMongoCollection<Painting> _paintings;

        public PaintingCollection(string conStr)
        {
            var client = new MongoClient(conStr);
            var database = client.GetDatabase("ArtDB");
            _paintings = database.GetCollection<Painting>("Paintings");
        }
        public List<Painting> Objects { get; }
        public void AddObject(Painting obj)
        {
            throw new NotImplementedException();
        }

        public void RemoveObject(string id)
        {
            throw new NotImplementedException();
        }

        public void UpdateObject(Painting obj)
        {
            throw new NotImplementedException();
        }

        public Painting FindObject(string id)
        {
            throw new NotImplementedException();
        }

        public List<Painting> GetArtistPaintings(string artistId)
        {
            throw new NotImplementedException();
        }

        public List<Painting> GetAuctionPaintings(string auctionId)
        {
            throw new NotImplementedException();
        }

        public List<Painting> GetOwnerPaintings(string ownerId)
        {
            throw new NotImplementedException();
        }
    }
}
