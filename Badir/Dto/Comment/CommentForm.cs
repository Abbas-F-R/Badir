namespace ReactNative.Dto.Comment;

public class CommentForm
{
    public required string Content { get; set; }

    public required int UserId { get; set; }

    public required int PostId { get; set; }
}