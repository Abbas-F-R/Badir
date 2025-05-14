namespace ReactNative.Service.CommentService;

public interface ICommentService
{
    Task<(CommentDto?,  string? error)> Add(CommentForm form);
    Task<(CommentDto? , string? error)> Get(int id, int userId );
    Task<(CommentDto?,  string? error)> Delete(int id );
    Task<(CommentDto? Data, string? error)> Update(CommentUpdate update, int id );
    Task<(List<CommentResponse>? Data, int? totalCount, string? error)> GatAll(CommentFilter filter); 

}