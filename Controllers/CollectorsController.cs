using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtAuction.Models;
using ArtAuction.Models.Collections;
using Microsoft.AspNetCore.Mvc;

namespace ArtAuction.Controllers
{
    public class CollectorsController : Controller
    {
        private readonly IUserCollection _users;
        private readonly IEditableCollection<Gallery> _galleries;

        public CollectorsController(IUserCollection users, IEditableCollection<Gallery> galleries)
        {
            _users = users;
            _galleries = galleries;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View(_users.Users);
        }

        [HttpGet]
        public IActionResult CollectorView(string id)
        { 
            User user = _users.Users.Find(us => us.Id == id);
            return View(user);
        }

        [HttpPost]
        public IActionResult DeleteCollector(string id)
        {
            User user = _users.FindUser(id);
            if (user.IsRepresentative)
            {
                Gallery gallery = _galleries.FindObject(user.GalleryId);
                gallery.Representatives.Remove(user);
                _galleries.UpdateObject(gallery);
            }
           _users.RemoveUser(id);
            return RedirectToAction("Index");
        }
    }
}