namespace ReactNative.Repository;

public class TopicRepository : GenericRepository<Topic, int> , ITopicRepository
{
    public TopicRepository(DatabaseContext context, IMapper mapper) : base(context, mapper)
    {
    }
}