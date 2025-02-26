using Lab5.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab5.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieRepository _movieRepository;

        public HomeController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }
        public IActionResult Index()
        {
            var movies = _movieRepository.GetAllMovies();
            return View("Index", movies);
        }
    }
}
