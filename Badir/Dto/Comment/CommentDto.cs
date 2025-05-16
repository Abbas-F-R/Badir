namespace ReactNative.Dto.Comment;

public class CommentDto
{
    public string? Content { get; set; }
    
    public int? UserId { get; set; }
    public int? PostId { get; set; }
    public string? UserName { get; set; }
    public int? LikeCount { get; set; }

}