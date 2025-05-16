namespace Badir.Dto.CampaignActivities;

public class CampaignActivitiesForm
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    
    public required int PostId { get; set; }
}