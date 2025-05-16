namespace Badir.Model;

public class ReplayComment : BaseEntity
{
    public string? Content { get; set; }
    
    public int? UserId { get; set; }
    public User? User { get; set; }
    
    public int? CommentId { get; set; }
    public Comment? Comment { get; set; }
    
    public List<ReplayCommentLike>? Likes { get; set; }
}