using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ArtAuction.Models;
using ArtAuction.Models.Collections;

namespace ArtAuction.Controllers
{
    [Authorize]
    public class AuctionsController : Controller
    {
        private readonly IAuctionCollection _auctions;
        private readonly IUserCollection _users;
        private readonly IEditableCollection<Artist> _artists;
        private readonly IEditableCollection<Gallery> _galleries;
        private readonly IPaintingCollection _paintings;

        public AuctionsController(IAuctionCollection auctions, IUserCollection users, IEditableCollection<Artist> artists, IEditableCollection<Gallery> galleries, IPaintingCollection paintings)
        {
            _auctions = auctions;
            _users = users;
            _artists = artists;
            _galleries = galleries;
            _paintings = paintings;
        }

        public List<Auction> Auctions { get; set; }
        public List<Painting> Paintings { get; set; }
        public Auction Auction { get; set; }
        public Painting Painting { get; set; }
        public Artist Artist { get; set; }
        public Gallery Gallery { get; set; }

        public IActionResult Upcoming()
        {
            Auctions = _auctions.Auctions.FindAll(auc => 
                (auc.EndDateTime - DateTime.Now).TotalSeconds >= 0)
                .OrderBy(x => x.StartDateTime).ToList();
            return View(Auctions);
        }

        public IActionResult Past()
        {
            Auctions = _auctions.Auctions.FindAll(auc => 
                (auc.EndDateTime - DateTime.Now).TotalSeconds < 0)
                .OrderBy(x => x.StartDateTime).ToList();
            return View(Auctions);
        }

        public IActionResult AuctionView(string id)
        {
            Auction = _auctions.FindAuction(id);
            Auction.Paintings = _paintings.GetAuctionPaintings(Auction.Id);
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
            Paintings = _paintings.GetAuctionPaintings(id);

            foreach (var painting in Paintings)
            {
                if (!painting.IsBought)
                {
                    painting.CurrentlyLocated = "Not on sale";
                    painting.AuctionId = null;
                }
            }
            _auctions.RemoveAuction(id);
            return RedirectToAction("Upcoming");
        }
        
        public IActionResult SuccessfullyBought(string paintingID)
        {
            Painting = _paintings.FindObject(paintingID);
            return View(Painting);
        }

        [HttpPost]
        public IActionResult BuyPainting(string paintingId)
        {
            User user = _users.FindUser(User.Identity.Name);
            Painting = _paintings.FindObject(paintingId);

            Painting.IsBought = true;

            if (user.Role != "Representative")
            {
                Painting.OwnerId = user.Id;
                Painting.CurrentlyLocated = "Private Collection";
                Painting.OwnerName = user.FirstName + " " + user.LastName;
            }
            else
            {
                Gallery = _galleries.Objects.Find(gal => gal.Title == user.Gallery);
                Painting.OwnerId = Gallery.Id;
                Painting.CurrentlyLocated = "Art Gallery";
                Painting.OwnerName = Gallery.Title;
            }
  
            _paintings.UpdateObject(Painting);

            return RedirectToAction("SuccessfullyBought", "Auctions", new { @paintingID = paintingId});
        }
    }
}