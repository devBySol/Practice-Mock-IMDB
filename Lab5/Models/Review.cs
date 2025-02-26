namespace Lab5.Models
{
    public class Review
    {
        public int Id { get; set; }
        public int MovieId { get; set; }
        public Movie Movie { get; set; }
        public string UserName { get; set; }
        public string Comment { get; set; } 
        public double Rating { get; set; } 
        public DateTime DatePosted { get; set; } = DateTime.Now;
    }
}
