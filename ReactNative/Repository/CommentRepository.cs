namespace ReactNative.Repository;

public class CommentRepository : GenericRepository<Comment, int> , ICommentRepository
{
    public CommentRepository(DatabaseContext context, IMapper mapper) : base(context, mapper)
    {
    }
}