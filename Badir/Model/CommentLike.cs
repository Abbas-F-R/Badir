namespace Badir.Model;

public class CommentLike : LikeBase
{

    public int? CommentId { get; set; }
    public Comment? Comment { get; set; }
}