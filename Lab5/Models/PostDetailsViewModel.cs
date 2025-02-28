namespace Lab5.Models
{
    public class PostDetailsViewModel
    {
        public Post Post { get; set; }
        public IEnumerable<Comment> Comments { get; set; }
    }
}
