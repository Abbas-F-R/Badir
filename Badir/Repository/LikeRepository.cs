namespace Badir.Repository;

public class LikeRepository : GenericRepository<Like, int> , ILikeRepository
{

    public LikeRepository(DatabaseContext context, IMapper mapper) : base(context, mapper)
    {
    }
}