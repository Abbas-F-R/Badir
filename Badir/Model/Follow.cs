namespace Badir.Model;

public class Follow : BaseEntity
{
    
    public int? FollowerId { get; set; }
    public User? follower { get; set; } 
    public int? FollowingId { get; set; }
    public User? following { get; set; }
}