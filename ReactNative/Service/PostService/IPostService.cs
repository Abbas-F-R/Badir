namespace ReactNative.Service.PostService;

public interface IPostService
{

    Task<(PostDto? data, string? error)> Add(PostForm form);
    Task<(PostDto? data, string? error)> Get(int id, int? userId);
    Task<(PostDto? data, string? error)> Update(PostUpdate update, int id);
    Task<(PostDto? data, string? error)> Delete(int id);
    Task<(List<PostResponse>? data, int? totalCount, string? error)> GetAll(PostFilter filter);
    Task<(PostDto? data, string? error)> IncrementClickCount(int id);

}