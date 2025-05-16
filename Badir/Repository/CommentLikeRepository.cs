namespace Badir.Repository;

public class CommentLikeRepository : GenericRepository<CommentLike, int>, ICommentLikeRepository
{
    public CommentLikeRepository(DatabaseContext context, IMapper mapper) : base(context, mapper)
    {
    }
}