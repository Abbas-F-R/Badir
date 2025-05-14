namespace ReactNative.Repository;

public class CampaignInvitationRepository : GenericRepository<CampaignInvitation, int> , ICampaignInvitationRepository
{
    public CampaignInvitationRepository(DatabaseContext context, IMapper mapper) : base(context, mapper)
    {
    }
}