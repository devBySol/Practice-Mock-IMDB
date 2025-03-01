using Microsoft.AspNetCore.Mvc;
using Lab5.Models;
using System.Linq;

namespace Lab5.Controllers
{
    public class MovieController : Controller
    {
        private readonly IMovieRepository _movieRepository;

        public MovieController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        // All movie
        public IActionResult Movies()
        {
            var movies = _movieRepository.GetAllMovies();
            return View(movies);
        }

        // movie details
        public IActionResult MovieDetails(int id)
        {
            var movie = _movieRepository.GetById(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }
    }
}
