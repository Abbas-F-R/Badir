namespace Badir.Model;

public class CampaignActivities : BaseEntity
{
    
    public string? Title { get; set; }
    public string? Description { get; set; }
    
    public int? PostId { get; set; }
    public Post? Post { get; set; }
}