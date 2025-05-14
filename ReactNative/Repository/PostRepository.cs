namespace ReactNative.Repository;

public class PostRepository : GenericRepository<Post , int> , IPostRepository
{
    public PostRepository(DatabaseContext context, IMapper mapper) : base(context, mapper)
    {
    }
}