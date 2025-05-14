namespace ReactNative.Repository;

public class CampaignActivitiesRepository : GenericRepository<CampaignActivities, int> , ICampaignActivitiesRepository
{
    public CampaignActivitiesRepository(DatabaseContext context, IMapper mapper) : base(context, mapper)
    {
    }
}