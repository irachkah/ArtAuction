using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ArtAuction.Models;
using ArtAuction.Models.Collections;

namespace ArtAuction.Controllers
{
    [Authorize]
    public class GalleriesController : Controller
    {
        private readonly IEditableCollection<Gallery> _galleries;
        private readonly IUserCollection _users;
        private readonly IPaintingCollection _paintings;

        public GalleriesController(IEditableCollection<Gallery> artists, IUserCollection users, IPaintingCollection paintings)
        {
            _galleries = artists;
            _users = users;
            _paintings = paintings;
        }

        public List<Gallery> Galleries { get; set; }
        public List<Painting> Paintings { get; set; }
        public List<User> Users { get; set; }
        public Gallery Gallery { get; set; }

        public IActionResult Index()
        {
            Galleries = _galleries.Objects;
            return View(Galleries);
        }
        
        public IActionResult GalleryView(string id)
        {
            Gallery = _galleries.FindObject(id);
            Gallery.Paintings = _paintings.GetOwnerPaintings(id);
            Gallery.Representatives = _users.Users.FindAll(us => us.GalleryId == Gallery.Id);
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
            Users = _users.Users.FindAll(us => us.GalleryId == id);
            foreach (var user in Users)
            {
                user.Role = "User";
                user.GalleryId = "";
                user.Gallery = "";

                _users.UpdateUser(user);
            }

            Paintings = _paintings.GetOwnerPaintings(id);
            foreach (var painting in Paintings)
            {
                painting.OwnerId = null;
            }
            
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