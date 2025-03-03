using Microsoft.AspNetCore.Mvc;
using Lab5.Models;
using System;

namespace Lab5.Controllers
{
    public class PostController : Controller
    {
        private readonly IMovieRepository _movieRepository;

        public PostController(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        // 게시물 세부 정보
        public IActionResult PostDetails(int id)
        {
            var post = _movieRepository.GetPostById(id);
            if (post == null)
            {
                return NotFound("Post not found.");
            }

            var comments = _movieRepository.GetCommentsByPostId(id).ToList();

            var viewModel = new PostDetails
            {
                Post = post,
                Comments = comments
            };

            return View(viewModel);
        }

        // 게시글 작성 (GET)
        [HttpGet]
        public IActionResult CreatePost()
        {
            return View();
        }

        // 게시글 작성 (POST)
        [HttpPost]
        public IActionResult CreatePost(Post model)
        {
            if (ModelState.IsValid)
            {
                _movieRepository.AddPost(model);
                return RedirectToAction("Community", "Community");  
            }
            return View(model);
        }

        // 댓글 작성 (POST)
        [HttpPost]
        public IActionResult AddComment(Comment model)
        {
            if (ModelState.IsValid)
            {
                _movieRepository.AddComment(model);
                return RedirectToAction("PostDetails", new { id = model.PostId });
            }
            return RedirectToAction("PostDetails", new { id = model.PostId });
        }
    }
}
