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

        public List<Auction> Auctions { get; set; }
        public Auction Auction { get; set; }
        public Painting Painting { get; set; }

        public AuctionsController(IAuctionCollection auctions, IFileManager fileManager, IUserCollection users, IEditableCollection<Artist> artists)
        {
            _auctions = auctions;
            _fileManager = fileManager;
            _users = users;
            _artists = artists;
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
            _auctions.RemoveAuction(id);
            return RedirectToAction("Upcoming");
        }
        
        public IActionResult AddPainting(string id)
        {
            PaintingViewModel paintingVM = new PaintingViewModel();
            ViewBag.OwnerId = id;
            return View(paintingVM);
        }

        public void Test()
        {
            User user = _users.FindUser(User.Identity.Name);
            if (user.Paintings == null)
            {
                user.Paintings = new List<Painting>();
            }

           // user.Paintings = null;
            _users.UpdateUser(user);
        }
        [HttpPost]
        public async Task<IActionResult> AddPainting(PaintingViewModel paintingVM)
        {
            if (ModelState.IsValid)
            {
                Painting = new Painting(paintingVM);

                Painting.ImgId = await _fileManager.SaveImage(paintingVM.Image);
                Auction = _auctions.FindAuction(Painting.OwnerId);
                if (Auction.Paintings == null)
                {
                    Painting.Id = $"{0}";
                    Auction.Paintings = new List<Painting>();
                }

                Painting.Id = $"{Auction.Paintings.Count}";
                Auction.Paintings.Add(Painting);
                _auctions.UpdateAuction(Auction);
                return RedirectToAction("AuctionView", "Auctions", new{@id=Painting.OwnerId});
            }
            return View(paintingVM);
        }
        [HttpPost]
        public IActionResult DeletePainting(string auctionId, string paintingId)
        {
            Auction = _auctions.FindAuction(auctionId);
            Painting = Auction.Paintings.Find(p => p.Id == paintingId);
            Auction.Paintings.Remove(Painting);
            _auctions.UpdateAuction(Auction);

            return RedirectToAction("AuctionView", "Auctions", new { @id = auctionId });
        }

        public IActionResult PaintingView(string auctionId, string paintingId)
        {
            Auction = _auctions.FindAuction(auctionId);
            Painting = Auction.Paintings.Find(p => p.Id == paintingId);
            return View(Painting);
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
            Painting.IsBought = true;
            Painting.OwnerId = user.Id;
            Painting.CurrentlyLocated = "PrivateCollection";
            Painting.OwnerName = user.FirstName + " " + user.LastName;
            user.Paintings.Add(Painting);

            _auctions.UpdateAuction(Auction);
            _users.UpdateUser(user);
            
            return RedirectToAction("SuccessfullyBought", "Auctions", new { @paintingID = paintingId, @auctionID = auctionId});
        }

        /*public IActionResult Artist(string name)
        {
            Models.Artist artist = _artists.Objects.Find(x => x.Name == name);
            if (artist != null)
            {
                RedirectToAction("ArtistView", "Artists", new {@id = artist.Id});
            }
            
        }*/
    }

}