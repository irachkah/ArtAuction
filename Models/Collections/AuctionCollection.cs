using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace ArtAuction.Models.Collections
{
    public class AuctionCollection : IAuctionCollection
    {
        private readonly IMongoCollection<Auction> _auctions;

        public AuctionCollection(string conStr)
        {
            var client = new MongoClient(conStr);
            var database = client.GetDatabase("ArtDB");
            _auctions = database.GetCollection<Auction>("Auctions");
        }

        public List<Auction> Auctions
        {
            get { return _auctions.Find(_ => true).ToList(); }
        }
        public List<Auction> UpcomingAuctions {
            get
            {
                var now = DateTime.Now;
                return _auctions.Find(auc => (now - auc.EndDateTime).TotalSeconds >= 0).ToList();
            }
         }

        public List<Auction> PastAuctions
        {
            get
            {
                var now = DateTime.Now;
                return _auctions.Find(auc => DateTime.Compare(DateTime.Now, auc.EndDateTime) < 0).ToList();
            }
        }

        public void AddAuction(Auction auction)
        {
            _auctions.InsertOne(auction);
        }

        public void RemoveAuction(string id)
        {
            _auctions.DeleteOne(user => user.Id == id);
        }

        public void UpdateAuction(Auction auction)
        {
            var filter = new BsonDocument("_id", new ObjectId(auction.Id));
            var res = _auctions.ReplaceOne(filter, auction);
        }
        public Auction FindAuction(string id)
        {
            var auctionFound = _auctions.Find(auc => auc.Id == id).ToList();
            return auctionFound[0];
        }
        public Auction FindAuctionByTitle(string title)
        {
            var auctionFound = _auctions.Find(auc => auc.Title == title).ToList();
            return auctionFound[0];
        }
    }
}
