using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtAuction.Models;
using ArtAuction.Models.Collections;
using Microsoft.AspNetCore.Mvc;

namespace ArtAuction.Controllers
{
    public class GalleriesController : Controller
    {
        private readonly IEditableCollection<Gallery> _galleries;
        public List<Gallery> Galleries { get; set; }
        public Gallery Gallery { get; set; }

        public GalleriesController(IEditableCollection<Gallery> artists)
        {
            _galleries = artists;
        }
        public IActionResult Index()
        {
            Galleries = _galleries.Objects;
            return View(Galleries);
        }

        public void Test()
        {
            foreach (var gal in _galleries.Objects)
            {
                gal.Representatives = new List<User>();
                _galleries.UpdateObject(gal);
            }
        }
        public IActionResult GalleryView(string id)
        {
            Gallery = _galleries.FindObject(id);
            return View(Gallery);
        }

        [HttpGet]
        public IActionResult AddGallery()
        {
            return View(new Gallery());
        }
        [HttpPost]
        public IActionResult AddGallery(Gallery gallery)
        {
            if (ModelState.IsValid)
            {
                _galleries.AddObject(gallery);

                return RedirectToAction("Index");
            }
            return View(gallery);
        }

        [HttpPost]
        public IActionResult DeleteGallery(string id)
        {
            _galleries.RemoveObject(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditGallery(string id)
        {
            Gallery = _galleries.FindObject(id);
            return View(Gallery);
        }

        [HttpPost]
        public IActionResult EditGallery(Gallery gallery)
        {
            _galleries.UpdateObject(gallery);
            return RedirectToAction("Index");
        }
    }
}