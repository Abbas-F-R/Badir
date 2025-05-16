namespace ReactNative.Repository;

public class HashtagRepository : GenericRepository<Hashtag, int>, IHashtagRepository 
{
    public HashtagRepository(DatabaseContext context, IMapper mapper) : base(context, mapper)
    {
    }
}