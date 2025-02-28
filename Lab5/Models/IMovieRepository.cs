namespace Lab5.Models
{
    public interface IMovieRepository
    {
        // 영화 관련
        IEnumerable<Movie> GetAllMovies();
        Movie GetById(int id);

        // 리뷰 관련
        IEnumerable<Review> GetAllReviews();
        IEnumerable<Review> GetReviewsByMovieId(int movieId);
        void AddReview(Review review);

        // 게시글 관련
        IEnumerable<Post> GetAllPosts();
        Post GetPostById(int postId); 
        void AddPost(Post post);

        // 댓글 관련 (특정 게시글의 댓글만 가져옴)
        IEnumerable<Comment> GetCommentsByPostId(int postId);
        void AddComment(Comment comment);
    }
}
