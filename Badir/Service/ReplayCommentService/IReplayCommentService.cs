using Badir.Dto.ReplayComment;

namespace Badir.Service.ReplayCommentService;

public interface IReplayCommentService
{
    Task<(ReplayCommentDto?, string? error)> Add(ReplayCommentForm form);
        
    Task<(ReplayCommentDto?, string? error)> Get(int id, int userId);
        
    Task<(ReplayCommentDto? Data, string? error)> Update(ReplayCommentUpdate update, int id);
        
    Task<(List<ReplayCommentResponse>? Data, int? totalCount, string? error)> GetAll(ReplayCommentFilter filter);
        
    Task<(ReplayCommentDto?, string? error)> Delete(int id);

}