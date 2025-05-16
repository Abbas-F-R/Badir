namespace Badir.Model;

public class Comment : BaseEntity
{
    public string? Content { get; set; }
    
    public int? UserId { get; set; }
    public User? User { get; set; }
    
    public int? PostId { get; set; }
    public Post? Post { get; set; }
    
    public int? LikeCount { get; set; }
    public List<CommentLike>? Likes { get; set; }
    public List<ReplayComment>? ReplayComments { get; set; }
}