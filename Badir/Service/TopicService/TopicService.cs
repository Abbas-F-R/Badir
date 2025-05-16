namespace Badir.Service.TopicService;

public class TopicService(
    IRepositoryWrapper wrapper,
    IMapper mapper
    ) : ITopicService
{
    public async Task<(TopicDto? data, string? error)> Add(TopicForm form, int userId, string username)
    {

        var user = await wrapper.User.GetById(userId);
        if (user == null)
        {
            return (null, "  user Not Found  ");
        }

        var existTopic = await wrapper.Topic.Get(t => t.Name == form.Name);
        if (existTopic != null)
        {
            return (null , "  Topic Name Already Exists  ");
        }

        var topic = mapper.Map<Topic>(form);
        topic.UserId = userId;
        topic.Users = [user];
        var result = await wrapper.Topic.Add(topic);
 
        return result != null ?(mapper.Map<TopicDto>(result), null) : (null, " can not add topic");
    }

    public async Task<(List<TopicResponse>? data, int? totalCount, string? error)> GetAll(TopicFilter filter)
    {
        var (date, totalCount) = await wrapper.Topic.GetAll<TopicResponse>(t =>
                (!filter.UserId.HasValue || t.UserId == filter.UserId.Value) &&
                (string.IsNullOrEmpty(filter.Name) || t.Name!.Contains(filter.Name)),
            filter.PageNumber, filter.PageSize);
        return (date != null || totalCount != 0)
            ? (mapper.Map<List<TopicResponse>>(date), totalCount, null)
            : (null, null, " can not get all topics");
    }

    public async Task<(TopicDto? data, string? error)> Update(TopicUpdate topicUpdate, int userId, string username)
    {

        var topic = await wrapper.Topic.GetById(topicUpdate.Id);
        if (topic == null)
        {
            return (null, "topic Not Found");
        }

        var user = await wrapper.User.GetById(topicUpdate.UserId);
        if (user == null)
        {
            return (null, "user Not Found");
        }

        topic.Users!.Add(user);
        user.UpdateTopics = true;
        await wrapper.User.Update(user);
        var result = await wrapper.Topic.Update(topic);
       
        return result != null ? (mapper.Map<TopicDto>(topic), null) : (null, " can not add topic");
    }
}