using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArtAuction.Models;
using ArtAuction.Models.Collections;
using Microsoft.AspNetCore.Mvc;

namespace ArtAuction.Controllers
{
    public class MyCollectionController : Controller
    {
        private readonly IUserCollection _users;
        public MyCollectionController(IUserCollection users)
        {
            _users = users;
        }
        public IActionResult Index()
        {
            User user = _users.FindUser(User.Identity.Name);
            return View(user);
        }
    }
}