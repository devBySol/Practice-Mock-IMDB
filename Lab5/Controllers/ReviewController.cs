using Microsoft.AspNetCore.Mvc;
using Lab5.Models;

namespace Lab5.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IMovieRepository _movieRepository;

        public ReviewController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public IActionResult AllReviews()
        {
            var allReviews = _movieRepository.GetAllReviews();
            return View(allReviews);
        }
    }
}
