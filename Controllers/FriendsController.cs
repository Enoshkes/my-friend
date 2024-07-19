using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyFriend.Models;
using MyFriend.ModelView;
using MyFriend.Repository;
using MyFriend.Service;

namespace MyFriend.Controllers
{
    public class FriendsController(IFriendsService friendsService) : Controller
    {
        private readonly IFriendsService _friendsService = friendsService;

        public async Task<IActionResult> Index()
        {
            return View(await _friendsService.GetAll());
        }

        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FriendModelView modelView)
        {
            if (ModelState.IsValid) 
            { 
                if (modelView.Image != null && modelView.Image.Length > 0)
                {
                    using var ms = new MemoryStream();
                    modelView.Image.CopyTo(ms);
                    var image = new ImageModel()
                    {
                        Data = ms.ToArray(),

                    };
                    var model = new FriendModel()
                    {
                        FirstName = modelView.FirstName,
                        LastName = modelView.LastName,
                        Email = modelView.Email,
                        Images = [image]
                    };
                    await _friendsService.Add(model);
                    RedirectToAction("Index");
                }
            }

            return View();
        }
    }
}
