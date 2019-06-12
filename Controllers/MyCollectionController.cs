using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ArtAuction.Models;
using ArtAuction.Models.Collections;

namespace ArtAuction.Controllers
{
    [Authorize]
    public class MyCollectionController : Controller
    {
        private readonly IUserCollection _users;
        private readonly IPaintingCollection _paintings;

        public MyCollectionController(IUserCollection users, IPaintingCollection paintings)
        {
            _users = users;
            _paintings = paintings;
        }

        public IActionResult Index()
        {
            User user = _users.FindUser(User.Identity.Name);
            user.Paintings = _paintings.GetOwnerPaintings(user.Id);
            return View(user);
        }
    }
}