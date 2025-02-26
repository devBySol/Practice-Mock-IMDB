using Lab5.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq; 
namespace Lab5.Controllers
{
    public class RateController : Controller
    {
        private readonly IMovieRepository _movieRepository;

        public RateController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public IActionResult Index()
        {
         
            var movies = _movieRepository.GetAllMovies()
                                         .OrderByDescending(m => m.Rating)
                                         .ToList();
            return View("Index", movies);
        }
    }
}
