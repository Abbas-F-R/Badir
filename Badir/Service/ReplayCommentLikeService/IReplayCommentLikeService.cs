namespace Badir.Service;

public interface IReplayCommentLikeService
{
    Task<(LikeDto? data, string? error)> LikeUnlikeReplayComment(ReplayCommentLikeForm form, int userId);

}