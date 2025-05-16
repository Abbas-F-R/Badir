namespace Badir.Dto.Comment;

public class CommentResponse
{
    public int Id { get; set; }
    public int? UserId { get; set; }
    public string? UserName { get; set; }
    
    public int? PostId { get; set; }
    
    public int? LikeCount { get; set; }
    public string? Content { get; set; }
}
