using Lab5.Models;
using Lab5.Services; 
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;

namespace Lab5.Controllers
{
    public class MovieController : Controller
    {
        private readonly MovieService _movieService;

        public MovieController(MovieService movieService)
        {
            _movieService = movieService;
        }

    
        public async Task<IActionResult> Movies()
        {
            var movies = await _movieService.GetMoviesAsync();
            return View(movies);
        }

      
        public async Task<IActionResult> MovieDetails(string id)
        {
            if (string.IsNullOrEmpty(id))
                return NotFound();

            var movies = await _movieService.GetMoviesAsync();
            var movie = movies.FirstOrDefault(m => m.imdbID == id);

            if (movie == null)
            {
                return NotFound();
            }

            return View(movie);
        }

        // Top Rated
        public async Task<IActionResult> TopRated()
        {
            var movies = await _movieService.GetMoviesAsync();
            var topRatedMovies = movies
                .Where(m => float.TryParse(m.imdbRating, out float rating) && rating >= 8.0)
                .OrderByDescending(m => float.Parse(m.imdbRating))
                .Take(20)
                .ToList();

            return View("TopRated", topRatedMovies);  
        }

        // Trending
        public async Task<IActionResult> Trending()
        {
            var movies = await _movieService.GetMoviesAsync();
            var trendingMovies = movies
                .OrderByDescending(m => m.imdbVotes)
                .Take(20)
                .ToList();

            return View("Treding", trendingMovies);  
        }

    }
}
