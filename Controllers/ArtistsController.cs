using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ArtAuction.Models;
using ArtAuction.Models.Collections;
using ArtAuction.Models.FileManager;
using ArtAuction.ViewModels;


namespace ArtAuction.Controllers
{
    [Authorize]
    public class ArtistsController : Controller
    {
        private readonly IEditableCollection<Artist> _artists;
        private readonly IFileManager _fileManager;
        private readonly IAuctionCollection _auctions;
        private readonly IPaintingCollection _paintings;
        private readonly IUserCollection _users;

        public ArtistsController(IEditableCollection<Artist> artists, 
            IFileManager fileManager,
            IAuctionCollection auctions, 
            IPaintingCollection paintings,
            IUserCollection users)
        {
            _artists = artists;
            _auctions = auctions;
            _fileManager = fileManager;
            _paintings = paintings;
            _users = users;
        }

        public Auction Auction { get; set; }
        public Painting Painting { get; set; }
        public List<Artist> Artists { get; set; }
        public List<Auction> Auctions { get; set; }
        public List<Painting> Paintings { get; set; }
        public Artist Artist { get; set; }

        public IActionResult Index()
        {
            Artists = _artists.Objects;
            return View(Artists);
        }

        public IActionResult NoArtistFound()
        {
            return View();
        }

        public IActionResult ArtistView(string id)
        {
            if (id == null)
            {
               return RedirectToAction("NoArtistFound");
            }
            Artist = _artists.FindObject(id);
            Artist.Paintings = _paintings.GetArtistPaintings(Artist.Id);
            
            return View(Artist);
        }
        
        [HttpGet]
        public IActionResult AddArtist()
        {
            return View(new Artist());
        }

        [HttpPost]
        public IActionResult AddArtist(Artist artist)
        {
            if (ModelState.IsValid)
            {
                _artists.AddObject(artist);
       
                return RedirectToAction("Index");
            }
            return View(artist);
        }
      
        [HttpPost]
        public IActionResult DeleteArtist(string id)
        {
            Paintings = _paintings.GetArtistPaintings(id);
            foreach (var painting in Paintings)
            {
                if (!painting.IsBought)
                {
                    _paintings.RemoveObject(painting.Id);
                }
                else
                {
                    painting.ArtistId = null;
                    _paintings.UpdateObject(painting);
                }
            }
            _artists.RemoveObject(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditArtist(string id)
        {
            Artist = _artists.FindObject(id);
            return View(Artist);
        }

        [HttpPost]
        public IActionResult EditArtist(Artist artist)
        {
            _artists.UpdateObject(artist);
            return RedirectToAction("Index");
        }

        public IActionResult AddPainting(string id)
        {
            Auctions = _auctions.Auctions.FindAll(auc => (auc.EndDateTime - DateTime.Now).TotalSeconds >= 0)
                .OrderBy(x => x.StartDateTime).ToList();
            ViewData["Auctions"] = Auctions;
            PaintingViewModel paintingVM = new PaintingViewModel();
            ViewBag.ArtistId = id;
           
            return View(paintingVM);
        }

        [HttpPost]
        public async Task<IActionResult> AddPainting(PaintingViewModel paintingVM)
        {
            if (ModelState.IsValid)
            {
                
                Painting = new Painting(paintingVM);
                if (Painting.CurrentlyLocated != "Not on sale")
                {
                    Auction = _auctions.FindAuctionByTitle(Painting.CurrentlyLocated);
                    Painting.AuctionId = Auction.Id;
                }

                Artist = _artists.FindObject(Painting.ArtistId);
                Painting.Artist = Artist.FirstName + " " + Artist.LastName;

                Painting.ImgId = await _fileManager.SaveImage(paintingVM.Image);

                _paintings.AddObject(Painting);
                return RedirectToAction("ArtistView", "Artists", new { @id = Painting.ArtistId });
            }

            Auctions = _auctions.Auctions.FindAll(auc => (auc.EndDateTime - DateTime.Now).TotalSeconds >= 0)
                .OrderBy(x => x.StartDateTime).ToList();
            ViewData["Auctions"] = Auctions;
            ViewBag.ArtistId = paintingVM.ArtistId;
            return View(paintingVM);
        }

        public IActionResult PaintingView(string paintingId)
        {
            Painting = _paintings.FindObject(paintingId);
            ViewData["UserId"] =  _users.FindUser(User.Identity.Name).Id;
            return View(Painting);
        }

        public IActionResult EditPainting(string paintingId)
        {
            Auctions = _auctions.Auctions.FindAll(auc => (auc.EndDateTime - DateTime.Now).TotalSeconds >= 0)
                .OrderBy(x => x.StartDateTime).ToList();
            ViewData["Auctions"] = Auctions;
            Painting = _paintings.FindObject(paintingId);

            return View(Painting);
        }

        [HttpPost]
        public IActionResult EditPainting(Painting painting)
        {
            if (painting.CurrentlyLocated == "Not on sale")
            {
                painting.AuctionId = null;
            }
            else
            {
                painting.AuctionId = _auctions.FindAuctionByTitle(painting.CurrentlyLocated).Id;
            }
            _paintings.UpdateObject(painting);

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeletePainting(string paintingId)
        {
            _paintings.RemoveObject(paintingId);

            return RedirectToAction("Index", "Artists");
        }
    }
}