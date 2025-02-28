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
        public IActionResult Details(int id)
        {
            var movie = _movieRepository.GetById(id);
            if (movie == null)
            {
                return NotFound();
            }
            return View(movie);
        }

        //    // add new movie page
        //    public IActionResult Create()
        //    {
        //        return View();
        //    }


        //    [HttpPost]
        //    public IActionResult Create(Movie movie)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            _movieRepository.AddMovie(movie);
        //            return RedirectToAction("Index");
        //        }
        //        return View(movie);
        //    }

        //    // edit movie
        //    public IActionResult Edit(int id)
        //    {
        //        var movie = _movieRepository.GetById(id);
        //        if (movie == null)
        //        {
        //            return NotFound();
        //        }
        //        return View(movie);
        //    }

        //    // update movie
        //    [HttpPost]
        //    public IActionResult Edit(Movie movie)
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            _movieRepository.UpdateMovie(movie);
        //            return RedirectToAction("Index");
        //        }
        //        return View(movie);
        //    }

        //    // delete movie
        //    public IActionResult Delete(int id)
        //    {
        //        var movie = _movieRepository.GetById(id);
        //        if (movie == null)
        //        {
        //            return NotFound();
        //        }
        //        return View(movie);
        //    }


        //    [HttpPost, ActionName("Delete")]
        //    public IActionResult DeleteConfirmed(int id)
        //    {
        //        _movieRepository.DeleteMovie(id);
        //        return RedirectToAction("Index");
        //    }
    }
}
