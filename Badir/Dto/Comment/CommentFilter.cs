namespace Badir.Dto.Comment;

public class CommentFilter : BaseFilter
{
    public int? UserId { get; set; }
    public int? PostId { get; set; }
}