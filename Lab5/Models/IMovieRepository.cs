namespace Lab5.Models
{
    public interface IMovieRepository
    {
     
        // 게시글 관련
        IEnumerable<Post> GetAllPosts();
        Post GetPostById(int postId); 
        void AddPost(Post post);

        // 댓글 관련 
        IEnumerable<Comment> GetCommentsByPostId(int postId);
        void AddComment(Comment comment);
    }
}
