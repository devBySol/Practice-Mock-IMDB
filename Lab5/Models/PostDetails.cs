namespace Lab5.Models
{
    public class PostDetails
    {
        public Post Post { get; set; }
        public List<Comment> Comments { get; set; } = new List<Comment>(); 
    }
}
