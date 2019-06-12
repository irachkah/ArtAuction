using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

using ArtAuction.ViewModels;

namespace ArtAuction.Models
{
    [BsonIgnoreExtraElements]
    public class Painting
    {
       [BsonId]
       [BsonRepresentation(BsonType.ObjectId)]
        // Painting Info
        public string Id { get; set; }
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Style { get; set; }
        public string CreationDate { get; set; }
        public string Estimated { get; set; }
        //Binding to Auction and Artist
        public string CurrentlyLocated { get; set; } //= "OnAuction";
        public string ArtistId { get; set; }
        public string AuctionId { get; set; }
        //Ownership
        public bool IsBought { get; set; } = false;
        public string OwnerId { get; set; }
        public string OwnerName { get; set; }
        //Image
        public string ImgId { get; set; }

        public Painting()
        {
                
        }
        public Painting(PaintingViewModel vm)
        {
            Title = vm.Title;
            Style = vm.Style;
            CreationDate = vm.CreationDate;
            CurrentlyLocated = vm.CurrentlyLocated;
           
            IsBought = vm.IsBought;
            Estimated = vm.Estimated;
            ArtistId = vm.ArtistId;
        }
    }
}
