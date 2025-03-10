using Lab5.Models;
using Microsoft.EntityFrameworkCore;

public class SQLMovieRepository : IMovieRepository
{
    private readonly AppDBContext _context;

    public SQLMovieRepository(AppDBContext context)
    {
        _context = context;
    }

    // 게시글 전체 조회
    public IEnumerable<Post> GetAllPosts() => _context.Posts.ToList();

    // 게시글 ID로 조회
    public Post GetPostById(int id) => _context.Posts.Include(p => p.Comments).FirstOrDefault(p => p.Id == id);

    // 게시글 추가
    public void AddPost(Post post)
    {
        post.DatePosted = DateTime.Now;
        _context.Posts.Add(post);
        _context.SaveChanges();
    }

    // 댓글 조회 (PostId 기준)
    public IEnumerable<Comment> GetCommentsByPostId(int postId) =>
        _context.Comments.Where(c => c.PostId == postId).ToList();

    // 댓글 추가
    public void AddComment(Comment comment)
    {
        comment.DatePosted = DateTime.Now;
        _context.Comments.Add(comment);
        _context.SaveChanges();
    }

    // 이벤트 조회
    public IEnumerable<Event> GetAllEvents() => _context.Events.ToList();
}
