using Microsoft.AspNetCore.Mvc;
using Services.Implementation;
using Services.Interfaces;
using ViewModels;

namespace VideoRentalOnlineStore.Controllers
{
    public class MovieController : Controller
    {
        private IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
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
        public IActionResult Rent()
        {
            var movies = _movieService.GetMovies();
            return View(movies);
        }
        public IActionResult Return()
        {
            var movies = _movieService.GetMovies();
            return View(movies);
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
                    _movieService.Save(model); // Call Save method
                    return RedirectToAction("Index"); // Redirect after successful save
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message); // Add model error if movie already exists
                }
            }
            return View(model);
        }
    }
}
