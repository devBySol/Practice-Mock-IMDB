using Lab5.Models;
using Microsoft.EntityFrameworkCore;

public class SQLMovieRepository : IMovieRepository
{
    private readonly AppDBContext _context;

    public SQLMovieRepository(AppDBContext context)
    {
        _context = context;
    }

    // �Խñ� ��ü ��ȸ
    public IEnumerable<Post> GetAllPosts() => _context.Posts.ToList();

    // �Խñ� ID�� ��ȸ
    public Post GetPostById(int id) => _context.Posts.Include(p => p.Comments).FirstOrDefault(p => p.Id == id);

    // �Խñ� �߰�
    public void AddPost(Post post)
    {
        post.DatePosted = DateTime.Now;
        _context.Posts.Add(post);
        _context.SaveChanges();
    }

    // ��� ��ȸ (PostId ����)
    public IEnumerable<Comment> GetCommentsByPostId(int postId) =>
        _context.Comments.Where(c => c.PostId == postId).ToList();

    // ��� �߰�
    public void AddComment(Comment comment)
    {
        comment.DatePosted = DateTime.Now;
        _context.Comments.Add(comment);
        _context.SaveChanges();
    }

    // �̺�Ʈ ��ȸ
    public IEnumerable<Event> GetAllEvents() => _context.Events.ToList();
}
