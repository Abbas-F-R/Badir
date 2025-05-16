namespace Badir.Model;

public class ReplayCommentLike : LikeBase
{
    public int? ReplayCommentId { get; set; }
    public ReplayComment? ReplayComment { get; set; }
}