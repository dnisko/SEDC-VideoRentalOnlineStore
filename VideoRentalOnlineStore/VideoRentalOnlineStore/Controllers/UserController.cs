using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using Services.Implementation;

namespace VideoRentalOnlineStore.Controllers
{
    public class UserController : Controller
    {
        private IUserService _userService;

        public UserController()
        {
            _userService = new UserService();
        }
        public IActionResult Index()
        {
            var items = _userService.GetAll();
            return View(items);
        }
    }
}
