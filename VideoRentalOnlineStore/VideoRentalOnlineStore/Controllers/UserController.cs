using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.Implementation;
using ViewModels;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace VideoRentalOnlineStore.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        private readonly IRentalService _rentalService;

        public UserController(IUserService userService, IRentalService rentalService)
        {
            _userService = userService;
            _rentalService = rentalService;
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

        [Authorize]
        public IActionResult MyRentals()
        {
            var userIdCookie = Request.Cookies["UserId"];
            if (userIdCookie == null || !int.TryParse(userIdCookie, out int userId))
            {
                return BadRequest();
            }

            try
            {
                var rentals = _userService.GetCurrentRentals(userId);
                return View(rentals);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize]
        public IActionResult RentalHistory()
        {
            var userIdCookie = Request.Cookies["UserId"];
            if (userIdCookie == null || !int.TryParse(userIdCookie, out int userId))
            {
                return BadRequest();
            }

            try
            {
                var rentals = _userService.GetRentalHistory(userId);
                return View(rentals);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult ReturnMovie(int rentalId)
        {
            _rentalService.ReturnMovie(rentalId);
            return RedirectToAction(nameof(MyRentals));
        }

    }
}
