namespace ReactNative.Repository;

public class ReplayCommentRepository : GenericRepository<ReplayComment, int>, IReplayCommentRepository
{
    public ReplayCommentRepository(DatabaseContext context, IMapper mapper) : base(context, mapper)
    {
    }
}