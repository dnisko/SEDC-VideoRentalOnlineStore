using DataAccess.Interfaces;
using DomainModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System.Security.Claims;
using ViewModels;

namespace VideoRentalOnlineStore.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieService _movieService;
        private readonly IRentalService _rentalService;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserRepository _userRepository;

        public MovieController(IMovieService movieService,
            IRentalService rentalService,
            UserManager<ApplicationUser> userManager,
            IUserRepository userRepository
            )
        {
            _movieService = movieService;
            _rentalService = rentalService;
            _userManager = userManager;
            _userRepository = userRepository;
        }
        public IActionResult Index()
        {
            var movies = _movieService.GetMovies();
            return View(movies);
        }
        public IActionResult Details(int id)
        {
            var item = _movieService.GetDetails(id);
            return View(item);
        }

        [HttpPost]
        public IActionResult SearchByName([FromForm] FilterViewModel filterModel)
        {
            var items = _movieService.SearchByTitle(filterModel.Name);
            return View("Index", items);
        }

        [Authorize]
        [HttpPost]
        public IActionResult RentMovie(int movieId)
        {
            var userIdCookie = Request.Cookies["UserId"];
            if (userIdCookie == null || !int.TryParse(userIdCookie, out int userId))
            {
                return BadRequest();
            }

            try
            {
                _rentalService.RentMovie(userId, movieId);
                return RedirectToAction("MyRentals", "User");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize]
        [HttpPost]
        public IActionResult ReturnMovie(int rentalId)
        {
            try
            {
                _rentalService.ReturnMovie(rentalId);
                return RedirectToAction("MyRentals", "User");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        public IActionResult AddMovie()
        {
            var model = new MovieViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddMovie(MovieViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _movieService.Save(model);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            return View(model);
        }

    }
}
