using System.Collections.Generic;

namespace ArtAuction.Models.Collections
{
    public interface IPaintingCollection : IEditableCollection<Painting>
    {
        List<Painting> GetArtistPaintings(string artistId);
        List<Painting> GetAuctionPaintings(string auctionId);
        List<Painting> GetOwnerPaintings(string ownerId);
        void RemoveArtistPaintings(string artistId);
    }
}
