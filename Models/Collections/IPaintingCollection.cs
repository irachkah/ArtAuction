using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ArtAuction.Models.Collections
{
    public interface IPaintingCollection : IEditableCollection<Painting>
    {
        List<Painting> GetArtistPaintings(string artistId);
        List<Painting> GetAuctionPaintings(string auctionId);
        List<Painting> GetOwnerPaintings(string ownerId);
    }
}
