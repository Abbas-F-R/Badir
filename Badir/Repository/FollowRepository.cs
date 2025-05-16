namespace Badir.Repository;

public class FollowRepository : GenericRepository<Follow, int> , IFollowRepository
{
    public FollowRepository(DatabaseContext context, IMapper mapper) : base(context, mapper)
    {
    }
}