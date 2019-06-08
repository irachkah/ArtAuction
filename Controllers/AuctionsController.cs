using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ArtAuction.Models;
using ArtAuction.Models.Collections;
using ArtAuction.Models.FileManager;
using ArtAuction.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace ArtAuction.Controllers
{
    public class AuctionsController : Controller
    {
        private readonly IAuctionCollection _auctions;
        private IFileManager _fileManager;
        private readonly IUserCollection _users;
        private readonly IEditableCollection<Artist> _artists;
        private readonly IEditableCollection<Gallery> _galleries;

        public List<Auction> Auctions { get; set; }
        public Auction Auction { get; set; }
        public Painting Painting { get; set; }
        public Artist Artist { get; set; }
        public Gallery Gallery { get; set; }

        public AuctionsController(IAuctionCollection auctions, IFileManager fileManager, IUserCollection users, IEditableCollection<Artist> artists, IEditableCollection<Gallery> galleries)
        {
            _auctions = auctions;
            _fileManager = fileManager;
            _users = users;
            _artists = artists;
            _galleries = galleries;
        }
        public IActionResult Upcoming()
        {
            Auctions = _auctions.Auctions.FindAll(auc => (auc.EndDateTime - DateTime.Now).TotalSeconds >= 0).OrderBy(x => x.StartDateTime).ToList();
            return View(Auctions);
        }
        public IActionResult Past()
        {
            Auctions = _auctions.Auctions.FindAll(auc => (auc.EndDateTime - DateTime.Now).TotalSeconds < 0); ;
            return View(Auctions);
        }

        public IActionResult AuctionView(string id)
        {
            Auction = _auctions.FindAuction(id);
            return View(Auction);
        }
        [HttpGet]
        public IActionResult AddAuction()
        {
            return View(Auction);
        }

        [HttpPost]
        public IActionResult AddAuction(Auction auction)
        {
            if (ModelState.IsValid)
            {
                _auctions.AddAuction(auction);
                return RedirectToAction("Index", "Home"); 
            }
            return View(auction);
        }
        [HttpGet]
        public IActionResult EditAuction(string id)
        {
            Auction = _auctions.FindAuction(id);
            return View(Auction);
        }

        [HttpPost]
        public IActionResult EditAuction(Auction auction)
        {
            _auctions.UpdateAuction(auction);
            return RedirectToAction("Upcoming", "Auctions");
        }
        [HttpPost]
        public IActionResult DeleteAuction(string id)
        {
            Auction = _auctions.FindAuction(id);
            foreach (var painting in Auction.Paintings)
            {
                painting.CurrentlyLocated = "Not on sale";
                painting.AuctionId = null;
                Artist = _artists.FindObject(painting.ArtistId);
                Artist.UpdatePainting(painting);

                _artists.UpdateObject(Artist);
            }
            _auctions.RemoveAuction(id);
            return RedirectToAction("Upcoming");
        }
        
        public IActionResult SuccessfullyBought(string paintingID, string auctionID)
        {
            Auction = _auctions.FindAuction(auctionID);
            Painting = Auction.Paintings.Find(p => p.Id == paintingID);
            return View(Painting);
        }

        [HttpPost]
        public IActionResult BuyPainting(string paintingId, string auctionId)
        {
            User user = _users.FindUser(User.Identity.Name);
            if (user.Paintings == null)
            {
                user.Paintings = new List<Painting>();
            }

            Auction = _auctions.FindAuction(auctionId);
            Painting = Auction.Paintings.Find(p => p.Id == paintingId);
            Artist = _artists.FindObject(Painting.ArtistId);
            Painting.IsBought = true;

            if (user.Role != "Representative")
            {
                Painting.OwnerId = user.Id;
                Painting.CurrentlyLocated = "PrivateCollection";
                Painting.OwnerName = user.FirstName + " " + user.LastName;
                user.Paintings.Add(Painting);
                _users.UpdateUser(user);
            }
            else
            {
                Gallery = _galleries.Objects.Find(gal => gal.Title == user.Gallery);
                Painting.OwnerId = Gallery.Id;
                Painting.CurrentlyLocated = "Art gallery";
                Painting.OwnerName = Gallery.Title;
                Gallery.Paintings.Add(Painting);
                _galleries.UpdateObject(Gallery);
            }
            
            Artist.UpdatePainting(Painting);
            _artists.UpdateObject(Artist);
            _auctions.UpdateAuction(Auction);
            
            
            return RedirectToAction("SuccessfullyBought", "Auctions", new { @paintingID = paintingId, @auctionID = auctionId});
        }
    }
}