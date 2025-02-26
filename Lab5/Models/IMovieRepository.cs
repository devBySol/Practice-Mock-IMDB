namespace Lab5.Models
{
    public interface IMovieRepository
    {
        IEnumerable<Movie> GetAllMovies();
        Movie GetById(int id);

        void AddMovie(Movie movie);
        void UpdateMovie(Movie movie);
        void DeleteMovie(int id);

        IEnumerable<Review> GetReviewsByMovieId(int movieId);
        void AddReview(Review review);

        IEnumerable<Review> GetAllReviews();

    }
}
