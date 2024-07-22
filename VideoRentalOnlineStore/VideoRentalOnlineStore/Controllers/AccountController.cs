using DomainModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using ViewModels;

namespace VideoRentalOnlineStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IUserService _userService;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            IUserService userService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FullName = model.FullName,
                    Age = model.Age,
                    CardNumber = model.CardNumber,
                    CreatedOn = DateTime.Now,
                    IsSubscriptionExpired = false,
                    SubscriptionType = model.SubscriptionType
                };

                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    var appUser = new UserViewModel
                    {
                        FullName = user.FullName,
                        Age = user.Age,
                        UserName = user.UserName,
                        Email = user.Email,
                        CardNumber = user.CardNumber,
                        CreatedOn = user.CreatedOn,
                        IsSubscriptionExpired = user.IsSubscriptionExpired,
                        SubscriptionType = user.SubscriptionType
                    };

                    await _userService.SaveAsync(appUser);

                    return RedirectToAction("Index", "Home");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }
    }
}
