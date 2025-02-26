using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Lab5.Models;

public class MovieService
{
    private readonly HttpClient _httpClient;
    private const string ApiKey = " 4568d10a"; // Replace with actual API key
    private const string BaseUrl = "http://www.omdbapi.com/";

    public MovieService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<Movie> GetMovieByTitleAsync(string title)
    {
        try
        {
            var url = $"{BaseUrl}?t={title}&apikey={ApiKey}";
            var response = await _httpClient.GetStringAsync(url);

            // Ensure response is not empty
            if (string.IsNullOrEmpty(response))
            {
                Console.WriteLine($"Error: Empty response for movie '{title}'");
                return null;
            }

            var movie = JsonConvert.DeserializeObject<Movie>(response);

            // Validate movie data
            if (movie == null || string.IsNullOrEmpty(movie.Title))
            {
                Console.WriteLine($"Error: Movie '{title}' not found in OMDb API.");
                return null;
            }

            return movie;
        }
        catch (HttpRequestException httpEx)
        {
            Console.WriteLine($"HTTP Request Error for '{title}': {httpEx.Message}");
            return null;
        }
        catch (JsonException jsonEx)
        {
            Console.WriteLine($"JSON Parsing Error for '{title}': {jsonEx.Message}");
            return null;
        }
    }
}
