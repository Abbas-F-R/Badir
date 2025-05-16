namespace ReactNative.Base;

public class LikeBase : BaseEntity
{
    public int? UserId { get; set; }
    public User? User { get; set; }
}