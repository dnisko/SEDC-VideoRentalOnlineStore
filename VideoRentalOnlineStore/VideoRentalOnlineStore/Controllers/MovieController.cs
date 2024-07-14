using Microsoft.AspNetCore.Mvc;
using Services.Implementation;
using Services.Interfaces;
using ViewModels;

namespace VideoRentalOnlineStore.Controllers
{
    public class MovieController : Controller
    {
        private IMovieService _movieService;

        public MovieController()
        {
            _movieService = new MovieService();
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
    }
}
