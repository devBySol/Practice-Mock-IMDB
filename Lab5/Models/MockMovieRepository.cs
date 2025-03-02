using Lab5.Models;
using Lab5;

public class MockMovieRepository : IMovieRepository
{

    private List<Post> _posts;
    private List<Comment> _comments;
    public MockMovieRepository()
    {
 
        _posts = new List<Post>
            {
                new Post { Id = 1, UserName = "Alice", Title = "What's your favorite movie?", Content = "Hey everyone! 🎬\r\nI’m curious—what’s your all-time favorite movie and why? For me, it’s Inception. The mind-bending concept, the stunning visuals, and Hans Zimmer’s incredible soundtrack make it an unforgettable experience.\r\n\r\nDo you prefer classics like The Godfather, action-packed films like The Dark Knight, or maybe something more heartwarming like Forrest Gump? Let’s discuss!\r\n\r\n", DatePosted = DateTime.Now.AddDays(-2) },
                new Post { Id = 2, UserName = "Bob", Title = "Best Action Films?", Content = "Looking for recommendations!", DatePosted = DateTime.Now.AddDays(-1) }
            };
        _comments = new List<Comment>
            {
            new Comment { Id = 1, PostId = 1, UserName = "Alice", Content = "Great discussion!", DatePosted = DateTime.Now.AddDays(-1) },
            new Comment { Id = 2, PostId = 1, UserName = "Bob", Content = "I totally agree!", DatePosted = DateTime.Now.AddHours(-5) },
            new Comment { Id = 3, PostId = 2, UserName = "Charlie", Content = "I love action movies!", DatePosted = DateTime.Now.AddHours(-2)
            }
};



    }

   
    //게시글관련
    public IEnumerable<Post> GetAllPosts() => _posts ?? new List<Post>();
    public Post GetPostById(int id) => _posts.FirstOrDefault(p => p.Id == id);
    public void AddPost(Post post)
    {
        post.Id = _posts.Count + 1;
        post.DatePosted = DateTime.Now;
        _posts.Add(post);
    }

    // 댓글 관련
    public IEnumerable<Comment> GetCommentsByPostId(int postId) => _comments.Where(c => c.PostId == postId).ToList();
    public void AddComment(Comment comment)
    {
        comment.Id = _comments.Count + 1;
        comment.DatePosted = DateTime.Now;
        _comments.Add(comment);

        var post = _posts.FirstOrDefault(p => p.Id == comment.PostId);
        if (post != null)
        {
            if (post.Comments == null) post.Comments = new List<Comment>();
            post.Comments.Add(comment);
        }

    }
}
