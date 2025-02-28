namespace Lab5.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime DatePosted { get; set; }

         public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
