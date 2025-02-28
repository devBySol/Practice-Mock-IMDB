namespace Lab5.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public int PostId { get; set; }
        public string UserName { get; set; }
        public string Content { get; set; }
        public DateTime DatePosted { get; set; }


     
    }
}
