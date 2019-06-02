using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtAuction.Models;
using ArtAuction.Models.Collections;
using Microsoft.AspNetCore.Mvc;

namespace ArtAuction.Controllers
{
    public class ArtistsController : Controller
    {
        private readonly IEditableCollection<Artist> _artists;
        public List<Artist> Artists { get; set; }
        public Artist Artist { get; set; }

        public ArtistsController(IEditableCollection<Artist> artists)
        {
            _artists = artists;
        }
        public IActionResult Index()
        {
            Artists = _artists.Objects;
            return View(Artists);
        }
        public IActionResult ArtistView(string id)
        {
            Artist = _artists.FindObject(id);
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
            return View(Artist);
        }

        [HttpPost]
        public IActionResult EditArtist(Artist artist)
        {
            _artists.UpdateObject(artist);
            return RedirectToAction("Index");
        }
    }
}