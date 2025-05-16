namespace ReactNative.Service.TopicService;

public interface ITopicService
{
    Task<(TopicDto? data, string? error)> Add(TopicForm form, int userId, string username);
    Task<(List<TopicResponse>? data, int? totalCount, string? error)> GetAll(TopicFilter filter);
    Task<(TopicDto? data, string? error)> Update(TopicUpdate topicUpdated, int userId, string username);
}