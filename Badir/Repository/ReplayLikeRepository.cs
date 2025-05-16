namespace ReactNative.Repository;

public class ReplayLikeRepository : GenericRepository<ReplayCommentLike, int> , IReplayLikeRepository
{
    public ReplayLikeRepository(DatabaseContext context, IMapper mapper) : base(context, mapper)
    {
    }
}