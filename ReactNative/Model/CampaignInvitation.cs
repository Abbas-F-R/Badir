namespace ReactNative.Model;

public class CampaignInvitation : BaseEntity
{
    public int? PostId { get; set; }
    public Post? Post { get; set; }
    public List<User>? Users { get; set; } = new List<User>();
}