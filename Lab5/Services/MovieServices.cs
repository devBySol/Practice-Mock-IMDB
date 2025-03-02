using Lab5.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lab5.Services
{
    public class MovieService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ActorServices _actorService = new ActorServices();

        private readonly string _apikey = "4568d10a";
        private List<Movie> _cachedMovies = new List<Movie>(); 

        // 하드코딩된 영화 제목들
        private readonly List<string> _movieTitles = new List<string>
        {
            "Inception",
            "The Dark Knight",
            "The Godfather",
            "The Matrix",
            "The Shawshank Redemption",
            "Pulp Fiction",
            "Fight Club",
            "Forrest Gump",
            "The Lord of the Rings: The Return of the King",
            "Interstellar",
            "Snow White",
            "Wicked",
            "Barbie",
            "Avengers: Endgame",
            "Spider-Man: No Way Home",
            "The Wolf of Wall Street",
            "Parasite",
            "Joker",
            "Toy Story",
            "Shrek",
            "Harry Potter and the Sorcerer's Stone",
            "Pirates of the Caribbean: The Curse of the Black Pearl",
            "The Conjuring",
            "Get Out",
            "Blade Runner 2049",
            "Mad Max: Fury Road",
            "Guardians of the Galaxy",
            "The Lion King",
            "Frozen",
            "The Hunger Games",
            "John Wick",
            "A Quiet Place",
            "Black Panther",
            "Coco",
            "The Incredibles",
            "Zootopia",
            "Doctor Strange",
            "La La Land",
            "Whiplash",
            "The Revenant",
            "Django Unchained",
            "Logan",
            "Her",
            "The Grand Budapest Hotel"

        };

        public MovieService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<List<Movie>> GetMoviesAsync()
        {
            if (_cachedMovies.Count > 0)
            {
                return _cachedMovies; 
            }

            var httpClient = _httpClientFactory.CreateClient();
            httpClient.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");

            var movies = new List<Movie>();
            foreach (var title in _movieTitles)
            {
                string apiUrl = $"http://www.omdbapi.com/?t={title}&apikey={_apikey}";
                var response = await httpClient.GetAsync(apiUrl);

                if (!response.IsSuccessStatusCode)
                    continue;
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    var movieData = JsonConvert.DeserializeObject<Movie>(jsonResponse);

                    if (movieData != null && movieData.Title != null)
                    {
                        movieData.Cast = await _actorService.GetActorsFromTmdbAsync(movieData.imdbID);
                        movies.Add(movieData);
                    }
                }
            }

            _cachedMovies = movies; 
            return movies;
        }

       
        public Movie GetMovieById(int id)
        {
            return _cachedMovies.FirstOrDefault(m => m.Id == id);
        }
    }
}
