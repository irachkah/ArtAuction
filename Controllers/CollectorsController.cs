using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ArtAuction.Models;
using ArtAuction.Models.Collections;

namespace ArtAuction.Controllers
{
    [Authorize]
    public class CollectorsController : Controller
    {
        private readonly IUserCollection _users;
        private readonly IEditableCollection<Gallery> _galleries;
        private readonly IPaintingCollection _paintings;

        public CollectorsController(IUserCollection users, IEditableCollection<Gallery> galleries, IPaintingCollection paintings)
        {
            _users = users;
            _galleries = galleries;
            _paintings = paintings;
        }

        [HttpGet]
        public IActionResult Index()
        {
            foreach (var user in _users.Users)
            {
                if (user.IsRepresentative)
                {
                    user.Gallery = _galleries.FindObject(user.GalleryId).Title;
                    _users.UpdateUser(user);
                }
            }
            return View(_users.Users);
        }

        [HttpGet]
        public IActionResult CollectorView(string id)
        { 
            User user = _users.Users.Find(us => us.Id == id);

            if (user.IsRepresentative)
            {
                user.Gallery = _galleries.FindObject(user.GalleryId).Title;

            }
            else
            {
                user.Paintings = _paintings.GetOwnerPaintings(user.Id);
            }

            return View(user);
        }

        [HttpPost]
        public IActionResult DeleteCollector(string id)
        {
            _users.RemoveUser(id);

            return RedirectToAction("Index");
        }
    }
}