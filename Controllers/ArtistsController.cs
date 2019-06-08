using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtAuction.Models;
using ArtAuction.Models.Collections;
using ArtAuction.Models.FileManager;
using ArtAuction.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ArtAuction.Controllers
{
    public class ArtistsController : Controller
    {
        private readonly IEditableCollection<Artist> _artists;
        private IFileManager _fileManager;
        private readonly IAuctionCollection _auctions;

        // ??
        public Auction Auction { get; set; }
        public Painting Painting { get; set; }


        public List<Artist> Artists { get; set; }
        public List<Auction> Auctions { get; set; }
        public Artist Artist { get; set; }

        public ArtistsController(IEditableCollection<Artist> artists, IFileManager fileManager, IAuctionCollection auctions)
        {
            _artists = artists;
            _auctions = auctions;
            _fileManager = fileManager;
        }
        public IActionResult Index()
        {
            Artists = _artists.Objects;
            return View(Artists);
        }
        public IActionResult ArtistView(string id)
        {
            Artist = _artists.FindObject(id);
            
            Artist.Paintings.OrderBy(p => p.Title);
            
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
            _artists.RemoveObject(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditArtist(string id)
        {
            Artist = _artists.FindObject(id);
            ViewData["Paintings"] = Artist.Paintings;
            return View(Artist);
        }

        [HttpPost]
        public IActionResult EditArtist(Artist artist)
        {
            _artists.UpdateObject(artist);
            return RedirectToAction("Index");
        }

        // adding painting
        public IActionResult AddPainting(string id)
        {
            Auctions = _auctions.Auctions.FindAll(auc => (auc.EndDateTime - DateTime.Now).TotalSeconds >= 0).OrderBy(x => x.StartDateTime).ToList();
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
                else
                {
                    Auction = null;
                }
                Artist = _artists.FindObject(Painting.ArtistId);
                Painting.Artist = Artist.Name;

                Painting.ImgId = await _fileManager.SaveImage(paintingVM.Image);

                Painting.Id = $"{Artist.Name}{DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss")}";
                Artist.Paintings.Add(Painting);
                if (Auction != null)
                {
                    Auction.Paintings.Add(Painting);
                    _auctions.UpdateAuction(Auction);
                }
              
                _artists.UpdateObject(Artist);
    
                return RedirectToAction("ArtistView", "Artists", new { @id = Painting.ArtistId });
            }
            Auctions = _auctions.Auctions.FindAll(auc => (auc.EndDateTime - DateTime.Now).TotalSeconds >= 0).OrderBy(x => x.StartDateTime).ToList();
            ViewData["Auctions"] = Auctions;
            ViewBag.ArtistId = paintingVM.ArtistId;
            return View(paintingVM);
        }
        public IActionResult PaintingView(string artistId, string paintingId)
        {
            Artist = _artists.FindObject(artistId);
            Painting = Artist.Paintings.Find(p => p.Id == paintingId);
            return View(Painting);
        }

        public IActionResult EditPainting(string paintingId, string artistId)
        {
            Auctions = _auctions.Auctions.FindAll(auc => (auc.EndDateTime - DateTime.Now).TotalSeconds >= 0).OrderBy(x => x.StartDateTime).ToList();
            ViewData["Auctions"] = Auctions;

            Artist = _artists.FindObject(artistId);
            Painting = Artist.Paintings.Find(p => p.Id == paintingId);
            return View(Painting);
        }

        [HttpPost]
        public IActionResult EditPainting(Painting painting)
        {
            Artist = _artists.FindObject(painting.ArtistId);
            Artist.UpdatePainting(painting);

            _artists.UpdateObject(Artist);

            if (Painting.AuctionId != null)
            {
                Auction = _auctions.FindAuction(Painting.AuctionId);
                Auction.UpdatePainting(painting);

                _auctions.UpdateAuction(Auction);
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeletePainting(string artistId, string paintingId)
        {
            Artist = _artists.FindObject(artistId);
            Painting = Artist.Paintings.Find(p => p.Id == paintingId);  

            if (Painting.AuctionId != null)
            {
                Auction = _auctions.FindAuction(Painting.AuctionId);
                Auction.Paintings.RemoveAll(p => p.Id == paintingId);
                _auctions.UpdateAuction(Auction);
            }
            Artist.Paintings.RemoveAll(p => p.Id == paintingId);
            _artists.UpdateObject(Artist);

            return RedirectToAction("Index", "Home");
        }
    }
}