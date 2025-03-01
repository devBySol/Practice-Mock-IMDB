using Microsoft.AspNetCore.Mvc;
using Lab5.Models;

namespace Lab5.Controllers
{
    public class PostController : Controller
    {
        private readonly IMovieRepository _movieRepository;

        public PostController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public IActionResult PostDetails(int id)
        {
            var post = _movieRepository.GetPostById(id);
            if (post == null)
            {
                return NotFound("Post not found.");
            }

            var comments = _movieRepository.GetCommentsByPostId(id);

            var viewModel = new PostDetailsViewModel
            {
                Post = post,
                Comments = comments
            };

            return View(viewModel);
        }
    }
}
