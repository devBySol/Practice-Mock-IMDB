public class Movie
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Director { get; set; }
    public int ReleaseYear { get; set; }
    public string Genre { get; set; }
    public double Rating { get; set; }
    public string PosterUrl { get; set; }
    public string Trailer { get; set; }
    public string Description { get; set; }
    public List<Actor> Cast { get; set; } 
}

public class Actor
{
    public string Name { get; set; }
    public string ProfileImageUrl { get; set; }
}
