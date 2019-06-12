using System.Collections.Generic;

namespace ArtAuction.Models.Collections
{
    public interface IAuctionCollection
    {
        List<Auction> Auctions { get; }
       //List<Auction> UpcomingAuctions { get; }
        //List<Auction> PastAuctions { get; }
        void AddAuction(Auction auction);
        void RemoveAuction(string id);
        void UpdateAuction(Auction auction);
        Auction FindAuction(string id);
        Auction FindAuctionByTitle(string title);
    }
}
