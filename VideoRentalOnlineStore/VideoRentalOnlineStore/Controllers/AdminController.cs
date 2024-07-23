using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ViewModels;

namespace VideoRentalOnlineStore.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddMovie(MovieViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Movie");
            }
            return View(model);
        }
    }
}
