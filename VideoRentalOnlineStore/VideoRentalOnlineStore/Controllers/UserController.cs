using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.Implementation;
using ViewModels;

namespace VideoRentalOnlineStore.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            var items = _userService.GetAll();
            return View(items);
        }

        public IActionResult Details(int id)
        {
            var item = _userService.GetDetails(id);
            return View(item);
        }

        [HttpPost]
        public IActionResult SearchByName([FromForm] FilterViewModel filterModel)
        {
            var items = _userService.SearchByName(filterModel.Name);
            return View("Index", items);
        }
        public IActionResult Edit(int id)
        {
            var user = _userService.GetDetails(id);
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit([FromForm] UserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _userService.SaveAsync(model);


            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _userService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}
